using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
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
            UnitOfWork unitOfWork = new UnitOfWork(loginDbContext);
            LoginService loginService = new LoginService(unitOfWork, new Repository<User>(loginDbContext), new Repository<AccountVerification>(loginDbContext));

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
