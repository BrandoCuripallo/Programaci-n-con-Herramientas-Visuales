using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    class Paciente : Persona
    {
        private string contraseniaPaciente;
        private List<CitaMedica> citas;
        private List<AtencionQuirurgica> cirugias;
        private List<Factura> facturas;
        private List<Receta> recetas;
        public Paciente()
        {

        }
        public Paciente(string cedula, string contraseniaPaciente)
        {
            Cedula = cedula;
            this.ContraseniaPaciente = contraseniaPaciente;
            this.Citas = new List<CitaMedica>();
            this.Cirugias = new List<AtencionQuirurgica>();
            this.Facturas = new List<Factura>();
            this.Recetas = new List<Receta>();
        }

        public string ContraseniaPaciente { get => contraseniaPaciente; set => contraseniaPaciente = value; }
        internal List<CitaMedica> Citas { get => citas; set => citas = value; }
        internal List<AtencionQuirurgica> Cirugias { get => cirugias; set => cirugias = value; }
        internal List<Factura> Facturas { get => facturas; set => facturas = value; }
        internal List<Receta> Recetas { get => recetas; set => recetas = value; }
    }
}
