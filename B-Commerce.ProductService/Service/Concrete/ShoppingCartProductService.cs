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
    public class ShoppingCartProductService : IShoppingCartProductService
    {
        private IRepository<ShoppingCartProduct> _repositoryShoppingCartProduct;
        private IUnitOfWork _unitOfWork;
        private IRepository<ShoppingCart> _repostiyoryShoppingCart;
        public ShoppingCartProductService(IRepository<ShoppingCartProduct> repositoryShoppingCartProduct, IRepository<ShoppingCart> repositoryShoppingCart, IUnitOfWork unitOfWork)
        {
            _repositoryShoppingCartProduct = repositoryShoppingCartProduct;
            _unitOfWork = unitOfWork;
            _repostiyoryShoppingCart = repositoryShoppingCart;
        }

        public BaseResponse Add(ShoppingCartProduct shoppingCartProduct)
        {
           
            BaseResponse response = new BaseResponse();
            try
            {
                _repositoryShoppingCartProduct.Add(shoppingCartProduct);
                _unitOfWork.SaveChanges();
                response.SetStatus(Common.Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception ex)
            {
                response.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return response;
            }
        }

        public ShoppingCartProductResponse GetShoppingCartofUser(int ID)
        {
            ShoppingCartProductResponse response = new ShoppingCartProductResponse();
            try
            {
               ShoppingCart shoppingCart= _repostiyoryShoppingCart.Get(t => t.UserID == ID).FirstOrDefault();
                
                response.shoppingCartProduct = _repositoryShoppingCartProduct.Get(t =>shoppingCart.UserID==ID).SingleOrDefault();

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
