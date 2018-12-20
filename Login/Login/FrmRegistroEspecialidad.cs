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
    public partial class FrmRegistroEspecialidad : Form
    {
        public FrmRegistroEspecialidad()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmIngresarEspecialidad frmIngresarEspecialidad = new FrmIngresarEspecialidad();
            frmIngresarEspecialidad.Show();
        }

        
    }
}
