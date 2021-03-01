using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoTarea6.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; }
        public string AliasUsuario { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public DateTime FechaUsuario { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
    }
}
