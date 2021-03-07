using ProyectoTarea6.BLL;
using ProyectoTarea6.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoTarea6.UI
{
    public partial class rRoles : Form
    {
        public List<RolesDetalle> Detalle { get; set; }
        public rRoles()
        {
            InitializeComponent();
            this.Detalle = new List<RolesDetalle>();
        }

        private void rRoles_Load(object sender, EventArgs e)
        {
            PermisoIdComboBox.DataSource = PermisosBLL.GetPermisos();
            PermisoIdComboBox.DisplayMember = "PermisoID";
            PermisoIdComboBox.ValueMember = "DescripcionPermiso";
        }
        public void CargarGrid()
        {
            DetallesDataGridView.DataSource = null;
            DetallesDataGridView.DataSource = this.Detalle;
        }
        public void Limpiar()
        {
            RolIdNumericUpDown.Value = 0;
            DescripcionRolTextBox.Clear();
            MyErrorProvider.Clear();
            EsAsignadoCheckBox.Checked = false;
            ActivoCheckBox.Checked = false;
            FechaDateTimePicker.Value = DateTime.Now;

            this.Detalle = new List<RolesDetalle>();
            CargarGrid();
        }

        public void LlenaCampo(Roles roles)
        {
            RolIdNumericUpDown.Value = roles.RolID;
            DescripcionRolTextBox.Text = roles.DescripcionRol;
            ActivoCheckBox.Checked = roles.esActivo;
            FechaDateTimePicker.Value = roles.FechaCreacion;
            this.Detalle = roles.Detalle;
            CargarGrid();
        }

        public Roles LlenaClase()
        {
            Roles roles = new Roles();
            roles.RolID = (int)RolIdNumericUpDown.Value;
            roles.DescripcionRol = DescripcionRolTextBox.Text;
            roles.esActivo = ActivoCheckBox.Checked;
            roles.Detalle = this.Detalle;
            CargarGrid();

            return roles;
        }
        public bool Validar()
        {
            bool paso = true;

            if (DescripcionRolTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(DescripcionRolTextBox, "Debes agregar un dato a este campo");
                DescripcionRolTextBox.Focus();

                paso = false;
            }

            return paso;
        }
        public bool ExisteEnLaBaseDeDatos()
        {
            Roles roles = RolesBLL.Buscar((int)RolIdNumericUpDown.Value);
            return (roles != null);
        }
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Roles roles;
            int id;
            int.TryParse(RolIdNumericUpDown.Text, out id);

            Limpiar();

            roles = RolesBLL.Buscar(id);

            if (roles != null)
            {
                MessageBox.Show("Rol encontrado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenaCampo(roles);
            }
            else
                MessageBox.Show("Este Rol no existe, prueba buscar otro!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private void AgregarButton_Click(object sender, EventArgs e)
        {
            if (DetallesDataGridView.DataSource != null)
                this.Detalle = (List<RolesDetalle>)DetallesDataGridView.DataSource;

            if (PermisoIdComboBox.Text == string.Empty)
            {
                MessageBox.Show("Debes seleccionar un permiso antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            this.Detalle.Add(
                new RolesDetalle(
                    ID: 0,
                    RolID: (int)RolIdNumericUpDown.Value,
                    PermisoID: Convert.ToInt32(PermisoIdComboBox.Text),
                    esAsignado: EsAsignadoCheckBox.Checked
                )
            );
            CargarGrid();
            PermisoIdComboBox.Focus();
        }
        private void RemoverButton_Click(object sender, EventArgs e)
        {
            if ((DetallesDataGridView.Rows.Count > 0 && DetallesDataGridView.CurrentRow != null))
            {
                Detalle.RemoveAt(DetallesDataGridView.CurrentRow.Index);
                CargarGrid();
            }
            else
            {
                MyErrorProvider.SetError(DetallesDataGridView, "No hay datos aqui.");
                DetallesDataGridView.Focus();
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Roles roles;

            if (!Validar())
                return;

            roles = LlenaClase();

            var paso = RolesBLL.Guardar(roles);

            if (paso)
            {
                MessageBox.Show("Rol guardado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo guardar este permiso, intentalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
            int id;
            int.TryParse(RolIdNumericUpDown.Text, out id);

            if (RolIdNumericUpDown.Value == 0)
            {
                MessageBox.Show("Debes agregar un Id valido para poder eliminar un Rol", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ExisteEnLaBaseDeDatos())
            {
                if (MessageBox.Show("Deseas eliminar este Rol?", "Elije una opcion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (PermisosBLL.Eliminar(id))
                    {
                        MessageBox.Show("Rol eliminado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                        MyErrorProvider.SetError(RolIdNumericUpDown, "Agrega un Id Valido! Este no existe.");
                }

            }
            else
                MessageBox.Show("Este Rol no existe en la base de datos, prueba a eliminar otro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

    }
}
