using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Recepcionista
    {
        private string usuario;
        private string contrasenia;
        private List<CitaMedica> citas;

        public Recepcionista(string usuario, string contrasenia, List<CitaMedica> citas)
        {
            this.Usuario = usuario;
            this.Contrasenia = contrasenia;
            this.Citas = citas;
        }

        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        internal List<CitaMedica> Citas { get => citas; set => citas = value; }
    }
}
