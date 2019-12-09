using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace B_Commerce.ProductService.Service.Concrete
{
    public class ShoppingCartService : IShoppingCartService
    {
        private IRepository<ShoppingCartProduct> _repositoryShoppingCartProduct;
        private IUnitOfWork _unitOfWork;
        private IRepository<ShoppingCart> _repostiyoryShoppingCart;
        private IRepository<Product> _repostiyoryProduct;
        public ShoppingCartService(IRepository<ShoppingCartProduct> repositoryShoppingCartProduct, IRepository<ShoppingCart> repositoryShoppingCart, IUnitOfWork unitOfWork, IRepository<Product> repostiyoryProduct)
        {
            _repositoryShoppingCartProduct = repositoryShoppingCartProduct;
            _unitOfWork = unitOfWork;
            _repostiyoryShoppingCart = repositoryShoppingCart;
            _repostiyoryProduct = repostiyoryProduct;
        }

        public ShoppingCartResponse Add(string token, int userid, int productid, int count)
        {

            ShoppingCartResponse response = new ShoppingCartResponse();
            ShoppingCart shoppingCart = null;
            try
            {

                shoppingCart = _repostiyoryShoppingCart.Get(t => t.Token == token).FirstOrDefault();

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
                        //spetim var ama urun sepette yok


                        Product p = _repostiyoryProduct.Get(t => t.ID == productid).FirstOrDefault();

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

                    _repostiyoryShoppingCart.Add(shoppingCart);
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
                        item.Product = _repostiyoryProduct.Get(t => t.ID == item.ProductID).FirstOrDefault();
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
                            ProductID = item.ProductID
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
                ShoppingCart shoppingCart = _repostiyoryShoppingCart.Get(t => t.Token == token).FirstOrDefault();

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
                                ProductID = item.ProductID
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
    }
}
