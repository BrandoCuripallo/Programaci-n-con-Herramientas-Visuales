using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class CitaMedica
    {
        private int numeroCita;
        private Paciente paciente;
        private DateTime fechaCita;
        private string descripcion;
        private Especialidad especialidad;
        private Doctor doctor;
        private Recepcionista recepcionista;

        public CitaMedica(int numeroCita, Paciente paciente, DateTime fechaCita, string descripcion, Especialidad especialidad, Doctor doctor, Recepcionista recepcionista)
        {
            this.NumeroCita = numeroCita;
            this.Paciente = paciente;
            this.FechaCita = fechaCita;
            this.Descripcion = descripcion;
            this.Especialidad = especialidad;
            this.Doctor = doctor;
            this.Recepcionista = recepcionista;
        }

        public int NumeroCita { get => numeroCita; set => numeroCita = value; }
        public DateTime FechaCita { get => fechaCita; set => fechaCita = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Doctor Doctor { get => doctor; set => doctor = value; }
        internal Paciente Paciente { get => paciente; set => paciente = value; }
        internal Especialidad Especialidad { get => especialidad; set => especialidad = value; }
        internal Recepcionista Recepcionista { get => recepcionista; set => recepcionista = value; }
    }
}
