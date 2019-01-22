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
    public partial class FrmRegistroCirugia : Form
    {
        private Administrador administrador;
        private Cirugia cirugia;
        private List<Cirugia> cirugias = new List<Cirugia>();
        public FrmRegistroCirugia()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarTextos();
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = true;
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
        }
        public void llenarDataGridView()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Código");
            tbl.Columns.Add("Nombre");
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblCirugia";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            cirugia = new Cirugia();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cirugia.IdCirugia = reader.GetInt32(0);
                    cirugia.NombreCirugia = reader.GetString(1);
                    cirugias.Add(cirugia);
                    cirugia = new Cirugia();
                }
                DataBase.cerrarConexion(conexion);
                foreach (var aux in cirugias)
                {
                    tbl.Rows.Add(aux.IdCirugia, aux.NombreCirugia);
                }
            }
            dgvCirugias.DataSource = tbl;
        }
        private void FrmRegistroCirugia_Load(object sender, EventArgs e)
        {

        }

        private void dgvCirugias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCirugias.SelectedRows.Count > 0)//Verifica que el usuario seleccione más de una fila
                {
                    cirugia = new Cirugia();
                    cirugia.IdCirugia = Convert.ToInt32(dgvCirugias.Rows[e.RowIndex].Cells[0].Value.ToString());
                    cirugia.NombreCirugia = dgvCirugias.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtNombre.Text = cirugia.NombreCirugia;
                    btnActualizar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnGuardar.Enabled = false;
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Seleccione una fila correcta", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void limpiarTextos()
        {
            txtNombre.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                try
                {
                    cirugia = new Cirugia(0, txtNombre.Text);
                    if (administrador.ingresarCirugia(cirugia))
                    {
                        MessageBox.Show("Cirugía ingresada con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarTextos();
                    }
                    else
                        MessageBox.Show("La cirugía ya se encuentra registrada", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch
                {
                    MessageBox.Show("Error de ingreso de datos", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("El campo Nombre no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro en eliminar la cirugía?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                if (administrador.eliminarCirugia(cirugia.IdCirugia))
                {
                    MessageBox.Show("Cirugía eliminada", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnActualizar.Enabled = false;
                    btnEliminar.Enabled = false;
                    limpiarTextos();
                }
                else
                    MessageBox.Show("La cirugía no se pudo eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                DialogResult resultado = MessageBox.Show("¿Desea actualizar la cirugía?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        cirugia.NombreCirugia = txtNombre.Text;
                        if (administrador.modificarCirugia(cirugia))
                        {
                            MessageBox.Show("Cirugía modificada con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnActualizar.Enabled = false;
                            btnEliminar.Enabled = false;
                            limpiarTextos();
                        }
                        else
                            MessageBox.Show("La cirugía no se pudo modificar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch
                    {
                        MessageBox.Show("Error de ingreso de datos", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("El campo Nombre no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
