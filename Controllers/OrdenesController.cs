using PizzaSystem.Helpers;
using PizzaSystem.Models;
using PizzaSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaSystem.Controllers
{
    public class OrdenesController : Controller
    {
        private PizzaSystemDbContext db;
        private Helper hp;
        public OrdenesController()
        {
            db = new PizzaSystemDbContext();
            hp = new Helper();
        }

        [AuthorizeTool(Roles = "User,Administrador")]
        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("~/Login/Index");
            }

            ViewBag.Administrador = hp.CheckMyRol("Administrador");
            return View();
        }

        [AuthorizeTool(Roles = "User,Administrador")]
        public ActionResult GetOrdenesPizza()
        {
            try
            {
                List<OrdenesViewModel> model = new List<OrdenesViewModel>();
                model = db.Database.SqlQuery<OrdenesViewModel>("EXEC GetOrdenesPizzas").ToList();
                var data = Json(new { data = model }, JsonRequestBehavior.AllowGet);
                data.MaxJsonLength = int.MaxValue;
                return data;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [AuthorizeTool(Roles = "User,Administrador")]
        public ActionResult OrdenesForm(int? id)
        {
            OrdenesViewModel model = new OrdenesViewModel();
            try
            {
                if (id == null)
                {
                    
                }
                else
                {
                    SqlParameter Id = new SqlParameter("@Id", id);
                    model = db.Database.SqlQuery<OrdenesViewModel>("EXEC GetOrdenesPizzasById @Id", Id).FirstOrDefault();
                }
                model.CatalogoPizzaList = db.CatalogoPizza.Where(a => a.Enabled == true).ToList();
                return PartialView("~/Views/Ordenes/_OrdenesForm.cshtml", model);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [AuthorizeTool(Roles = "User,Administrador")]
        public ActionResult SaveOrdenesPizza(OrdenesViewModel model)
        {
            try
            {
                int IdUser = (int)Session["IdUsuario"];
                var username = hp.GetUserById(IdUser).UserName;
                OrdenPizza op = new OrdenPizza()
                {
                    NumeroOrden = model.NumeroOrden,
                    NombreCompletoSolicitante = model.NombreCompletoSolicitante,
                    IdCatalogoPizza = model.IdCatalogoPizza,
                    CantidadOrden = model.CantidadOrden,
                    FechaRealizoOrden = model.FechaRealizoOrden,
                    DireccionEnvio = model.DireccionEnvio,
                    Comentarios = model.Comentarios,
                    OrdenEntregada = model.OrdenEntregada,
                    OrdenCreadaPor = username,
                    FechaCreado = DateTime.Now,
                    Enabled = true
                };
                db.OrdenPizza.Add(op);
                db.SaveChanges();
                return Json(new { e = 1, msj = "La orden ha sido guardada" });
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [AuthorizeTool(Roles = "User,Administrador")]
        public ActionResult EditOrdenesPizza(OrdenesViewModel model)
        {
            try
            {
                int IdUser = (int)Session["IdUsuario"];
                var username = hp.GetUserById(IdUser).UserName;
                OrdenPizza op = new OrdenPizza();
                op = db.OrdenPizza.FirstOrDefault(a => a.IdOrdenPizza == model.IdOrdenPizza && a.Enabled == true);
                op.NombreCompletoSolicitante = model.NombreCompletoSolicitante;
                op.IdCatalogoPizza = model.IdCatalogoPizza;
                op.CantidadOrden = model.CantidadOrden;
                op.FechaRealizoOrden = model.FechaRealizoOrden;
                op.DireccionEnvio = model.DireccionEnvio;
                op.Comentarios = model.Comentarios;
                op.OrdenEntregada = model.OrdenEntregada;
                op.ModificadoPor = username;
                op.FechaModificado = DateTime.Now;
                db.SaveChanges();
                return Json(new { e = 1, msj = "La orden ha sido actualizada" });
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [AuthorizeTool(Roles = "User,Administrador")]
        public ActionResult DeleteOrdenesPizza(int id)
        {
            try
            {
                int IdUser = (int)Session["IdUsuario"];
                var username = hp.GetUserById(IdUser).UserName;
                OrdenPizza op = new OrdenPizza();
                op = db.OrdenPizza.FirstOrDefault(a => a.IdOrdenPizza == id && a.Enabled == true);
                op.ModificadoPor = username;
                op.FechaModificado = DateTime.Now;
                op.Enabled = false;
                db.SaveChanges();
                return Json(new { e = 1, msj = "La orden ha sido eliminada" });
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}