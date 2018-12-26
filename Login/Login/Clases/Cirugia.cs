using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Clases
{
    class Cirugia
    {
        private int idCirugia;
        private string nombreCirugia;
        public Cirugia()
        {

        }
        public Cirugia(int idCirugia, string nombreCirugia)
        {
            this.IdCirugia = idCirugia;
            this.NombreCirugia = nombreCirugia;
        }

        public int IdCirugia { get => idCirugia; set => idCirugia = value; }
        public string NombreCirugia { get => nombreCirugia; set => nombreCirugia = value; }
    }
}
