﻿using B_Commerce.Login.DomainClass;
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
        BaseResponse CheckVerificationCode(string email, string code);
        LoginResponse FacebookLogin(FacebookRequest facebookRequest);
        RegisterResponse UserRegistry(User user);

        PasswordChangeResponse SendPasswordChangeCode(string Email);
        PasswordChangeResponse CheckPasswordChangeCode(string Email, string Code);
        PasswordChangeResponse ChangePassword(string Email,string Code, string newPassword);
        PasswordChangeResponse ChangePassword(int UserID, string oldPassword, string newPassword);
        VerificationResponse SendAccountVerificationCode(string Email);
        VisitorTokenResponse CreateVisitorToken(int ExpireTime = 7);

        CheckTokenResponse CheckToken(string token);
    }
}
