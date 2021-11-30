using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Areas.Admin.Models;
using Models;
using WebBanHang.Areas.Admin.Code;
using System.Web.Security;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.UserName) && String.IsNullOrEmpty(model.Password))
                {
                    ViewBag.MsgErr = "Vui lòng điền tài khoản và mật khẩu!!!";
                    return View();
                }
                else if (String.IsNullOrEmpty(model.UserName))
                {
                    ViewBag.MsgErr = "Vui lòng điền tài khoản!!!";
                    return View();
                } 
                else if (String.IsNullOrEmpty(model.Password))
                {
                    ViewBag.MsgErr = "Vui lòng điền mật khẩu!!!";
                    return View();
                }
            }
            //var rs = new AccountModel().Login(model.UserName, model.Password);
            if (Membership.ValidateUser(model.UserName,model.Password) && ModelState.IsValid)
            {
                //SessionHelper.SetSession(new UserSession() { UserName = model.UserName });
                FormsAuthentication.SetAuthCookie(model.UserName, !model.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.MsgErr =( "Tài khoản hoặc mật khẩu không chính xác!");
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}