using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzaSystem.Models
{
    public class PizzaSystemDbContext : DbContext
    {
        public PizzaSystemDbContext()
            : base("PizzaSystemConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<PizzaSystemDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<OrdenPizza> OrdenPizza { get; set; }
        public DbSet<CatalogoPizza> CatalogoPizza { get; set; }
        public DbSet<UsuarioRoles> UsuarioRoles { get; set; }
    }
}