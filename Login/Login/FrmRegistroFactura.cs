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
    public partial class FrmRegistroFactura : Form
    {
        Administrador administrador;
        Medicamento medicamento;
        Factura factura;
        Farmaceutico farmaceutico;
        Paciente paciente;        
        List<Medicamento> medicamentos = new List<Medicamento>();
        List<Factura> facturas = new List<Factura>();
        public FrmRegistroFactura()
        {
            InitializeComponent();
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmIngresarFactura frmIngresarFactura = new FrmIngresarFactura();
            frmIngresarFactura.asignarAdministrador(this.administrador);
            frmIngresarFactura.llenarProductos(this.medicamentos);
            frmIngresarFactura.llenarDataGridView();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT TOP 1 idFactura FROM tblFactura ORDER BY idFactura DESC";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    frmIngresarFactura.txtNumeroFactura.Text = Convert.ToString(reader.GetInt32(0) + 1);
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }else
                frmIngresarFactura.txtNumeroFactura.Text = "1";
            frmIngresarFactura.Show();
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
            tbl.Columns.Add("Número de Factura");
            tbl.Columns.Add("Cédula del Farmaceútico");
            tbl.Columns.Add("Cédula del Cliente");
            tbl.Columns.Add("Fecha de Emisión");
            tbl.Columns.Add("Total");
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblFactura";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            factura = new Factura();
            farmaceutico = new Farmaceutico();
            paciente = new Paciente();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    factura.IdFactura = reader.GetInt32(0);
                    farmaceutico.Cedula = reader.GetString(1);
                    paciente.Cedula = reader.GetString(2);
                    factura.FechaEmision = reader.GetDateTime(3);
                    factura.Total = Convert.ToDouble(Convert.ToString(reader.GetSqlMoney(4)));
                    factura.Paciente = paciente;
                    factura.Farmaceutico = farmaceutico;
                    facturas.Add(factura);
                    factura = new Factura();
                    paciente = new Paciente();
                    farmaceutico = new Farmaceutico();
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
                foreach (var aux in facturas)
                {
                    tbl.Rows.Add(aux.IdFactura, aux.Farmaceutico.Cedula, aux.Paciente.Cedula, aux.FechaEmision.ToString("dd/MM/yy"), aux.Total);
                }
                dgvFacturas.DataSource = tbl;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                factura = administrador.buscarFactura(factura.IdFactura);
                paciente = administrador.buscarPaciente(factura.Paciente.Cedula);
                factura.Paciente = paciente;
                farmaceutico = administrador.buscarFarmaceutico(factura.Farmaceutico.Cedula);
                factura.Farmaceutico = farmaceutico;
                FrmIngresarFactura frmIngresarFactura = new FrmIngresarFactura();
                frmIngresarFactura.editar = true;
                frmIngresarFactura.asignarAdministrador(this.administrador);
                frmIngresarFactura.llenarProductos(this.medicamentos);
                frmIngresarFactura.txtCedula.Text = factura.Paciente.Cedula;
                frmIngresarFactura.txtNombres.Text = factura.Paciente.Nombres;
                frmIngresarFactura.txtApellidoPaterno.Text = factura.Paciente.ApellidoPaterno;
                frmIngresarFactura.txtApellidoMaterno.Text = factura.Paciente.ApellidoMaterno;
                frmIngresarFactura.txtCorreo.Text = factura.Paciente.CorreoElectronico;
                frmIngresarFactura.txtDireccion.Text = factura.Paciente.Direccion;
                frmIngresarFactura.txtTelefono.Text = factura.Paciente.Telefono;
                frmIngresarFactura.txtCedulaFarmaceutico.Text = factura.Farmaceutico.Cedula;
                frmIngresarFactura.txtNombresFarmaceutico.Text = factura.Farmaceutico.Nombres;
                frmIngresarFactura.txtApellidoPaternoFarmaceutico.Text = factura.Farmaceutico.ApellidoPaterno;
                frmIngresarFactura.txtNumeroFactura.Text = Convert.ToString(factura.IdFactura);
                frmIngresarFactura.dtpFechaEmision.Value = factura.FechaEmision;
                frmIngresarFactura.llenarDetalles(factura.Detalles);
                frmIngresarFactura.llenarDataGridView();
                frmIngresarFactura.txtCedula.Enabled = false;
                frmIngresarFactura.txtCedulaFarmaceutico.Enabled = false;
                frmIngresarFactura.btnBuscar.Enabled = false;
                frmIngresarFactura.btnBuscarFarmaceútico.Enabled = false;
                frmIngresarFactura.Show();
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
                    if (administrador.eliminarFactura(factura.IdFactura))
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
    }
}
