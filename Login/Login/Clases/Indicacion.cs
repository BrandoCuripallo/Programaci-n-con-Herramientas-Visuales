using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    class Indicacion
    {
        private int numeroIndicacion;
        private Medicamento medicamento;
        private string indicaciones;
        public Indicacion()
        {

        }
        public Indicacion(int numeroIndicacion, Medicamento medicamento, string indicaciones)
        {
            this.NumeroIndicacion = numeroIndicacion;
            this.Medicamento = medicamento;
            this.Indicaciones = indicaciones;
        }

        public int NumeroIndicacion { get => numeroIndicacion; set => numeroIndicacion = value; }
        public string Indicaciones { get => indicaciones; set => indicaciones = value; }
        internal Medicamento Medicamento { get => medicamento; set => medicamento = value; }
    }
}
