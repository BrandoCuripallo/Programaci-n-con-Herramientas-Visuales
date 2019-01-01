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
    public partial class FrmIngresarMedicamento : Form
    {
        public bool editar = false;
        public string codigo;
        Medicamento medicamento;
        private Administrador administrador;
        public FrmIngresarMedicamento()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
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

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != 46))
            {
                MessageBox.Show("Solo se permiten numeros", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text != "")
            {
                if(txtNombre.Text != "")
                {
                    if(txtDescripcion.Text != "")
                    {
                        if(txtStock.Text != "")
                        {
                            if(txtPrecioUnitario.Text != "")
                            {
                                DialogResult resultado = MessageBox.Show("¿Desea guardar el Registro?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (resultado == DialogResult.Yes)
                                {
                                    try
                                    {
                                        medicamento = new Medicamento();
                                        medicamento.CodigoMedicamento = txtCodigo.Text;
                                        medicamento.NombreMedicamento = txtNombre.Text;
                                        medicamento.Descripcion = txtDescripcion.Text;
                                        medicamento.Stock = Convert.ToInt32(txtStock.Text);
                                        medicamento.PrecioUnitario = Convert.ToDouble(txtPrecioUnitario.Text);
                                        Console.WriteLine(medicamento.PrecioUnitario);
                                        if (editar)
                                        {
                                            if (administrador.modificarMedicamento(medicamento, codigo))
                                            {
                                                MessageBox.Show("Medicamento modificado con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                limpiarTextos();
                                            }
                                            else
                                                MessageBox.Show("El Medicamento ya existe", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                        else
                                        {
                                            if (administrador.ingresarMedicamento(medicamento))
                                            {

                                                MessageBox.Show("Medicamento ingresado con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                limpiarTextos();
                                            }
                                            else
                                                MessageBox.Show("El medicamento ya se encuentra registrado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Error de ingreso de datos", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                                MessageBox.Show("El campo Precio Unitario no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("El campo Stock no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("El campo Descripción no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("El campo Nombre no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("El campo Código no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void limpiarTextos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtStock.Text = "";
            txtPrecioUnitario.Text = "";
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Ingrese el Código sin espacios", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
