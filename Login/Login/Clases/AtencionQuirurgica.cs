using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    class AtencionQuirurgica
    {
        private int idAtencionQuirurgica;
        private Paciente paciente;
        private Cirugia cirugia;
        private Doctor doctor;
        private string descripcion;
        private DateTime fechaCirugia;
        public AtencionQuirurgica()
        {

        }
        public AtencionQuirurgica(int idAtencionQuirurgica, Paciente paciente, Cirugia cirugia, Doctor doctor, string descripcion, DateTime fechaCirugia)
        {
            this.IdAtencionQuirurgica = idAtencionQuirurgica;
            this.Paciente = paciente;
            this.Cirugia = cirugia;
            this.Doctor = doctor;
            this.Descripcion = descripcion;
            this.FechaCirugia = fechaCirugia;
        }

        public int IdAtencionQuirurgica { get => idAtencionQuirurgica; set => idAtencionQuirurgica = value; }
        public Doctor Doctor { get => doctor; set => doctor = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime FechaCirugia { get => fechaCirugia; set => fechaCirugia = value; }
        internal Paciente Paciente { get => paciente; set => paciente = value; }
        internal Cirugia Cirugia { get => cirugia; set => cirugia = value; }
    }
}
