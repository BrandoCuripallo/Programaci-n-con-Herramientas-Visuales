using System;
using System.Collections.Generic;
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
    }
}
