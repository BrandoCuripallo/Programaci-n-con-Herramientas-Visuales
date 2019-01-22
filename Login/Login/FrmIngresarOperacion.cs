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
    public partial class FrmIngresarOperacion : Form
    {
        public bool editar = false;
        Administrador administrador;
        Paciente paciente;
        Doctor doctor;
        Cirugia cirugia;
        AtencionQuirurgica atencionQuirurgica;
        DataTable tbl;
        List<Doctor> doctores = new List<Doctor>();
        List<Cirugia> cirugias = new List<Cirugia>();
        public FrmIngresarOperacion()
        {
            InitializeComponent();
        }
        public void llenarDoctores(Object doctor)
        {
            this.doctores = (List<Doctor>)doctor;
            cbxDoctor.Items.Clear();
            foreach (var aux in doctores)
                cbxDoctor.Items.Add(aux.ApellidoPaterno);
        }
        public void llenarCirugias(Object cirugi)
        {
            this.cirugias = (List<Cirugia>)cirugi;
            cbxCirugia.Items.Clear();
            foreach (var aux in cirugias)
                cbxCirugia.Items.Add(aux.NombreCirugia);
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
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
            txtDescripcion.Text = "";
            cbxCirugia.SelectedIndex = 0;
            cbxDoctor.SelectedIndex = 0;
            dtpFechaCirugia.Value = DateTime.Today;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            paciente = administrador.buscarPaciente(txtCedula.Text);
            if (paciente != null)
            {
                txtNombres.Text = paciente.Nombres;
                txtApellidoPaterno.Text = paciente.ApellidoPaterno;
                txtApellidoMaterno.Text = paciente.ApellidoMaterno;
            }
            else
                MessageBox.Show("El paciente no se encuentra registrado", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFechaCirugia.Value > DateTime.Today)
                {
                    if (txtCedula.Text != "")
                    {
                        if (cbxCirugia.Text != "")
                        {
                            if (txtDescripcion.Text != "")
                            {
                                if (cbxDoctor.Text != "")
                                {
                                    DialogResult resultado = MessageBox.Show("¿Desea guardar el Registro?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (resultado == DialogResult.Yes)
                                    {
                                        try
                                        {
                                            atencionQuirurgica = new AtencionQuirurgica();
                                            atencionQuirurgica.IdAtencionQuirurgica = Convert.ToInt32(txtNumeroCirugia.Text);
                                            atencionQuirurgica.Paciente = paciente;
                                            atencionQuirurgica.FechaCirugia = dtpFechaCirugia.Value;
                                            atencionQuirurgica.Descripcion = txtDescripcion.Text;
                                            cirugia = cirugias.SingleOrDefault(aux => aux.NombreCirugia == cbxCirugia.Text);
                                            atencionQuirurgica.Cirugia = cirugia;
                                            doctor = doctores.SingleOrDefault(aux => aux.ApellidoPaterno == cbxDoctor.Text);
                                            atencionQuirurgica.Doctor = doctor;
                                            if (editar)
                                            {
                                                paciente = new Paciente();
                                                paciente.Cedula = txtCedula.Text;
                                                atencionQuirurgica.Paciente = paciente;
                                                if (administrador.modificarOperacionQuirurgica(atencionQuirurgica))
                                                {
                                                    MessageBox.Show("Cirugía modificada con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    this.Close();
                                                }
                                                else
                                                    MessageBox.Show("La Cirugía ya existe", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                            else
                                            {
                                                if (administrador.validarFechaCirugia(dtpFechaCirugia.Value, doctor.Cedula))
                                                {
                                                    if (administrador.ingresarOperacionQuirurgica(atencionQuirurgica))
                                                    {

                                                        MessageBox.Show("Cirugía ingresada con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        this.Close();
                                                    }
                                                    else
                                                        MessageBox.Show("La Cirugía ya se encuentra registrada", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                }
                                                else
                                                    MessageBox.Show("La fecha de la cirguía coincide con otra asignada", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                        }
                                        catch
                                        {
                                            MessageBox.Show("Error de ingreso de datos", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                else
                                    MessageBox.Show("Seleccione el Médico para la especialidad", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                                MessageBox.Show("Ingrese el motivo de la cita", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                            MessageBox.Show("Seleccione el tipo de Cirugía", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        MessageBox.Show("Ingrese la cédula del paciente", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("La fecha ingresada no puede ser menor a la fecha actual", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Error de ingreso de datos", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
