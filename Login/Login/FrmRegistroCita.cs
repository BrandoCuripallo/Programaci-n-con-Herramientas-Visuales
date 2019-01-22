using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login.Clases;
using System.Data.SqlClient;
namespace Login
{
    public partial class FrmRegistroCita : Form
    {
        private Administrador administrador;
        private Doctor doctor;
        Especialidad especialidad;
        CitaMedica citaMedica;
        Paciente paciente;
        Recepcionista recepcionista;
        List<Doctor> doctores = new List<Doctor>();
        List<CitaMedica> citasMedicas = new List<CitaMedica>();
        List<Especialidad> especialidades = new List<Especialidad>();
        public FrmRegistroCita()
        {
            InitializeComponent();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmIngresarCita frmIngresarCita = new FrmIngresarCita();
            frmIngresarCita.asignarAdministrador(this.administrador);
            frmIngresarCita.llenarEspecialidades(this.especialidades);
            frmIngresarCita.llenarDoctores(this.doctores);
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT TOP 1 idCita FROM tblCitaMedica ORDER BY idCita DESC";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    frmIngresarCita.txtNumeroCita.Text = Convert.ToString(reader.GetInt32(0) + 1);
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
            else
                frmIngresarCita.txtNumeroCita.Text = "1";
            frmIngresarCita.Show();
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
        }
        public void llenarDataGridView()
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT idCita, fechaCita, tblCitaMedica.cedulaPaciente, tblPaciente.nombres, tblPaciente.apellidoPaterno, nombreEspecialidad, " + 
                "tblcitaMedica.descripcion, tblDoctor.cedulaDoctor, tblDoctor.nombres, tblDoctor.apellidoPaterno, tblCitaMedica.cedulaRecepcionista FROM tblCitaMedica INNER JOIN tblPaciente " + 
                "ON tblCitaMedica.cedulaPaciente = tblPaciente.cedulaPaciente INNER JOIN tblEspecialidad ON tblCitaMedica.codigoEspecialidad = tblEspecialidad.codigoEspecialidad " + 
                "INNER JOIN tblDoctor ON tblCitaMedica.cedulaDoctor = tblDoctor.cedulaDoctor INNER JOIN tblRecepcionista ON tblCitaMedica.cedulaRecepcionista = tblRecepcionista.cedulaRecepcionista";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Número de Cita");
            tbl.Columns.Add("Fecha de la Cita");
            tbl.Columns.Add("Cédula del Paciente");
            tbl.Columns.Add("Nombres");
            tbl.Columns.Add("Apellido Paterno");
            tbl.Columns.Add("Especialidad");
            tbl.Columns.Add("Motivo de la Cita");
            tbl.Columns.Add("Nombre del Doctor");
            tbl.Columns.Add("Apellido");
            especialidad = new Especialidad();
            doctor = new Doctor();
            paciente = new Paciente();
            citaMedica = new CitaMedica();
            especialidad = new Especialidad();
            recepcionista = new Recepcionista();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    citaMedica.NumeroCita = reader.GetInt32(0);
                    citaMedica.FechaCita = reader.GetDateTime(1);
                    paciente.Cedula = reader.GetString(2);
                    paciente.Nombres = reader.GetString(3);
                    paciente.ApellidoPaterno = reader.GetString(4);
                    citaMedica.Paciente = paciente;
                    especialidad.NombreEspecialidad = reader.GetString(5);
                    citaMedica.Especialidad = especialidad;
                    citaMedica.Descripcion = reader.GetString(6);
                    doctor.Cedula = reader.GetString(7);
                    doctor.Nombres = reader.GetString(8);
                    doctor.ApellidoPaterno = reader.GetString(9);
                    citaMedica.Doctor = doctor;
                    recepcionista.Cedula = reader.GetString(10);
                    citaMedica.Recepcionista = recepcionista;
                    citasMedicas.Add(citaMedica);
                    especialidad = new Especialidad();
                    doctor = new Doctor();
                    paciente = new Paciente();
                    citaMedica = new CitaMedica();
                    especialidad = new Especialidad();
                    recepcionista = new Recepcionista();
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
                foreach (var aux in citasMedicas)
                {
                    tbl.Rows.Add(aux.NumeroCita, aux.FechaCita, aux.Paciente.Cedula, aux.Paciente.Nombres, aux.Paciente.ApellidoPaterno, aux.Especialidad.NombreEspecialidad, aux.Descripcion, aux.Doctor.Nombres, aux.Doctor.ApellidoPaterno);
                }
                
            }
            dgvCitas.DataSource = tbl;
        }

        private void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCitas.SelectedRows.Count > 0)//Verifica que el usuario seleccione más de una fila
                {
                    citaMedica = new CitaMedica();
                    citaMedica.NumeroCita = Convert.ToInt32(dgvCitas.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Seleccione una fila correcta", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void llenarEspecialidades()
        {
            especialidad = new Especialidad();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblEspecialidad";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    especialidad.IdEspecialidad = reader.GetInt32(0);
                    especialidad.NombreEspecialidad = reader.GetString(1);
                    especialidad.Descripcion = reader.GetString(2);
                    especialidades.Add(especialidad);
                    especialidad = new Especialidad();
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
        }
        public void llenarDoctores()
        {
            doctor = new Doctor();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblDoctor";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    doctor.Cedula = reader.GetString(0);
                    doctor.Nombres = reader.GetString(1);
                    doctor.ApellidoPaterno = reader.GetString(2);
                    doctor.ApellidoMaterno = reader.GetString(3);
                    especialidad.IdEspecialidad = reader.GetInt32(13);
                    doctor.Especialidad = especialidad;
                    doctores.Add(doctor);
                    doctor = new Doctor();
                    especialidad = new Especialidad();
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro en eliminar la Cita agendada?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (administrador.eliminarCitaMedica(citaMedica.NumeroCita))
                        MessageBox.Show("Cita eliminada", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("La Cita no se pudo eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                citaMedica = citasMedicas.SingleOrDefault(aux => aux.NumeroCita == citaMedica.NumeroCita);
                citaMedica.Paciente = administrador.buscarPaciente(citaMedica.Paciente.Cedula);
                citaMedica.Doctor = administrador.buscarDoctor(citaMedica.Doctor.Cedula);
                citaMedica.Especialidad = administrador.buscarEspecialidadPorNombre(citaMedica.Especialidad.NombreEspecialidad);
                citaMedica.Recepcionista = administrador.buscarRecepcionista(citaMedica.Recepcionista.Cedula);
                FrmIngresarCita frmIngresarCita = new FrmIngresarCita();
                frmIngresarCita.asignarAdministrador(this.administrador);
                frmIngresarCita.llenarDoctores(this.doctores);
                frmIngresarCita.llenarEspecialidades(this.especialidades);
                frmIngresarCita.editar = true;
                frmIngresarCita.txtCedula.Text = citaMedica.Paciente.Cedula;
                frmIngresarCita.txtNombres.Text = citaMedica.Paciente.Nombres;
                frmIngresarCita.txtApellidoPaterno.Text = citaMedica.Paciente.ApellidoPaterno;
                frmIngresarCita.txtApellidoMaterno.Text = citaMedica.Paciente.ApellidoMaterno;
                frmIngresarCita.txtCorreo.Text = citaMedica.Paciente.CorreoElectronico;
                frmIngresarCita.cbxProvincia.Text = citaMedica.Paciente.Provincia;
                frmIngresarCita.txtCanton.Text = citaMedica.Paciente.Canton;
                frmIngresarCita.txtDireccion.Text = citaMedica.Paciente.Direccion;
                frmIngresarCita.txtTelefono.Text = citaMedica.Paciente.Telefono;
                frmIngresarCita.txtCedulaRecepcionista.Text = citaMedica.Recepcionista.Cedula;
                frmIngresarCita.txtNombresRecepcionista.Text = citaMedica.Recepcionista.Nombres;
                frmIngresarCita.txtApellidoPaternoRecepcionista.Text = citaMedica.Recepcionista.ApellidoPaterno;
                frmIngresarCita.txtNumeroCita.Text = Convert.ToString(citaMedica.NumeroCita);
                frmIngresarCita.dtpFechaCita.Value = citaMedica.FechaCita;
                frmIngresarCita.txtDescripcion.Text = citaMedica.Descripcion;
                frmIngresarCita.cbxEspecialidad.Text = citaMedica.Especialidad.NombreEspecialidad;
                frmIngresarCita.cbxDoctor.Text = citaMedica.Doctor.ApellidoPaterno;
                frmIngresarCita.txtCedula.Enabled = false;
                frmIngresarCita.txtCedulaRecepcionista.Enabled = false;
                frmIngresarCita.btnBuscar.Enabled = false;
                frmIngresarCita.btnBuscarRecepcionista.Enabled = false;
                frmIngresarCita.Show();
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para modificar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
