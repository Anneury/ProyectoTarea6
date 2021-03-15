using ProyectoTarea6.BLL;
using ProyectoTarea6.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTarea6.UI.Consultas
{
    public partial class cRoles : Form
    {
        public cRoles()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            var listado = new List<Roles>();

            if (!string.IsNullOrEmpty(CriterioTextBox.Text))
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = RolesBLL.GetList(e => e.RolID == Conversiones.AEntero(CriterioTextBox.Text));
                        break;

                    case 1:
                        listado = RolesBLL.GetList(e => e.DescripcionRol.Contains(CriterioTextBox.Text));
                        break;

                }
            }
            else
            {
                listado = RolesBLL.GetList(c => true);
            }

            if (UsarFechaCheckBox.Checked == true)
            {
                listado = RolesBLL.GetList(e => e.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && e.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date);
            }

            if (ActivoRadioButton.Checked == true)
            {
                listado = RolesBLL.GetList(e => e.esActivo == true);
            }

            if (InactivoRadioButton.Checked == true)
            {
                listado = RolesBLL.GetList(e => e.esActivo == false);
            }
            /*//ninguno seleccionado
            if (UsarFechaCheckBox.Checked == false && CriterioTextBox.Text == string.Empty && TodosRadioButton.Checked == false && ActivoRadioButton.Checked == false && InactivoRadioButton.Checked == false)
            {
                listado = RolesBLL.GetList(e => true);
            }

            //De uno en uno
            if (UsarFechaCheckBox.Checked != false && CriterioTextBox.Text == string.Empty && TodosRadioButton.Checked == false && ActivoRadioButton.Checked == false && InactivoRadioButton.Checked == false)
            {
                listado = RolesBLL.GetList(e => e.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && e.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date);
            }
            if (UsarFechaCheckBox.Checked == false && CriterioTextBox.Text != string.Empty && TodosRadioButton.Checked == false && ActivoRadioButton.Checked == false && InactivoRadioButton.Checked == false)
            {
                if (!string.IsNullOrEmpty(CriterioTextBox.Text))
                {
                    switch (FiltroComboBox.SelectedIndex)
                    {
                        case 0:
                            listado = RolesBLL.GetList(e => e.RolID == int.Parse(CriterioTextBox.Text));
                            break;

                        case 1:
                            listado = RolesBLL.GetList(e => e.DescripcionRol.Contains(CriterioTextBox.Text));
                            break;

                    }
                }
                else
                {
                    listado = RolesBLL.GetList(c => true);
                }
            }
            if (UsarFechaCheckBox.Checked == false && CriterioTextBox.Text == string.Empty && TodosRadioButton.Checked != false && ActivoRadioButton.Checked == false && InactivoRadioButton.Checked == false)
            {
                listado = RolesBLL.GetList(e => e.esActivo == true || e.esActivo == false);
            }
            if (UsarFechaCheckBox.Checked == false && CriterioTextBox.Text == string.Empty && TodosRadioButton.Checked == false && ActivoRadioButton.Checked != false && InactivoRadioButton.Checked == false)
            {
                listado = RolesBLL.GetList(e => e.esActivo == true);
            }
            if (UsarFechaCheckBox.Checked == false && CriterioTextBox.Text == string.Empty && TodosRadioButton.Checked == false && ActivoRadioButton.Checked == false && InactivoRadioButton.Checked != false)
            {
                listado = RolesBLL.GetList(e => e.esActivo == false);
            }

            //De dos en dos
            //Empezando con Las fechas
            if (UsarFechaCheckBox.Checked != false && CriterioTextBox.Text != string.Empty && TodosRadioButton.Checked == false && ActivoRadioButton.Checked == false && InactivoRadioButton.Checked == false)
            {
                if (!string.IsNullOrEmpty(CriterioTextBox.Text))
                {
                    switch (FiltroComboBox.SelectedIndex)
                    {
                        case 0:
                            listado = RolesBLL.GetList(e => e.RolID == int.Parse(CriterioTextBox.Text) && e.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && e.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date);
                            break;

                        case 1:
                            listado = RolesBLL.GetList(e => e.DescripcionRol.Contains(CriterioTextBox.Text) && e.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && e.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date);
                            break;

                    }
                }
                else
                {
                    listado = RolesBLL.GetList(c => c.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && c.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date);
                }
            }
            if (UsarFechaCheckBox.Checked != false && CriterioTextBox.Text == string.Empty && TodosRadioButton.Checked != false && ActivoRadioButton.Checked == false && InactivoRadioButton.Checked == false)
            {
                listado = RolesBLL.GetList(e => e.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && e.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date && e.esActivo == true || e.esActivo == false);
            }
            if (UsarFechaCheckBox.Checked != false && CriterioTextBox.Text == string.Empty && TodosRadioButton.Checked == false && ActivoRadioButton.Checked != false && InactivoRadioButton.Checked == false)
            {
                listado = RolesBLL.GetList(e => e.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && e.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date && e.esActivo == true);
            }
            if (UsarFechaCheckBox.Checked != false && CriterioTextBox.Text == string.Empty && TodosRadioButton.Checked == false && ActivoRadioButton.Checked == false && InactivoRadioButton.Checked != false)
            {
                listado = RolesBLL.GetList(e => e.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && e.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date || e.esActivo == false);
            }

            //De dos en dos
            //Con el criterio
            if (UsarFechaCheckBox.Checked == false && CriterioTextBox.Text != string.Empty && TodosRadioButton.Checked != false && ActivoRadioButton.Checked == false && InactivoRadioButton.Checked == false)
            {
                if (!string.IsNullOrEmpty(CriterioTextBox.Text) && TodosRadioButton.Checked == true)
                {
                    switch (FiltroComboBox.SelectedIndex)
                    {
                        case 0:
                            listado = RolesBLL.GetList(e => e.RolID == int.Parse(CriterioTextBox.Text) && e.esActivo == true || e.esActivo == false);
                            break;

                        case 1:
                            listado = RolesBLL.GetList(e => e.DescripcionRol.Contains(CriterioTextBox.Text) && e.esActivo == true || e.esActivo == false);
                            break;

                    }
                }

                else
                {
                    listado = RolesBLL.GetList(c => c.esActivo == true || c.esActivo == false);
                }

            }

            if (UsarFechaCheckBox.Checked == false && CriterioTextBox.Text != string.Empty && TodosRadioButton.Checked == false && ActivoRadioButton.Checked != false && InactivoRadioButton.Checked == false)
            {
                if (!string.IsNullOrEmpty(CriterioTextBox.Text) && ActivoRadioButton.Checked == true)
                {
                    switch (FiltroComboBox.SelectedIndex)
                    {
                        case 0:
                            listado = RolesBLL.GetList(e => e.RolID == int.Parse(CriterioTextBox.Text) && e.esActivo == true);
                            break;

                        case 1:
                            listado = RolesBLL.GetList(e => e.DescripcionRol.Contains(CriterioTextBox.Text) && e.esActivo == true);
                            break;

                    }
                }
                else
                {
                    listado = RolesBLL.GetList(c => c.esActivo == true);
                }
            }

            if (UsarFechaCheckBox.Checked == false && CriterioTextBox.Text != string.Empty && TodosRadioButton.Checked == false && ActivoRadioButton.Checked == false && InactivoRadioButton.Checked != false)
            {
                if (!string.IsNullOrEmpty(CriterioTextBox.Text) && InactivoRadioButton.Checked == true)
                {
                    switch (FiltroComboBox.SelectedIndex)
                    {
                        case 0:
                            listado = RolesBLL.GetList(e => e.RolID == int.Parse(CriterioTextBox.Text) && e.esActivo == false);
                            break;

                        case 1:
                            listado = RolesBLL.GetList(e => e.DescripcionRol.Contains(CriterioTextBox.Text) && e.esActivo == false);
                            break;

                    }
                }
                else
                {
                    listado = RolesBLL.GetList(c => c.esActivo == false);
                }
            }

            //De tres en tres 
            //Con usar fechas y criterio
            if (UsarFechaCheckBox.Checked != false && CriterioTextBox.Text != string.Empty && TodosRadioButton.Checked != false && ActivoRadioButton.Checked == false && InactivoRadioButton.Checked == false)
            {
                if (!string.IsNullOrEmpty(CriterioTextBox.Text) && TodosRadioButton.Checked == true)
                {
                    switch (FiltroComboBox.SelectedIndex)
                    {
                        case 0:
                            listado = RolesBLL.GetList(e => e.RolID == int.Parse(CriterioTextBox.Text) && e.esActivo == true || e.esActivo == false && e.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && e.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date);
                            break;

                        case 1:
                            listado = RolesBLL.GetList(e => e.DescripcionRol.Contains(CriterioTextBox.Text) && e.esActivo == true || e.esActivo == false && e.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && e.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date);
                            break;

                    }
                }

                else
                {
                    listado = RolesBLL.GetList(c => c.esActivo == true || c.esActivo == false && c.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && c.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date);
                }
            }
            if (UsarFechaCheckBox.Checked != false && CriterioTextBox.Text != string.Empty && TodosRadioButton.Checked == false && ActivoRadioButton.Checked != false && InactivoRadioButton.Checked == false)
            {
                if (!string.IsNullOrEmpty(CriterioTextBox.Text) && ActivoRadioButton.Checked == true)
                {
                    switch (FiltroComboBox.SelectedIndex)
                    {
                        case 0:
                            listado = RolesBLL.GetList(e => e.RolID == int.Parse(CriterioTextBox.Text) && e.esActivo == true && e.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && e.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date);
                            break;

                        case 1:
                            listado = RolesBLL.GetList(e => e.DescripcionRol.Contains(CriterioTextBox.Text) && e.esActivo == true && e.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && e.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date);
                            break;

                    }
                }
                else
                {
                    listado = RolesBLL.GetList(c => c.esActivo == true && c.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && c.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date);
                }
            }
            if (UsarFechaCheckBox.Checked != false && CriterioTextBox.Text != string.Empty || CriterioTextBox.Text == string.Empty && FiltroComboBox.Text != string.Empty && TodosRadioButton.Checked == false && ActivoRadioButton.Checked == false && InactivoRadioButton.Checked != false)
            {
                if (!string.IsNullOrEmpty(CriterioTextBox.Text) && InactivoRadioButton.Checked == true)
                {
                    switch (FiltroComboBox.SelectedIndex)
                    {
                        case 0:
                            listado = RolesBLL.GetList(e => e.RolID == int.Parse(CriterioTextBox.Text) && e.esActivo == false && e.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && e.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date);
                            break;

                        case 1:
                            listado = RolesBLL.GetList(e => e.DescripcionRol.Contains(CriterioTextBox.Text) && e.esActivo == false && e.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && e.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date);
                            break;

                    }
                }
                else
                {
                    MessageBox.Show("Pase por aqui lo ultimio.", "Pasando");
                    listado = RolesBLL.GetList(c => c.esActivo == false && c.FechaCreacion.Date >= FechaDesdeDateTimePicker.Value.Date && c.FechaCreacion.Date <= FechaHastaDateTimePicker.Value.Date);
                }
            }*/

            DatosDataGrid.DataSource = null;
            DatosDataGrid.DataSource = listado;
        }
    }
}
