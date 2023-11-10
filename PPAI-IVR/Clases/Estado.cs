using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public abstract class Estado
    {   
        
        // Cómo corregir con el patron? 
        private string nombre { get; set; }
        private int id { get; set; }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }

        public Estado(string nombre, int idEstado) 
        {
            this.nombre = nombre;
            this.id = idEstado;
        }





        // Patrón state
        public abstract void contestarLlamada(DateTime fechaHoraActual, Llamada llamada, bool confirmacion);
        public abstract Estado crearProximoEstado(DateTime fechaHoraActual, Llamada llamada, bool confirmacion);
        public abstract void crearNuevoCambioEstado(DateTime fechaHoraActual, Estado estado, Llamada llamada,bool confirmacion);
        public abstract void finalizarLlamada(DateTime fechaHoraActual, Llamada llamada, String rtaOperador, bool confirmacion);
        public abstract void cancelarLlamada(DateTime fechHoraActual, Llamada llamada, bool confirmacion);
                



        /*
        public bool esEnCurso() 
        {
            if (this.nombre == "EnCurso")
            {
                return true;
            }
            return false;
        }

        public bool esFinalizada()
        {
            if (this.nombre == "Finalizada")
            {
                return true;
            }
            return false;
        }

        public bool esCancelado()
        {
            if (this.nombre == "Cancelado")
            {
                return true;
            }
            return false;
        }
        
        */
    }
}
