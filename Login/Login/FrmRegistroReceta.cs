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
    public partial class FrmRegistroReceta : Form
    {
        Administrador administrador;
        Doctor doctor;
        Paciente paciente;
        Medicamento medicamento;
        Receta receta;
        List<Receta> recetas = new List<Receta>();
        List<Medicamento> medicamentos = new List<Medicamento>();
        public FrmRegistroReceta()
        {
            InitializeComponent();
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmIngresarReceta frmIngresarReceta = new FrmIngresarReceta();
            frmIngresarReceta.asignarAdministrador(this.administrador);
            frmIngresarReceta.llenarMedicamentos(this.medicamentos);
            frmIngresarReceta.llenarDataGridView();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT TOP 1 idReceta FROM tblReceta ORDER BY idReceta DESC";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    frmIngresarReceta.txtNumeroReceta.Text = Convert.ToString(reader.GetInt32(0) + 1);
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
            else
                frmIngresarReceta.txtNumeroReceta.Text = "1";
            frmIngresarReceta.Show();
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
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Número de Receta");
            tbl.Columns.Add("Fecha de Emisión");
            tbl.Columns.Add("Cédula del Paciente");
            tbl.Columns.Add("Nombres");
            tbl.Columns.Add("Apellido");
            tbl.Columns.Add("Cédula del Doctor");
            tbl.Columns.Add("Nombre del Doctor");
            tbl.Columns.Add("Apellido del Doctor");
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT idReceta, fechaEmision, tblReceta.cedulaPaciente, tblPaciente.nombres, tblPaciente.apellidoPaterno,  tblReceta.cedulaDoctor, " + 
                "tblDoctor.nombres, tblDoctor.apellidoPaterno FROM tblReceta INNER JOIN tblPaciente ON tblReceta.cedulaPaciente = tblPaciente.cedulaPaciente " + 
                "INNER JOIN tblDoctor ON tblDoctor.cedulaDoctor = tblReceta.cedulaDoctor";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            receta = new Receta();
            doctor = new Doctor();
            paciente = new Paciente();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    receta.IdReceta = reader.GetInt32(0);
                    receta.FechaEmision = reader.GetDateTime(1);
                    paciente.Cedula = reader.GetString(2);
                    paciente.Nombres = reader.GetString(3);
                    paciente.ApellidoPaterno = reader.GetString(4);
                    receta.Paciente = paciente;
                    doctor.Cedula = reader.GetString(5);
                    doctor.Nombres = reader.GetString(6);
                    doctor.ApellidoPaterno = reader.GetString(7);
                    receta.Doctor = doctor;
                    recetas.Add(receta);
                    receta = new Receta();
                    doctor = new Doctor();
                    paciente = new Paciente();
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
                foreach (var aux in recetas)
                {
                    tbl.Rows.Add(aux.IdReceta, aux.FechaEmision.ToString("dd/MM/yy"), aux.Paciente.Cedula, aux.Paciente.Nombres, aux.Paciente.ApellidoPaterno, aux.Doctor.Cedula, aux.Doctor.Nombres, aux.Doctor.ApellidoPaterno);
                }
            }
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
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro en eliminar la receta?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (administrador.eliminarReceta(receta.IdReceta))
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                receta = administrador.buscarReceta(receta.IdReceta);
                paciente = administrador.buscarPaciente(receta.Paciente.Cedula);
                receta.Paciente = paciente;
                doctor = administrador.buscarDoctor(receta.Doctor.Cedula);
                receta.Doctor = doctor;
                FrmIngresarReceta frmIngresarReceta = new FrmIngresarReceta();
                frmIngresarReceta.editar = true;
                frmIngresarReceta.asignarAdministrador(this.administrador);
                frmIngresarReceta.llenarMedicamentos(this.medicamentos);
                frmIngresarReceta.llenarIndicaciones(receta.Indicaciones);
                frmIngresarReceta.txtCedula.Text = receta.Paciente.Cedula;
                frmIngresarReceta.txtNombres.Text = receta.Paciente.Nombres;
                frmIngresarReceta.txtApellidoPaterno.Text = receta.Paciente.ApellidoPaterno;
                frmIngresarReceta.txtApellidoMaterno.Text = receta.Paciente.ApellidoMaterno;
                frmIngresarReceta.txtCorreo.Text = receta.Paciente.CorreoElectronico;
                frmIngresarReceta.txtDireccion.Text = receta.Paciente.Direccion;
                frmIngresarReceta.txtTelefono.Text = receta.Paciente.Telefono;
                frmIngresarReceta.txtCedulaDoctor.Text = receta.Doctor.Cedula;
                frmIngresarReceta.txtNombresDoctor.Text = receta.Doctor.Nombres;
                frmIngresarReceta.txtApellidoPaternoDoctor.Text = receta.Doctor.ApellidoPaterno;
                frmIngresarReceta.txtNumeroReceta.Text = Convert.ToString(receta.IdReceta);
                frmIngresarReceta.dtpFechaEmision.Value = receta.FechaEmision;
                frmIngresarReceta.llenarDataGridView();
                frmIngresarReceta.txtCedula.Enabled = false;
                frmIngresarReceta.txtCedulaDoctor.Enabled = false;
                frmIngresarReceta.btnBuscar.Enabled = false;
                frmIngresarReceta.btnBuscarDoctor.Enabled = false;
                frmIngresarReceta.Show();
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para modificar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
