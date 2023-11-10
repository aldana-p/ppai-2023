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

       public string Nombre { get => nombre; set => nombre = value; }

        public Estado(string nombre) 
        {
            this.nombre = nombre;
        }
        



        // Patrón state
        public abstract void contestarLlamada(DateTime fechaHoraActual, Llamada llamada);
        public abstract Estado crearProximoEstado(DateTime fechaHoraActual, Llamada llamada);
        public abstract void crearNuevoCambioEstado(DateTime fechaHoraActual, Estado estado, Llamada llamada);
        public abstract void finalizarLlamada(DateTime fechaHoraActual, Llamada llamada, String rtaOperador);
                



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
