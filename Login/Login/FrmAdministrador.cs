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
                pnlMenu.Width = 50;
                btnMenu.Location = new Point(4,16);
            }
            else
            {
                panelExtendido();
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

        private void tmrFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }
    }
}
