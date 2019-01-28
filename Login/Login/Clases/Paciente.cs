using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Login.Clases
{
    class Paciente : Persona
    {
        private string contraseniaPaciente;
        private List<CitaMedica> citas;
        private List<AtencionQuirurgica> cirugias;
        private List<Factura> facturas;
        private List<Receta> recetas;
        public Paciente()
        {

        }
        public Paciente(string cedula, string contraseniaPaciente)
        {
            Cedula = cedula;
            this.ContraseniaPaciente = contraseniaPaciente;
            this.Citas = new List<CitaMedica>();
            this.Cirugias = new List<AtencionQuirurgica>();
            this.Facturas = new List<Factura>();
            this.Recetas = new List<Receta>();
        }

        public string ContraseniaPaciente { get => contraseniaPaciente; set => contraseniaPaciente = value; }
        internal List<CitaMedica> Citas { get => citas; set => citas = value; }
        internal List<AtencionQuirurgica> Cirugias { get => cirugias; set => cirugias = value; }
        internal List<Factura> Facturas { get => facturas; set => facturas = value; }
        internal List<Receta> Recetas { get => recetas; set => recetas = value; }
        public bool validarPaciente()
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblPaciente WHERE cedulaPaciente = '" + Cedula + "' AND contrasenia = '" + ContraseniaPaciente + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Cedula = reader.GetString(0);
                Nombres = reader.GetString(1);
                ApellidoPaterno = reader.GetString(2);
                ApellidoMaterno = reader.GetString(3);
                this.setFechaNacimiento(reader.GetDateTime(4));
                Sexo = reader.GetString(5);
                CorreoElectronico = reader.GetString(6);
                Provincia = reader.GetString(7);
                Canton = reader.GetString(8);
                Direccion = reader.GetString(9);
                Telefono = reader.GetString(10);
                this.calcularEdad();
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return true;
            }
            reader.Close();
            DataBase.cerrarConexion(conexion);
            return false;
        }
        public DataTable buscarCitas()
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT idCita, fechaCita, nombreEspecialidad, tblcitaMedica.descripcion, tblDoctor.nombres, tblDoctor.apellidoPaterno, estado" +
                " FROM tblCitaMedica INNER JOIN tblPaciente " +
                "ON tblCitaMedica.cedulaPaciente = tblPaciente.cedulaPaciente INNER JOIN tblEspecialidad ON tblCitaMedica.codigoEspecialidad = tblEspecialidad.codigoEspecialidad " +
                "INNER JOIN tblDoctor ON tblCitaMedica.cedulaDoctor = tblDoctor.cedulaDoctor WHERE tblCitaMedica.cedulaPaciente = '" + Cedula + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Número de Cita");
            tbl.Columns.Add("Fecha de la Cita");
            tbl.Columns.Add("Especialidad");
            tbl.Columns.Add("Motivo de la Cita");
            tbl.Columns.Add("Nombres del Doctor");
            tbl.Columns.Add("Apellido");
            tbl.Columns.Add("Estado");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tbl.Rows.Add(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
            return tbl;
        }
        public DataTable buscarRecetas()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Número de Receta");
            tbl.Columns.Add("Fecha de Emisión");
            tbl.Columns.Add("Nombres del Doctor");
            tbl.Columns.Add("Apellido del Doctor");
            tbl.Columns.Add("Especialidad");
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT idReceta, fechaEmision, tblDoctor.nombres, tblDoctor.apellidoPaterno, tblEspecialidad.nombreEspecialidad " + 
                "FROM tblReceta INNER JOIN tblPaciente ON tblReceta.cedulaPaciente = tblPaciente.cedulaPaciente INNER JOIN tblDoctor ON " + 
                "tblDoctor.cedulaDoctor = tblReceta.cedulaDoctor INNER JOIN tblEspecialidad ON tblDoctor.codigoEspecialidad = tblEspecialidad.codigoEspecialidad " + 
                "WHERE tblReceta.cedulaPaciente = '" + Cedula + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tbl.Rows.Add(reader.GetInt32(0), reader.GetDateTime(1).ToString("dd/MM/yy"), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
            return tbl;
        }
        public Receta buscarReceta(int idReceta)
        {
            int id = 1;
            Receta receta = new Receta();
            Indicacion indicacion = new Indicacion();
            Medicamento medicamento = new Medicamento();
            Doctor doctor = new Doctor();
            List<Indicacion> indicaciones = new List<Indicacion>();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblReceta WHERE idReceta = " + idReceta;
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                receta.IdReceta = reader.GetInt32(0);
                doctor.Cedula = reader.GetString(2);
                receta.Doctor = doctor;
                receta.FechaEmision = reader.GetDateTime(3);
                reader.Close();
                consulta = "SELECT * FROM tblRecetaMedicamento INNER JOIN tblMedicamento ON tblRecetaMedicamento.codigoMedicamento = tblMedicamento.codigoMedicamento WHERE idReceta = " + idReceta;
                comando = new SqlCommand(consulta, conexion);
                SqlDataReader reader2 = comando.ExecuteReader();
                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        indicacion.NumeroIndicacion = id++;
                        medicamento.CodigoMedicamento = reader2.GetString(1);
                        medicamento.NombreMedicamento = reader2.GetString(4);
                        indicacion.Medicamento = medicamento;
                        indicacion.Indicaciones = reader2.GetString(2);
                        indicaciones.Add(indicacion);
                        indicacion = new Indicacion();
                        medicamento = new Medicamento();
                    }
                    receta.Indicaciones = indicaciones;
                    reader2.Close();
                    DataBase.cerrarConexion(conexion);
                }
            }
            return receta;
        }
        public DataTable buscarFacturas()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Número de Factura");
            tbl.Columns.Add("Cédula del Farmaceútico");
            tbl.Columns.Add("Fecha de Emisión");
            tbl.Columns.Add("Total");
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblFactura WHERE cedulaPaciente = '" + Cedula + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tbl.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(3), Convert.ToDouble(Convert.ToString(reader.GetSqlMoney(4))));
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
            return tbl;
        }
        public Factura buscarFactura(int idFactura)
        {
            int id = 1;
            Factura factura = new Factura();
            Detalle detalle = new Detalle();
            Medicamento medicamento = new Medicamento();
            List<Detalle> detalles = new List<Detalle>();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblFactura WHERE idFactura = " + idFactura;
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                factura.IdFactura = reader.GetInt32(0);
                factura.FechaEmision = reader.GetDateTime(3);
                factura.Total = Convert.ToDouble(Convert.ToString(reader.GetSqlMoney(4)));
                reader.Close();
                consulta = "SELECT * FROM tblMedicamentoFactura INNER JOIN tblMedicamento ON tblMedicamentoFactura.codigoMedicamento = tblMedicamento.codigoMedicamento WHERE idFactura = " + idFactura;
                comando = new SqlCommand(consulta, conexion);
                SqlDataReader reader2 = comando.ExecuteReader();
                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        detalle.IdDetalle = id++;
                        medicamento.CodigoMedicamento = reader2.GetString(4);
                        medicamento.NombreMedicamento = reader2.GetString(5);
                        medicamento.PrecioUnitario = Convert.ToDouble(Convert.ToString(reader2.GetSqlMoney(8)));
                        detalle.Medicamento = medicamento;
                        detalle.Cantidad = reader2.GetInt32(2);
                        detalle.Subtotal = Convert.ToDouble(Convert.ToString(reader2.GetSqlMoney(3)));
                        detalles.Add(detalle);
                        detalle = new Detalle();
                        medicamento = new Medicamento();
                    }
                    factura.Detalles = detalles;
                    reader2.Close();
                    DataBase.cerrarConexion(conexion);
                }
            }
            return factura;
        }
    }
}
