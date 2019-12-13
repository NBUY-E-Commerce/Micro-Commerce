using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Request;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Service.Abstract;
using System;
using System.Linq;

namespace B_Commerce.ProductService.Service.Concrete
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _repositoryOrder;
        private IRepository<ShoppingCart> _repositoryCart;
        private IShoppingCartService _shoppingCartService;
        private IUnitOfWork _unitOfWork;
        public OrderService(IRepository<Order> repositoryOrder, IRepository<ShoppingCart> repositoryCart, IShoppingCartService shoppingCartService, IUnitOfWork unitOfWork)
        {
            _repositoryOrder = repositoryOrder;
            _repositoryCart = repositoryCart;
            _shoppingCartService = shoppingCartService;
            _unitOfWork = unitOfWork;
        }

        public ShoppingCartResponse ShoppingCartPayment(OrderRequest request)
        {
            ShoppingCartResponse shoppingCartResponse = new ShoppingCartResponse();
            try
            {
                var shoppingCartModel = _repositoryCart.Get(t => t.Token == request.Token).FirstOrDefault();

                //Ödeme serivisi true gibiymiş
                /*
                 * if(PaymentService.PaymentResponse==false){
                 * shoppingCartResponse.SetStatus(Common.Constants.ResponseCode.FAILED_TO_PAYMENT);
                 * }
                 */

                _repositoryOrder.Add(new Order
                {
                    insertDateTime = DateTime.Now,
                    PaymentTypeId = request.PaymentTypeId,
                    ShoppingCartId = shoppingCartModel.ID
                   
                });
                
                
                shoppingCartModel.IsPayed = true;
                shoppingCartModel.PaymentType.ID = request.PaymentTypeId;
                shoppingCartResponse = _shoppingCartService.GetShoppingCartofUser(request.Token);

                shoppingCartModel.Token = "0";
                //Token sıfırlanıyor ve yeni sepet için user'a yeni token verilmesi gerekir 
                _repositoryCart.Update(shoppingCartModel);
                int saveResult = _unitOfWork.SaveChanges();
            }

            catch (Exception ex)
            {

                shoppingCartResponse.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
            }
            return shoppingCartResponse;
        }
    }
}
