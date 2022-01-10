using PizzaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authorize(string user_login, string user_password)
        {
            using (PizzaSystemDbContext db = new PizzaSystemDbContext())
            {
                var userDetails = db.Usuarios.FirstOrDefault(a => a.UserName == user_login && a.Password == user_password && a.Enabled == true);
                if (userDetails == null)
                {
                    return Json(new { e = 0 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Session["IdUsuario"] = userDetails.IdUsuario;
                    Session["UserName"] = userDetails.UserName;
                    return Json(new { e = 1 }, JsonRequestBehavior.AllowGet);
                }
            }            
        }

        public ActionResult LogOut()
        {
            try
            {
                Session.Abandon();
                return RedirectToAction("Index", "Login");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }            
        }
    }
}