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
        private List<Medicamento> medicamentos;
        private string indicaciones;

        public Receta(int idReceta, Paciente paciente, Doctor doctor, DateTime fechaEmision, List<Medicamento> medicamentos, string indicaciones)
        {
            this.IdReceta = idReceta;
            this.Paciente = paciente;
            this.Doctor = doctor;
            this.FechaEmision = fechaEmision;
            this.Medicamentos = medicamentos;
            this.Indicaciones = indicaciones;
        }

        public int IdReceta { get => idReceta; set => idReceta = value; }
        public Doctor Doctor { get => doctor; set => doctor = value; }
        public DateTime FechaEmision { get => fechaEmision; set => fechaEmision = value; }
        public string Indicaciones { get => indicaciones; set => indicaciones = value; }
        internal Paciente Paciente { get => paciente; set => paciente = value; }
        internal List<Medicamento> Medicamentos { get => medicamentos; set => medicamentos = value; }
    }
}
