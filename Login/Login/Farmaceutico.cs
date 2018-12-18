using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class Farmaceutico : Persona
    {
        private string usuarioFarmaceutico;
        private string contraseniaFarmaceutico;

        public Farmaceutico()
        {
        }


        public Farmaceutico(string cedula, string nombres, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, int edad, string sexo, string correoElectronico, string provincia, string ciudad, string direccion, string telefono, string usuarioFarmaceutico, string contraseniaFarmaceutico) : base(cedula, nombres, apellidoPaterno, apellidoMaterno, fechaNacimiento, edad, sexo, correoElectronico, provincia, ciudad, direccion, telefono)
        {
            this.UsuarioFarmaceutico = usuarioFarmaceutico;
            this.ContraseniaFarmaceutico = contraseniaFarmaceutico;
        }

        public string UsuarioFarmaceutico { get => usuarioFarmaceutico; set => usuarioFarmaceutico = value; }
        public string ContraseniaFarmaceutico { get => contraseniaFarmaceutico; set => contraseniaFarmaceutico = value; }
    }
}
