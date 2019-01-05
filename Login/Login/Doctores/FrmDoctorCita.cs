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
namespace Login.Doctores
{
    public partial class FrmDoctorCita : Form
    {
        Doctor doctor;
        public FrmDoctorCita()
        {
            InitializeComponent();
        }
        public void asignarDoctor(Object doctor)
        {
            this.doctor = (Doctor)doctor;
        }
        public void llenarDataGridView()
        {
            DataTable tbl = doctor.buscarCitas();
            dgvCitas.DataSource = tbl;
        }
    }
}
