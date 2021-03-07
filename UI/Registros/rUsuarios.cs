using ProyectoTarea6.Entidades;
using ProyectoTarea6.BLL;
using System;
using System.Windows.Forms;

namespace ProyectoTarea6.UI
{
    public partial class rUsuarios : Form
    {
        public rUsuarios()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            UsuarioIdNumericUpDown.Value = 0;
            AliasTextBox.Clear();
            NombreTextBox.Clear();
            ClaveTextBox.Clear();
            ConfirmarClaveTextBox.Clear();
            EmailTextBox.Clear();
            FechaCreacionDateTimePicker.Value = DateTime.Now;
            RolComboBox.Text = " ";
            ActivoCheckBox.Checked = false;
        }
        public void LlenaCampos(Usuarios usuarios)
        {
            ActivoCheckBox.Checked = usuarios.Activo;
            UsuarioIdNumericUpDown.Value = usuarios.UsuarioID;
            NombreTextBox.Text = usuarios.NombreUsuario;
            ClaveTextBox.Text = usuarios.Clave;
            ConfirmarClaveTextBox.Text = usuarios.Clave;
            EmailTextBox.Text = usuarios.Email;
            FechaCreacionDateTimePicker.Value = usuarios.FechaUsuario;
            RolComboBox.Text = usuarios.Rol;
            AliasTextBox.Text = usuarios.AliasUsuario;
        }
        private Usuarios LlenaClase()
        {
            Usuarios usuario = new Usuarios();
            usuario.UsuarioID = (int)UsuarioIdNumericUpDown.Value;
            usuario.AliasUsuario = AliasTextBox.Text;
            usuario.Activo = ActivoCheckBox.Checked;
            usuario.Email = EmailTextBox.Text;
            usuario.FechaUsuario = FechaCreacionDateTimePicker.Value;
            usuario.Rol = RolComboBox.Text;
            usuario.Clave = ClaveTextBox.Text;
            usuario.NombreUsuario = NombreTextBox.Text;

            return usuario;
        }
        private void rUsuarios_Load(object sender, EventArgs e)
        {
            RolComboBox.DataSource = RolesBLL.GetRoles();
            RolComboBox.DisplayMember = "DescripcionRol";
            RolComboBox.ValueMember = "RolID";
        }
        private bool Validar()
        {
            bool paso = true;

            if (NombreTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NombreTextBox, "El campo nombre no puede estar vacio");
                NombreTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MyErrorProvider.SetError(EmailTextBox, "El Email no puede estar vacio");
                EmailTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(AliasTextBox.Text))
            {
                MyErrorProvider.SetError(AliasTextBox, "El campo Alias no puede estar vacio");
                AliasTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(RolComboBox.Text))
            {
                MyErrorProvider.SetError(RolComboBox, "Debe agregar un rol especifico");
                RolComboBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ClaveTextBox.Text))
            {
                MyErrorProvider.SetError(ClaveTextBox, "Debe asignar una clave a su usuario");
                ClaveTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ConfirmarClaveTextBox.Text))
            {
                MyErrorProvider.SetError(ConfirmarClaveTextBox, "Debe confirmar la clave");
                ConfirmarClaveTextBox.Focus();
                paso = false;
            }
            if (ClaveTextBox.Text != ConfirmarClaveTextBox.Text)
            {
                MyErrorProvider.SetError(ConfirmarClaveTextBox, "Las contrseñas deben ser iguales.");
                ConfirmarClaveTextBox.Focus();
                MyErrorProvider.SetError(ClaveTextBox, "Las contraseñas deben ser iguales.");
                ClaveTextBox.Focus();
                paso = false;
            }
            if (UsuariosBLL.ExisteAlias(AliasTextBox.Text))
            {
                MyErrorProvider.SetError(AliasTextBox, "Los Alias no pueden repetirse!");
                AliasTextBox.Focus();
                paso = false;
            }

            return paso;
        }
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Usuarios usuario = new Usuarios();
            int.TryParse(UsuarioIdNumericUpDown.Text, out id);

            Limpiar();

            usuario = UsuariosBLL.Buscar(id);

            if (usuario != null)
            {
                MessageBox.Show("Persona Encotrada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenaCampos(usuario);
            }
            else
            {
                MessageBox.Show("Persona no Encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuarios;

            if (!Validar())
                return;

            usuarios = LlenaClase();

            var paso = UsuariosBLL.Guardar(usuarios);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();

            int id;
            int.TryParse(UsuarioIdNumericUpDown.Text, out id);

            Limpiar();

            if (UsuariosBLL.Eliminar(id))
                MessageBox.Show("Eliminado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(UsuarioIdNumericUpDown, "No se puede eliminar una persona que no existe");
        }

    }
}
