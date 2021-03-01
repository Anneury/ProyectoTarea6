using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoTarea6.Entidades
{
    public class RolesDetalle
    {
        [Key]
        public int ID { get; set; }
        public int RolID { get; set; }
        public int PermisoID { get; set; }
        public bool esAsignado { get; set; }

        public RolesDetalle()
        {
            ID = 0;
            RolID = 0;
            PermisoID = 0;
            esAsignado = false;
        }

        public RolesDetalle(int ID, int RolID, int PermisoID, bool esAsignado)
        {
            this.ID = ID;
            this.RolID = RolID;
            this.PermisoID = PermisoID;
            this.esAsignado = esAsignado;
        }
    }
}
