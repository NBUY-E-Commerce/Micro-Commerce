using B_Commerce.Common.Repository.Concrete;
using B_Commerce.Common.UnitOfWork.Concrete;
using B_Commerce.Login.Common;
using B_Commerce.Login.DatabaseContext;
using B_Commerce.Login.DomainClass;
using B_Commerce.Login.Request;
using B_Commerce.Login.Response;
using B_Commerce.Login.Service.Concrete;
using System;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            //IOC servisi yazılacak
            LoginDbContext loginDbContext = new LoginDbContext();
            ECommerceUnitOfWork unitOfWork = new ECommerceUnitOfWork(loginDbContext);
            LoginService loginService = new LoginService(unitOfWork, new EfRepository<User>(loginDbContext));

            Console.WriteLine("Email ve şifre gir");
            LoginRequest loginRequest = new LoginRequest
            {
                Email = Console.ReadLine(),
                Password = Console.ReadLine(),
            };

            LoginResponse loginResponse = loginService.Login(loginRequest);

            Console.WriteLine(Constants.ResponseCodes[loginResponse.Code]);
        }
    }
}
}
