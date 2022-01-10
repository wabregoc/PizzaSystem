using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaSystem.Models.ViewModels
{
    public class OrdenesViewModel
    {
        public int IdOrdenPizza { get; set; }
        public string NumeroOrden { get; set; }
        public string NombreCompletoSolicitante { get; set; }
        public int? IdCatalogoPizza { get; set; }
        public int? CantidadOrden { get; set; }
        public DateTime? FechaRealizoOrden { get; set; }
        public string DireccionEnvio { get; set; }
        public string Comentarios { get; set; }
        public bool? OrdenEntregada { get; set; }
        public string OrdenCreadaPor { get; set; }
        public DateTime? FechaCreado { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }
        public bool? Enabled { get; set; }
        public decimal? PrecioUnidad { get; set; }
        public decimal? Total { get; set; }
        public List<CatalogoPizza> CatalogoPizzaList { get; set; }
    }
}