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
namespace Login.Doctores
{
    public partial class FrmDoctorIngresarAtencion : Form
    {
        int id;
        bool evaluar = true;
        HistoriaClinica historiaClinica;
        Doctor doctor;
        Atencion atencion;
        List<Atencion> atenciones = new List<Atencion>();
        List<Atencion> atencionesAnteriores = new List<Atencion>();
        public FrmDoctorIngresarAtencion()
        {
            InitializeComponent();
        }
        public void asignarDoctor(Object doctor)
        {
            this.doctor = (Doctor)doctor;
            txtEspecialidad.Text = this.doctor.Especialidad.NombreEspecialidad;
        }
        public void asignarHistoriaClinica(Object historia)
        {
            this.historiaClinica = (HistoriaClinica)historia;
            txtNumeroHistoriaClinica.Text = Convert.ToString(historiaClinica.NumeroHistoria);
            txtCedula.Text = historiaClinica.Paciente.Cedula;
            txtNombres.Text = historiaClinica.Paciente.Nombres;
            txtApellidoPaterno.Text = historiaClinica.Paciente.ApellidoPaterno;
            txtApellidoMaterno.Text = historiaClinica.Paciente.ApellidoMaterno;
        }
        public void llenarAtenciones(Object atenc)
        {
            this.atenciones = (List<Atencion>)atenc;
            this.atencionesAnteriores = (List<Atencion>)atenc;
            if (atenciones.Count == 0)
                id = 1;
            else
                id = atenciones.Last().IdAtencion + 1;
            txtIdAtencion.Text = Convert.ToString(id);
            if (atenciones.Count != 0)
                evaluar = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void llenarDataGridView()
        {

            DataTable tbl = new DataTable();
            tbl.Columns.Add("Número");
            tbl.Columns.Add("Fecha de Atención");
            foreach (var aux in atenciones)
            {
                tbl.Rows.Add(aux.IdAtencion, aux.FechaAtencion.ToString("dd/MM/yy"));
            }
            dgvAtenciones.DataSource = tbl;
        }

        private void dgvAtenciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvAtenciones.SelectedRows.Count > 0)
                {
                    atencion = new Atencion();
                    atencion.IdAtencion = Convert.ToInt32(dgvAtenciones.Rows[e.RowIndex].Cells[0].Value.ToString());
                    atencion = atenciones.SingleOrDefault(aux => aux.IdAtencion == atencion.IdAtencion);
                    txtIdAtencion.Text = Convert.ToString(atencion.IdAtencion);
                    txtTemperatura.Text = Convert.ToString(atencion.Temperatura);
                    txtAltura.Text = Convert.ToString(atencion.Altura);
                    txtPeso.Text = Convert.ToString(atencion.Peso);
                    dtpFechaAtencion.Value = atencion.FechaAtencion;
                    txtDiagnostico.Text = atencion.Diagnostico;
                    txtIndicaciones.Text = atencion.Indicaciones;
                    btnEliminar.Enabled = true;
                    btnEditar.Enabled = true;
                    btnIngresar.Enabled = false;
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
            limpiarTextos();
            id = atenciones.Last().IdAtencion + 1;
            txtIdAtencion.Text = Convert.ToString(id);
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            btnIngresar.Enabled = true;
        }
        private void limpiarTextos()
        {
            txtIndicaciones.Text = "";
            txtDiagnostico.Text = "";
            txtTemperatura.Text = "";
            txtPeso.Text = "";
            txtAltura.Text = "";
            dtpFechaAtencion.Value = DateTime.Today;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtTemperatura.Text != "")
            {
                if (txtPeso.Text != "")
                {
                    if (txtAltura.Text != "")
                    {
                        if (txtDiagnostico.Text != "")
                        {
                            if (txtIndicaciones.Text != "")
                            {
                                DialogResult resultado = MessageBox.Show("¿Desea actualizar la Atención?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (resultado == DialogResult.Yes)
                                {
                                    try
                                    {
                                        var index = atenciones.FindIndex(aux => aux.IdAtencion == Convert.ToInt32(txtIdAtencion.Text));
                                        atenciones.RemoveAt(index);
                                        atencion = new Atencion();
                                        atencion.IdAtencion = Convert.ToInt32(txtIdAtencion.Text);
                                        atencion.FechaAtencion = dtpFechaAtencion.Value;
                                        atencion.Temperatura = Convert.ToDouble(txtTemperatura.Text);
                                        atencion.Altura = Convert.ToDouble(txtAltura.Text);
                                        atencion.Peso = Convert.ToDouble(txtPeso.Text);
                                        atencion.Diagnostico = txtDiagnostico.Text;
                                        atencion.Indicaciones = txtIndicaciones.Text;
                                        atenciones.Insert(index, atencion);
                                        limpiarTextos();
                                        MessageBox.Show("Atención modificada", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtIdAtencion.Text = Convert.ToString(id);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Error de ingreso de datos", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                                MessageBox.Show("Ingrese las indicaciones para el paciente", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Ingrese el Diagnóstico del paciente", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Ingrese la Estatura del paciente", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Ingrese el Peso del paciente", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Ingrese la Temperatura del paciente", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea eliminar la Atención?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                var item = atenciones.SingleOrDefault(aux => aux.IdAtencion == atencion.IdAtencion);
                if (item != null)
                {
                    atenciones.Remove(item);
                    limpiarTextos();
                    llenarDataGridView();
                }
                id = atenciones.Last().IdAtencion + 1;
                txtIdAtencion.Text = Convert.ToString(id);
                btnEliminar.Enabled = false;
                btnEditar.Enabled = false;
                btnIngresar.Enabled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea guardar el Historial Clínico?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                historiaClinica.Atenciones = atenciones;
                if (evaluar)
                {
                    if (doctor.ingresarAtenciones(historiaClinica))
                    {
                        MessageBox.Show("Historial Clínico ingresado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    if (doctor.modificarAtenciones(historiaClinica, atencionesAnteriores))
                    {
                        MessageBox.Show("Historial Clínico ingresado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtTemperatura.Text != "")
            {
                if (txtPeso.Text != "")
                {
                    if (txtAltura.Text != "")
                    {
                        if (txtDiagnostico.Text != "")
                        {
                            if (txtIndicaciones.Text != "")
                            {
                                DialogResult resultado = MessageBox.Show("¿Desea registrar la Atención?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (resultado == DialogResult.Yes)
                                {
                                    try
                                    {
                                        atencion = new Atencion();
                                        atencion.IdAtencion = Convert.ToInt32(txtIdAtencion.Text);
                                        atencion.Doctor = doctor;
                                        atencion.FechaAtencion = dtpFechaAtencion.Value;
                                        atencion.Temperatura = Convert.ToDouble(txtTemperatura.Text);
                                        atencion.Altura = Convert.ToDouble(txtAltura.Text);
                                        atencion.Peso = Convert.ToDouble(txtPeso.Text);
                                        atencion.Diagnostico = txtDiagnostico.Text;
                                        atencion.Indicaciones = txtIndicaciones.Text;
                                        atenciones.Add(atencion);
                                        limpiarTextos();
                                        txtIdAtencion.Text = Convert.ToString(id + 1);
                                        llenarDataGridView();
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Error de ingreso de datos", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                                MessageBox.Show("Ingrese las indicaciones para el paciente", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Ingrese el Diagnóstico del paciente", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Ingrese la Estatura del paciente", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Ingrese el Peso del paciente", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Ingrese la Temperatura del paciente", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtTemperatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != 46))
            {
                MessageBox.Show("Solo se permiten numeros", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != 46))
            {
                MessageBox.Show("Solo se permiten numeros", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != 46))
            {
                MessageBox.Show("Solo se permiten numeros", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void FrmDoctorIngresarAtencion_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
