using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    class Doctor : Persona
    {
        private string usuarioDoctor;
        private string contraseniaDoctor;
        private Especialidad especialidad;
        private List<CitaMedica> citas;
        private List<Atencion> atenciones;
        private List<AtencionQuirurgica> cirugias;
        public Doctor()
        {

        }
        public Doctor(string usuario, string contrasenia)
        {
            this.usuarioDoctor = usuario;
            this.contraseniaDoctor = contrasenia;
        }
        public Doctor(string usuarioDoctor, string contraseniaDoctor, Especialidad especialidad, List<CitaMedica> citas, List<Atencion> atenciones, List<AtencionQuirurgica> cirugias)
        {
            this.UsuarioDoctor = usuarioDoctor;
            this.ContraseniaDoctor = contraseniaDoctor;
            this.Especialidad = especialidad;
            this.Citas = citas;
            this.Atenciones = atenciones;
            this.Cirugias = cirugias;
        }

        public string UsuarioDoctor { get => usuarioDoctor; set => usuarioDoctor = value; }
        public string ContraseniaDoctor { get => contraseniaDoctor; set => contraseniaDoctor = value; }
        internal Especialidad Especialidad { get => especialidad; set => especialidad = value; }
        internal List<CitaMedica> Citas { get => citas; set => citas = value; }
        internal List<Atencion> Atenciones { get => atenciones; set => atenciones = value; }
        internal List<AtencionQuirurgica> Cirugias { get => cirugias; set => cirugias = value; }
    }
}
