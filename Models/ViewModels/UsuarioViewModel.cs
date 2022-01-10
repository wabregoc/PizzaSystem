using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaSystem.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellido { get; set; }
        public string SegundoApellido { get; set; }
        public string UserName { get; set; }
    }
}