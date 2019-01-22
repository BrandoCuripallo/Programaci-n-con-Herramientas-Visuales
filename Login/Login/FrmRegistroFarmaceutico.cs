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
    public partial class FrmRegistroFarmaceutico : Form
    {
        private Administrador administrador;
        private Farmaceutico farmaceutico;
        List<Farmaceutico> farmaceuticos = new List<Farmaceutico>();
        public FrmRegistroFarmaceutico()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmIngresarFarmaceutico frmIngresarFarmaceutico = new FrmIngresarFarmaceutico();
            frmIngresarFarmaceutico.asignarAdministrador(this.administrador);
            frmIngresarFarmaceutico.Show();
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
            tbl.Columns.Add("Usuario");
            tbl.Columns.Add("Contraseñia");
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblFarmaceutico";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            farmaceutico = new Farmaceutico();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    farmaceutico.Cedula = reader.GetString(0);
                    farmaceutico.Nombres = reader.GetString(1);
                    farmaceutico.ApellidoPaterno = reader.GetString(2);
                    farmaceutico.ApellidoMaterno = reader.GetString(3);
                    farmaceutico.setFechaNacimiento(reader.GetDateTime(4));
                    farmaceutico.Sexo = reader.GetString(5);
                    farmaceutico.CorreoElectronico = reader.GetString(6);
                    farmaceutico.Provincia = reader.GetString(7);
                    farmaceutico.Canton = reader.GetString(8);
                    farmaceutico.Direccion = reader.GetString(9);
                    farmaceutico.Telefono = reader.GetString(10);
                    farmaceutico.Usuario = reader.GetString(11);
                    farmaceutico.Contrasenia = reader.GetString(12);
                    farmaceutico.calcularEdad();
                    farmaceuticos.Add(farmaceutico);
                    farmaceutico = new Farmaceutico();
                }
                DataBase.cerrarConexion(conexion);
                foreach (var aux in farmaceuticos)
                {
                    tbl.Rows.Add(aux.Cedula, aux.Nombres, aux.ApellidoPaterno, aux.ApellidoMaterno, aux.getFechaNacimiento(), aux.Edad, aux.Sexo, aux.CorreoElectronico, aux.Provincia, aux.Canton, aux.Direccion, aux.Telefono, aux.Usuario, aux.Contrasenia);
                }
            }
            dgvFarmaceuticos.DataSource = tbl;
        }

        private void dgvFarmaceuticos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvFarmaceuticos.SelectedRows.Count > 0)//Verifica que el usuario seleccione más de una fila
                {
                    farmaceutico = new Farmaceutico();
                    farmaceutico.Cedula = dgvFarmaceuticos.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Seleccione una fila correcta", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                farmaceutico = administrador.buscarFarmaceutico(farmaceutico.Cedula);
                FrmIngresarFarmaceutico frmIngresarFarmaceutico = new FrmIngresarFarmaceutico();
                frmIngresarFarmaceutico.cedula = farmaceutico.Cedula;
                frmIngresarFarmaceutico.asignarAdministrador(this.administrador);
                frmIngresarFarmaceutico.editar = true;
                frmIngresarFarmaceutico.txtCedula.Text = farmaceutico.Cedula;
                frmIngresarFarmaceutico.txtNombres.Text = farmaceutico.Nombres;
                frmIngresarFarmaceutico.txtApellidoPaterno.Text = farmaceutico.ApellidoPaterno;
                frmIngresarFarmaceutico.txtApellidoMaterno.Text = farmaceutico.ApellidoMaterno;
                frmIngresarFarmaceutico.txtCorreo.Text = farmaceutico.CorreoElectronico;
                frmIngresarFarmaceutico.cbxProvincia.Text = farmaceutico.Provincia;
                frmIngresarFarmaceutico.txtCanton.Text = farmaceutico.Canton;
                frmIngresarFarmaceutico.txtDireccion.Text = farmaceutico.Direccion;
                frmIngresarFarmaceutico.txtTelefono.Text = farmaceutico.Telefono;
                frmIngresarFarmaceutico.mcdFechaNacimiento.SetDate(Convert.ToDateTime(farmaceutico.getFechaNacimiento()));
                frmIngresarFarmaceutico.txtUsuario.Text = farmaceutico.Usuario;
                frmIngresarFarmaceutico.txtContrasenia.Text = farmaceutico.Contrasenia;
                if (farmaceutico.Sexo == "Masculino")
                    frmIngresarFarmaceutico.rdbMasculino.Checked = true;
                else
                    frmIngresarFarmaceutico.rdbFemenino.Checked = true;
                frmIngresarFarmaceutico.Show();
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
                DialogResult resultado = MessageBox.Show("¿Está seguro en eliminar el farmaceútico?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (administrador.eliminarFarmaceutico(farmaceutico.Cedula))
                        MessageBox.Show("Farmaceútico eliminado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("El farmaceútico no se pudo eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
