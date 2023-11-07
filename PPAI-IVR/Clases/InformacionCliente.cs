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
        
        public InformacionCliente(string datoAValidar)
        {
            this.datoAValidar = datoAValidar;
        }
        

        public bool esInformacionCorrecta(string respuesta )
        {
            return (respuesta == datoAValidar);

        }
        
    }
}
