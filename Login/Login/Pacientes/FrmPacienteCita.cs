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
using System.Data.SqlClient;
namespace Login.Pacientes
{
    public partial class FrmPacienteCita : Form
    {
        Paciente paciente;
        List<Atencion> atenciones = new List<Atencion>();
        public FrmPacienteCita()
        {
            InitializeComponent();
        }
        public void asignarPaciente(Object paciente)
        {
            this.paciente = (Paciente)paciente;
        }
        public void llenarDataGridView()
        {
            DataTable tbl = paciente.buscarCitas();
            dgvCitas.DataSource = tbl;
        }
    }
}
