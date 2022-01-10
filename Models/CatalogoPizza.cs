using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaSystem.Models
{
    [Table("CatalogoPizza")]
    public class CatalogoPizza
    {
        public CatalogoPizza()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdCatalogoPizza { get; set; }
        public string NombreProducto { get; set; }
        public int? CantidadPorciones { get; set; }
        public string DescripcionProducto { get; set; }
        public decimal? PrecioUnidad { get; set; }
        public string Tamano { get; set; }
        public string CreadoPor { get; set; }
        public DateTime? FechaCreado { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }
        public bool? Enabled { get; set; }
    }
}