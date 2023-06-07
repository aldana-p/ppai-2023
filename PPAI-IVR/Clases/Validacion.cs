using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class Validacion
    {
        //private string mensajeValidacion { get; set; }//hace falta? es audio
        private string nombre { get; set; }
        //private List<OpcionValidacion> opcionesValidacion { get; set; }
        //private TipoInformacion tipo { get; set; }

        public Validacion(string nombre)
        {
            this.nombre = nombre;
        }   

        public string getValidacion()
        {
            return nombre;
        }

    }
}
