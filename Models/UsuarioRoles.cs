using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaSystem.Models
{
    [Table("UsuarioRoles")]
    public class UsuarioRoles
    {
        public UsuarioRoles()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdUsuarioRoles { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdRol { get; set; }
        public string CreadoPor { get; set; }
        public DateTime? FechaCreado { get; set; }
        public bool? Enabled { get; set; }
    }
}