using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoTarea6.Entidades
{
    public class Permisos
    {
        [Key]
        public int PermisoID { get; set; }
        public string NombrePermiso { get; set; }
        public string DescripcionPermiso { get; set; }
        public int VecesAsignado { get; set; }
        [ForeignKey("PermisoID")]
        public virtual Permisos Permiso { get; set; }

        public Permisos()
        {
            PermisoID = 0;
            DescripcionPermiso = string.Empty;
            NombrePermiso = string.Empty;
        }
    }
}
