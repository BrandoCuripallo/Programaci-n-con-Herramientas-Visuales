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
namespace Login
{
    public partial class FrmRegistroHistoriaClinica : Form
    {
        Administrador administrador;
        HistoriaClinica historiaClinica;
        Paciente paciente;
        List<Atencion> atenciones = new List<Atencion>();
        List<HistoriaClinica> historiasClinicas = new List<HistoriaClinica>();
        public FrmRegistroHistoriaClinica()
        {
            InitializeComponent();
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
        }
        public void llenarHistoriasClinicas()
        {
            historiaClinica = new HistoriaClinica();
            paciente = new Paciente();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT numeroHistoria, tblPaciente.cedulaPaciente, nombres, apellidoPaterno, apellidoMaterno FROM tblHistoriaClinica INNER JOIN " + 
                "tblPaciente ON tblHistoriaClinica.cedulaPaciente = tblPaciente.cedulaPaciente";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    historiaClinica.NumeroHistoria = reader.GetInt32(0);
                    paciente.Cedula = reader.GetString(1);
                    paciente.Nombres = reader.GetString(2);
                    paciente.ApellidoPaterno = reader.GetString(3);
                    paciente.ApellidoMaterno = reader.GetString(4);
                    historiaClinica.Paciente = paciente;
                    historiasClinicas.Add(historiaClinica);
                    historiaClinica = new HistoriaClinica();
                    paciente = new Paciente();
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
        }
        public void llenarDataGridView()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Número de Historia Clínica");
            tbl.Columns.Add("Cédula del Paciente");
            tbl.Columns.Add("Nombres");
            tbl.Columns.Add("Apellido Paterno");
            tbl.Columns.Add("Apellido Materno");
            foreach (var aux in historiasClinicas)
            {
                tbl.Rows.Add(aux.NumeroHistoria, aux.Paciente.Cedula, aux.Paciente.Nombres, aux.Paciente.ApellidoPaterno, aux.Paciente.ApellidoMaterno);
            }
            dgvHistoriasClinicas.DataSource = tbl;
        }
        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmIngresarAtencion frmIngresarAtencion = new FrmIngresarAtencion();
                frmIngresarAtencion.asignarAdministrador(this.administrador);
                frmIngresarAtencion.asignarHistoriaClinica(this.historiaClinica);
                atenciones = administrador.buscarAtenciones(this.historiaClinica.NumeroHistoria);
                if (atenciones == null)
                    atenciones = new List<Atencion>();
                frmIngresarAtencion.llenarAtenciones(this.atenciones);
                frmIngresarAtencion.llenarDataGridView();
                frmIngresarAtencion.Show();
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para visualizar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvHistoriasClinicas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHistoriasClinicas.SelectedRows.Count > 0)
                {
                    historiaClinica = historiasClinicas.SingleOrDefault(aux => aux.NumeroHistoria == Convert.ToInt32(dgvHistoriasClinicas.Rows[e.RowIndex].Cells[0].Value.ToString()));
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
            }
        }
    }
}
