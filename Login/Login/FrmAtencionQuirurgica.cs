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
    public partial class FrmAtencionQuirurgica : Form
    {
        Administrador administrador;
        Doctor doctor;
        AtencionQuirurgica atencionQuirurgica;
        Paciente paciente;
        Cirugia cirugia;
        List<Doctor> doctores = new List<Doctor>();
        List<AtencionQuirurgica> atencionesQuirurgicas = new List<AtencionQuirurgica>();
        List<Cirugia> cirugias = new List<Cirugia>();
        public FrmAtencionQuirurgica()
        {
            InitializeComponent();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmIngresarOperacion frmIngresarOperacion = new FrmIngresarOperacion();
            frmIngresarOperacion.asignarAdministrador(this.administrador);
            frmIngresarOperacion.llenarDoctores(this.doctores);
            frmIngresarOperacion.llenarCirugias(this.cirugias);
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT TOP 1 idCirugiaPaciente FROM tblCirugiaPaciente ORDER BY idCirugiaPaciente DESC";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    frmIngresarOperacion.txtNumeroCirugia.Text = Convert.ToString(reader.GetInt32(0) + 1);
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
            else
                frmIngresarOperacion.txtNumeroCirugia.Text = "1";
            frmIngresarOperacion.Show();
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
        }
        public void llenarDataGridView()
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT idCirugiaPaciente, fecha, tblCirugiaPaciente.cedulaPaciente, tblPaciente.nombres, tblPaciente.apellidoPaterno, tblCirugia.nombreCirugia, " +
                "tblCirugiaPaciente.descripcion, tblDoctor.cedulaDoctor, tblDoctor.nombres, tblDoctor.apellidoPaterno FROM tblCirugiaPaciente INNER JOIN " +
                "tblPaciente ON tblCirugiaPaciente.cedulaPaciente = tblPaciente.cedulaPaciente " + "INNER JOIN tblCirugia ON tblCirugia.idCirugia = tblCirugiaPaciente.idCirugia " +
                "INNER JOIN tblDoctor ON tblCirugiaPaciente.cedulaDoctor = tblDoctor.cedulaDoctor";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Número de Cirugía");
            tbl.Columns.Add("Fecha de la Cirugía");
            tbl.Columns.Add("Cédula del Paciente");
            tbl.Columns.Add("Nombres");
            tbl.Columns.Add("Apellido Paterno");
            tbl.Columns.Add("Tipo de Cirugía");
            tbl.Columns.Add("Motivo de la Cirugía");
            tbl.Columns.Add("Nombre del Doctor");
            tbl.Columns.Add("Apellido");
            cirugia = new Cirugia();
            doctor = new Doctor();
            paciente = new Paciente();
            atencionQuirurgica = new AtencionQuirurgica();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    atencionQuirurgica.IdAtencionQuirurgica = reader.GetInt32(0);
                    atencionQuirurgica.FechaCirugia = reader.GetDateTime(1);
                    paciente.Cedula = reader.GetString(2);
                    paciente.Nombres = reader.GetString(3);
                    paciente.ApellidoPaterno = reader.GetString(4);
                    atencionQuirurgica.Paciente = paciente;
                    cirugia.NombreCirugia = reader.GetString(5);
                    atencionQuirurgica.Cirugia = cirugia;
                    atencionQuirurgica.Descripcion = reader.GetString(6);
                    doctor.Cedula = reader.GetString(7);
                    doctor.Nombres = reader.GetString(8);
                    doctor.ApellidoPaterno = reader.GetString(9);
                    atencionQuirurgica.Doctor = doctor;
                    atencionesQuirurgicas.Add(atencionQuirurgica);
                    cirugia = new Cirugia();
                    doctor = new Doctor();
                    paciente = new Paciente();
                    atencionQuirurgica = new AtencionQuirurgica();
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
                foreach (var aux in atencionesQuirurgicas)
                {
                    tbl.Rows.Add(aux.IdAtencionQuirurgica, aux.FechaCirugia, aux.Paciente.Cedula, aux.Paciente.Nombres, aux.Paciente.ApellidoPaterno, aux.Cirugia.NombreCirugia, aux.Descripcion, aux.Doctor.Nombres, aux.Doctor.ApellidoPaterno);
                }

            }
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
                    doctores.Add(doctor);
                    doctor = new Doctor();
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro en eliminar la Cirugía agendada?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (administrador.eliminarOperacionQuirurgica(atencionQuirurgica.IdAtencionQuirurgica))
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
                atencionQuirurgica = atencionesQuirurgicas.SingleOrDefault(aux => aux.IdAtencionQuirurgica == atencionQuirurgica.IdAtencionQuirurgica);
                atencionQuirurgica.Paciente = administrador.buscarPaciente(atencionQuirurgica.Paciente.Cedula);
                atencionQuirurgica.Doctor = administrador.buscarDoctor(atencionQuirurgica.Doctor.Cedula);
                atencionQuirurgica.Cirugia = administrador.buscarCirugiaPorNombre(atencionQuirurgica.Cirugia.NombreCirugia);
                FrmIngresarOperacion frmIngresarOperacion = new FrmIngresarOperacion();
                frmIngresarOperacion.asignarAdministrador(this.administrador);
                frmIngresarOperacion.llenarDoctores(this.doctores);
                frmIngresarOperacion.llenarCirugias(this.cirugias);
                frmIngresarOperacion.editar = true;
                frmIngresarOperacion.txtCedula.Text = atencionQuirurgica.Paciente.Cedula;
                frmIngresarOperacion.txtNombres.Text = atencionQuirurgica.Paciente.Nombres;
                frmIngresarOperacion.txtApellidoPaterno.Text = atencionQuirurgica.Paciente.ApellidoPaterno;
                frmIngresarOperacion.txtApellidoMaterno.Text = atencionQuirurgica.Paciente.ApellidoMaterno;
                frmIngresarOperacion.txtNumeroCirugia.Text = Convert.ToString(atencionQuirurgica.IdAtencionQuirurgica);
                frmIngresarOperacion.dtpFechaCirugia.Value = atencionQuirurgica.FechaCirugia;
                frmIngresarOperacion.txtDescripcion.Text = atencionQuirurgica.Descripcion;
                frmIngresarOperacion.cbxCirugia.Text = atencionQuirurgica.Cirugia.NombreCirugia;
                frmIngresarOperacion.cbxDoctor.Text = atencionQuirurgica.Doctor.ApellidoPaterno;
                frmIngresarOperacion.txtCedula.Enabled = false;
                frmIngresarOperacion.btnBuscar.Enabled = false;
                frmIngresarOperacion.Show();
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para modificar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
