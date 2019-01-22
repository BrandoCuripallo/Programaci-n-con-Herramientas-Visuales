using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    class Doctor : Persona
    {
        private string usuarioDoctor;
        private string contraseniaDoctor;
        private Especialidad especialidad;
        private List<CitaMedica> citas;
        private List<Atencion> atenciones;
        private List<AtencionQuirurgica> cirugias;
        public Doctor()
        {

        }
        public Doctor(string usuario, string contrasenia)
        {
            this.usuarioDoctor = usuario;
            this.contraseniaDoctor = contrasenia;
        }
        public Doctor(string usuarioDoctor, string contraseniaDoctor, Especialidad especialidad, List<CitaMedica> citas, List<Atencion> atenciones, List<AtencionQuirurgica> cirugias)
        {
            this.UsuarioDoctor = usuarioDoctor;
            this.ContraseniaDoctor = contraseniaDoctor;
            this.Especialidad = especialidad;
            this.Citas = citas;
            this.Atenciones = atenciones;
            this.Cirugias = cirugias;
        }

        public string UsuarioDoctor { get => usuarioDoctor; set => usuarioDoctor = value; }
        public string ContraseniaDoctor { get => contraseniaDoctor; set => contraseniaDoctor = value; }
        internal Especialidad Especialidad { get => especialidad; set => especialidad = value; }
        internal List<CitaMedica> Citas { get => citas; set => citas = value; }
        internal List<Atencion> Atenciones { get => atenciones; set => atenciones = value; }
        internal List<AtencionQuirurgica> Cirugias { get => cirugias; set => cirugias = value; }
        public bool validarDoctor()
        {
            Especialidad especialidad = new Especialidad();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblDoctor WHERE usuario = '" + usuarioDoctor+ "' AND contrasenia = '" + ContraseniaDoctor + "'";
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
                especialidad.IdEspecialidad = reader.GetInt32(13);
                this.Especialidad = especialidad;
                this.calcularEdad();
                reader.Close();
                DataBase.cerrarConexion(conexion);
                return true;
            }
            reader.Close();
            DataBase.cerrarConexion(conexion);
            return false;
        }
        public void asignarEspecialidad(int idEspecialidad)
        {
            Especialidad especialidad = new Especialidad();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblEspecialidad WHERE codigoEspecialidad = " + idEspecialidad;
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            especialidad.IdEspecialidad = reader.GetInt32(0);
            especialidad.NombreEspecialidad = reader.GetString(1);
            especialidad.Descripcion = reader.GetString(2);
            reader.Close();
            DataBase.cerrarConexion(conexion);
            this.Especialidad = especialidad;
        }
        public DataTable buscarCitas()
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT idCita, fechaCita, tblcitaMedica.descripcion, tblPaciente.nombres, tblPaciente.apellidoPaterno, tblPaciente.apellidoMaterno" +
                " FROM tblCitaMedica INNER JOIN tblPaciente ON tblCitaMedica.cedulaPaciente = tblPaciente.cedulaPaciente INNER JOIN tblDoctor ON " + 
                "tblCitaMedica.cedulaDoctor = tblDoctor.cedulaDoctor WHERE tblCitaMedica.cedulaDoctor = '" + Cedula + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Número de Cita");
            tbl.Columns.Add("Fecha de la Cita");
            tbl.Columns.Add("Motivo de la Cita");
            tbl.Columns.Add("Nombres del Paciente");
            tbl.Columns.Add("Apellido Paterno");
            tbl.Columns.Add("Apellido Materno");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tbl.Rows.Add(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
            return tbl;
        }
        public DataTable buscarHistoriasClinicas()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Número de Historia Clínica");
            tbl.Columns.Add("Cédula del Paciente");
            tbl.Columns.Add("Nombres");
            tbl.Columns.Add("Apellido Paterno");
            tbl.Columns.Add("Apellido Materno");
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT numeroHistoria, tblPaciente.cedulaPaciente, nombres, apellidoPaterno, apellidoMaterno FROM tblHistoriaClinica INNER JOIN " +
                "tblPaciente ON tblHistoriaClinica.cedulaPaciente = tblPaciente.cedulaPaciente";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tbl.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
            return tbl;
        }
        public List<Atencion> buscarAtenciones(int numeroHistoriaClinica)
        {
            int id = 1;
            Atencion atencion = new Atencion();
            List<Atencion> atenciones = new List<Atencion>();
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT fecha, temperaturaPaciente, altura, peso, diagnostico, indicaciones FROM tblHistoriaClinicaDoctor " +
                "WHERE numeroHistoria = " + numeroHistoriaClinica + " AND cedulaDoctor = '" + Cedula + "'";
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
                    atenciones.Add(atencion);
                    atencion = new Atencion();
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
                        aux.Altura + ", " + aux.Peso + ", '" + aux.Diagnostico + "', '" + aux.Indicaciones + "', '" + Cedula + "')";
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
            consulta = "DELETE FROM tblHistoriaClinicaDoctor WHERE numeroHistoria = " + historiaClinica.NumeroHistoria + " AND cedulaDoctor = '" + Cedula + "'";
            comando = new SqlCommand(consulta, conexion);
            if (comando.ExecuteNonQuery() > 0)
            {
                foreach (var aux in atencionesAnteriores)
                {
                    consulta = "INSERT INTO tblHistoriaClinicaDoctor VALUES (" + historiaClinica.NumeroHistoria + ", '" + aux.FechaAtencion + "', " + aux.Temperatura + ", " +
                        aux.Altura + ", " + aux.Peso + ", '" + aux.Diagnostico + "', '" + aux.Indicaciones + "', '" + Cedula + "')";
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
        public DataTable buscarRecetas()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Número de Receta");
            tbl.Columns.Add("Fecha de Emisión");
            tbl.Columns.Add("Cédula del Paciente");
            tbl.Columns.Add("Nombres");
            tbl.Columns.Add("Apellido");
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT idReceta, fechaEmision, tblReceta.cedulaPaciente, tblPaciente.nombres, tblPaciente.apellidoPaterno FROM tblReceta " +
                "INNER JOIN tblPaciente ON tblReceta.cedulaPaciente = tblPaciente.cedulaPaciente WHERE cedulaDoctor = '" + Cedula + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tbl.Rows.Add(reader.GetInt32(0), reader.GetDateTime(1).ToString("hh/MM/yy"), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);

            }
            return tbl;
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
                consulta = "INSERT INTO tblReceta VALUES ('" + receta.Paciente.Cedula + "', '" + Cedula + "', '" + receta.FechaEmision + "')";
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
            string consulta = "UPDATE tblReceta SET fechaEmision = '" + receta.FechaEmision + "' WHERE idReceta = " + receta.IdReceta;
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
        public DataTable buscarCirugias()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Número de Cirugía");
            tbl.Columns.Add("Fecha de la Cirugía");
            tbl.Columns.Add("Cédula del Paciente");
            tbl.Columns.Add("Nombres");
            tbl.Columns.Add("Apellido");
            tbl.Columns.Add("Tipo de Cirugía");
            tbl.Columns.Add("Motivo de la Cirugía");
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT idCirugiaPaciente, fecha, tblCirugiaPaciente.cedulaPaciente, tblPaciente.nombres, tblPaciente.apellidoPaterno, tblCirugia.nombreCirugia, " +
                "tblCirugiaPaciente.descripcion FROM tblCirugiaPaciente INNER JOIN tblPaciente ON tblCirugiaPaciente.cedulaPaciente = tblPaciente.cedulaPaciente " + 
                "INNER JOIN tblCirugia ON tblCirugia.idCirugia = tblCirugiaPaciente.idCirugia WHERE cedulaDoctor = '" + Cedula + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
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
        public AtencionQuirurgica buscarOperacionQuirurgica(int idAtencionQuirurgica)
        {
            Cirugia cirugia;
            Paciente paciente;
            AtencionQuirurgica atencionQuirurgica;
            Doctor doc;
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT idCirugiaPaciente, fecha, tblCirugiaPaciente.cedulaPaciente, tblPaciente.nombres, tblPaciente.apellidoPaterno, tblCirugia.nombreCirugia, " +
                "tblCirugiaPaciente.descripcion, tblDoctor.cedulaDoctor, tblDoctor.nombres, tblDoctor.apellidoPaterno FROM tblCirugiaPaciente INNER JOIN " +
                "tblPaciente ON tblCirugiaPaciente.cedulaPaciente = tblPaciente.cedulaPaciente " + "INNER JOIN tblCirugia ON tblCirugia.idCirugia = tblCirugiaPaciente.idCirugia " +
                "INNER JOIN tblDoctor ON tblCirugiaPaciente.cedulaDoctor = tblDoctor.cedulaDoctor WHERE idCirugiaPaciente = " + idAtencionQuirurgica;
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            cirugia = new Cirugia();
            doc = new Doctor();
            paciente = new Paciente();
            atencionQuirurgica = new AtencionQuirurgica();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    atencionQuirurgica.IdAtencionQuirurgica = reader.GetInt32(0);
                    atencionQuirurgica.FechaCirugia = reader.GetDateTime(1);
                    paciente.Cedula = reader.GetString(2);
                    paciente.Nombres = reader.GetString(3);
                    paciente.ApellidoPaterno = reader.GetString(4);
                    atencionQuirurgica.Paciente = paciente;
                    cirugia.NombreCirugia = reader.GetString(5);
                    atencionQuirurgica.Cirugia = cirugia;
                    atencionQuirurgica.Descripcion = reader.GetString(6);
                    doc.Cedula = reader.GetString(7);
                    doc.Nombres = reader.GetString(8);
                    doc.ApellidoPaterno = reader.GetString(9);
                    atencionQuirurgica.Doctor = doc;
                }
                reader.Close();
                DataBase.cerrarConexion(conexion);
            }
            return atencionQuirurgica;
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
        public bool validarFechaCirugia(DateTime fechaCirugia, string cedulaDoctor)
        {
            SqlConnection conexion = DataBase.obtenerConexion();
            string consulta = "SELECT * FROM tblCirugiaPaciente WHERE cedulaDoctor = '" + cedulaDoctor + "' AND fecha = '" + fechaCirugia + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                DataBase.cerrarConexion(conexion);
                return false;
            }
            else
            {
                DataBase.cerrarConexion(conexion);
                return true;
            }
        }
    }
}
