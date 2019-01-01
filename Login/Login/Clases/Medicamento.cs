using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    class Medicamento
    {
        private string codigoMedicamento;
        private string nombreMedicamento;
        private string descripcion;
        private int stock;
        private double precioUnitario;
        public Medicamento()
        {

        }
        public Medicamento(string codigoMedicamento, string nombreMedicamento, string descripcion, int stock, double precioUnitario)
        {
            this.CodigoMedicamento = codigoMedicamento;
            this.NombreMedicamento = nombreMedicamento;
            this.Descripcion = descripcion;
            this.Stock = stock;
            this.precioUnitario = precioUnitario;
        }

        public string CodigoMedicamento { get => codigoMedicamento; set => codigoMedicamento = value; }
        public string NombreMedicamento { get => nombreMedicamento; set => nombreMedicamento = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Stock { get => stock; set => stock = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
    }
}
