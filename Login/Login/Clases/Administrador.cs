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
            string consulta = "UPDATE tblEspecialidad SET nombreEspecialidad = '" + especialidad.NombreEspecialidad + "', descripcion = '" + especialidad.Descripcion +
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
        public Especialidad buscarEspecialidadPorNombre(string nombre)
        {
            Especialidad especialidad = new Especialidad();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblEspecialidad WHERE nombreEspecialidad = '" + nombre + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                especialidad.IdEspecialidad = reader.GetInt32(0);
                especialidad.NombreEspecialidad = reader.GetString(1);
                especialidad.Descripcion = reader.GetString(2);
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return especialidad;
            }
            else
            {
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return null;
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
            Farmaceutico farmaceutico = new Farmaceutico();
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
                    + "', telefono = '" + farmaceutico.Telefono + "', usuario = '" + farmaceutico.Usuario + "', contrasenia = '" + farmaceutico.Contrasenia + "' WHERE cedulaFarmaceutico = '" + cedula + "'";
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
                    farmaceutico.Provincia + "', '" + farmaceutico.Canton + "', '" + farmaceutico.Direccion + "', '" + farmaceutico.Telefono + "', '" + farmaceutico.Usuario + "', '" + farmaceutico.Contrasenia + "')";
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
                    consulta = "INSERT INTO tblHistoriaClinica VALUES ('" + paciente.Cedula + "')";
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
            string consulta = "SELECT * FROM tblDoctor LEFT JOIN tblEspecialidad ON tblDoctor.codigoEspecialidad = tblEspecialidad.codigoEspecialidad WHERE tblDoctor.cedulaDoctor = '" + cedula + "'";
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
                doctor.UsuarioDoctor = reader.GetString(11);
                doctor.ContraseniaDoctor = reader.GetString(12);
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
        public Cirugia buscarCirugiaPorNombre(string nombre)
        {
            Cirugia cirugia = new Cirugia();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblCirugia WHERE nombreCirugia = '" + nombre + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                cirugia.IdCirugia = reader.GetInt32(0);
                cirugia.NombreCirugia = reader.GetString(1);
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return cirugia;
            }
            else
            {
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return null;
            }
        }
        /*************************************************************************/
        /*
         * Métodos de conexión a la DB para el Medicamento
         */
        public bool ingresarMedicamento(Medicamento medicamento)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblMedicamento WHERE codigoMedicamento = '" + medicamento.CodigoMedicamento + "'";
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
                consulta = "INSERT INTO tblMedicamento VALUES ('" + medicamento.CodigoMedicamento + "', '" + medicamento.NombreMedicamento + "', '" +
                    medicamento.Descripcion + "', " + medicamento.Stock + ", " + medicamento.PrecioUnitario + ")";
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
        public bool modificarMedicamento(Medicamento medicamento, string codigo)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "UPDATE tblMedicamento SET codigoMedicamento = '" + medicamento.CodigoMedicamento + "', nombreMedicamento = '" + medicamento.NombreMedicamento +
                "', descripcion = '" + medicamento.Descripcion + "', stock = " + medicamento.Stock + ", precioUnitario = " + medicamento.PrecioUnitario + " WHERE codigoMedicamento = '" + codigo + "'";
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
        public Medicamento buscarMedicamento(string codigo)
        {
            Medicamento medicamento = new Medicamento();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblMedicamento WHERE codigoMedicamento = '" + codigo + "'";
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
        public bool eliminarMedicamento(string codigo)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "DELETE FROM tblMedicamento WHERE codigoMedicamento = '" + codigo + "'";
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
        /*************************************************************************/
        /*
         * Métodos de conexión a la DB para el Recepcionista
         */
        public bool eliminarRecepcionista(string cedula)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "DELETE FROM tblRecepcionista WHERE cedulaRecepcionista = '" + cedula + "'";
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
        public Recepcionista buscarRecepcionista(string cedula)
        {
            Recepcionista recepcionista = new Recepcionista();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblRecepcionista WHERE cedulaRecepcionista = '" + cedula + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                recepcionista.Cedula = reader.GetString(0);
                recepcionista.Nombres = reader.GetString(1);
                recepcionista.ApellidoPaterno = reader.GetString(2);
                recepcionista.ApellidoMaterno = reader.GetString(3);
                recepcionista.setFechaNacimiento(reader.GetDateTime(4));
                recepcionista.Sexo = reader.GetString(5);
                recepcionista.CorreoElectronico = reader.GetString(6);
                recepcionista.Provincia = reader.GetString(7);
                recepcionista.Canton = reader.GetString(8);
                recepcionista.Direccion = reader.GetString(9);
                recepcionista.Telefono = reader.GetString(10);
                recepcionista.Usuario = reader.GetString(11);
                recepcionista.Contrasenia = reader.GetString(12);
                recepcionista.calcularEdad();
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return recepcionista;
            }
            else
            {
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return null;
            }
        }
        public bool modificarRecepcionista(Recepcionista recepcionista, string cedula)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "UPDATE tblRecepcionista SET cedulaRecepcionista = '" + recepcionista.Cedula + "', nombres = '" + recepcionista.Nombres + "', apellidoPaterno = '" +
                    recepcionista.ApellidoPaterno + "', apellidoMaterno = '" + recepcionista.ApellidoMaterno + "', fechaNacimiento = '" + recepcionista.getFechaNacimiento() + "', sexo = '" + recepcionista.Sexo + "', correoElectronico = '" +
                    recepcionista.CorreoElectronico + "', provincia = '" + recepcionista.Provincia + "', ciudad = '" + recepcionista.Canton + "', direccion = '" + recepcionista.Direccion
                    + "', telefono = '" + recepcionista.Telefono + "', usuario = '" + recepcionista.Usuario + "', contrasenia = '" + recepcionista.Contrasenia + "' WHERE cedulaRecepcionista = '" + cedula + "'";
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
        public bool ingresarRecepcionista(Recepcionista recepcionista)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblRecepcionista WHERE cedulaRecepcionista = '" + recepcionista.Cedula + "'";
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
                consulta = "INSERT INTO tblRecepcionista VALUES ('" + recepcionista.Cedula + "', '" + recepcionista.Nombres + "', '" + recepcionista.ApellidoPaterno + "', '" +
                    recepcionista.ApellidoMaterno + "', '" + recepcionista.getFechaNacimiento() + "', '" + recepcionista.Sexo + "', '" + recepcionista.CorreoElectronico + "', '" +
                    recepcionista.Provincia + "', '" + recepcionista.Canton + "', '" + recepcionista.Direccion + "', '" + recepcionista.Telefono + "', '" + recepcionista.Usuario + "', '" + recepcionista.Contrasenia + "')";
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
         * Métodos de conexión a la DB para la Factura
         */
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
        /*************************************************************************/
        /*
         * Métodos de conexión a la DB para la Cita
         */
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
        public bool modificarCitaMedica(CitaMedica citaMedica)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "UPDATE tblCitaMedica SET fechaCita = '" + citaMedica.FechaCita + "', descripcion = '" + citaMedica.Descripcion + "', cedulaPaciente = '" +
                    citaMedica.Paciente.Cedula + "', codigoEspecialidad = '" + citaMedica.Especialidad.IdEspecialidad + "', cedulaRecepcionista = '" + citaMedica.Recepcionista.Cedula +
                    "', cedulaDoctor = '" + citaMedica.Doctor.Cedula + "' WHERE idCita = " + citaMedica.NumeroCita;
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
        public bool eliminarCitaMedica(int idCita)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "DELETE FROM tblCitaMedica WHERE idCita = '" + idCita + "'";
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
        /*************************************************************************/
        /*
         * Métodos de conexión a la DB para la Operacion Quirúrgica
         */
        public bool ingresarOperacionQuirurgica(AtencionQuirurgica atencionQuirurgica)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "INSERT INTO tblCirugiaPaciente VALUES (" + atencionQuirurgica.Cirugia.IdCirugia + ", '" + atencionQuirurgica.Doctor.Cedula + "', '" +
                atencionQuirurgica.Paciente.Cedula + "', '" + atencionQuirurgica.Descripcion + "', '" + atencionQuirurgica.FechaCirugia + "')";
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
        public bool modificarOperacionQuirurgica(AtencionQuirurgica atencionQuirurgica)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "UPDATE tblCirugiaPaciente SET idCirugia = " + atencionQuirurgica.Cirugia.IdCirugia + ", cedulaDoctor = '" + atencionQuirurgica.Doctor.Cedula +
                "', cedulaPaciente = '" + atencionQuirurgica.Paciente.Cedula + "', descripcion = '" + atencionQuirurgica.Descripcion + "', fecha = '" + atencionQuirurgica.FechaCirugia +
                "' WHERE idCirugiaPaciente = " + atencionQuirurgica.IdAtencionQuirurgica;
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
        public bool eliminarOperacionQuirurgica(int idAtencionQuirurgica)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "DELETE FROM tblCirugiaPaciente WHERE idCirugiaPaciente = '" + idAtencionQuirurgica + "'";
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
        /*************************************************************************/
        /*
         * Métodos de conexión a la DB para la Receta
         */
        public bool ingresarReceta(Receta receta)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblReceta WHERE idReceta = " + receta.IdReceta + "";
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
                consulta = "INSERT INTO tblReceta VALUES ('" + receta.Paciente.Cedula + "', '" + receta.Doctor.Cedula + "', '" + receta.FechaEmision + "')";
                comando = new SqlCommand(consulta, conexion);
                if (comando.ExecuteNonQuery() > 0)
                {
                    foreach (var aux in receta.Indicaciones)
                    {
                        consulta = "INSERT INTO tblRecetaMedicamento VALUES (" + receta.IdReceta + ", '" + aux.Medicamento.CodigoMedicamento + "', '" + aux.Indicaciones + "')";
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
        public bool modificarReceta(Receta receta, List<Indicacion> indicacionesAnteriores)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "UPDATE tblReceta SET cedulaPaciente = '" + receta.Paciente.Cedula + "', cedulaDoctor = '" + receta.Doctor.Cedula + "', fechaEmision = '" +
                    receta.FechaEmision + "' WHERE idReceta = " + receta.IdReceta;
            SqlCommand comando = new SqlCommand(consulta, conexion);
            if (comando.ExecuteNonQuery() > 0)
            {
                consulta = "DELETE FROM tblRecetaMedicamento WHERE idReceta = " + receta.IdReceta;
                comando = new SqlCommand(consulta, conexion);
                if (comando.ExecuteNonQuery() > 0)
                {
                    foreach (var aux in indicacionesAnteriores)
                    {
                        consulta = "INSERT INTO tblRecetaMedicamento VALUES (" + receta.IdReceta + ", '" + aux.Medicamento.CodigoMedicamento + "', '" + aux.Indicaciones + "')";
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
        public bool eliminarReceta(int idReceta)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "DELETE FROM tblReceta WHERE idReceta = " + idReceta;
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
        public Receta buscarReceta(int idReceta)
        {
            int id = 1;
            Receta receta = new Receta();
            Indicacion indicacion = new Indicacion();
            Medicamento medicamento = new Medicamento();
            Doctor doctor = new Doctor();
            Paciente paciente = new Paciente();
            List<Indicacion> indicaciones = new List<Indicacion>();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblReceta WHERE idReceta = " + idReceta;
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                receta.IdReceta = reader.GetInt32(0);
                paciente.Cedula = reader.GetString(1);
                receta.Paciente = paciente;
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
                    return receta;
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
        /*************************************************************************/
        /*
         * Métodos de conexión a la DB para la Atención Médica
         */
        public bool ingresarAtenciones(HistoriaClinica historiaClinica)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta;
            SqlCommand comando;
            try
            {
                foreach (var aux in historiaClinica.Atenciones)
                {
                    consulta = "INSERT INTO tblHistoriaClinicaDoctor VALUES (" + historiaClinica.NumeroHistoria + ", '" + aux.FechaAtencion + "', " + aux.Temperatura + ", " +
                        aux.Altura + ", " + aux.Peso + ", '" + aux.Diagnostico + "', '" + aux.Indicaciones + "', '" + aux.Doctor.Cedula + "')";
                    comando = new SqlCommand(consulta, conexion);
                    if (comando.ExecuteNonQuery() > 0)
                        continue;
                }
                DataBase.cerrarConexion(conexion);
                return true;
            }
            catch
            {
                DataBase.cerrarConexion(conexion);
                return false;
            }
        }
        public bool modificarAtenciones(HistoriaClinica historiaClinica, List<Atencion> atencionesAnteriores)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta;
            SqlCommand comando;
            consulta = "DELETE FROM tblHistoriaClinicaDoctor WHERE numeroHistoria = " + historiaClinica.NumeroHistoria;
            comando = new SqlCommand(consulta, conexion);
            if (comando.ExecuteNonQuery() > 0)
            {
                foreach (var aux in atencionesAnteriores)
                {
                    consulta = "INSERT INTO tblHistoriaClinicaDoctor VALUES (" + historiaClinica.NumeroHistoria + ", '" + aux.FechaAtencion + "', " + aux.Temperatura + ", " +
                        aux.Altura + ", " + aux.Peso + ", '" + aux.Diagnostico + "', '" + aux.Indicaciones + "', '" + aux.Doctor.Cedula + "')";
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
        public List<Atencion> buscarAtenciones(int numeroHistoriaClinica)
        {
            int id = 1;
            Atencion atencion = new Atencion();
            Doctor doctor = new Doctor();
            Especialidad especialidad = new Especialidad();
            List<Atencion> atenciones = new List<Atencion>();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT fecha, temperaturaPaciente, altura, peso, diagnostico, indicaciones, tblDoctor.cedulaDoctor, nombres, apellidoPaterno, " +
                "tblEspecialidad.nombreEspecialidad FROM tblHistoriaClinicaDoctor INNER JOIN tblDoctor ON tblHistoriaClinicaDoctor.cedulaDoctor = tblDoctor.cedulaDoctor " +
                "INNER JOIN tblEspecialidad ON tblDoctor.codigoEspecialidad = tblEspecialidad.codigoEspecialidad WHERE numeroHistoria = " + numeroHistoriaClinica;
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    atencion.IdAtencion = id++;
                    atencion.FechaAtencion = reader.GetDateTime(0);
                    atencion.Temperatura = reader.GetDouble(1);
                    atencion.Altura = reader.GetDouble(2);
                    atencion.Peso = reader.GetDouble(3);
                    atencion.Diagnostico = reader.GetString(4);
                    atencion.Indicaciones = reader.GetString(5);
                    doctor.Cedula = reader.GetString(6);
                    doctor.Nombres = reader.GetString(7);
                    doctor.ApellidoPaterno = reader.GetString(8);
                    especialidad.NombreEspecialidad = reader.GetString(9);
                    doctor.Especialidad = especialidad;
                    atencion.Doctor = doctor;
                    atenciones.Add(atencion);
                    atencion = new Atencion();
                    doctor = new Doctor();
                    especialidad = new Especialidad();
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return atenciones;
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
