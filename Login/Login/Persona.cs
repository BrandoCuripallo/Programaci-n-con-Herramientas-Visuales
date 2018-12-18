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
        private string ciudad;
        private string direccion;
        private string telefono;

        public Persona()
        {
        }

        public Persona(string cedula, string nombres, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, int edad, string sexo, string correoElectronico, string provincia, string ciudad, string direccion, string telefono)
        {
            this.Cedula = cedula;
            this.Nombres = nombres;
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
            this.FechaNacimiento = fechaNacimiento;
            this.Edad = edad;
            this.Sexo = sexo;
            this.CorreoElectronico = correoElectronico;
            this.Provincia = provincia;
            this.Ciudad = ciudad;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
