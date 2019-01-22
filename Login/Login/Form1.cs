using Login.Clases;
using Login.Farmaceuticos;
using Login.Pacientes;
using Login.Recepcionistas;
using Login.Doctores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(cbxModo.Text != "")
            {
                if (txtUsuario.Text != "")
                {
                    if (txtContrasenia.Text != "")
                    {
                        switch (cbxModo.Text)
                        {
                            case "ADMINISTRADOR":
                                Administrador administrador = new Administrador(txtUsuario.Text, txtContrasenia.Text);
                                if (administrador.validarAdministrador())
                                {
                                    MessageBox.Show("Bienvenido al sistema", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    desplazar();
                                    this.Hide();
                                    FrmAdministrador frmAdministrador = new FrmAdministrador();
                                    frmAdministrador.asignarAdministrador(administrador);
                                    frmAdministrador.Show();                                    
                                }
                                else
                                {
                                    MessageBox.Show("Usuario no existe", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                break;
                            case "DOCTOR":
                                Doctor doctor = new Doctor(txtUsuario.Text, txtContrasenia.Text);
                                if (doctor.validarDoctor())
                                {
                                    MessageBox.Show("Bienvenido al sistema", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    desplazar();
                                    this.Hide();
                                    FrmDoctor frmDoctor = new FrmDoctor();
                                    doctor.asignarEspecialidad(doctor.Especialidad.IdEspecialidad);
                                    frmDoctor.asignarDoctor(doctor);
                                    frmDoctor.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Usuario no existe", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                break;
                            case "RECEPCIONISTA":
                                Recepcionista recepcionista = new Recepcionista(txtUsuario.Text, txtContrasenia.Text);
                                if (recepcionista.validarRecepcionista())
                                {
                                    MessageBox.Show("Bienvenido al sistema", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    desplazar();
                                    this.Hide();
                                    FrmRecepcionista frmRecepcionista = new FrmRecepcionista();
                                    frmRecepcionista.asignarRecepcionista(recepcionista);
                                    frmRecepcionista.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Usuario no existe", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                break;
                            case "FARMACEÚTICO":
                                Farmaceutico farmaceutico = new Farmaceutico(txtUsuario.Text, txtContrasenia.Text);
                                if (farmaceutico.validarFarmaceutico())
                                {
                                    MessageBox.Show("Bienvenido al sistema", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    desplazar();
                                    this.Hide();
                                    FrmFarmaceutico frmFarmaceutico = new FrmFarmaceutico();
                                    frmFarmaceutico.asignarFarmaceutico(farmaceutico);
                                    frmFarmaceutico.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Usuario no existe", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                break;
                            case "PACIENTE":
                                Paciente paciente = new Paciente(txtUsuario.Text, txtContrasenia.Text);
                                if (paciente.validarPaciente())
                                {
                                    MessageBox.Show("Bienvenido al sistema", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    desplazar();
                                    this.Hide();
                                    FrmPaciente frmPaciente = new FrmPaciente();
                                    frmPaciente.asignarPaciente(paciente);
                                    frmPaciente.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Usuario no existe", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese la contraseñia", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el usuario", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un MODO", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbxModo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxModo.Text == "PACIENTE")
            {
                lblUsuario.Text = "CÉDULA";
            }
            else
            {
                lblUsuario.Text = "USUARIO";
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                e.Handled = true;
                return;
            }
        }

        private void txtContrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                e.Handled = true;
                return;
            }
        }
        private void desplazar()
        {
            Point punto = new Point(this.Location.X, this.Location.Y);
            for (int i = 0; i < 500; i++)
            {
                punto.X += 1;
                this.Location = punto;
            }
        }
        
    }
}
