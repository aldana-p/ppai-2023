using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class InformacionCliente
    {
        private string datoAValidar;
        private Validacion validacion;
        private OpcionValidacion opcionCorrecta;
       // private TipoInformacion tipoInformacion;

        public InformacionCliente(string datoAValidar, Validacion val, OpcionValidacion opVal)
        {
            this.datoAValidar = datoAValidar;
            this.validacion = val;
            this.opcionCorrecta = opVal;
        }

        public void esInformacionCorrecta()
        {

        }
    }
}
