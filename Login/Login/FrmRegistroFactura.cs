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
    public partial class FrmRegistroFactura : Form
    {
        public FrmRegistroFactura()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmIngresarFactura frmIngresarFactura = new FrmIngresarFactura();
            frmIngresarFactura.Show();
        }
    }
}
