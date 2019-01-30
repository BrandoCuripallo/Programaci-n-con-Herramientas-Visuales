using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Login.Clases;
namespace Login
{
    public partial class FrmIngresarFarmaceutico : Form
    {
        public bool editar = false;
        public string cedula;
        Farmaceutico farmaceutico;
        private Administrador administrador;
        public FrmIngresarFarmaceutico()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtApellidoPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) || (e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y un solo apellido", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtApellidoMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) || (e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y un solo apellido", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCanton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private Boolean validarEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "")
            {
                if (txtNombres.Text != "")
                {
                    if (txtApellidoPaterno.Text != "")
                    {
                        if (txtApellidoMaterno.Text != "")
                        {
                            if (txtCorreo.Text != "")
                            {
                                if (cbxProvincia.Text != "")
                                {
                                    if (txtCanton.Text != "")
                                    {
                                        if (txtDireccion.Text != "")
                                        {
                                            if (txtTelefono.Text != "")
                                            {
                                                if (txtContrasenia.Text != "")
                                                {
                                                    if(txtUsuario.Text != "")
                                                    {
                                                        if (validarEmail(txtCorreo.Text))
                                                        {
                                                            if (mcdFechaNacimiento.SelectionRange.Start.Date < DateTime.Today)
                                                            {
                                                                DialogResult resultado = MessageBox.Show("¿Desea guardar el Registro?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                                if (resultado == DialogResult.Yes)
                                                                {
                                                                    try
                                                                    {
                                                                        farmaceutico = new Farmaceutico();
                                                                        farmaceutico.Cedula = txtCedula.Text;
                                                                        farmaceutico.Nombres = txtNombres.Text;
                                                                        farmaceutico.ApellidoPaterno = txtApellidoPaterno.Text;
                                                                        farmaceutico.ApellidoMaterno = txtApellidoMaterno.Text;
                                                                        farmaceutico.setFechaNacimiento(mcdFechaNacimiento.SelectionRange.Start.Date);
                                                                        farmaceutico.calcularEdad();
                                                                        if (rdbMasculino.Checked)
                                                                            farmaceutico.Sexo = rdbMasculino.Text;
                                                                        else
                                                                            farmaceutico.Sexo = rdbFemenino.Text;
                                                                        farmaceutico.CorreoElectronico = txtCorreo.Text;
                                                                        farmaceutico.Provincia = cbxProvincia.Text;
                                                                        farmaceutico.Canton = txtCanton.Text;
                                                                        farmaceutico.Direccion = txtDireccion.Text;
                                                                        farmaceutico.Telefono = txtTelefono.Text;
                                                                        farmaceutico.Usuario = txtUsuario.Text;
                                                                        farmaceutico.Contrasenia = txtContrasenia.Text;
                                                                        if (editar)
                                                                        {
                                                                            if (administrador.modificarFarmaceutico(farmaceutico, cedula))
                                                                            {
                                                                                MessageBox.Show("Farmaceútico modificado con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                limpiarTextos();
                                                                            }
                                                                            else
                                                                                MessageBox.Show("El farmaceútico ya existe", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (administrador.ingresarFarmaceutico(farmaceutico))
                                                                            {

                                                                                MessageBox.Show("Farmaceútico ingresado con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                limpiarTextos();
                                                                            }
                                                                            else
                                                                                MessageBox.Show("El farmaceútico ya se encuentra registrado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                                        }
                                                                    }
                                                                    catch
                                                                    {
                                                                        MessageBox.Show("Error de ingreso de datos", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                    }
                                                                }
                                                            }
                                                            else
                                                                MessageBox.Show("La fecha de nacimiento no puede ser mayor a la fecha actual", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                                        }
                                                        else
                                                            MessageBox.Show("La dirección de Correo Electrónico es incorrecta", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                    else
                                                        MessageBox.Show("El campo Usuario no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                else
                                                    MessageBox.Show("El campo Contraseñia no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            else
                                                MessageBox.Show("El campo Teléfono no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                            MessageBox.Show("El campo Dirección no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                        MessageBox.Show("El campo Cantón no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                    MessageBox.Show("Seleccione una provincia", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                                MessageBox.Show("El campo Correo no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("El campo Apellido Materno no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("El campo Apellido Paterno no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("El campo Nombres no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("El campo Cédula no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void limpiarTextos()
        {
            txtCedula.Text = "";
            txtNombres.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtCorreo.Text = "";
            txtCanton.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Text = "";
            txtContrasenia.Text = "";
            rdbMasculino.Checked = true;
            cbxProvincia.SelectedIndex = 0;
            mcdFechaNacimiento.SetDate(DateTime.Today);
        }
    }
}
