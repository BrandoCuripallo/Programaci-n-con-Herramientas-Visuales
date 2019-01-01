using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    class HistoriaClinica
    {
        private int numeroHistoria;
        private Paciente paciente;
        private List<Atencion> atenciones;
        public HistoriaClinica()
        {

        }
        public HistoriaClinica(int numeroHistoria, Paciente paciente, List<Atencion> atenciones)
        {
            this.NumeroHistoria = numeroHistoria;
            this.Paciente = paciente;
            this.Atenciones = atenciones;
        }

        public int NumeroHistoria { get => numeroHistoria; set => numeroHistoria = value; }
        internal Paciente Paciente { get => paciente; set => paciente = value; }
        internal List<Atencion> Atenciones { get => atenciones; set => atenciones = value; }
    }
}
