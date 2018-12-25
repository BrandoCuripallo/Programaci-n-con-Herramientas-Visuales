using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Login.Clases
{
    class Administrador : Persona
    {
        private string usuario;
        private string contrasenia;

        public Administrador(string usuario, string contrasenia)
        {
            this.Usuario = usuario;
            this.Contrasenia = contrasenia;
        }

        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public bool eliminarPaciente(string cedula)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "DELETE FROM tblPaciente WHERE cedulaPaciente = '" + cedula + "'";
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
            Paciente paciente = new Paciente(); ;
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
        public bool modificarPaciente(Paciente paciente, string cedula)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "UPDATE tblPaciente SET cedulaPaciente = '" + paciente.Cedula + "', nombres = '" + paciente.Nombres + "', apellidoPaterno = '" +
                    paciente.ApellidoPaterno + "', apellidoMaterno = '" + paciente.ApellidoMaterno + "', fechaNacimiento = '" + paciente.getFechaNacimiento() + "', sexo = '" + paciente.Sexo + "', correoElectronico = '" +
                    paciente.CorreoElectronico + "', provincia = '" + paciente.Provincia + "', ciudad = '" + paciente.Canton + "', direccion = '" + paciente.Direccion
                    + "', telefono = '" + paciente.Telefono + "', contrasenia = '" + paciente.ContraseniaPaciente + "' WHERE cedulaPaciente = '" + cedula + "'";
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
        public bool ingresarPaciente(Paciente paciente)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblPaciente WHERE cedulaPaciente = '" + paciente.Cedula + "'";
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
                consulta = "INSERT INTO tblPaciente VALUES ('" + paciente.Cedula + "', '" + paciente.Nombres + "', '" + paciente.ApellidoPaterno + "', '" +
                    paciente.ApellidoMaterno + "', '" + paciente.getFechaNacimiento() + "', '" + paciente.Sexo + "', '" + paciente.CorreoElectronico + "', '" +
                    paciente.Provincia + "', '" + paciente.Canton + "', '" + paciente.Direccion + "', '" + paciente.Telefono + "', '" + paciente.ContraseniaPaciente + "')";
                comando = new SqlCommand(consulta, conexion);
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
        public bool validarAdministrador()
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblAdministrador WHERE usuario = '" + Usuario + "' AND contrasenia = '" + Contrasenia + "'";
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
    }
}
