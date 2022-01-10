using PizzaSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaSystem.Controllers
{
    public class MenuController : Controller
    {
        private Helper hp;
        public MenuController()
        {
            hp = new Helper();
        }

        public ActionResult Menu()
        {
            try
            {
                int IdUser = (int)Session["IdUsuario"];
                var user = hp.GetUserById(IdUser);
                ViewBag.infoUser = user;
                ViewBag.Administrador = hp.CheckMyRol("Administrador");
                return PartialView();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}