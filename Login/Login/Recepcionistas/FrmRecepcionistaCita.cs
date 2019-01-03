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
namespace Login.Recepcionistas
{
    public partial class FrmRecepcionistaCita : Form
    {
        Recepcionista recepcionista;
        Doctor doctor;
        Especialidad especialidad;
        CitaMedica citaMedica;
        List<Doctor> doctores = new List<Doctor>();
        List<Especialidad> especialidades = new List<Especialidad>();
        public FrmRecepcionistaCita()
        {
            InitializeComponent();
        }
        public void asignarRecepcionista(Object recepcionista)
        {
            this.recepcionista = (Recepcionista)recepcionista;
        }
        public void llenarDataGridView()
        {
            DataTable tbl = recepcionista.buscarCitas();
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmRecepcionistaIngresarCita frmRecepcionistaIngresarCita = new FrmRecepcionistaIngresarCita();
            frmRecepcionistaIngresarCita.asignarRecepcionista(this.recepcionista);
            frmRecepcionistaIngresarCita.llenarEspecialidades(this.especialidades);
            frmRecepcionistaIngresarCita.llenarDoctores(this.doctores);
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT TOP 1 idCita FROM tblCitaMedica ORDER BY idCita DESC";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    frmRecepcionistaIngresarCita.txtNumeroCita.Text = Convert.ToString(reader.GetInt32(0) + 1);
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
            else
                frmRecepcionistaIngresarCita.txtNumeroCita.Text = "1";
            frmRecepcionistaIngresarCita.Show();
        }
    }
}
