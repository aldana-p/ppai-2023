using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class CambioEstado
    {
        public DateTime fechaHoraInicio { get; set; }
        public Estado estado { get; set; }

        public CambioEstado(DateTime fechaHora, Estado estado)
        {
            this.fechaHoraInicio = fechaHora;
            this.estado = estado;
        }
    }
}
