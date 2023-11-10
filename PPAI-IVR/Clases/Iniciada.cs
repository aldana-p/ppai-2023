using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class Iniciada : Estado
    {
        public Iniciada(string nombre, int idEstado) : base(nombre, idEstado)
        {
        }

        public override void cancelarLlamada(DateTime fechHoraActual, Llamada llamada, bool confirmacion)
        {
            throw new NotImplementedException();
        }

        public override void contestarLlamada(DateTime fechaHoraActual, Llamada llamada, bool confirmacion)
        {
            Estado enCurso = crearProximoEstado(fechaHoraActual, llamada, confirmacion);
            crearNuevoCambioEstado(fechaHoraActual, enCurso, llamada,confirmacion);
        }

        public override void crearNuevoCambioEstado(DateTime fechaHoraActual, Estado estado, Llamada llamada, bool confirmacion)
        {
            CambioEstado cambioEnCurso = new CambioEstado(fechaHoraActual, estado);
            llamada.agregarCambioEstado(cambioEnCurso);
            llamada.setEstadoActual(estado);
        }

        public override Estado crearProximoEstado(DateTime fechaHoraActual, Llamada llamada, bool confirmacion)
        {
            Estado enCurso = new EnCurso("EnCurso", 2);
            return enCurso;
            
        }

        public override void finalizarLlamada(DateTime fechaHoraActual, Llamada llamada, String rtaOperador, bool confirmacion)
        {
            throw new NotImplementedException();
        }
      }
}
