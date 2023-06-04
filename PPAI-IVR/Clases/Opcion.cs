using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class Opcion
    {
        private string mensajeSubopciones { get; set; }
        private string nombre { get; set; }
        private int nroOrden { get; set; }
        private List<Subopcion> subopcion { get; set; }
        private List<Validacion> validacionesRequeridas { get; set; }

        public List<Subopcion> Subopcion { get => subopcion; set => subopcion = value; }

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
