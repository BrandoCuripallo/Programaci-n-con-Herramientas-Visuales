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
    public partial class FrmRegistroHistoriaClinica : Form
    {
        public FrmRegistroHistoriaClinica()
        {
            InitializeComponent();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            FrmIngresarAtencion frmAtencion = new FrmIngresarAtencion();
            frmAtencion.Show();
        }
    }
}
