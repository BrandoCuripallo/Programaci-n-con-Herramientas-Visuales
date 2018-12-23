using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    class Atencion
    {
        private int idAtencion;
        private Doctor doctor;
        private DateTime fechaAtencion;
        private float temperatura;
        private float altura;
        private float peso;
        private string diagnostico;
        private string indicaciones;

        public Atencion(int idAtencion, Doctor doctor, DateTime fechaAtencion, float temperatura, float altura, float peso, string diagnostico, string indicaciones)
        {
            this.IdAtencion = idAtencion;
            this.Doctor = doctor;
            this.FechaAtencion = fechaAtencion;
            this.Temperatura = temperatura;
            this.Altura = altura;
            this.Peso = peso;
            this.Diagnostico = diagnostico;
            this.Indicaciones = indicaciones;
        }

        public int IdAtencion { get => idAtencion; set => idAtencion = value; }
        public Doctor Doctor { get => doctor; set => doctor = value; }
        public DateTime FechaAtencion { get => fechaAtencion; set => fechaAtencion = value; }
        public float Temperatura { get => temperatura; set => temperatura = value; }
        public float Altura { get => altura; set => altura = value; }
        public float Peso { get => peso; set => peso = value; }
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }
        public string Indicaciones { get => indicaciones; set => indicaciones = value; }
    }
}
