using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Login.Clases;
namespace Login
{
    public partial class FrmRegistroEspecialidad : Form
    {
        private Administrador administrador;
        private Especialidad especialidad;
        List<Especialidad> especialidades = new List<Especialidad>();
        public FrmRegistroEspecialidad()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarTextos();
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = true;
        }
        public void asignarAdministrador(Object administrador)
        {
            this.administrador = (Administrador)administrador;
        }
        public void llenarDataGridView()
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblEspecialidad";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            especialidad = new Especialidad();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    especialidad.IdEspecialidad = reader.GetInt32(0);
                    especialidad.NombreEspecialidad= reader.GetString(1);
                    especialidad.Descripcion = reader.GetString(2);
                    especialidades.Add(especialidad);
                    especialidad = new Especialidad();
                }
                DataBase.cerrarConexion(conexion);
                DataTable tbl = new DataTable();
                tbl.Columns.Add("Código");
                tbl.Columns.Add("Nombre");
                tbl.Columns.Add("Descripción");
                foreach (var aux in especialidades)
                {
                    tbl.Rows.Add(aux.IdEspecialidad, aux.NombreEspecialidad, aux.Descripcion);
                }
                dgvEspecialidades.DataSource = tbl;
            }
        }

        private void dgvEspecialidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvEspecialidades.SelectedRows.Count > 0)//Verifica que el usuario seleccione más de una fila
                {
                    especialidad = new Especialidad();
                    especialidad.IdEspecialidad= Convert.ToInt32(dgvEspecialidades.Rows[e.RowIndex].Cells[0].Value.ToString());
                    especialidad.NombreEspecialidad = dgvEspecialidades.Rows[e.RowIndex].Cells[1].Value.ToString();
                    especialidad.Descripcion = dgvEspecialidades.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtNombre.Text = especialidad.NombreEspecialidad;
                    txtDescripcion.Text = especialidad.Descripcion;
                    btnActualizar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnGuardar.Enabled = false;
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Seleccione una fila correcta", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void limpiarTextos()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text != "")
            {
                if(txtDescripcion.Text != "")
                {
                    try
                    {
                        especialidad = new Especialidad(0, txtNombre.Text, txtDescripcion.Text);
                        if (administrador.ingresarEspecialidad(especialidad))
                        {
                            MessageBox.Show("Especialidad ingresada con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiarTextos();
                        }
                        else
                            MessageBox.Show("La especialidad ya se encuentra registrada", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch
                    {
                        MessageBox.Show("Error de ingreso de datos", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("El campo Descripción no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("El campo Nombre no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro en eliminar la especialidad?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                if (administrador.eliminarEspecialidad(especialidad.IdEspecialidad))
                {
                    MessageBox.Show("Especialidad eliminada", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnActualizar.Enabled = false;
                    btnEliminar.Enabled = false;
                    limpiarTextos();
                }
                else
                    MessageBox.Show("La especialidad no se pudo eliminar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                if (txtDescripcion.Text != "")
                {
                    DialogResult resultado = MessageBox.Show("¿Desea actualizar la especialidad?", "IESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        try
                        {
                            especialidad.NombreEspecialidad = txtNombre.Text;
                            especialidad.Descripcion = txtDescripcion.Text;
                            if (administrador.modificarEspecialidad(especialidad))
                            {
                                MessageBox.Show("Especialidad modificada con éxito", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnActualizar.Enabled = false;
                                btnEliminar.Enabled = false;
                                limpiarTextos();
                            }
                            else
                                MessageBox.Show("La especialidad no se pudo modificar", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        catch
                        {
                            MessageBox.Show("Error de ingreso de datos", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("El campo Descripción no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("El campo Nombre no puede estar vacío", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
