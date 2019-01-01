using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    class Detalle
    {
        private int idDetalle;
        private Medicamento medicamento;
        private int cantidad;
        private double subtotal;
        public Detalle()
        {

        }
        public Detalle(int idDetalle, Medicamento medicamento, int cantidad)
        {
            this.IdDetalle = idDetalle;
            this.Medicamento = medicamento;
            this.Cantidad = cantidad;
            this.Subtotal = medicamento.PrecioUnitario * cantidad;
        }

        public int IdDetalle { get => idDetalle; set => idDetalle = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        internal Medicamento Medicamento { get => medicamento; set => medicamento = value; }
    }
}
