using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class Iniciada : Estado
    {
        public Iniciada(string nombre) : base(nombre)
        {
        }

        public override void contestarLlamada(DateTime fechaHoraActual, Llamada llamada)
        {
            Estado enCurso = crearProximoEstado(fechaHoraActual, llamada);
            crearNuevoCambioEstado(fechaHoraActual, enCurso, llamada);
        }

        public override void crearNuevoCambioEstado(DateTime fechaHoraActual, Estado estado, Llamada llamada)
        {
            CambioEstado cambioEnCurso = new CambioEstado(fechaHoraActual, estado);
            llamada.agregarCambioEstado(cambioEnCurso);
            llamada.setEstadoActual(estado);
        }

        public override Estado crearProximoEstado(DateTime fechaHoraActual, Llamada llamada)
        {
            Estado enCurso = new EnCurso("EnCurso");
            return enCurso;
            
        }

        public override void finalizarLlamada(DateTime fechaHoraActual, Llamada llamada, String rtaOperador)
        {
            throw new NotImplementedException();
        }
      }
}
