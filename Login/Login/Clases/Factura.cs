using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    class Factura
    {
        private int idFactura;
        private Farmaceutico farmaceutico;
        private Paciente paciente;
        private DateTime fechaEmision;
        private List<Detalle> detalles;
        private float total;

        public Factura(int idFactura, Farmaceutico farmaceutico, Paciente paciente, DateTime fechaEmision, List<Detalle> detalles)
        {
            this.IdFactura = idFactura;
            this.Farmaceutico = farmaceutico;
            this.Paciente = paciente;
            this.FechaEmision = fechaEmision;
            this.Detalles = detalles;
        }

        public int IdFactura { get => idFactura; set => idFactura = value; }
        public Farmaceutico Farmaceutico { get => farmaceutico; set => farmaceutico = value; }
        public DateTime FechaEmision { get => fechaEmision; set => fechaEmision = value; }
        internal Paciente Paciente { get => paciente; set => paciente = value; }
        internal List<Detalle> Detalles { get => detalles; set => detalles = value; }
        public void calcularTotal()
        {
            this.total = 0;
            foreach(var aux in this.detalles)
            {
                this.total = this.total + aux.Subtotal;
            }
        }
    }
}
