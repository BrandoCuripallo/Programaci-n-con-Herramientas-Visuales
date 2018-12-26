using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Especialidad
    {
        private int idEspecialidad;
        private string nombreEspecialidad;
        private string descripcion;
        public Especialidad()
        {

        }
        public Especialidad(int idEspecialidad, string nombreEspecialidad, string descripcion)
        {
            this.IdEspecialidad = idEspecialidad;
            this.NombreEspecialidad = nombreEspecialidad;
            this.Descripcion = descripcion;
        }

        public int IdEspecialidad { get => idEspecialidad; set => idEspecialidad = value; }
        public string NombreEspecialidad { get => nombreEspecialidad; set => nombreEspecialidad = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
