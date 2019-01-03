using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    class Recepcionista : Persona
    {
        private string usuario;
        private string contrasenia;
        private List<CitaMedica> citas;
        public Recepcionista()
        {

        }
        public Recepcionista(string usuario, string contrasenia)
        {
            this.Usuario = usuario;
            this.Contrasenia = contrasenia;
            citas = new List<CitaMedica>();
        }

        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        internal List<CitaMedica> Citas { get => citas; set => citas = value; }
        public bool validarRecepcionista()
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblRecepcionista " +
                "WHERE usuario = '" + Usuario + "' AND contrasenia = '" + Contrasenia + "'";
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
            string consulta = "SELECT idCita, fechaCita, tblCitaMedica.cedulaPaciente, tblPaciente.nombres, tblPaciente.apellidoPaterno, nombreEspecialidad, " +
                "tblcitaMedica.descripcion, tblDoctor.nombres, tblDoctor.apellidoPaterno FROM tblCitaMedica INNER JOIN tblPaciente ON tblCitaMedica.cedulaPaciente = tblPaciente.cedulaPaciente " + 
                "INNER JOIN tblEspecialidad ON tblCitaMedica.codigoEspecialidad = tblEspecialidad.codigoEspecialidad INNER JOIN tblDoctor ON tblCitaMedica.cedulaDoctor = tblDoctor.cedulaDoctor " + 
                "INNER JOIN tblRecepcionista ON tblCitaMedica.cedulaRecepcionista = tblRecepcionista.cedulaRecepcionista WHERE tblCitaMedica.cedulaRecepcionista = '" + Cedula + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Número de Cita");
            tbl.Columns.Add("Fecha de la Cita");
            tbl.Columns.Add("Cédula del Paciente");
            tbl.Columns.Add("Nombres");
            tbl.Columns.Add("Apellido Paterno");
            tbl.Columns.Add("Especialidad");
            tbl.Columns.Add("Motivo de la Cita");
            tbl.Columns.Add("Nombre del Doctor");
            tbl.Columns.Add("Apellido");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tbl.Rows.Add(reader.GetInt32(0), reader.GetDateTime(1).ToString("dd/MM/yy"), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));
                }
            }
            reader.Close();
            DataBase.cerrarConexion(conexion);
            return tbl;

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
        public bool ingresarCitaMedica(CitaMedica citaMedica)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "INSERT INTO tblCitaMedica VALUES ('" + citaMedica.FechaCita + "', '" + citaMedica.Descripcion + "', '" + citaMedica.Paciente.Cedula + "', " +
                citaMedica.Especialidad.IdEspecialidad + ", '" + citaMedica.Recepcionista.Cedula + "', '" + citaMedica.Doctor.Cedula + "')";
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
    }
}
