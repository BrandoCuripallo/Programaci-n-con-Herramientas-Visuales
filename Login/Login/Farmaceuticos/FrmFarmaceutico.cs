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
namespace Login.Farmaceuticos
{
    public partial class FrmFarmaceutico : Form
    {
        Farmaceutico farmaceutico;
        public FrmFarmaceutico()
        {
            InitializeComponent();
        }
        public void asignarFarmaceutico(Object farmaceutico)
        {
            this.farmaceutico = (Farmaceutico)farmaceutico;
        }
        private void tmrFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }
        private void tmrMostrar_Tick(object sender, EventArgs e)
        {
            for (int i = 50; i <= 167; i++)
            {
                pnlMenu.Width = i;
            }
            tmrMostrar.Enabled = false;
        }
        private void tmrOcultar_Tick(object sender, EventArgs e)
        {
            for (int i = 167; i >= 50; i--)
            {
                pnlMenu.Width = i;
            }
            tmrOcultar.Enabled = false;
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
            if (pnlContenedor.Controls.Count > 0)//Verificamos si el panel tiene controles y los eliminamos
                pnlContenedor.Controls.RemoveAt(0);
            Form fh = frmHijo as Form;//El objeto recibido lo convertimos en objeto Fromulario
            fh.TopLevel = false;//Se especifica que se un fomrulario secundario
            fh.Dock = DockStyle.Fill;//Permite que el formulario ocupe todo el panel
            pnlContenedor.Controls.Add(fh);//Añadimos el formulario recibido al panel
            pnlContenedor.Tag = fh;
            fh.Show();//Mostramos el formulario
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Width == 167)
            {
                tmrOcultar.Enabled = true;
                btnMenu.Location = new Point(4, 16);
            }
            else
            {
                tmrMostrar.Enabled = true;
                btnMenu.Location = new Point(127, 16);
            }
        }
        private void FrmFarmaceutico_Load(object sender, EventArgs e)
        {
            lblNombre.Text = farmaceutico.Nombres + " " + farmaceutico.ApellidoPaterno + " " + farmaceutico.ApellidoMaterno;
            FrmInicio frmInicio = new FrmInicio();
            abrirFormHijo(frmInicio);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usted acaba de salir del sistema", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Close();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Width != 167)
                panelExtendido();
            FrmFarmaceuticoFactura frmFarmaceuticoFactura = new FrmFarmaceuticoFactura();
            frmFarmaceuticoFactura.asignarFarmaceutico(this.farmaceutico);
            frmFarmaceuticoFactura.llenarDataGridView();
            frmFarmaceuticoFactura.llenarMedicamentos();
            pnlFacturas.Visible = true;
            abrirFormHijo(frmFarmaceuticoFactura);
        }
    }
}
