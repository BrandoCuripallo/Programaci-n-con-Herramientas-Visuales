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
    public partial class FrmIngresarDoctor : Form
    {
        public bool editar = false;
        public string cedula;
        Doctor doctor;
        private Administrador administrador;
        private List<Especialidad> especialidades;
        public FrmIngresarDoctor()
        {
            InitializeComponent();
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
        }
        public void llenarEspecialidades(Object especialidad)
        {
            especialidades = (List<Especialidad>)especialidad;
            cbxEspecialidad.Items.Clear();
            foreach(var aux in especialidades)
            {
                cbxEspecialidad.Items.Add(aux.NombreEspecialidad);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
            cbxEspecialidad.SelectedIndex = 0;
            mcdFechaNacimiento.SetDate(DateTime.Today);
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
                                                    if (txtUsuario.Text != "")
                                                    {
                                                        if (cbxEspecialidad.Text != "")
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
                                                                            doctor = new Doctor();
                                                                            doctor.Cedula = txtCedula.Text;
                                                                            doctor.Nombres = txtNombres.Text;
                                                                            doctor.ApellidoPaterno = txtApellidoPaterno.Text;
                                                                            doctor.ApellidoMaterno = txtApellidoMaterno.Text;
                                                                            doctor.setFechaNacimiento(mcdFechaNacimiento.SelectionRange.Start.Date);
                                                                            doctor.calcularEdad();
                                                                            if (rdbMasculino.Checked)
                                                                                doctor.Sexo = rdbMasculino.Text;
                                                                            else
                                                                                doctor.Sexo = rdbFemenino.Text;
                                                                            doctor.CorreoElectronico = txtCorreo.Text;
                                                                            doctor.Provincia = cbxProvincia.Text;
                                                                            doctor.Canton = txtCanton.Text;
                                                                            doctor.Direccion = txtDireccion.Text;
                                                                            doctor.Telefono = txtTelefono.Text;
                                                                            doctor.UsuarioDoctor = txtUsuario.Text;
                                                                            doctor.ContraseniaDoctor = txtContrasenia.Text;
                                                                            doctor.Especialidad = obtenerIdEspecialidad(cbxEspecialidad.Text);
                                                                            if (editar)
                                                                            {
                                                                                if (administrador.modificarDoctor(doctor, cedula))
                                                                                {
                                                                                    MessageBox.Show("Doctor modificado con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                    limpiarTextos();
                                                                                }
                                                                                else
                                                                                    MessageBox.Show("El doctor ya existe", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (administrador.ingresarDoctor(doctor))
                                                                                {

                                                                                    MessageBox.Show("Doctor ingresado con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                    limpiarTextos();
                                                                                }
                                                                                else
                                                                                    MessageBox.Show("El doctor ya se encuentra registrado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                                                            MessageBox.Show("Seleccione una especialidad", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private Especialidad obtenerIdEspecialidad(string nombreEspecialidad)
        {
            var item= especialidades.SingleOrDefault(aux => aux.NombreEspecialidad == nombreEspecialidad);
            if (item != null)
                return item;
            else
                return null;
        }
    }
}
