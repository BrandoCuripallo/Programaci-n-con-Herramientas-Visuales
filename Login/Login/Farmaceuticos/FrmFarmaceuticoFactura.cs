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
namespace Login.Farmaceuticos
{
    public partial class FrmFarmaceuticoFactura : Form
    {
        Farmaceutico farmaceutico;
        Factura factura;
        Paciente paciente;
        Medicamento medicamento;
        List<Medicamento> medicamentos = new List<Medicamento>();
        public FrmFarmaceuticoFactura()
        {
            InitializeComponent();
        }
        public void asignarFarmaceutico(Object farmaceutico)
        {
            this.farmaceutico = (Farmaceutico)farmaceutico;
        }
        public void llenarDataGridView()
        {
            DataTable tbl = farmaceutico.buscarFacturas();
            dgvFacturas.DataSource = tbl;
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
        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvFacturas.SelectedRows.Count > 0)//Verifica que el usuario seleccione más de una fila
                {
                    factura = new Factura();
                    factura.IdFactura = Convert.ToInt32(dgvFacturas.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Seleccione una fila correcta", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmFarmaceuticoIngresarFactura frmFarmaceuticoIngresarFactura = new FrmFarmaceuticoIngresarFactura();
            frmFarmaceuticoIngresarFactura.asignarFarmaceutico(this.farmaceutico);
            frmFarmaceuticoIngresarFactura.llenarProductos(this.medicamentos);
            frmFarmaceuticoIngresarFactura.llenarDataGridView();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT TOP 1 idFactura FROM tblFactura ORDER BY idFactura DESC";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    frmFarmaceuticoIngresarFactura.txtNumeroFactura.Text = Convert.ToString(reader.GetInt32(0) + 1);
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
            else
                frmFarmaceuticoIngresarFactura.txtNumeroFactura.Text = "1";
            frmFarmaceuticoIngresarFactura.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                factura = farmaceutico.buscarFactura(factura.IdFactura);
                paciente = farmaceutico.buscarPaciente(factura.Paciente.Cedula);
                factura.Paciente = paciente;
                factura.Farmaceutico = this.farmaceutico;
                FrmFarmaceuticoIngresarFactura frmFarmaceuticoIngresarFactura = new FrmFarmaceuticoIngresarFactura();
                frmFarmaceuticoIngresarFactura.editar = true;
                frmFarmaceuticoIngresarFactura.asignarFarmaceutico(this.farmaceutico);
                frmFarmaceuticoIngresarFactura.llenarProductos(this.medicamentos);
                frmFarmaceuticoIngresarFactura.txtCedula.Text = factura.Paciente.Cedula;
                frmFarmaceuticoIngresarFactura.txtNombres.Text = factura.Paciente.Nombres;
                frmFarmaceuticoIngresarFactura.txtApellidoPaterno.Text = factura.Paciente.ApellidoPaterno;
                frmFarmaceuticoIngresarFactura.txtApellidoMaterno.Text = factura.Paciente.ApellidoMaterno;
                frmFarmaceuticoIngresarFactura.txtCorreo.Text = factura.Paciente.CorreoElectronico;
                frmFarmaceuticoIngresarFactura.txtDireccion.Text = factura.Paciente.Direccion;
                frmFarmaceuticoIngresarFactura.txtTelefono.Text = factura.Paciente.Telefono;
                frmFarmaceuticoIngresarFactura.txtNumeroFactura.Text = Convert.ToString(factura.IdFactura);
                frmFarmaceuticoIngresarFactura.dtpFechaEmision.Value = factura.FechaEmision;
                frmFarmaceuticoIngresarFactura.llenarDetalles(factura.Detalles);
                frmFarmaceuticoIngresarFactura.llenarDataGridView();
                frmFarmaceuticoIngresarFactura.txtCedula.Enabled = false;
                frmFarmaceuticoIngresarFactura.btnBuscar.Enabled = false;
                frmFarmaceuticoIngresarFactura.Show();
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
                DialogResult resultado = MessageBox.Show("¿Está seguro en eliminar la factura?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (farmaceutico.eliminarFactura(factura.IdFactura))
                        MessageBox.Show("Factura eliminada", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("La Factura no se pudo eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
