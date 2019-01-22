using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Login.Clases
{
    class Farmaceutico : Persona
    {
        private string usuario;
        private string contrasenia;
        private List<Factura> facturas;
        public Farmaceutico()
        {

        }
        public Farmaceutico(string usuario, string contrasenia)
        {
            this.Usuario = usuario;
            this.Contrasenia = contrasenia;
            facturas = new List<Factura>();
        }

        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        internal List<Factura> Facturas { get => facturas; set => facturas = value; }
        public bool validarFarmaceutico()
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblFarmaceutico WHERE usuario = '" + Usuario+ "' AND contrasenia = '" + Contrasenia + "'";
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
        public DataTable buscarFacturas()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Número de Factura");
            tbl.Columns.Add("Cédula del Paciente");
            tbl.Columns.Add("Nombres");
            tbl.Columns.Add("Apellido");
            tbl.Columns.Add("Fecha de Emisión");
            tbl.Columns.Add("Total");
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT idFactura, tblFactura.cedulaPaciente, tblPaciente.nombres, tblPaciente.apellidoPaterno, fechaEmision, total " +
                "FROM tblFactura INNER JOIN tblPaciente ON tblPaciente.cedulaPaciente = tblFactura.cedulaPaciente WHERE cedulaFarmaceutico = '" + Cedula + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tbl.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), Convert.ToDouble(Convert.ToString(reader.GetSqlMoney(5))));
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
            return tbl;
        }
        public Medicamento buscarMedicamentoPorNombre(string nombre)
        {
            Medicamento medicamento = new Medicamento();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblMedicamento WHERE nombreMedicamento = '" + nombre + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                medicamento.CodigoMedicamento = reader.GetString(0);
                medicamento.NombreMedicamento = reader.GetString(1);
                medicamento.Descripcion = reader.GetString(2);
                medicamento.Stock = reader.GetInt32(3);
                medicamento.PrecioUnitario = Convert.ToDouble(Convert.ToString(reader.GetSqlMoney(4)));
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return medicamento;
            }
            else
            {
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return null;
            }
        }
        public bool modificarStock(Medicamento medicamento, int cantidad)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "UPDATE tblMedicamento SET stock = " + cantidad + " WHERE codigoMedicamento = '" + medicamento.CodigoMedicamento + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            if (comando.ExecuteNonQuery() > 0)
            {
                DataBase.cerrarConexion(conexion);
                return true;
            }
            else
            {
                DataBase.cerrarConexion(conexion);
                return false;
            }
        }
        public Paciente buscarPaciente(string cedula)
        {
            Paciente paciente = new Paciente();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblPaciente WHERE cedulaPaciente = '" + cedula + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                paciente.Cedula = reader.GetString(0);
                paciente.Nombres = reader.GetString(1);
                paciente.ApellidoPaterno = reader.GetString(2);
                paciente.ApellidoMaterno = reader.GetString(3);
                paciente.setFechaNacimiento(reader.GetDateTime(4));
                paciente.Sexo = reader.GetString(5);
                paciente.CorreoElectronico = reader.GetString(6);
                paciente.Provincia = reader.GetString(7);
                paciente.Canton = reader.GetString(8);
                paciente.Direccion = reader.GetString(9);
                paciente.Telefono = reader.GetString(10);
                paciente.calcularEdad();
                paciente.ContraseniaPaciente = reader.GetString(11);
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return paciente;
            }
            else
            {
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return null;
            }
        }
        public bool ingresarFactura(Factura factura)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblFactura WHERE idFactura = " + factura.IdFactura + "";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return false;
            }
            else
            {
                reader.Close();
                consulta = "INSERT INTO tblFactura VALUES ('" + factura.Farmaceutico.Cedula + "', '" + factura.Paciente.Cedula + "', '" +
                    factura.FechaEmision + "', " + factura.Total + ")";
                comando = new SqlCommand(consulta, conexion);
                if (comando.ExecuteNonQuery() > 0)
                {
                    foreach (var aux in factura.Detalles)
                    {
                        consulta = "INSERT INTO tblMedicamentoFactura VALUES (" + factura.IdFactura + ", '" + aux.Medicamento.CodigoMedicamento + "', " + aux.Cantidad + ", " + aux.Subtotal + ")";
                        comando = new SqlCommand(consulta, conexion);
                        if (comando.ExecuteNonQuery() > 0)
                            continue;
                    }
                    DataBase.cerrarConexion(conexion);
                    return true;
                }
                else
                {
                    DataBase.cerrarConexion(conexion);
                    return false;
                }
            }
        }
        public bool modificarFactura(Factura factura, List<Detalle> detallesAnteriores)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "UPDATE tblFactura SET cedulaFarmaceutico = '" + factura.Farmaceutico.Cedula + "', cedulaPaciente = '" + factura.Paciente.Cedula + "', fechaEmision = '" +
                    factura.FechaEmision + "', total = " + factura.Total + " WHERE idFactura = " + factura.IdFactura;
            SqlCommand comando = new SqlCommand(consulta, conexion);
            if (comando.ExecuteNonQuery() > 0)
            {
                foreach (var aux in factura.Detalles)
                {
                    consulta = "DELETE FROM tblMedicamentoFactura WHERE idFactura = " + factura.IdFactura;
                    comando = new SqlCommand(consulta, conexion);
                }
                if (comando.ExecuteNonQuery() > 0)
                {
                    foreach (var aux in detallesAnteriores)
                    {
                        consulta = "INSERT INTO tblMedicamentoFactura VALUES (" + factura.IdFactura + ", '" + aux.Medicamento.CodigoMedicamento + "', " + aux.Cantidad + ", " + aux.Subtotal + ")";
                        comando = new SqlCommand(consulta, conexion);
                        if (comando.ExecuteNonQuery() > 0)
                            continue;
                    }
                    DataBase.cerrarConexion(conexion);
                    return true;
                }
                else
                {
                    DataBase.cerrarConexion(conexion);
                    return false;
                }
            }
            else
            {
                DataBase.cerrarConexion(conexion);
                return false;
            }
        }
        public bool eliminarFactura(int idFactura)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "DELETE FROM tblFactura WHERE idFactura = " + idFactura;
            SqlCommand comando = new SqlCommand(consulta, conexion);
            if (comando.ExecuteNonQuery() > 0)
            {
                DataBase.cerrarConexion(conexion);
                return true;
            }
            else
            {
                DataBase.cerrarConexion(conexion);
                return false;
            }
        }
        public Factura buscarFactura(int idFactura)
        {
            int id = 1;
            Factura factura = new Factura();
            Detalle detalle = new Detalle();
            Medicamento medicamento = new Medicamento();
            Farmaceutico farmaceutico = new Farmaceutico();
            Paciente paciente = new Paciente();
            List<Detalle> detalles = new List<Detalle>();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblFactura WHERE idFactura = " + idFactura;
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                factura.IdFactura = reader.GetInt32(0);
                farmaceutico.Cedula = reader.GetString(1);
                factura.Farmaceutico = farmaceutico;
                paciente.Cedula = reader.GetString(2);
                factura.Paciente = paciente;
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
                    return factura;
                }
                else
                {
                    reader.Close();
                    DataBase.cerrarConexion(conexion);
                    return null;
                }
            }
            else
            {
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return null;
            }
        }
    }
}
