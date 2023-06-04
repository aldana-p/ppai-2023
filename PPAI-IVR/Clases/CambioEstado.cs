using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class CambioEstado
    {
        private DateTime fechaHoraInicio { get; set; }
        private Estado estado { get; set; }

        public DateTime FechaHoraInicio { get => fechaHoraInicio; set => fechaHoraInicio = value; }
        public Estado Estado { get => estado; set => estado = value; }


        public CambioEstado(DateTime fechaHora, Estado estado)
        {
            this.fechaHoraInicio = fechaHora;
            this.estado = estado;
        }
    }
}
