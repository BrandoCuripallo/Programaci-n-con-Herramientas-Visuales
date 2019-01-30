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
    public partial class FrmIngresarReceta : Form
    {
        public bool editar = false;
        int id = 1;
        Administrador administrador;
        Receta receta;
        Medicamento medicamento;
        Indicacion indicacion;
        Paciente paciente;
        Doctor doctor;
        List<Indicacion> indicaciones = new List<Indicacion>();
        List<Indicacion> indicacionesAnteriores = new List<Indicacion>();
        List<Medicamento> medicamentos = new List<Medicamento>();
        DataTable tbl;
        public FrmIngresarReceta()
        {
            InitializeComponent();
        }
        public void llenarIndicaciones(Object indicac)
        {
            this.indicaciones = (List<Indicacion>)indicac;
            this.indicacionesAnteriores = (List<Indicacion>)indicac;
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
        }
        public void llenarMedicamentos(Object medicamento)
        {
            medicamentos = (List<Medicamento>)medicamento;
            cbxMedicamentos.Items.Clear();
            foreach (var aux in medicamentos)
            {
                cbxMedicamentos.Items.Add(aux.NombreMedicamento);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
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

        private void txtCedulaDoctor_KeyPress(object sender, KeyPressEventArgs e)
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
            txtCedulaDoctor.Text = "";
            txtNombresDoctor.Text = "";
            txtApellidoPaternoDoctor.Text = "";
            cbxMedicamentos.SelectedIndex = 0;
            txtIndicaciones.Text = "";
            tbl = new DataTable();
            tbl.Columns.Add("Número");
            tbl.Columns.Add("Nombre del Medicamento");
            dgvMedicamentos.DataSource = tbl;
            dtpFechaEmision.Value = DateTime.Today;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtIndicaciones.Text != "")
            {
                medicamento = administrador.buscarMedicamentoPorNombre(cbxMedicamentos.Text);
                indicacion = new Indicacion(id++, medicamento, txtIndicaciones.Text);
                indicaciones.Add(indicacion);
                cbxMedicamentos.SelectedIndex = 0;
                txtIndicaciones.Text = "";
                llenarDataGridView();
            }
            else
                MessageBox.Show("Ingrese las indicaciones para el medicamento", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public void llenarDataGridView()
        {
            try
            {
                tbl = new DataTable();
                tbl.Columns.Add("Número");
                tbl.Columns.Add("Nombre del Medicamento");
                foreach (var aux in indicaciones)
                {
                    tbl.Rows.Add(aux.NumeroIndicacion, aux.Medicamento.NombreMedicamento);
                }
                dgvMedicamentos.DataSource = tbl;
            }
            catch
            {
                MessageBox.Show("Debe eliminar un item y volver a añadir para editar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvMedicamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMedicamentos.SelectedRows.Count > 0)
                {
                    indicacion = new Indicacion();
                    indicacion.NumeroIndicacion = Convert.ToInt32(dgvMedicamentos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    indicacion = indicaciones.SingleOrDefault(aux => aux.NumeroIndicacion == indicacion.NumeroIndicacion);
                    txtIndicaciones.Text = indicacion.Indicaciones;
                    btnEliminar.Enabled = true;
                    btnAgregar.Enabled = false;
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
            try
            {
                var item = indicaciones.SingleOrDefault(aux => aux.NumeroIndicacion == indicacion.NumeroIndicacion);
                if (item != null)
                {
                    indicaciones.Remove(item);
                    llenarDataGridView();
                }
                btnEliminar.Enabled = false;
            }
            catch
            {

            }
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

        private void btnBuscarDoctor_Click(object sender, EventArgs e)
        {
            doctor = administrador.buscarDoctor(txtCedulaDoctor.Text);
            if (doctor != null)
            {
                txtNombresDoctor.Text = doctor.Nombres;
                txtApellidoPaternoDoctor.Text = doctor.ApellidoPaterno;
            }
            else
                MessageBox.Show("El Doctor no se encuentra registrado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "")
            {
                if (txtCedulaDoctor.Text != "")
                {
                    if (indicaciones.Count != 0)
                    {
                        DialogResult resultado = MessageBox.Show("¿Desea guardar el Registro?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.Yes)
                        {
                            try
                            {
                                receta = new Receta();
                                doctor = new Doctor();
                                paciente = new Paciente();
                                receta.IdReceta = Convert.ToInt32(txtNumeroReceta.Text);
                                doctor.Cedula = txtCedulaDoctor.Text;
                                receta.Doctor = doctor;
                                paciente.Cedula = txtCedula.Text;
                                receta.Paciente = paciente;
                                receta.FechaEmision = dtpFechaEmision.Value;
                                receta.Indicaciones = indicaciones;
                                if (editar)
                                {
                                    if (administrador.modificarReceta(receta, indicaciones))
                                    {
                                        MessageBox.Show("Receta modificada con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    else
                                        MessageBox.Show("La Receta ya existe", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    if (administrador.ingresarReceta(receta))
                                    {

                                        MessageBox.Show("Receta ingresada con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    else
                                        MessageBox.Show("La Receta ya se encuentra registrada", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Error de ingreso de datos", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Para emitir una Receta debe almenos ingresar un medicamento", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Ingrese la cédula del Doctor", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Ingrese la cédula del Paciente", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void cbxMedicamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIndicaciones.Text = "";
            btnEliminar.Enabled = false;
            btnAgregar.Enabled = true;
        }

        private void FrmIngresarReceta_Load(object sender, EventArgs e)
        {
            try
            {
                var item = indicaciones.Last();
                if (item != null)
                    id = item.NumeroIndicacion + 1;
            }
            catch { }
        }
    }
}
