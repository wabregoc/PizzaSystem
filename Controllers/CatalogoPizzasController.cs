using PizzaSystem.Helpers;
using PizzaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaSystem.Controllers
{
    public class CatalogoPizzasController : Controller
    {
        private PizzaSystemDbContext db;
        private Helper hp;

        public CatalogoPizzasController()
        {
            db = new PizzaSystemDbContext();
            hp = new Helper();
        }

        [AuthorizeTool(Roles = "Administrador")]
        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("~/Login/Index");
            }
            ViewBag.Administrador = hp.CheckMyRol("Administrador");
            return View();
        }

        [AuthorizeTool(Roles = "Administrador")]
        public ActionResult GetCatalogoPizza()
        {
            try
            {
                List<CatalogoPizza> model = new List<CatalogoPizza>();
                model = db.CatalogoPizza.Where(a => a.Enabled == true).ToList();
                var data = Json(new { data = model }, JsonRequestBehavior.AllowGet);
                data.MaxJsonLength = int.MaxValue;
                return data;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [AuthorizeTool(Roles = "Administrador")]
        public ActionResult CatalogoPizzaForm(int? id)
        {
            CatalogoPizza model = new CatalogoPizza();
            try
            {
                if (id == null)
                {
                }
                else
                {
                    model = db.CatalogoPizza.FirstOrDefault(a => a.IdCatalogoPizza == id && a.Enabled == true);
                }
                return PartialView("~/Views/CatalogoPizzas/_CatalogoPizzaForm.cshtml", model);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [AuthorizeTool(Roles = "Administrador")]
        public ActionResult SaveCatalogoPizza(CatalogoPizza model)
        {
            try
            {
                int IdUser = (int)Session["IdUsuario"];
                var username = hp.GetUserById(IdUser).UserName;
                model.CreadoPor = username;
                model.FechaCreado = DateTime.Now;
                model.Enabled = true;
                db.CatalogoPizza.Add(model);
                db.SaveChanges();
                return Json(new { e = 1, msj = "El catalago de pizzas ha sido guardado" });
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [AuthorizeTool(Roles = "Administrador")]
        public ActionResult EditCatalogoPizza(CatalogoPizza model)
        {
            try
            {
                int IdUser = (int)Session["IdUsuario"];
                var username = hp.GetUserById(IdUser).UserName;
                CatalogoPizza cp = new CatalogoPizza();
                cp = db.CatalogoPizza.FirstOrDefault(a => a.IdCatalogoPizza == model.IdCatalogoPizza && a.Enabled == true);
                cp.NombreProducto = model.NombreProducto;
                cp.CantidadPorciones = model.CantidadPorciones;
                cp.DescripcionProducto = model.DescripcionProducto;
                cp.PrecioUnidad = model.PrecioUnidad;
                cp.Tamano = model.Tamano;
                cp.ModificadoPor = username;
                cp.FechaModificado = DateTime.Now;
                db.SaveChanges();
                return Json(new { e = 1, msj = "El catalogo de pizzas ha sido actualizado" });
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [AuthorizeTool(Roles = "Administrador")]
        public ActionResult DeleteCatalogoPizza(int id)
        {
            try
            {
                int IdUser = (int)Session["IdUsuario"];
                var username = hp.GetUserById(IdUser).UserName;
                CatalogoPizza cp = new CatalogoPizza();
                cp = db.CatalogoPizza.FirstOrDefault(a => a.IdCatalogoPizza == id && a.Enabled == true);
                cp.ModificadoPor = username;
                cp.FechaModificado = DateTime.Now;
                cp.Enabled = false;
                db.SaveChanges();
                return Json(new { e = 1, msj = "El catalogo de pizzas ha sido eliminado" });
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}