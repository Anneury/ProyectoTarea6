using ProyectoTarea6.UI.Registros;
using ProyectoTarea6.UI.Consultas;
using ProyectoTarea6.UI;
using System;
using System.Windows.Forms;

namespace ProyectoTarea6
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.UsuariosToolStripMenuItem.Click += new EventHandler(this.UsuariosToolStripMenuItem_ItemClicked);
            this.RolesToolStripMenuItem.Click += new EventHandler(this.RolesToolStripMenuItem_ItemClicked);
            this.PermisosToolStripMenuItem.Click += new EventHandler(this.PermisosToolStripMenuItem_ItemClicked);

            this.ConsultarRolesToolStripMenuItem.Click += new EventHandler(this.ConsultarRolesToolStripMenuItem_ItemClicked);
        }
        private void UsuariosToolStripMenuItem_ItemClicked(object sender, EventArgs e)
        {
            var usuarios = new rUsuarios();
            usuarios.MdiParent = this;
            usuarios.Show();
        }
        private void RolesToolStripMenuItem_ItemClicked(object sender, EventArgs e)
        {
            var roles = new rRoles();
            roles.MdiParent = this;
            roles.Show();
        }
        private void PermisosToolStripMenuItem_ItemClicked(object sender, EventArgs e)
        {
            var permisos = new rPermisos();
            permisos.MdiParent = this;
            permisos.Show();
        }
        private void ConsultarRolesToolStripMenuItem_ItemClicked(object sender, EventArgs e)
        {
            var consultas = new cRoles();
            consultas.MdiParent = this;
            consultas.Show();
        }
    }
}
