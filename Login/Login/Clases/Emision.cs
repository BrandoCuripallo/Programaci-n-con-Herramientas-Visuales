using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    public class Emision
    {
        private string cedulaPaciente;
        private string nombres;
        private string apellidoPaterno;
        private string correoElectronico;
        private string direccion;
        private string telefono;
        private int numeroFactura;
        private DateTime fecha;
        private double total;
        private int numero;
        private string descripcion;
        private int cantidad;
        private double precioUnitario;
        private double subTotal;
        public string CedulaPaciente { get => cedulaPaciente; set => cedulaPaciente = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int NumeroFactura { get => numeroFactura; set => numeroFactura = value; }
        public double Total { get => total; set => total = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public double SubTotal { get => subTotal; set => subTotal = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
