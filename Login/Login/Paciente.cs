using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class Paciente : Persona
    {
        private string contraseniaPaciente;

        public Paciente()
        {
        }


        public Paciente(string cedula, string nombres, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, int edad, string sexo, string correoElectronico, string provincia, string ciudad, string direccion, string telefono, string contraseniaPaciente) : base(cedula, nombres, apellidoPaterno, apellidoMaterno, fechaNacimiento, edad, sexo, correoElectronico, provincia, ciudad, direccion, telefono)
        {
            this.ContraseniaPaciente = contraseniaPaciente;
        }

        public string ContraseniaPaciente { get => contraseniaPaciente; set => contraseniaPaciente = value; }
    }
}
