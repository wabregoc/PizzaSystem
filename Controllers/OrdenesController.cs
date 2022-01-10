using PizzaSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaSystem.Controllers
{
    public class OrdenesController : Controller
    {
        // GET: Ordenes
        [AuthorizeTool(Roles = "User,Administrador")]
        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("~/Login/Index");
            }
            return View();
        }
    }
}