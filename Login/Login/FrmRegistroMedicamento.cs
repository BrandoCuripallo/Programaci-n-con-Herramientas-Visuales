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
    public partial class FrmRegistroMedicamento : Form
    {
        private Administrador administrador;
        private Medicamento medicamento;
        List<Medicamento> medicamentos = new List<Medicamento>();
        public FrmRegistroMedicamento()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmIngresarMedicamento frmIngresarMedicamento = new FrmIngresarMedicamento();
            frmIngresarMedicamento.asignarAdministrador(this.administrador);
            frmIngresarMedicamento.Show();
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
        }
        public void llenarDataGridView()
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblMedicamento";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            medicamento = new Medicamento();
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
                DataBase.cerrarConexion(conexion);
                DataTable tbl = new DataTable();
                tbl.Columns.Add("Código");
                tbl.Columns.Add("Nombre");
                tbl.Columns.Add("Descripción");
                tbl.Columns.Add("Stock");
                tbl.Columns.Add("Precio Unitario");
                foreach (var aux in medicamentos)
                {
                    tbl.Rows.Add(aux.CodigoMedicamento, aux.NombreMedicamento, aux.Descripcion, aux.Stock, aux.PrecioUnitario);
                }
                dgvMedicamentos.DataSource = tbl;
            }
        }

        private void dgvMedicamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMedicamentos.SelectedRows.Count > 0)//Verifica que el usuario seleccione más de una fila
                {
                    medicamento = new Medicamento();
                    medicamento.CodigoMedicamento = dgvMedicamentos.Rows[e.RowIndex].Cells[0].Value.ToString();
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
                medicamento = administrador.buscarMedicamento(medicamento.CodigoMedicamento);
                FrmIngresarMedicamento frmIngresarMedicamento = new FrmIngresarMedicamento();
                frmIngresarMedicamento.codigo = medicamento.CodigoMedicamento;
                frmIngresarMedicamento.asignarAdministrador(this.administrador);
                frmIngresarMedicamento.editar = true;
                frmIngresarMedicamento.txtCodigo.Text = medicamento.CodigoMedicamento;
                frmIngresarMedicamento.txtNombre.Text = medicamento.NombreMedicamento;
                frmIngresarMedicamento.txtDescripcion.Text = medicamento.Descripcion;
                frmIngresarMedicamento.txtStock.Text = Convert.ToString(medicamento.Stock);
                frmIngresarMedicamento.txtPrecioUnitario.Text = Convert.ToString(medicamento.PrecioUnitario);
                frmIngresarMedicamento.Show();
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
                DialogResult resultado = MessageBox.Show("¿Está seguro en eliminar el medicamento?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (administrador.eliminarMedicamento(medicamento.CodigoMedicamento))
                        MessageBox.Show("Medicamento eliminado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("El medicamento no se pudo eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
