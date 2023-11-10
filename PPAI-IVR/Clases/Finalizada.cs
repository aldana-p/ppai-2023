using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class Finalizada : Estado
    {
        public Finalizada(string nombre, int idEstado) : base(nombre, idEstado)
        {
        }

        public override void cancelarLlamada(DateTime fechHoraActual, Llamada llamada, bool confirmacion)
        {
            throw new NotImplementedException();
        }

        public override void contestarLlamada(DateTime fechaHoraActual, Llamada llamada, bool confirmacion)
        {
            throw new NotImplementedException();
        }

        public override void crearNuevoCambioEstado(DateTime fechaHoraActual, Estado estado, Llamada llamada, bool confirmacion)
        {
            throw new NotImplementedException();
        }

        public override Estado crearProximoEstado(DateTime fechaHoraActual, Llamada llamada, bool confirmacion)
        {
            throw new NotImplementedException();
        }

        public override void finalizarLlamada(DateTime fechaHoraActual, Llamada llamada, string rtaOperador, bool confirmacion)
        {
            throw new NotImplementedException();
        }
    }
}
