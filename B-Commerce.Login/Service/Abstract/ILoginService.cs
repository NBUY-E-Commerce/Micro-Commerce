using B_Commerce.Login.DomainClass;
using B_Commerce.Login.Request;
using B_Commerce.Login.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Service.Abstract
{
    public interface ILoginService
    {
        LoginResponse Login(LoginRequest loginRequest);
        RegisterResponse UserRegistry(User user);
        CheckTokenResponse CheckToken(string token);
        LoginResponse FacebookLogin(LoginRequest loginRequest);
        LoginResponse CheckVerificationCode(string token, string code);
    }
}
