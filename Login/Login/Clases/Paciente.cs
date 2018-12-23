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

        public Paciente(string contraseniaPaciente, List<CitaMedica> citas, List<AtencionQuirurgica> cirugias, List<Factura> facturas, List<Receta> recetas)
        {
            this.ContraseniaPaciente = contraseniaPaciente;
            this.Citas = citas;
            this.Cirugias = cirugias;
            this.Facturas = facturas;
            this.Recetas = recetas;
        }

        public string ContraseniaPaciente { get => contraseniaPaciente; set => contraseniaPaciente = value; }
        internal List<CitaMedica> Citas { get => citas; set => citas = value; }
        internal List<AtencionQuirurgica> Cirugias { get => cirugias; set => cirugias = value; }
        internal List<Factura> Facturas { get => facturas; set => facturas = value; }
        internal List<Receta> Recetas { get => recetas; set => recetas = value; }
    }
}
