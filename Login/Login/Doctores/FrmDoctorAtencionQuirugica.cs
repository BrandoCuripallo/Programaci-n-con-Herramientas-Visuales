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
namespace Login.Doctores
{
    public partial class FrmDoctorAtencionQuirugica : Form
    {
        Doctor doctor;
        Doctor doc;
        AtencionQuirurgica atencionQuirurgica;
        Cirugia cirugia;
        List<Cirugia> cirugias = new List<Cirugia>();
        List<Doctor> doctores = new List<Doctor>();
        public FrmDoctorAtencionQuirugica()
        {
            InitializeComponent();
        }
        public void asignarDoctor(Object doctor)
        {
            this.doctor = (Doctor)doctor;
        }
        public void llenarDataGridView()
        {
            DataTable tbl = doctor.buscarCirugias();
            dgvOperacionesQuirurgicas.DataSource = tbl;
        }
        private void dgvOperacionesQuirurgicas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvOperacionesQuirurgicas.SelectedRows.Count > 0)//Verifica que el usuario seleccione más de una fila
                {
                    atencionQuirurgica = new AtencionQuirurgica();
                    atencionQuirurgica.IdAtencionQuirurgica = Convert.ToInt32(dgvOperacionesQuirurgicas.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
            }
        }
        public void llenarCirugias()
        {
            cirugia = new Cirugia();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblCirugia";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cirugia.IdCirugia = reader.GetInt32(0);
                    cirugia.NombreCirugia = reader.GetString(1);
                    cirugias.Add(cirugia);
                    cirugia = new Cirugia();
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
        }
        public void llenarDoctores()
        {
            doc = new Doctor();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblDoctor";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    doc.Cedula = reader.GetString(0);
                    doc.Nombres = reader.GetString(1);
                    doc.ApellidoPaterno = reader.GetString(2);
                    doc.ApellidoMaterno = reader.GetString(3);
                    doctores.Add(doc);
                    doc = new Doctor();
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDoctorIngresarOperacion frmDoctorIngresarOperacion = new FrmDoctorIngresarOperacion();
            frmDoctorIngresarOperacion.asignarDoctor(this.doctor);
            frmDoctorIngresarOperacion.llenarDoctores(this.doctores);
            frmDoctorIngresarOperacion.llenarCirugias(this.cirugias);
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT TOP 1 idCirugiaPaciente FROM tblCirugiaPaciente ORDER BY idCirugiaPaciente DESC";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    frmDoctorIngresarOperacion.txtNumeroCirugia.Text = Convert.ToString(reader.GetInt32(0) + 1);
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
            else
                frmDoctorIngresarOperacion.txtNumeroCirugia.Text = "1";
            frmDoctorIngresarOperacion.Show();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro en eliminar la Cirugía agendada?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (doctor.eliminarOperacionQuirurgica(atencionQuirurgica.IdAtencionQuirurgica))
                        MessageBox.Show("Cirugía eliminada", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("La Cirugía no se pudo eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                atencionQuirurgica = doctor.buscarOperacionQuirurgica(atencionQuirurgica.IdAtencionQuirurgica);
                atencionQuirurgica.Paciente = doctor.buscarPaciente(atencionQuirurgica.Paciente.Cedula);
                atencionQuirurgica.Doctor = doctor.buscarDoctor(atencionQuirurgica.Doctor.Cedula);
                atencionQuirurgica.Cirugia = doctor.buscarCirugiaPorNombre(atencionQuirurgica.Cirugia.NombreCirugia);
                FrmDoctorIngresarOperacion frmDoctorIngresarOperacion = new FrmDoctorIngresarOperacion();
                frmDoctorIngresarOperacion.asignarDoctor(this.doctor);
                frmDoctorIngresarOperacion.llenarDoctores(this.doctores);
                frmDoctorIngresarOperacion.llenarCirugias(this.cirugias);
                frmDoctorIngresarOperacion.editar = true;
                frmDoctorIngresarOperacion.txtCedula.Text = atencionQuirurgica.Paciente.Cedula;
                frmDoctorIngresarOperacion.txtNombres.Text = atencionQuirurgica.Paciente.Nombres;
                frmDoctorIngresarOperacion.txtApellidoPaterno.Text = atencionQuirurgica.Paciente.ApellidoPaterno;
                frmDoctorIngresarOperacion.txtApellidoMaterno.Text = atencionQuirurgica.Paciente.ApellidoMaterno;
                frmDoctorIngresarOperacion.txtNumeroCirugia.Text = Convert.ToString(atencionQuirurgica.IdAtencionQuirurgica);
                frmDoctorIngresarOperacion.dtpFechaCirugia.Value = atencionQuirurgica.FechaCirugia;
                frmDoctorIngresarOperacion.txtDescripcion.Text = atencionQuirurgica.Descripcion;
                frmDoctorIngresarOperacion.cbxCirugia.Text = atencionQuirurgica.Cirugia.NombreCirugia;
                frmDoctorIngresarOperacion.cbxDoctor.Text = atencionQuirurgica.Doctor.ApellidoPaterno;
                frmDoctorIngresarOperacion.txtCedula.Enabled = false;
                frmDoctorIngresarOperacion.btnBuscar.Enabled = false;
                frmDoctorIngresarOperacion.Show();
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para modificar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
