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
        /*
         * Métodos de conexión a la DB para la Especialidad
         */
        public bool modificarEspecialidad(Especialidad especialidad)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta ="UPDATE tblEspecialidad SET nombreEspecialidad = '" + especialidad.NombreEspecialidad + "', descripcion = '" + especialidad.Descripcion +
                "' WHERE codigoEspecialidad = " + especialidad.IdEspecialidad;
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
        public bool eliminarEspecialidad(int idEspecialidad)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "DELETE FROM tblEspecialidad WHERE codigoEspecialidad = '" + idEspecialidad + "'";
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
        public bool ingresarEspecialidad(Especialidad especialidad)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblEspecialidad WHERE nombreEspecialidad = '" + especialidad.NombreEspecialidad + "'";
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
                consulta = "INSERT INTO tblEspecialidad VALUES ('" + especialidad.NombreEspecialidad + "', '" + especialidad.Descripcion + "')";
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
        /*************************************************************************/
        /*
         * Métodos de conexión a la DB para el Farmaceútico
         */
        public bool eliminarFarmaceutico(string cedula)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "DELETE FROM tblFarmaceutico WHERE cedulaFarmaceutico = '" + cedula + "'";
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
        public Farmaceutico buscarFarmaceutico(string cedula)
        {
            Farmaceutico farmaceutico = new Farmaceutico(); ;
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblFarmaceutico WHERE cedulaFarmaceutico = '" + cedula + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                farmaceutico.Cedula = reader.GetString(0);
                farmaceutico.Nombres = reader.GetString(1);
                farmaceutico.ApellidoPaterno = reader.GetString(2);
                farmaceutico.ApellidoMaterno = reader.GetString(3);
                farmaceutico.setFechaNacimiento(reader.GetDateTime(4));
                farmaceutico.Sexo = reader.GetString(5);
                farmaceutico.CorreoElectronico = reader.GetString(6);
                farmaceutico.Provincia = reader.GetString(7);
                farmaceutico.Canton = reader.GetString(8);
                farmaceutico.Direccion = reader.GetString(9);
                farmaceutico.Telefono = reader.GetString(10);
                farmaceutico.Usuario = reader.GetString(11);
                farmaceutico.Contrasenia = reader.GetString(12);
                farmaceutico.calcularEdad();
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return farmaceutico;
            }
            else
            {
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return null;
            }
        }
        public bool modificarFarmaceutico(Farmaceutico farmaceutico, string cedula)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "UPDATE tblFarmaceutico SET cedulaFarmaceutico = '" + farmaceutico.Cedula + "', nombres = '" + farmaceutico.Nombres + "', apellidoPaterno = '" +
                    farmaceutico.ApellidoPaterno + "', apellidoMaterno = '" + farmaceutico.ApellidoMaterno + "', fechaNacimiento = '" + farmaceutico.getFechaNacimiento() + "', sexo = '" + farmaceutico.Sexo + "', correoElectronico = '" +
                    farmaceutico.CorreoElectronico + "', provincia = '" + farmaceutico.Provincia + "', ciudad = '" + farmaceutico.Canton + "', direccion = '" + farmaceutico.Direccion
                    + "', telefono = '" + farmaceutico.Telefono + "', usuario = '" + farmaceutico.Usuario + "', contrasenia = '" + farmaceutico.Contrasenia+ "' WHERE cedulaFarmaceutico = '" + cedula + "'";
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
        public bool ingresarFarmaceutico(Farmaceutico farmaceutico)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblFarmaceutico WHERE cedulaFarmaceutico = '" + farmaceutico.Cedula + "'";
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
                consulta = "INSERT INTO tblFarmaceutico VALUES ('" + farmaceutico.Cedula + "', '" + farmaceutico.Nombres + "', '" + farmaceutico.ApellidoPaterno + "', '" +
                    farmaceutico.ApellidoMaterno + "', '" + farmaceutico.getFechaNacimiento() + "', '" + farmaceutico.Sexo + "', '" + farmaceutico.CorreoElectronico + "', '" +
                    farmaceutico.Provincia + "', '" + farmaceutico.Canton + "', '" + farmaceutico.Direccion + "', '" + farmaceutico.Telefono + "', '" + farmaceutico.Usuario+ "', '" + farmaceutico.Contrasenia + "')";
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
        /*************************************************************************/
        /*
         * Métodos de conexión a la DB para el Paciente
         */
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
        /*************************************************************************/
        /*
         * Métodos de conexión a la DB para el Doctor
         */
        public bool ingresarDoctor(Doctor doctor)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblDoctor WHERE cedulaDoctor = '" + doctor.Cedula + "'";
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
                consulta = "INSERT INTO tblDoctor VALUES ('" + doctor.Cedula + "', '" + doctor.Nombres + "', '" + doctor.ApellidoPaterno + "', '" +
                    doctor.ApellidoMaterno + "', '" + doctor.getFechaNacimiento() + "', '" + doctor.Sexo + "', '" + doctor.CorreoElectronico + "', '" +
                    doctor.Provincia + "', '" + doctor.Canton + "', '" + doctor.Direccion + "', '" + doctor.Telefono + "', '" + doctor.UsuarioDoctor + "', '" +
                    doctor.ContraseniaDoctor + "', " + doctor.Especialidad.IdEspecialidad + ")";
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
        public bool modificarDoctor(Doctor doctor, string cedula)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "UPDATE tblDoctor SET cedulaDoctor = '" + doctor.Cedula + "', nombres = '" + doctor.Nombres + "', apellidoPaterno = '" +
                    doctor.ApellidoPaterno + "', apellidoMaterno = '" + doctor.ApellidoMaterno + "', fechaNacimiento = '" + doctor.getFechaNacimiento() + 
                    "', sexo = '" + doctor.Sexo + "', correoElectronico = '" + doctor.CorreoElectronico + "', provincia = '" + doctor.Provincia + "', ciudad = '" 
                    + doctor.Canton + "', direccion = '" + doctor.Direccion + "', telefono = '" + doctor.Telefono + "', usuario = '" + doctor.UsuarioDoctor + 
                    "', contrasenia = '" + doctor.ContraseniaDoctor + "', codigoEspecialidad = " + doctor.Especialidad.IdEspecialidad + " WHERE cedulaDoctor = '" + cedula + "'";
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
        public bool eliminarDoctor(string cedula)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "DELETE FROM tblDoctor WHERE cedulaDoctor = '" + cedula + "'";
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
        public Doctor buscarDoctor(string cedula)
        {
            Doctor doctor = new Doctor();
            Especialidad especialidad = new Especialidad();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblDoctor LEFT JOIN tblEspecialidad ON tblDoctor.codigoEspecialidad = tblEspecialidad.codigoEspecialidad";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                doctor.Cedula = reader.GetString(0);
                doctor.Nombres = reader.GetString(1);
                doctor.ApellidoPaterno = reader.GetString(2);
                doctor.ApellidoMaterno = reader.GetString(3);
                doctor.setFechaNacimiento(reader.GetDateTime(4));
                doctor.Sexo = reader.GetString(5);
                doctor.CorreoElectronico = reader.GetString(6);
                doctor.Provincia = reader.GetString(7);
                doctor.Canton = reader.GetString(8);
                doctor.Direccion = reader.GetString(9);
                doctor.Telefono = reader.GetString(10);
                doctor.UsuarioDoctor= reader.GetString(11);
                doctor.ContraseniaDoctor= reader.GetString(12);
                especialidad.IdEspecialidad = reader.GetInt32(13);
                especialidad.NombreEspecialidad = reader.GetString(15);
                especialidad.Descripcion = reader.GetString(16);
                doctor.Especialidad = especialidad;
                doctor.calcularEdad();
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return doctor;
            }
            else
            {
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return null;
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
        /*************************************************************************/
        /*
         * Métodos de conexión a la DB para la Cirugía
         */
        public bool ingresarCirugia(Cirugia cirugia)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblCirugia WHERE nombreCirugia = '" + cirugia.NombreCirugia + "'";
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
                consulta = "INSERT INTO tblCirugia VALUES ('" + cirugia.NombreCirugia + "')";
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
        public bool eliminarCirugia(int idCirugia)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "DELETE FROM tblCirugia WHERE idCirugia = '" + idCirugia + "'";
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
        public bool modificarCirugia(Cirugia cirugia)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "UPDATE tblCirugia SET nombreCirugia = '" + cirugia.NombreCirugia + "' WHERE idCirugia = " + cirugia.IdCirugia;
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
