using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class InformacionCliente
    {
        private string datoAValidar { get; set; }
        // private Validacion validacion { get; set; }
        // private OpcionValidacion opcionCorrecta { get; set; }
        // private TipoInformacion tipoInformacion;

        public InformacionCliente(string datoAValidar) //, Validacion val, OpcionValidacion opVal)
        {
            this.datoAValidar = datoAValidar;
            //this.validacion = val;
            //this.opcionCorrecta = opVal;
        }
        

        public bool esInformacionCorrecta(string respuesta )
        {
            return (respuesta == datoAValidar);

        }
        
    }
}
