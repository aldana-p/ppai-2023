using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class Validacion
    {
        private string mensajeValidacion; //hace falta? es audio
        private string nombre;
        public List<OpcionValidacion> opcionesValidacion;
        private TipoInformacion tipo;

        public Validacion(string mensajeValidacion, string nombre, List<OpcionValidacion> opcionesValidacion, TipoInformacion tipo)
        {
            this.mensajeValidacion = mensajeValidacion;
            this.nombre = nombre;
            this.opcionesValidacion = opcionesValidacion;
            this.tipo = tipo;
        }   

        public string getValidacion()
        {
            return this.nombre;
        }

    }
}
