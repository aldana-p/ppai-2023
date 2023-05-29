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
        private List<OpcionValidacion> opcoinesValidacion;
        private TipoInformacion tipo;

        public Validacion(string mensajeValidacion, string nombre, List<OpcionValidacion> opcoinesValidacion, TipoInformacion tipo)
        {
            this.mensajeValidacion = mensajeValidacion;
            this.nombre = nombre;
            this.opcoinesValidacion = opcoinesValidacion;
            this.tipo = tipo;
        }   
    }
}
