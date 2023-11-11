using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_IVR.Clases
{
    public class EnCurso : Estado
    {
        public EnCurso(string nombre, int idEstado) : base(nombre, idEstado)
        {
            
        }

        public override void cancelarLlamada(DateTime fechaHoraActual, Llamada llamada, bool confirmacion)
        {
            Estado cancelada= crearProximoEstado(fechaHoraActual, llamada, confirmacion);
            crearNuevoCambioEstado(fechaHoraActual, cancelada, llamada, confirmacion);
            llamada.setEstadoActual(cancelada);

        }

        public override void contestarLlamada(DateTime fechaHoraActual, Llamada llamada, bool confirmacion)
        {
            throw new NotImplementedException();
        }

        public override void crearNuevoCambioEstado(DateTime fechaHoraActual, Estado estado, Llamada llamada, bool confirmacion)
        {
            if (confirmacion)
            {
                CambioEstado finalizadaCambio = new CambioEstado(fechaHoraActual, estado);
                llamada.agregarCambioEstado(finalizadaCambio);
            }
            else
            {
                CambioEstado canceladaCambio = new CambioEstado(fechaHoraActual, estado);
                llamada.agregarCambioEstado(canceladaCambio);
            }         
        }

        public override Estado crearProximoEstado(DateTime fechaHoraActual, Llamada llamada, bool confirmacion)
        {
            if (confirmacion)
            {
                Estado finalizada = new Finalizada("Finalizada", 3);
                return finalizada;
            }
            else
            {
                Estado cancelada = new Cancelada("Cancelada", 4);
                return cancelada;
            }
        }

        public override void finalizarLlamada(DateTime fechaHoraActual, Llamada llamada, String rtaOperador,bool confirmacion)
        {
            Estado finalizada = crearProximoEstado(fechaHoraActual, llamada, confirmacion);
            crearNuevoCambioEstado(fechaHoraActual, finalizada, llamada, confirmacion);
            llamada.setDescripcionOperador(rtaOperador);
            TimeSpan duracion = calcularDuracion(llamada);
            llamada.setDuracion(duracion);
            llamada.setEstadoActual(finalizada);


            // Prueba para mostrar que se crearon los cambios de estado, se seteo de la desc. del operador y la duración de la llamada.
            List<CambioEstado> lista = llamada.CambioEstado;
            MessageBox.Show(" Descripción operador: " + llamada.DescripcionOperador +
                "\n Duración de la llamada: " + llamada.Duracion.ToString("hh':'mm':'ss") +
                "\n Cantidad de cambios de estados: " + lista.Count.ToString(), "Datos de la llamada finalizada");

            Console.WriteLine(" Descripción operador: " + llamada.DescripcionOperador +
                              "\n Duración de la llamada: " + llamada.Duracion.ToString("hh':'mm':'ss") +
                              "\n Cantidad de cambios de estados: " + lista.Count.ToString());
        }

        public TimeSpan calcularDuracion(Llamada llamada)
        {
            DateTime inicio = new DateTime();
            DateTime fin = new DateTime();

            for (int i = 0; i < llamada.CambioEstado.Count; i++)
            {
                if (llamada.CambioEstado.ElementAt(i).Estado.Nombre == "EnCurso") { inicio = llamada.CambioEstado.ElementAt(i).FechaHoraInicio; }
                if (llamada.CambioEstado.ElementAt(i).Estado.Nombre == "Finalizada") { fin = llamada.CambioEstado.ElementAt(i).FechaHoraInicio; }
            }
            TimeSpan duracion = fin.Subtract(inicio);

            return duracion;
        }


    }
}
