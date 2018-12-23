using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    class Administrador : Persona
    {
        private string usuario;
        private string constrasenia;

        public Administrador(string usuario, string constrasenia)
        {
            this.Usuario = usuario;
            this.Constrasenia = constrasenia;
        }

        public string Usuario { get => usuario; set => usuario = value; }
        public string Constrasenia { get => constrasenia; set => constrasenia = value; }
    }
}
