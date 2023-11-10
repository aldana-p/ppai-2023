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
        public EnCurso(string nombre) : base(nombre)
        {
        }

        public override void contestarLlamada(DateTime fechaHoraActual, Llamada llamada)
        {
            throw new NotImplementedException();
        }

        public override void crearNuevoCambioEstado(DateTime fechaHoraActual, Estado estado, Llamada llamada)
        {
            CambioEstado finalizadaCambio = new CambioEstado(fechaHoraActual, estado);
            llamada.agregarCambioEstado(finalizadaCambio);

        }

        public override Estado crearProximoEstado(DateTime fechaHoraActual, Llamada llamada)
        {
            Estado finalizada = new Finalizada("Finalizada");
            //crearNuevoCambioEstado(fechaHoraActual, finalizada, llamada);
            return finalizada;
        }

        public override void finalizarLlamada(DateTime fechaHoraActual, Llamada llamada, String rtaOperador)
        {
            Estado finalizada = crearProximoEstado(fechaHoraActual, llamada);
            crearNuevoCambioEstado(fechaHoraActual, finalizada, llamada);
            llamada.setDescripcionOperador(rtaOperador);
            llamada.calcularDuracion();   //Al final lo dejé en llamada porque sino tengo que cambiar a public el atributo de cambios de estados!
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


    }
}
