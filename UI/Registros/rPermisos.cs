using ProyectoTarea6.Entidades;
using ProyectoTarea6.BLL;
using System;
using System.Windows.Forms;

namespace ProyectoTarea6.UI.Registros
{
    public partial class rPermisos : Form
    {
        public rPermisos()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            MyErrorProvider.Clear();
            PermisoIdNumericUpDown.Value = 0;
            NombrePermisoTextBox.Clear();
            DescripcionTextBox.Clear();

        }

        public void LlenaCampo(Permisos permiso)
        {
            PermisoIdNumericUpDown.Value = permiso.PermisoID;
            NombrePermisoTextBox.Text = permiso.NombrePermiso;
            DescripcionTextBox.Text = permiso.DescripcionPermiso;
        }

        public Permisos LlenaClase()
        {
            Permisos permiso = new Permisos();
            permiso.PermisoID = (int)PermisoIdNumericUpDown.Value;
            permiso.NombrePermiso = NombrePermisoTextBox.Text;
            permiso.DescripcionPermiso = DescripcionTextBox.Text;

            return permiso;
        }
        public bool ExisteEnLaBaseDeDatos()
        {
            Permisos permisos = PermisosBLL.Buscar((int)PermisoIdNumericUpDown.Value);

            return (permisos != null);
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Permisos permisos;
            int id;
            int.TryParse(PermisoIdNumericUpDown.Text, out id);

            if(PermisoIdNumericUpDown.Value == 0)
            {
                MessageBox.Show("Debes agregar un numero aqui para poder buscar.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Limpiar();

            permisos = PermisosBLL.Buscar(id);

            if (permisos != null)
            {
                MessageBox.Show("Permiso encontrado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenaCampo(permisos);
            }
            else
                MessageBox.Show("Este Permiso no existe, prueba buscar otro!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

 
    }
}
