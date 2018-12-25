using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    class Farmaceutico : Persona
    {
        private string usuario;
        private string contrasenia;
        private List<Factura> facturas;

        public Farmaceutico(string usuario, string contrasenia)
        {
            this.Usuario = usuario;
            this.Contrasenia = contrasenia;
            facturas = new List<Factura>();
        }

        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        internal List<Factura> Facturas { get => facturas; set => facturas = value; }
    }
}
