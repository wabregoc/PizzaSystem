using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaSystem.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        public Usuarios()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellido { get; set; }
        public string SegundoApellido { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CreadoPor { get; set; }
        public DateTime? FechaCreado { get; set; }
        public bool? Enabled { get; set; }
    }
}