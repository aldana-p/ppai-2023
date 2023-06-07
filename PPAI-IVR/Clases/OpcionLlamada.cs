using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class OpcionLlamada
    {
        // private string mensajeSubopciones { get; set; }
        private string nombre { get; set; }
        private int nroOrden { get; set; }
        private List<SubopcionLlamada> subopcion { get; set; }
        private List<Validacion> validacionesRequeridas { get; set; }

        public List<SubopcionLlamada> Subopcion { get => subopcion; set => subopcion = value; }

        public OpcionLlamada(string nombre, int nroOrden, List<SubopcionLlamada> subopciones)
        {
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            this.subopcion = subopciones;
        }

        public string getNombre()
        {
            return nombre;
        }

        public string[] mostrarOpcionSubopcion(SubopcionLlamada subopcionSeleccionada)
        {
            string nombreOpcion = this.getNombre();
            string nombreSubopcion = subopcionSeleccionada.mostrarSubopcion();
            string[] opcionSubopcion = new string[2] { nombreOpcion, nombreSubopcion };
            return opcionSubopcion;
        }
    }
}
