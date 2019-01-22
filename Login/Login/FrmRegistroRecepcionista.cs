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
    public partial class FrmRegistroRecepcionista : Form
    {
        private Administrador administrador;
        private Recepcionista recepcionista;
        List<Recepcionista> recepcionistas = new List<Recepcionista>();
        public FrmRegistroRecepcionista()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmIngresarRecepcionista frmIngresarRecepcionista = new FrmIngresarRecepcionista();
            frmIngresarRecepcionista.asignarAdministrador(this.administrador);
            frmIngresarRecepcionista.Show();
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
            string consulta = "SELECT * FROM tblRecepcionista";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            recepcionista = new Recepcionista();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    recepcionista.Cedula = reader.GetString(0);
                    recepcionista.Nombres = reader.GetString(1);
                    recepcionista.ApellidoPaterno = reader.GetString(2);
                    recepcionista.ApellidoMaterno = reader.GetString(3);
                    recepcionista.setFechaNacimiento(reader.GetDateTime(4));
                    recepcionista.Sexo = reader.GetString(5);
                    recepcionista.CorreoElectronico = reader.GetString(6);
                    recepcionista.Provincia = reader.GetString(7);
                    recepcionista.Canton = reader.GetString(8);
                    recepcionista.Direccion = reader.GetString(9);
                    recepcionista.Telefono = reader.GetString(10);
                    recepcionista.Usuario = reader.GetString(11);
                    recepcionista.Contrasenia = reader.GetString(12);
                    recepcionista.calcularEdad();
                    recepcionistas.Add(recepcionista);
                    recepcionista = new Recepcionista();
                }
                DataBase.cerrarConexion(conexion);
                foreach (var aux in recepcionistas)
                {
                    tbl.Rows.Add(aux.Cedula, aux.Nombres, aux.ApellidoPaterno, aux.ApellidoMaterno, aux.getFechaNacimiento(), aux.Edad, aux.Sexo, aux.CorreoElectronico, aux.Provincia, aux.Canton, aux.Direccion, aux.Telefono, aux.Usuario, aux.Contrasenia);
                }
            }
            dgvRecepcionistas.DataSource = tbl;
        }

        private void dgvRecepcionistas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvRecepcionistas.SelectedRows.Count > 0)//Verifica que el usuario seleccione más de una fila
                {
                    recepcionista= new Recepcionista();
                    recepcionista.Cedula = dgvRecepcionistas.Rows[e.RowIndex].Cells[0].Value.ToString();
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
                recepcionista = administrador.buscarRecepcionista(recepcionista.Cedula);
                FrmIngresarRecepcionista frmIngresarRecepcionista = new FrmIngresarRecepcionista();
                frmIngresarRecepcionista.cedula = recepcionista.Cedula;
                frmIngresarRecepcionista.asignarAdministrador(this.administrador);
                frmIngresarRecepcionista.editar = true;
                frmIngresarRecepcionista.txtCedula.Text = recepcionista.Cedula;
                frmIngresarRecepcionista.txtNombres.Text = recepcionista.Nombres;
                frmIngresarRecepcionista.txtApellidoPaterno.Text = recepcionista.ApellidoPaterno;
                frmIngresarRecepcionista.txtApellidoMaterno.Text = recepcionista.ApellidoMaterno;
                frmIngresarRecepcionista.txtCorreo.Text = recepcionista.CorreoElectronico;
                frmIngresarRecepcionista.cbxProvincia.Text = recepcionista.Provincia;
                frmIngresarRecepcionista.txtCanton.Text = recepcionista.Canton;
                frmIngresarRecepcionista.txtDireccion.Text = recepcionista.Direccion;
                frmIngresarRecepcionista.txtTelefono.Text = recepcionista.Telefono;
                frmIngresarRecepcionista.mcdFechaNacimiento.SetDate(Convert.ToDateTime(recepcionista.getFechaNacimiento()));
                frmIngresarRecepcionista.txtUsuario.Text = recepcionista.Usuario;
                frmIngresarRecepcionista.txtContrasenia.Text = recepcionista.Contrasenia;
                if (recepcionista.Sexo == "Masculino")
                    frmIngresarRecepcionista.rdbMasculino.Checked = true;
                else
                    frmIngresarRecepcionista.rdbFemenino.Checked = true;
                frmIngresarRecepcionista.Show();
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
                DialogResult resultado = MessageBox.Show("¿Está seguro en eliminar el recepcionista?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (administrador.eliminarRecepcionista(recepcionista.Cedula))
                        MessageBox.Show("Recepcionista eliminado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("El recepcionista no se pudo eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
