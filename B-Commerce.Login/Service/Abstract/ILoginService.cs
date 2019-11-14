using B_Commerce.Login.DomainClass;
using B_Commerce.Login.Response;
using System;
using System.Collections.Generic;
using System.Text;
using static B_Commerce.Login.Common.Constants;

namespace B_Commerce.Login.Service.Abstract
{
    public interface ILoginService
    {
        LoginResponse Login(User user);
        Token CreateToken();
        ResponseCode UserAdd(User user);
        ResponseCode UserBan(User user);
        bool IsUserBanned(User user);
        bool UserPasswordControl(User user);
        User UserNameControl(User user);
        ResponseCode UserUpdate(User user);
        ResponseCode UserDelete(User user);
        User UserGet(User user);
        bool UserControl(User user);
    }
}
