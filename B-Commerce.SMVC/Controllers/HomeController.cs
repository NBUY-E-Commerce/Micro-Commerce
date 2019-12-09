using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B_Commerce.SMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeLanguage(string lang)
        {

            if (Constants.AllLanguagesInsite.ContainsKey(lang))
            {

                HttpCookie cok = new HttpCookie("lang");
                cok.Expires = DateTime.Now.AddDays(30);
                cok.Value = lang;

                Response.Cookies.Add(cok);
            }

            return RedirectToAction("Index", "Home");

        }

        public ActionResult SiteLanguageBar()
        {
            string current = "tr-TR";
            if (Request.Cookies["lang"] != null)
            {
                current = Request.Cookies["lang"].Value;
            }
            var _model = new CultureModel();

            foreach (var item in Constants.AllLanguagesInsite)
            {
                if (item.Key == current)
                {
                    _model.CurrentLanguageKey = item.Key;
                    _model.CurrentLanguageName = item.Value;
                }
                else
                {

                    _model.Others.Add(item.Key, item.Value);
                }


            }



            return PartialView("_PartialSiteLanguageBar", _model);

        }

    }
}