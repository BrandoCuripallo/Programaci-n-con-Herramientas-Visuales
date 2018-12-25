using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class Persona
    {
        private string cedula;
        private string nombres;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private DateTime fechaNacimiento;
        private int edad;
        private string sexo;
        private string correoElectronico;
        private string provincia;
        private string canton;
        private string direccion;
        private string telefono;

        public Persona()
        {
        }

        public Persona(string cedula, string nombres, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, int edad, string sexo, string correoElectronico, string provincia, string canton, string direccion, string telefono)
        {
            this.Cedula = cedula;
            this.Nombres = nombres;
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
            this.setFechaNacimiento(fechaNacimiento);
            this.Edad = edad;
            this.Sexo = sexo;
            this.CorreoElectronico = correoElectronico;
            this.Provincia = provincia;
            this.Canton = canton;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
       public void setFechaNacimiento(DateTime fechaNacimiento)
        {
            this.fechaNacimiento = fechaNacimiento;
        }
        public string getFechaNacimiento()
        {
            return fechaNacimiento.Day + "/" + fechaNacimiento.Month + "/" + fechaNacimiento.Year;
        }
        public int Edad { get => edad; set => edad = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Canton { get => canton; set => canton= value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public void calcularEdad()
        {
            if(DateTime.Today.Month < fechaNacimiento.Month)
                edad = Convert.ToInt16(DateTime.Today.Year) - Convert.ToInt16(fechaNacimiento.Year) + 1;
            else
            {
                if (DateTime.Today.Day < fechaNacimiento.Day)
                    edad = Convert.ToInt16(DateTime.Today.Year) - Convert.ToInt16(fechaNacimiento.Year) + 1;
                else
                    edad = Convert.ToInt16(DateTime.Today.Year) - Convert.ToInt16(fechaNacimiento.Year);
            }
        }
    }
}
