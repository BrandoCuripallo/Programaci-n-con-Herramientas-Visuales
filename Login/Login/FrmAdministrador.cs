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
    public partial class FrmAdministrador : Form
    {
        public FrmAdministrador()
        {
            InitializeComponent();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            if (pnlPacientes.Visible == false)
            {
                btnFarmacia.Location = new Point(0, 271);
                pnlPacientes.Visible = true;
                pnlFarmacia.Visible = false;
                pnlLogistica.Visible = false;
                btnLogista.Location = new Point(0, 314);
                btnSalir.Location = new Point(0, 357);
                panelExtendido();
            }
            else
            {
                btnPosicionInicial();
            }   
        }
        
        private void btnFarmacia_Click(object sender, EventArgs e)
        {
            if (pnlFarmacia.Visible == false)
            {
                btnFarmacia.Location = new Point(0, 99);
                pnlPacientes.Visible = false;
                pnlFarmacia.Visible = true;
                pnlLogistica.Visible = false;
                btnLogista.Location = new Point(0, 271);
                btnSalir.Location = new Point(0, 314);
                panelExtendido();
            }
            else
            {
                btnPosicionInicial();
            }
        }

        private void btnLogista_Click(object sender, EventArgs e)
        {
            if (pnlLogistica.Visible == false)
            {
                btnFarmacia.Location = new Point(0, 99);
                pnlPacientes.Visible = false;
                pnlFarmacia.Visible = false;
                pnlLogistica.Visible = true;
                btnLogista.Location = new Point(0, 142);
                btnSalir.Location = new Point(0, 357);
                panelExtendido();
            }
            else
            {
                btnPosicionInicial();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if(pnlMenu.Width == 167)
            {
                tmrOcultar.Enabled = true;
                btnMenu.Location = new Point(4,16);
            }
            else
            {
                tmrMostrar.Enabled = true;
                btnMenu.Location = new Point(127, 16);
            }
        }
        private void btnPosicionInicial()
        {
            btnFarmacia.Location = new Point(0, 99);
            pnlPacientes.Visible = false;
            pnlFarmacia.Visible = false;
            pnlLogistica.Visible = false;
            btnLogista.Location = new Point(0, 142);
            btnSalir.Location = new Point(0, 185);
        }
        private void panelExtendido()
        {
            pnlMenu.Width = 167;
            btnMenu.Location = new Point(127, 16);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void abrirFormHijo(object frmHijo)
        {
            if(pnlContenedor.Controls.Count > 0)//Verificamos si el panel tiene controles y los eliminamos
                pnlContenedor.Controls.RemoveAt(0);
            Form fh = frmHijo as Form;//El objeto recibido lo convertimos en objeto Fromulario
            fh.TopLevel = false;//Se especifica que se un fomrulario secundario
            fh.Dock = DockStyle.Fill;//Permite que el formulario ocupe todo el panel
            pnlContenedor.Controls.Add(fh);//Añadimos el formulario recibido al panel
            pnlContenedor.Tag = fh;
            fh.Show();//Mostramos el formulario
        }
        private void tmrFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }

        private void btnRegistros_Click(object sender, EventArgs e)
        {
            FrmRegistroPaciente frmRegistroPaciente = new FrmRegistroPaciente();
            abrirFormHijo(frmRegistroPaciente);
        }

        private void btnFarmaceuticos_Click(object sender, EventArgs e)
        {
            FrmRegistroFarmaceutico frmRegistroFarmaceutico = new FrmRegistroFarmaceutico();
            abrirFormHijo(frmRegistroFarmaceutico);
        }

        private void btnCirugias_Click(object sender, EventArgs e)
        {
            FrmRegistroCirugia frmRegistroCirugia = new FrmRegistroCirugia();
            abrirFormHijo(frmRegistroCirugia);
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            FrmRegistroEspecialidad frmRegistroEspecialidad = new FrmRegistroEspecialidad();
            abrirFormHijo(frmRegistroEspecialidad);
        }

        private void btnMedicamentos_Click(object sender, EventArgs e)
        {
            FrmRegistroMedicamento frmRegistroMedicamento = new FrmRegistroMedicamento();
            abrirFormHijo(frmRegistroMedicamento);
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            FrmRegistroDoctor frmRegistroDoctor = new FrmRegistroDoctor();
            abrirFormHijo(frmRegistroDoctor);
        }

        private void btnRecepcionistas_Click(object sender, EventArgs e)
        {
            FrmRegistroRecepcionista frmRegistroRecepcionista = new FrmRegistroRecepcionista();
            abrirFormHijo(frmRegistroRecepcionista);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Close();
        }

        private void FrmAdministrador_Load(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            abrirFormHijo(frmInicio);
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            FrmRegistroCita frmRegistroCita = new FrmRegistroCita();
            abrirFormHijo(frmRegistroCita);
        }

        private void btnRecetasMedicas_Click(object sender, EventArgs e)
        {
            FrmRegistroReceta frmRegistroReceta = new FrmRegistroReceta();
            abrirFormHijo(frmRegistroReceta);
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            FrmRegistroFactura frmRegistroFactura = new FrmRegistroFactura();
            abrirFormHijo(frmRegistroFactura);
        }

        private void btnHistoriasClinicas_Click(object sender, EventArgs e)
        {
            FrmHistoriaClinica frmHistoriaClinica = new FrmHistoriaClinica();
            abrirFormHijo(frmHistoriaClinica);
        }

        private void tmrMostrar_Tick(object sender, EventArgs e)
        {
            for(int i = 50; i <= 167; i++)
            {
                pnlMenu.Width = i;
            }
            btnPosicionInicial();
            tmrMostrar.Enabled = false;
        }

        private void tmrOcultar_Tick(object sender, EventArgs e)
        {
            for (int i = 167; i >= 50; i--)
            {
                pnlMenu.Width = i;
            }
            btnPosicionInicial();
            tmrOcultar.Enabled = false;
        }
    }
}
