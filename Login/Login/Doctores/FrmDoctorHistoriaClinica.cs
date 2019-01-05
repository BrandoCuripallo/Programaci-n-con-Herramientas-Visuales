using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Login.Clases;
namespace Login.Doctores
{
    public partial class FrmDoctorHistoriaClinica : Form
    {
        Doctor doctor;
        HistoriaClinica historiaClinica;
        Paciente paciente = new Paciente();
        List<Atencion> atenciones = new List<Atencion>();
        public FrmDoctorHistoriaClinica()
        {
            InitializeComponent();
        }
        public void asignarDoctor(Object doctor)
        {
            this.doctor = (Doctor)doctor;
        }
        public void llenarDataGridView()
        {
            DataTable tbl = doctor.buscarHistoriasClinicas();
            dgvHistoriasClinicas.DataSource = tbl;
        }

        private void dgvHistoriasClinicas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHistoriasClinicas.SelectedRows.Count > 0)
                {
                    historiaClinica = new HistoriaClinica();
                    historiaClinica.NumeroHistoria = Convert.ToInt32(dgvHistoriasClinicas.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Seleccione una fila correcta", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = DataBase.obtenerConexion();
                string consulta = "SELECT numeroHistoria, tblPaciente.cedulaPaciente, nombres, apellidoPaterno, apellidoMaterno FROM tblHistoriaClinica INNER JOIN " +
                    "tblPaciente ON tblHistoriaClinica.cedulaPaciente = tblPaciente.cedulaPaciente WHERE numeroHistoria = " + historiaClinica.NumeroHistoria;
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        paciente.Cedula = reader.GetString(1);
                        paciente.Nombres = reader.GetString(2);
                        paciente.ApellidoPaterno = reader.GetString(3);
                        paciente.ApellidoMaterno = reader.GetString(4);
                        historiaClinica.Paciente = paciente;
                    }
                    reader.Close();
                    DataBase.cerrarConexion(conexion);
                }
                historiaClinica.Paciente = paciente;
                FrmDoctorIngresarAtencion frmDoctorIngresarAtencion = new FrmDoctorIngresarAtencion();
                frmDoctorIngresarAtencion.asignarDoctor(this.doctor);
                frmDoctorIngresarAtencion.asignarHistoriaClinica(this.historiaClinica);
                atenciones = doctor.buscarAtenciones(historiaClinica.NumeroHistoria);
                if (atenciones == null)
                    atenciones = new List<Atencion>();
                frmDoctorIngresarAtencion.llenarAtenciones(this.atenciones);
                frmDoctorIngresarAtencion.llenarDataGridView();
                frmDoctorIngresarAtencion.Show();
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para visualizar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
