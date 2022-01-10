using PizzaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PizzaSystem.Helpers
{
    public class AuthorizeToolAttribute : AuthorizeAttribute
    {
        static Helper hp;
        private PizzaSystemDbContext db;
        public AuthorizeToolAttribute()
        {
            hp = new Helper();
            db = new PizzaSystemDbContext();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorize = false;
            var roles = Roles.Split(',');
            foreach (var rol in roles)
            {
                if (HasRole(rol))
                {
                    authorize = true;
                }
                else
                {
                    authorize = (authorize || false);
                }
            }
            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                            new
                            {
                                controller = "Error",
                                action = "AccessDenied"
                            }
                        )
                );
        }

        public static bool HasRole(string role)
        {
            int IdUser = (int)HttpContext.Current.Session["IdUsuario"];
            bool auth = false;
            
            try
            {
                auth = hp.CheckMyRol(role);
            }
            catch (Exception)
            {
                throw;
            }
            
            return auth;
        }
    }
}