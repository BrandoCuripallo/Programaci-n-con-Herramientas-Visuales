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
    public partial class FrmPacienteReceta : Form
    {
        Paciente paciente;
        Receta receta;
        public FrmPacienteReceta()
        {
            InitializeComponent();
        }
        public void asignarPaciente(Object paciente)
        {
            this.paciente = (Paciente)paciente;
        }
        public void llenarDataGridView()
        {
            DataTable tbl = paciente.buscarRecetas();
            dgvRecetas.DataSource = tbl;
        }

        private void dgvRecetas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvRecetas.SelectedRows.Count > 0)//Verifica que el usuario seleccione más de una fila
                {
                    receta = new Receta();
                    receta.IdReceta = Convert.ToInt32(dgvRecetas.Rows[e.RowIndex].Cells[0].Value.ToString());
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
            try
            {
                receta = paciente.buscarReceta(receta.IdReceta);
                FrmIngresarReceta frmIngresarReceta = new FrmIngresarReceta();
                frmIngresarReceta.llenarIndicaciones(receta.Indicaciones);
                frmIngresarReceta.txtCedula.Text = paciente.Cedula;
                frmIngresarReceta.txtNombres.Text = paciente.Nombres;
                frmIngresarReceta.txtApellidoPaterno.Text = paciente.ApellidoPaterno;
                frmIngresarReceta.txtApellidoMaterno.Text = paciente.ApellidoMaterno;
                frmIngresarReceta.txtCorreo.Text = paciente.CorreoElectronico;
                frmIngresarReceta.txtDireccion.Text = paciente.Direccion;
                frmIngresarReceta.txtTelefono.Text = paciente.Telefono;
                frmIngresarReceta.panel1.Visible = false;
                frmIngresarReceta.txtNumeroReceta.Text = Convert.ToString(receta.IdReceta);
                frmIngresarReceta.dtpFechaEmision.Value = receta.FechaEmision;
                frmIngresarReceta.llenarDataGridView();
                frmIngresarReceta.txtCedula.Enabled = false;
                frmIngresarReceta.txtCedulaDoctor.Enabled = false;
                frmIngresarReceta.btnBuscar.Visible = false;
                frmIngresarReceta.btnBuscarDoctor.Visible = false;
                frmIngresarReceta.btnCancelar.Visible = false;
                frmIngresarReceta.btnGuardar.Visible = false;
                frmIngresarReceta.btnAgregar.Visible = false;
                frmIngresarReceta.btnEliminar.Visible = false;
                frmIngresarReceta.cbxMedicamentos.Visible = false;
                frmIngresarReceta.lblMedicamento.Visible = false;
                frmIngresarReceta.Show();
            }
            catch
            {
                MessageBox.Show("Seleccione un registro para visualizar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
