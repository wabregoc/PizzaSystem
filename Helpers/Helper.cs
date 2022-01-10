using PizzaSystem.Models;
using PizzaSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaSystem.Helpers
{
    public class Helper
    {
        private PizzaSystemDbContext db;
        public Helper()
        {
            db = new PizzaSystemDbContext();
        }

        public UsuarioViewModel GetUserById(int id)
        {
            SqlParameter Id = new SqlParameter("@Id", id);
            UsuarioViewModel user = db.Database.SqlQuery<UsuarioViewModel>("EXEC GetUsuario @Id", Id).FirstOrDefault();

            return user;
        }

        public bool CheckMyRol(String role)
        {
            var IdUsuario = (int)HttpContext.Current.Session["IdUsuario"];
            bool auth = false;

            SqlParameter NombreRol = new SqlParameter("@NombreRol", role);
            SqlParameter IdUser= new SqlParameter("@IdUsuario", IdUsuario);
            UsuarioRoles rol = db.Database.SqlQuery<UsuarioRoles>("EXEC CheckMyRol @NombreRol, @IdUsuario", NombreRol, IdUser).FirstOrDefault();
            auth = (rol != null) ? true : false;
            return auth;
        }
    }
}