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
namespace Login.Pacientes
{
    public partial class FrmPacienteFactura : Form
    {
        Paciente paciente;
        Factura factura;
        public FrmPacienteFactura()
        {
            InitializeComponent();
        }
        public void asignarPaciente(Object paciente)
        {
            this.paciente= (Paciente)paciente;
        }
        public void llenarDataGridView()
        {
            DataTable tbl = paciente.buscarFacturas();
            dgvFacturas.DataSource = tbl;
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
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            factura = paciente.buscarFactura(factura.IdFactura);
            FrmIngresarFactura frmIngresarFactura = new FrmIngresarFactura();
            frmIngresarFactura.txtCedula.Enabled = false;
            frmIngresarFactura.btnBuscar.Visible = false;
            frmIngresarFactura.txtCedula.Text = paciente.Cedula;
            frmIngresarFactura.txtNombres.Text = paciente.Nombres;
            frmIngresarFactura.txtApellidoPaterno.Text = paciente.ApellidoPaterno;
            frmIngresarFactura.txtApellidoMaterno.Text = paciente.ApellidoMaterno;
            frmIngresarFactura.txtCorreo.Text = paciente.CorreoElectronico;
            frmIngresarFactura.txtDireccion.Text = paciente.Direccion;
            frmIngresarFactura.txtTelefono.Text = paciente.Telefono;
            frmIngresarFactura.panel1.Visible = false;
            frmIngresarFactura.txtNumeroFactura.Text = Convert.ToString(factura.IdFactura);
            frmIngresarFactura.dtpFechaEmision.Value = factura.FechaEmision;
            frmIngresarFactura.llenarDetalles(factura.Detalles);
            frmIngresarFactura.llenarDataGridView();
            frmIngresarFactura.lblMedicamento.Visible = false;
            frmIngresarFactura.cbxProductos.Visible = false;
            frmIngresarFactura.txtStock.Visible = false;
            frmIngresarFactura.lblStock.Visible = false;
            frmIngresarFactura.txtCantidad.Visible = false;
            frmIngresarFactura.lblCantidad.Visible = false;
            frmIngresarFactura.btnAgregar.Visible = false;
            frmIngresarFactura.btnEliminar.Visible = false;
            frmIngresarFactura.btnGuardar.Visible = false;
            frmIngresarFactura.btnCancelar.Visible = false;
            frmIngresarFactura.dtpFechaEmision.Enabled = false;
            frmIngresarFactura.Show();
        }
    }
}
