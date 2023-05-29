using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class Opcion
    {
        private string mensajeSubopciones;
        private string nombre;
        private int nroOrden;
        private List<Subopcion> subopcion;
        private List<Validacion> validacionesRequeridas;

        public Opcion(string nombre, int nroOrden, List<Subopcion> subopciones)
        {
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            this.subopcion = subopciones;
        }

        public string getNombre()
        {
            return nombre;
        }

        public string[] mostrarOpcionSubopcion(Subopcion subopcionSeleccionada)
        {
            string nombreOpcion = this.getNombre();
            string nombreSubopcion = subopcionSeleccionada.mostrarSubopcion();
            string[] opcionSubopcion = new string[2] { nombreOpcion, nombreSubopcion };
            return opcionSubopcion;
        }
    }
}
