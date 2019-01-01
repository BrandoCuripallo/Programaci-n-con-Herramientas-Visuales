using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login.Clases;
namespace Login
{
    public partial class FrmIngresarCita : Form
    {
        public bool editar = false;
        private Administrador administrador;
        Paciente paciente;
        Recepcionista recepcionista;
        Doctor doctor;
        Especialidad especialidad;
        CitaMedica citaMedica;
        List<Especialidad> especialidades;
        List<Doctor> doctores;
        DataTable tbl;
        public FrmIngresarCita()
        {
            InitializeComponent();
        }
        public void llenarDoctores(Object doctor)
        {
            this.doctores = (List<Doctor>)doctor;
        }
        public void llenarEspecialidades(Object especialid)
        {
            this.especialidades = (List<Especialidad>)especialid;
            cbxEspecialidad.Items.Clear();
            foreach (var aux in especialidades)
                cbxEspecialidad.Items.Add(aux.NombreEspecialidad);
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
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

        private void txtCedulaRecepcionista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void limpiarTextos()
        {
            txtNumeroCita.Text = Convert.ToString(Convert.ToInt32(txtNumeroCita.Text) + 1);
            txtCedula.Text = "";
            txtNombres.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCanton.Text = "";
            cbxProvincia.Text = "";
            txtCedulaRecepcionista.Text = "";
            txtNombresRecepcionista.Text = "";
            txtApellidoPaternoRecepcionista.Text = "";
            txtDescripcion.Text = "";
            cbxEspecialidad.SelectedIndex = 0;
            cbxDoctor.Items.Clear();
            dtpFechaCita.Value = DateTime.Today;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            paciente = administrador.buscarPaciente(txtCedula.Text);
            if (paciente != null)
            {
                txtNombres.Text = paciente.Nombres;
                txtApellidoPaterno.Text = paciente.ApellidoPaterno;
                txtApellidoMaterno.Text = paciente.ApellidoMaterno;
                txtCorreo.Text = paciente.CorreoElectronico;
                cbxProvincia.Text = paciente.Provincia;
                txtCanton.Text = paciente.Canton;
                txtDireccion.Text = paciente.Direccion;
                txtTelefono.Text = paciente.Telefono;
            }
            else
                MessageBox.Show("El paciente no se encuentra registrado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnBuscarRecepcionista_Click(object sender, EventArgs e)
        {
            recepcionista = administrador.buscarRecepcionista(txtCedulaRecepcionista.Text);
            if (recepcionista != null)
            {
                txtNombresRecepcionista.Text = recepcionista.Nombres;
                txtApellidoPaternoRecepcionista.Text = recepcionista.ApellidoPaterno;
            }
            else
                MessageBox.Show("El recepcionista no se encuentra registrado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "")
            {
                if (txtCedulaRecepcionista.Text != "")
                {
                    if (txtDescripcion.Text != "")
                    {
                        if(cbxEspecialidad.Text != "")
                        {
                            if(cbxDoctor.Text != "")
                            {
                                DialogResult resultado = MessageBox.Show("¿Desea guardar el Registro?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (resultado == DialogResult.Yes)
                                {
                                    try
                                    {
                                        citaMedica = new CitaMedica();
                                        citaMedica.NumeroCita = Convert.ToInt32(txtNumeroCita.Text);
                                        citaMedica.Paciente = paciente;
                                        citaMedica.FechaCita = dtpFechaCita.Value;
                                        citaMedica.Descripcion = txtDescripcion.Text;
                                        especialidad = especialidades.SingleOrDefault(aux => aux.NombreEspecialidad == cbxEspecialidad.Text);
                                        citaMedica.Especialidad = especialidad;
                                        doctor = doctores.SingleOrDefault(aux => aux.ApellidoPaterno == cbxDoctor.Text);
                                        citaMedica.Doctor = doctor;
                                        if (editar)
                                        {
                                            recepcionista = new Recepcionista();
                                            recepcionista.Cedula = txtCedulaRecepcionista.Text;
                                            citaMedica.Recepcionista = recepcionista;
                                            paciente = new Paciente();
                                            paciente.Cedula = txtCedula.Text;
                                            citaMedica.Paciente = paciente;
                                            if (administrador.modificarCitaMedica(citaMedica))
                                            {
                                                MessageBox.Show("Cita modificada con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                this.Close();
                                            }
                                            else
                                                MessageBox.Show("La Cita ya existe", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                        else
                                        {
                                            citaMedica.Recepcionista = recepcionista;
                                            citaMedica.Recepcionista = recepcionista;
                                            if (administrador.ingresarCitaMedica(citaMedica))
                                            {

                                                MessageBox.Show("Cita ingresada con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                limpiarTextos();
                                            }
                                            else
                                                MessageBox.Show("La Cita ya se encuentra registrada", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Error de ingreso de datos", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }   
                            }
                            else
                                MessageBox.Show("Seleccione el Médico para la especialidad", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                            MessageBox.Show("Seleccione la especialidad de la cita", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        MessageBox.Show("Ingrese el motivo de la cita", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Ingrese la cédula del recepcionista", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Ingrese la cédula del paciente", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void cbxEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string espe = cbxEspecialidad.Text;
            cbxDoctor.Items.Clear();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT apellidoPaterno FROM tblDoctor LEFT JOIN tblEspecialidad ON tblDoctor.codigoEspecialidad = tblEspecialidad.codigoEspecialidad WHERE tblEspecialidad.nombreEspecialidad = '" + espe + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cbxDoctor.Items.Add(reader.GetString(0));
                }
            }
        }
    }
}
