﻿using System;
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
    public partial class FrmDoctorIngresarReceta : Form
    {
        public bool editar = false;
        int id = 1;
        Receta receta;
        Medicamento medicamento;
        Indicacion indicacion;
        Paciente paciente;
        Doctor doctor;
        DataTable tbl;
        List<Indicacion> indicaciones = new List<Indicacion>();
        List<Indicacion> indicacionesAnteriores = new List<Indicacion>();
        List<Medicamento> medicamentos = new List<Medicamento>();
        public FrmDoctorIngresarReceta()
        {
            InitializeComponent();
        }
        public void asignarDoctor(Object doctor)
        {
            this.doctor = (Doctor)doctor;
        }
        public void llenarIndicaciones(Object indicac)
        {
            this.indicaciones = (List<Indicacion>)indicac;
            this.indicacionesAnteriores = (List<Indicacion>)indicac;
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
        private void limpiarTextos()
        {
            txtCedula.Text = "";
            txtNombres.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
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
                medicamento = doctor.buscarMedicamentoPorNombre(cbxMedicamentos.Text);
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
            var item = indicaciones.SingleOrDefault(aux => aux.NumeroIndicacion == indicacion.NumeroIndicacion);
            if (item != null)
            {
                indicaciones.Remove(item);
                llenarDataGridView();
            }
            btnEliminar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            paciente = doctor.buscarPaciente(txtCedula.Text);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "")
            {
                if (indicaciones.Count != 0)
                {
                    DialogResult resultado = MessageBox.Show("¿Desea guardar el Registro?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        try
                        {
                            receta = new Receta();
                            paciente = new Paciente();
                            receta.IdReceta = Convert.ToInt32(txtNumeroReceta.Text);
                            receta.Doctor = doctor;
                            paciente.Cedula = txtCedula.Text;
                            receta.Paciente = paciente;
                            receta.FechaEmision = dtpFechaEmision.Value;
                            receta.Indicaciones = indicaciones;
                            if (editar)
                            {
                                if (doctor.modificarReceta(receta, indicaciones))
                                {
                                    MessageBox.Show("Receta modificada con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                    MessageBox.Show("La Receta ya existe", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                if (doctor.ingresarReceta(receta))
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
                MessageBox.Show("Ingrese la cédula del Paciente", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void cbxMedicamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIndicaciones.Text = "";
            btnEliminar.Enabled = false;
            btnAgregar.Enabled = true;
        }

        private void FrmDoctorIngresarReceta_Load(object sender, EventArgs e)
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
