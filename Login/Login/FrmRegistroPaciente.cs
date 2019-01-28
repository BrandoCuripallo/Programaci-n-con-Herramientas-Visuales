using System;
using Login.Clases;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class FrmRegistroPaciente : Form
    {
        private Administrador administrador;
        private Paciente paciente;
        List<Paciente> pacientes = new List<Paciente>();
        public FrmRegistroPaciente()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmIngresarPaciente frmIngresarPaciente = new FrmIngresarPaciente();
            frmIngresarPaciente.asignarAdministrador(this.administrador);
            frmIngresarPaciente.Show();
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
        }
        public void llenarDataGridView()
        {
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
            tbl.Columns.Add("Contraseñia");
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblPaciente";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            paciente = new Paciente();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    paciente.Cedula = reader.GetString(0);
                    paciente.Nombres = reader.GetString(1);
                    paciente.ApellidoPaterno = reader.GetString(2);
                    paciente.ApellidoMaterno = reader.GetString(3);
                    paciente.setFechaNacimiento(reader.GetDateTime(4));
                    paciente.Sexo = reader.GetString(5);
                    paciente.CorreoElectronico = reader.GetString(6);
                    paciente.Provincia = reader.GetString(7);
                    paciente.Canton = reader.GetString(8);
                    paciente.Direccion = reader.GetString(9);
                    paciente.Telefono = reader.GetString(10);
                    paciente.ContraseniaPaciente = reader.GetString(11);
                    paciente.calcularEdad();
                    pacientes.Add(paciente);
                    paciente = new Paciente();
                }
                DataBase.cerrarConexion(conexion);
                foreach (var aux in pacientes)
                {
                    tbl.Rows.Add(aux.Cedula, aux.Nombres, aux.ApellidoPaterno, aux.ApellidoMaterno, aux.getFechaNacimiento(), aux.Edad, aux.Sexo, aux.CorreoElectronico, aux.Provincia, aux.Canton, aux.Direccion, aux.Telefono, aux.ContraseniaPaciente);
                }
            }
            dgvPacientes.DataSource = tbl;
        }

        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPacientes.SelectedRows.Count > 0)//Verifica que el usuario seleccione más de una fila
                {
                    paciente = new Paciente();
                    paciente.Cedula = dgvPacientes.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                paciente = administrador.buscarPaciente(paciente.Cedula);
                FrmIngresarPaciente frmIngresarPaciente = new FrmIngresarPaciente();
                frmIngresarPaciente.cedula = paciente.Cedula;
                frmIngresarPaciente.asignarAdministrador(this.administrador);
                frmIngresarPaciente.editar = true;
                frmIngresarPaciente.txtCedula.Text = paciente.Cedula;
                frmIngresarPaciente.txtNombres.Text = paciente.Nombres;
                frmIngresarPaciente.txtApellidoPaterno.Text = paciente.ApellidoPaterno;
                frmIngresarPaciente.txtApellidoMaterno.Text = paciente.ApellidoMaterno;
                frmIngresarPaciente.txtCorreo.Text = paciente.CorreoElectronico;
                frmIngresarPaciente.cbxProvincia.Text = paciente.Provincia;
                frmIngresarPaciente.txtCanton.Text = paciente.Canton;
                frmIngresarPaciente.txtDireccion.Text = paciente.Direccion;
                frmIngresarPaciente.txtTelefono.Text = paciente.Telefono;
                frmIngresarPaciente.txtContrasenia.Text = paciente.ContraseniaPaciente;
                frmIngresarPaciente.mcdFechaNacimiento.SetDate(Convert.ToDateTime(paciente.getFechaNacimiento()));
                if (paciente.Sexo == "Masculino")
                    frmIngresarPaciente.rdbMasculino.Checked = true;
                else
                    frmIngresarPaciente.rdbFemenino.Checked = true;
                frmIngresarPaciente.Show();
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para modificar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Al eliminar el paciente se eliminará junto con su historial.\n¿Está seguro en eliminar el paciente?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (administrador.eliminarPaciente(paciente.Cedula))
                        MessageBox.Show("Paciente eliminado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("El paciente no se pudo eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
