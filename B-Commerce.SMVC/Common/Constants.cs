using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Common
{
    public class Constants
    {

        public static Dictionary<string, string> AllLanguagesInsite = new Dictionary<string, string>
        {
            {"tr-TR","Turkçe"},
            { "en-US","English" }
        };



        //Facebook
        public const string FACEBOOK_APPID = "3462488800442988";
        public const string FACEBOOK_APPSECRET = "2f5eb5daf3ea0fea4c09e729b1b379d7";
        public const string MVC_FACEBOOK_URI = "https://localhost:44314/Login/FacebookLogin";//MVC FB URL



        //LoginAPI
        public const string LOGIN_API_BASE_URI = "http://localhost:63562/";//LoginApideki SSL Aktifleştirildi
        public const string LOGIN_API_LOGIN_URI = "/api/Login/Login";
        public const string LOGIN_API_REGISTER_URI = "/api/Login/UserRegistry";
        public const string LOGIN_API_CHECK_VERIFICATION_URI = "/api/Login/CheckVerificationCode";
        public const string LOGIN_API_FACEBOOK_URI = "/api/Login/FacebookLogin";
        public const string LOGIN_API_SEND_PASSWORD_CHANGE_CODE_URI = "/api/Login/SendPasswordChangeCode";
        public const string LOGIN_API_CHECK_PASSWORD_CHANGE_CODE_URI = "/api/Login/CheckPasswordChangeCode";
        public const string LOGIN_API_CHANGE_PASSWORD_URI = "/api/Login/ChangePassword";
        public const string LOGIN_API_CreateVisitorToken_URI = "/api/Login/CreateVisitorToken";
        public const string LOGIN_API_CHECKTOKEN_URI = "/api/Login/CheckToken";

        public const int LOGIN_RESPONSE_SUCCESS = 0;

        //ProductApi
        public const string PRODUCT_API_BASE_URI = "http://localhost:50984/";
        public const string PRODUCT_API_INDEX_URI = "/api/Category/GetSubCategoriesByCategoryID";
        public const string PRODUCT_API_SPECIAL_AREA = "/api/SpecialArea/Add";
        public const string PRODUCT_API_PRODUCT_SPECIAL_AREA_ADD = "/api/SpecialArea/ProductSpecialAreaAdd";
        public const string PRODUCT_API_PRODUCT_SPECIAL_AREA_DELETE = "/api/SpecialArea/DeleteProductSpecialAreaByID";


        public const string PRODUCT_API_GETSPECIAL_AREA = "/api/SpecialArea/GetSpecialAreas";
        public const string PRODUCT_API_GET_PRODUCT_SPECIAL_AREA = "/api/SpecialArea/GetProductSpecialAreas";
        public const string PRODUCT_API_UPDATESPECIAL_AREA = "/api/SpecialArea/Update";
        public const string PRODUCT_API_GETSPECIAL_AREA_BYID = "/api/SpecialArea/GetSpecialAreaByID";
        public const string PRODUCT_API_DELETE_SPECIAL_AREA = "/api/SpecialArea/Delete";

        public const string PRODUCT_API_ADD_CATEGORY = "/api/Category/Add";
        public const string PRODUCT_API_UPDATE_CATEGORY = "/api/Category/Update";
        public const string PRODUCT_API_DELETE_CATEGORY = "/api/Category/Delete";
        public const string PRODUCT_API_GETBYID_CATEGORY = "/api/Category/GetByID";
        public const string PRODUCT_API_GET_CATEGORY_SHORT_INFO = "/api/Category/GetCategoryShortInfo";
        public const string PRODUCT_API_GET_CATEGORY_BRANCH = "/api/Category/GetCategoryBranch";
        public const string PRODUCT_API_ADD = "/api/Product/Add";
        public const string PRODUCT_API_GETPRODUCTBYID = "/api/Product/GetProductByID";
        public const string PRODUCT_API_UPDATE = "/api/Product/Update";
        public const string PRODUCT_API_GETPRODUCTS = "/api/Product/GetProducts";
        public const string PRODUCT_API_GETRANDOMPRODUCTS = "/api/Product/GetRandomProducts";
        public const string PRODUCT_API_PRODUCTS_COLOR = "/api/Product/ProductsColor";
        public const string PRODUCT_API_GETPRODUCTS_COLOR = "/api/Product/GetProductsColor";
        public const string PRODUCT_API_GETPRODUCTS_BRAND = "/api/Product/ProductsBrand";
        public const string PRODUCT_API_SEARCH_FOR_PRODUCTS = "/api/Product/SearchforProducts";

        public const string PRODUCT_API_BANNER_URI = "/api/Product/GetBanners";
        public const string PRODUCT_API_GET_SPECIAL_PRODUCTS = "/api/Product/GetSpecialProducts";
        public const string PRODUCT_API_GET_SAME_BRAND_PRODUCTS = "/api/Product/GetSameBrandProducts";
        public const string PRODUCT_API_SHOPPINGCARD_ADD = "/api/ShoppingCart/Add";
        public const string PRODUCT_API_SHOPPINGCARD_UPDATE = "/api/ShoppingCart/UpdateProductCountOfShoppingCart";
        public const string PRODUCT_API_SHOPPINGCARD_OFUSER = "/api/ShoppingCart/GetShoppingCartofUser";





    }
}