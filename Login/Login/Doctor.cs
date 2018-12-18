using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class Doctor : Persona
    {
        private string usuarioDoctor;
        private string contraseniaDoctor;
        private string especialidad;

        public Doctor()
        {
        }

        public Doctor(string cedula, string nombres, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, int edad, string sexo, string correoElectronico, string provincia, string ciudad, string direccion, string telefono, string usuarioDoctor, string contraseniaDoctor, string especialidad) : base(cedula, nombres, apellidoPaterno, apellidoMaterno, fechaNacimiento, edad, sexo, correoElectronico, provincia, ciudad, direccion, telefono)
        {
            this.UsuarioDoctor = usuarioDoctor;
            this.ContraseniaDoctor = contraseniaDoctor;
            this.Especialidad = especialidad;
        }

        public string UsuarioDoctor { get => usuarioDoctor; set => usuarioDoctor = value; }
        public string ContraseniaDoctor { get => contraseniaDoctor; set => contraseniaDoctor = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
    }
}
