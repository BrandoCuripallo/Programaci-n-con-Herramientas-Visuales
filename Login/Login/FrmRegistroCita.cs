﻿using System;
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
    public partial class FrmRegistroCita : Form
    {
        public FrmRegistroCita()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmIngresarCita frmIngresarCita = new FrmIngresarCita();
            frmIngresarCita.Show();
        }
    }
}