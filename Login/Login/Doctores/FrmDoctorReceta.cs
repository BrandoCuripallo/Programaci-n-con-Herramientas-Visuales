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
    public partial class FrmDoctorReceta : Form
    {
        Doctor doctor;
        Receta receta;
        Paciente paciente;
        Medicamento medicamento;
        List<Medicamento> medicamentos = new List<Medicamento>();
        public FrmDoctorReceta()
        {
            InitializeComponent();
        }
        public void asignarDoctor(Object doctor)
        {
            this.doctor = (Doctor)doctor;
        }
        public void llenarMedicamentos()
        {
            medicamento = new Medicamento();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblMedicamento";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    medicamento.CodigoMedicamento = reader.GetString(0);
                    medicamento.NombreMedicamento = reader.GetString(1);
                    medicamento.Descripcion = reader.GetString(2);
                    medicamento.Stock = reader.GetInt32(3);
                    medicamento.PrecioUnitario = Convert.ToDouble(Convert.ToString(reader.GetSqlMoney(4)));
                    medicamentos.Add(medicamento);
                    medicamento = new Medicamento();
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
        }
        public void llenarDataGridView()
        {
            DataTable tbl = doctor.buscarRecetas();
            dgvRecetas.DataSource = tbl;
        }

        private void dgvRecetas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvRecetas.SelectedRows.Count > 0)//Verifica que el usuario seleccione más de una fila
                {
                    receta = new Receta();
                    receta.IdReceta = Convert.ToInt32(dgvRecetas.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Seleccione una fila correcta", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro en eliminar la receta?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (doctor.eliminarReceta(receta.IdReceta))
                        MessageBox.Show("Receta eliminada", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("La Receta no se pudo eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDoctorIngresarReceta frmDoctorIngresarReceta = new FrmDoctorIngresarReceta();
            frmDoctorIngresarReceta.asignarDoctor(this.doctor);
            frmDoctorIngresarReceta.llenarMedicamentos(this.medicamentos);
            frmDoctorIngresarReceta.llenarDataGridView();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT TOP 1 idReceta FROM tblReceta ORDER BY idReceta DESC";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    frmDoctorIngresarReceta.txtNumeroReceta.Text = Convert.ToString(reader.GetInt32(0) + 1);
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
            else
                frmDoctorIngresarReceta.txtNumeroReceta.Text = "1";
            frmDoctorIngresarReceta.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                receta = doctor.buscarReceta(receta.IdReceta);
                paciente = doctor.buscarPaciente(receta.Paciente.Cedula);
                receta.Paciente = paciente;
                receta.Doctor = doctor;
                FrmDoctorIngresarReceta frmDoctorIngresarReceta = new FrmDoctorIngresarReceta();
                frmDoctorIngresarReceta.editar = true;
                frmDoctorIngresarReceta.asignarDoctor(this.doctor);
                frmDoctorIngresarReceta.llenarMedicamentos(this.medicamentos);
                frmDoctorIngresarReceta.llenarIndicaciones(receta.Indicaciones);
                frmDoctorIngresarReceta.txtCedula.Text = receta.Paciente.Cedula;
                frmDoctorIngresarReceta.txtNombres.Text = receta.Paciente.Nombres;
                frmDoctorIngresarReceta.txtApellidoPaterno.Text = receta.Paciente.ApellidoPaterno;
                frmDoctorIngresarReceta.txtApellidoMaterno.Text = receta.Paciente.ApellidoMaterno;
                frmDoctorIngresarReceta.txtCorreo.Text = receta.Paciente.CorreoElectronico;
                frmDoctorIngresarReceta.txtDireccion.Text = receta.Paciente.Direccion;
                frmDoctorIngresarReceta.txtTelefono.Text = receta.Paciente.Telefono;
                frmDoctorIngresarReceta.txtNumeroReceta.Text = Convert.ToString(receta.IdReceta);
                frmDoctorIngresarReceta.dtpFechaEmision.Value = receta.FechaEmision;
                frmDoctorIngresarReceta.llenarDataGridView();
                frmDoctorIngresarReceta.txtCedula.Enabled = false;
                frmDoctorIngresarReceta.btnBuscar.Enabled = false;
                frmDoctorIngresarReceta.Show();
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para modificar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
