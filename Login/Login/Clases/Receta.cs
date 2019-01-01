using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    class Receta
    {
        private int idReceta;
        private Paciente paciente;
        private Doctor doctor;
        private DateTime fechaEmision;
        private List<Indicacion> indicaciones;
        public Receta()
        {

        }
        public Receta(int idReceta, Paciente paciente, Doctor doctor, DateTime fechaEmision, List<Indicacion> indicaciones)
        {
            this.IdReceta = idReceta;
            this.Paciente = paciente;
            this.Doctor = doctor;
            this.FechaEmision = fechaEmision;
            this.Indicaciones = indicaciones;
        }

        public int IdReceta { get => idReceta; set => idReceta = value; }
        public Doctor Doctor { get => doctor; set => doctor = value; }
        public DateTime FechaEmision { get => fechaEmision; set => fechaEmision = value; }
        internal Paciente Paciente { get => paciente; set => paciente = value; }
        internal List<Indicacion> Indicaciones { get => indicaciones; set => indicaciones = value; }
    }
}
