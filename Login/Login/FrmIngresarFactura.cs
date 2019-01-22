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
namespace Login
{
    public partial class FrmIngresarFactura : Form
    {
        public bool editar = false;
        public bool producto = false;
        int id = 1;
        private Administrador administrador;
        double total = 0;
        Factura factura;
        Medicamento medicamento;
        Detalle detalle;
        Paciente paciente;
        Farmaceutico farmaceutico;
        List<Detalle> detalles = new List<Detalle>();
        List<Detalle> detallesAnteriores = new List<Detalle>();
        List<Medicamento> medicamentos = new List<Medicamento>();
        DataTable tbl;
        public FrmIngresarFactura()
        {
            InitializeComponent();
        }
        public void llenarDetalles(Object detall)
        {
            this.detalles = (List<Detalle>)detall;
            this.detallesAnteriores = (List<Detalle>)detall;
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
        }
        public void llenarProductos(Object medicamento)
        {
            medicamentos = (List<Medicamento>)medicamento;
            cbxProductos.Items.Clear();
            foreach (var aux in medicamentos)
            {
                cbxProductos.Items.Add(aux.NombreMedicamento);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (producto)
            {
                foreach (var aux in detalles)
                {
                    medicamento = administrador.buscarMedicamentoPorNombre(aux.Medicamento.NombreMedicamento);
                    if (administrador.modificarStock(medicamento, medicamento.Stock + aux.Cantidad))
                        continue;
                }
            }
            this.Close();
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCedulaFarmaceutico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void limpiarTextos()
        {
            txtCedula.Text = "";
            txtNombres.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCedulaFarmaceutico.Text = "";
            txtCantidad.Text = "";
            txtTotal.Text = "";
            tbl = new DataTable();
            tbl.Columns.Add("Número");
            tbl.Columns.Add("Descripción");
            tbl.Columns.Add("Cantidad");
            tbl.Columns.Add("Subtotal");
            dgvProductos.DataSource = tbl;
            dtpFechaEmision.Value = DateTime.Today;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                if(medicamento.Stock > Convert.ToInt32(txtCantidad.Text))
                {
                    if (administrador.modificarStock(medicamento, Convert.ToInt32(txtStock.Text) - Convert.ToInt32(txtCantidad.Text)))
                    {
                        detalle = new Detalle(id++, medicamento, Convert.ToInt32(txtCantidad.Text));
                        detalles.Add(detalle);
                        cbxProductos.SelectedIndex = 0;
                        txtStock.Text = "";
                        txtCantidad.Text = "";
                        llenarDataGridView();
                        producto = true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo ingresar el Producto", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("No hay suficiente cantidad de Producto", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Ingrese la cantidad del Producto", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public void llenarDataGridView()
        {
            tbl = new DataTable();
            total = 0;
            tbl.Columns.Add("Número");
            tbl.Columns.Add("Descripción");
            tbl.Columns.Add("Cantidad");
            tbl.Columns.Add("Precio Unitario $");
            tbl.Columns.Add("Subtotal $");
            foreach (var aux in detalles)
            {
                tbl.Rows.Add(aux.IdDetalle, aux.Medicamento.NombreMedicamento, aux.Cantidad, aux.Medicamento.PrecioUnitario, aux.Subtotal);
                total = total + aux.Subtotal;
            }
            txtTotal.Text = Convert.ToString(total);
            dgvProductos.DataSource = tbl;
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProductos.SelectedRows.Count > 0)
                {
                    detalle = new Detalle();
                    detalle.IdDetalle = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    txtStock.Text = "";
                    txtCantidad.Text = "";
                    cbxProductos.SelectedIndex = 0;
                    btnEliminar.Enabled = true;
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Seleccione una fila correcta", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var item = detalles.SingleOrDefault(aux => aux.IdDetalle == detalle.IdDetalle);
            medicamento = administrador.buscarMedicamentoPorNombre(item.Medicamento.NombreMedicamento);
            if (item != null)
            {
                detalles.Remove(item);
                if(administrador.modificarStock(medicamento, medicamento.Stock + item.Cantidad))
                    llenarDataGridView();
            }
            btnEliminar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            paciente = administrador.buscarPaciente(txtCedula.Text);
            if (paciente != null)
            {
                txtNombres.Text = paciente.Nombres;
                txtApellidoPaterno.Text = paciente.ApellidoPaterno;
                txtApellidoMaterno.Text = paciente.ApellidoMaterno;
                txtCorreo.Text = paciente.CorreoElectronico;
                txtDireccion.Text = paciente.Direccion;
                txtTelefono.Text = paciente.Telefono;
            }
            else
                MessageBox.Show("El paciente no se encuentra registrado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnBuscarFarmaceútico_Click(object sender, EventArgs e)
        {
            farmaceutico = administrador.buscarFarmaceutico(txtCedulaFarmaceutico.Text);
            if (farmaceutico != null)
            {
                txtNombresFarmaceutico.Text = farmaceutico.Nombres;
                txtApellidoPaternoFarmaceutico.Text = farmaceutico.ApellidoPaterno;
            }
            else
                MessageBox.Show("El farmaceútico no se encuentra registrado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "")
            {
                if(txtCedulaFarmaceutico.Text != "")
                {
                    if(detalles.Count != 0)
                    {
                        DialogResult resultado = MessageBox.Show("¿Desea guardar el Registro?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.Yes)
                        {
                            try
                            {
                                factura = new Factura();
                                farmaceutico = new Farmaceutico();
                                paciente = new Paciente();
                                factura.IdFactura = Convert.ToInt32(txtNumeroFactura.Text);
                                farmaceutico.Cedula = txtCedulaFarmaceutico.Text;
                                factura.Farmaceutico = farmaceutico;
                                paciente.Cedula = txtCedula.Text;
                                factura.Paciente = paciente;
                                factura.FechaEmision = dtpFechaEmision.Value;
                                factura.Detalles = detalles;
                                factura.Total = Convert.ToDouble(txtTotal.Text);
                                if (editar)
                                {
                                    if (administrador.modificarFactura(factura, detallesAnteriores))
                                    {
                                        MessageBox.Show("Factura modificada con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    else
                                        MessageBox.Show("La Factura ya existe", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    if (administrador.ingresarFactura(factura))
                                    {

                                        MessageBox.Show("Factura ingresada con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    else
                                        MessageBox.Show("La factura ya se encuentra registrada", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Error de ingreso de datos", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Para emitir una factura debe almenos ingresar un producto", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Ingrese la cédula del farmaceútico", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Ingrese la cédula del paciente", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void cbxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            medicamento = administrador.buscarMedicamentoPorNombre(cbxProductos.Text);
            txtStock.Text = Convert.ToString(medicamento.Stock);
            btnEliminar.Enabled = false;
        }

        private void FrmIngresarFactura_Load(object sender, EventArgs e)
        {
            try
            {
                var item = detalles.Last();
                if (item != null)
                    id = item.IdDetalle + 1;
            }
            catch
            { }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Emision datos = new Emision();
            FrmFactura frmFactura = new FrmFactura();
            for (int i = 0; i < dgvProductos.Rows.Count - 1; i++)
            {
                datos = new Emision();
                datos.CedulaPaciente = txtCedula.Text;
                datos.Nombres = txtNombres.Text;
                datos.ApellidoPaterno = txtApellidoPaterno.Text;
                datos.CorreoElectronico = txtCorreo.Text;
                datos.Direccion = txtDireccion.Text;
                datos.Telefono = txtTelefono.Text;
                datos.NumeroFactura = Convert.ToInt32(txtNumeroFactura.Text);
                datos.Fecha = dtpFechaEmision.Value;
                datos.Total = Convert.ToDouble(txtTotal.Text);
                datos.Numero = Convert.ToInt32(dgvProductos.Rows[i].Cells[0].Value);
                datos.Descripcion = Convert.ToString(dgvProductos.Rows[i].Cells[1].Value);
                datos.Cantidad = Convert.ToInt32(dgvProductos.Rows[i].Cells[2].Value);
                datos.PrecioUnitario = Convert.ToDouble(dgvProductos.Rows[i].Cells[3].Value);
                datos.SubTotal = Convert.ToDouble(dgvProductos.Rows[i].Cells[4].Value);
                frmFactura.datos.Add(datos);
            }
            frmFactura.ShowDialog();
        }
    }
}
