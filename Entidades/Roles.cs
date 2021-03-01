using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoTarea6.Entidades
{
    public class Roles
    {
        [Key]
        public int RolID { get; set; }
        public string DescripcionRol { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool esActivo { get; set; }
        [ForeignKey("RolID")]
        public virtual List<RolesDetalle> Detalle { get; set; }

        public Roles()
        {
            RolID = 0;
            DescripcionRol = string.Empty;
            Detalle = new List<RolesDetalle>();
            FechaCreacion = DateTime.Now;
            esActivo = false;
        }
    }
}
