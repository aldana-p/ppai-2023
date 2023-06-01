using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class Validacion
    {
        private string mensajeValidacion { get; set; }//hace falta? es audio
        private string nombre { get; set; }
        public List<OpcionValidacion> opcionesValidacion { get; set; }
        private TipoInformacion tipo { get; set; }

        public Validacion(string mensajeValidacion, string nombre, List<OpcionValidacion> opcionesValidacion, TipoInformacion tipo)
        {
            this.mensajeValidacion = mensajeValidacion;
            this.nombre = nombre;
            this.opcionesValidacion = opcionesValidacion;
            this.tipo = tipo;
        }   

        public string getValidacion()
        {
            return nombre;
        }

    }
}
