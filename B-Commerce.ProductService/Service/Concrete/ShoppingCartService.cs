using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace B_Commerce.ProductService.Service.Concrete
{
    public class ShoppingCartService : IShoppingCartService
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<ShoppingCartProduct> _repositoryShoppingCartProduct;
        private IRepository<ShoppingCart> _repositoryShoppingCart;
        private IRepository<Product> _repositoryProduct;

        public ShoppingCartService(IRepository<ShoppingCartProduct> repositoryShoppingCartProduct, IRepository<ShoppingCart> repositoryShoppingCart, IUnitOfWork unitOfWork, IRepository<Product> repostiyoryProduct)
        {
            _repositoryShoppingCartProduct = repositoryShoppingCartProduct;
            _unitOfWork = unitOfWork;
            _repositoryShoppingCart = repositoryShoppingCart;
            _repositoryProduct = repostiyoryProduct;
        }

        public ShoppingCartResponse Add(string token, int userid, int productid, int count)
        {
            ShoppingCartResponse response = new ShoppingCartResponse();
            ShoppingCart shoppingCart = null;
            try
            {
                shoppingCart = _repositoryShoppingCart.Get(t => t.Token == token).FirstOrDefault();

                if (shoppingCart != null)
                {
                    //demekki sepeti var

                    ShoppingCartProduct shoppingCartProduct = shoppingCart.ShoppingCartProducts.FirstOrDefault(t => t.ProductID == productid);

                    if (shoppingCartProduct != null)
                    {
                        //bu urun zaten sepette var
                        shoppingCartProduct.ProductCount += count;
                    }
                    else
                    {
                        //sepetim var ama urun sepette yok

                        Product p = _repositoryProduct.Get(t => t.ID == productid).FirstOrDefault();

                        shoppingCart.ShoppingCartProducts.Add(new ShoppingCartProduct
                        {
                            ProductID = productid,
                            ProductCount = count,
                            Product = p
                        });
                    }
                }
                else
                {
                    shoppingCart = new ShoppingCart
                    {
                        Token = token,
                        UserID = userid,
                        ShoppingCartProducts = new List<ShoppingCartProduct>() {
                            new ShoppingCartProduct{
                                ProductID = productid,
                                ProductCount = count
                            }
                        }
                    };

                    _repositoryShoppingCart.Add(shoppingCart);
                }

                int result = _unitOfWork.SaveChanges();
                if (result < 1)
                {
                    response.SetStatus(Common.Constants.ResponseCode.SYSTEM_ERROR);
                    return response;
                }

                //**ef core crud işleminden sonra lazyloading aktif olarak bağlı olan productı getirmediği için kendimiz aldık
                foreach (var item in shoppingCart.ShoppingCartProducts)
                {
                    if (item.Product == null)
                    {
                        item.Product = _repositoryProduct.Get(t => t.ID == item.ProductID).FirstOrDefault();
                    }
                }

                decimal total = shoppingCart.ShoppingCartProducts.Sum(t => t.ProductCount * t.Product.Price);

                response.shoppingCartModel = new ShoppingCartModel
                {
                    DiscountPrice = 0,
                    TotalPrice = total,
                    LastPrice = total
                };
                foreach (var item in shoppingCart.ShoppingCartProducts)
                {
                    response.shoppingCartModel.cardProduct.Add(
                        new ShoppingCartProductModel
                        {
                            CartDiscount = 0,
                            MainImage = item.Product.ProductImages.FirstOrDefault().URL,
                            Price = item.Product.Price,
                            ProductName = item.Product.ProductName,
                            ProductID = item.ProductID,
                            ProductCount = item.ProductCount
                        }

                    );
                }
            }
            catch (Exception ex)
            {
                response.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return response;
            }

            response.SetStatus(Common.Constants.ResponseCode.SUCCESS);
            return response;
        }

        public ShoppingCartResponse GetShoppingCartofUser(string token)
        {
            ShoppingCartResponse response = new ShoppingCartResponse();
            try
            {
                ShoppingCart shoppingCart = _repositoryShoppingCart.Get(t => t.Token == token).FirstOrDefault();

                //mapping
                if (shoppingCart != null)
                {
                    response.shoppingCartModel = new ShoppingCartModel
                    {
                        DiscountPrice = 0,
                        TotalPrice = shoppingCart.ShoppingCartProducts.Sum(t => t.ProductCount * t.Product.Price),
                        LastPrice = shoppingCart.ShoppingCartProducts.Sum(t => t.ProductCount * t.Product.Price)
                    };
                    foreach (var item in shoppingCart.ShoppingCartProducts)
                    {
                        response.shoppingCartModel.cardProduct.Add(
                            new ShoppingCartProductModel
                            {
                                CartDiscount = 0,
                                MainImage = item.Product.ProductImages.FirstOrDefault().URL,
                                Price = item.Product.Price,
                                ProductName = item.Product.ProductName,
                                ProductID = item.ProductID,
                                ProductCount = item.ProductCount
                            }

                        );
                    }
                }

                response.SetStatus(Common.Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception ex)
            {
                response.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return response;
            }
        }

        /// <summary>
        /// new count 0 verilirse Product Sepetten Silinir.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="productid"></param>
        /// <param name="newcount"></param>
        /// <returns></returns>
        public ShoppingCartResponse UpdateProductCountOfShoppingCart(string token, int productid, int newcount)
        {
            ShoppingCartResponse response = new ShoppingCartResponse();
            ShoppingCart shoppingCart = new ShoppingCart();
            try
            {
                shoppingCart = _repositoryShoppingCart.Get(t => t.Token == token).SingleOrDefault();
                if (shoppingCart != null)
                {
                    // Logic İçerisinde Dönülen dizi değiştiği için ToList() ile dönüldü
                    foreach (ShoppingCartProduct item in shoppingCart.ShoppingCartProducts.ToList()) 
                    {
                        if (newcount == 0 && item.ProductID == productid)
                        {
                            shoppingCart.ShoppingCartProducts.Remove(item);
                        }
                        else if (item.ProductID == productid)
                        {
                            item.ProductCount = newcount;
                        }
                    }
                    _unitOfWork.SaveChanges();
                }
                else
                {
                    response.SetStatus(Common.Constants.ResponseCode.NOT_FOUND_SHOPPING_CART);
                    return response;
                }
            }
            catch (Exception exception)
            {
                response.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, exception.Message);
                return response;
            }

            response = GetShoppingCartofUser(token);
            return response;
        }
        public BaseResponse CartEqualizer(string vToken,string uToken)
        {
            BaseResponse baseResponse = new BaseResponse();
            ShoppingCart shoppingCart = new ShoppingCart();
            try
            {
                shoppingCart = _repositoryShoppingCart.Get(t => t.Token == vToken).FirstOrDefault();
                shoppingCart.Token = uToken;
                _repositoryShoppingCart.Update(shoppingCart);
                baseResponse.SetStatus(Common.Constants.ResponseCode.SUCCESS);
                int result = _unitOfWork.SaveChanges();
                if (result < 1)
                {
                    baseResponse.SetStatus(Common.Constants.ResponseCode.SYSTEM_ERROR);
                    return baseResponse;
                }
            }
            catch (Exception ex)
            {
                baseResponse.SetStatus(Common.Constants.ResponseCode.SUCCESS, ex.Message);
            }
            return baseResponse;
        }
    }
}