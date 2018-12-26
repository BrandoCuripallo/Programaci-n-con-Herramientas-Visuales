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
    public partial class FrmRegistroDoctor : Form
    {
        private Administrador administrador;
        private Doctor doctor;
        Especialidad especialidad;
        List<Doctor> doctores = new List<Doctor>();
        List<Especialidad> especialidades = new List<Especialidad>();
        public FrmRegistroDoctor()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmIngresarDoctor frmIngresarDoctor = new FrmIngresarDoctor();
            frmIngresarDoctor.asignarAdministrador(this.administrador);
            frmIngresarDoctor.llenarEspecialidades(this.especialidades);
            frmIngresarDoctor.Show();
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
        }
        public void llenarDataGridView()
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblDoctor LEFT JOIN tblEspecialidad ON tblDoctor.codigoEspecialidad = tblEspecialidad.codigoEspecialidad";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            doctor = new Doctor();
            especialidad = new Especialidad();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    doctor.Cedula = reader.GetString(0);
                    doctor.Nombres = reader.GetString(1);
                    doctor.ApellidoPaterno = reader.GetString(2);
                    doctor.ApellidoMaterno = reader.GetString(3);
                    doctor.setFechaNacimiento(reader.GetDateTime(4));
                    doctor.Sexo = reader.GetString(5);
                    doctor.CorreoElectronico = reader.GetString(6);
                    doctor.Provincia = reader.GetString(7);
                    doctor.Canton = reader.GetString(8);
                    doctor.Direccion = reader.GetString(9);
                    doctor.Telefono = reader.GetString(10);
                    doctor.UsuarioDoctor = reader.GetString(11);
                    doctor.ContraseniaDoctor = reader.GetString(12);
                    especialidad.IdEspecialidad = reader.GetInt32(13);
                    especialidad.NombreEspecialidad = reader.GetString(15);
                    especialidad.Descripcion = reader.GetString(16);
                    doctor.Especialidad = especialidad;
                    doctor.calcularEdad();
                    doctores.Add(doctor);
                    doctor = new Doctor();
                    especialidad = new Especialidad();
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
                DataTable tbl = new DataTable();
                tbl.Columns.Add("Cédula");
                tbl.Columns.Add("Nombres");
                tbl.Columns.Add("Apellido Paterno");
                tbl.Columns.Add("Apellido Materno");
                tbl.Columns.Add("Fecha de Nacimiento");
                tbl.Columns.Add("Edad");
                tbl.Columns.Add("Sexo");
                tbl.Columns.Add("Correo Electrónico");
                tbl.Columns.Add("Provincia");
                tbl.Columns.Add("Ciudad");
                tbl.Columns.Add("Dirección");
                tbl.Columns.Add("Teléfono");
                tbl.Columns.Add("Usuario");
                tbl.Columns.Add("Contraseñia");
                tbl.Columns.Add("Especialidad");
                foreach (var aux in doctores)
                {
                    tbl.Rows.Add(aux.Cedula, aux.Nombres, aux.ApellidoPaterno, aux.ApellidoMaterno, aux.getFechaNacimiento(), aux.Edad, aux.Sexo, aux.CorreoElectronico, aux.Provincia, aux.Canton, aux.Direccion, aux.Telefono, aux.UsuarioDoctor, aux.ContraseniaDoctor, aux.Especialidad.NombreEspecialidad);
                }
                dgvDoctores.DataSource = tbl;
            }
        }

        private void dgvDoctores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDoctores.SelectedRows.Count > 0)//Verifica que el usuario seleccione más de una fila
                {
                    doctor = new Doctor();
                    doctor.Cedula = dgvDoctores.Rows[e.RowIndex].Cells[0].Value.ToString();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro en eliminar el doctor?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                if (administrador.eliminarDoctor(doctor.Cedula))
                    MessageBox.Show("Doctor eliminado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("El doctor no se pudo eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            doctor = administrador.buscarDoctor(doctor.Cedula);
            FrmIngresarDoctor frmIngresarDoctor = new FrmIngresarDoctor();
            frmIngresarDoctor.cedula = doctor.Cedula;
            frmIngresarDoctor.asignarAdministrador(this.administrador);
            frmIngresarDoctor.editar = true;
            frmIngresarDoctor.txtCedula.Text = doctor.Cedula;
            frmIngresarDoctor.txtNombres.Text = doctor.Nombres;
            frmIngresarDoctor.txtApellidoPaterno.Text = doctor.ApellidoPaterno;
            frmIngresarDoctor.txtApellidoMaterno.Text = doctor.ApellidoMaterno;
            frmIngresarDoctor.txtCorreo.Text = doctor.CorreoElectronico;
            frmIngresarDoctor.cbxProvincia.Text = doctor.Provincia;
            frmIngresarDoctor.txtCanton.Text = doctor.Canton;
            frmIngresarDoctor.txtDireccion.Text = doctor.Direccion;
            frmIngresarDoctor.txtTelefono.Text = doctor.Telefono;
            frmIngresarDoctor.mcdFechaNacimiento.SetDate(Convert.ToDateTime(doctor.getFechaNacimiento()));
            frmIngresarDoctor.txtUsuario.Text = doctor.UsuarioDoctor;
            frmIngresarDoctor.txtContrasenia.Text = doctor.ContraseniaDoctor;
            frmIngresarDoctor.llenarEspecialidades(this.especialidades);
            frmIngresarDoctor.cbxEspecialidad.Text = doctor.Especialidad.NombreEspecialidad;
            if (doctor.Sexo == "Masculino")
                frmIngresarDoctor.rdbMasculino.Checked = true;
            else
                frmIngresarDoctor.rdbFemenino.Checked = true;
            frmIngresarDoctor.Show();
        }
    }
}
