using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class Categoria
    {
        private string mensajeOpciones { get; set; }
        private string nombre { get; set; }
        private int nroOrden { get; set; }
        private List<Opcion> opcion { get; set; }

        public Categoria(string nombre, int nroOrden, List<Opcion> opciones)
        {
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            this.opcion = opciones;
        }

        public string getNombre()
        {
            return nombre;
        }

        public string[] mostrarDatosCategoriaOpcionSubopcion(Opcion opcionSeleccionada, Subopcion subopcion)
        {
            string nombreCategoria = this.getNombre();
            string[] opcionSubopcion = opcionSeleccionada.mostrarOpcionSubopcion(subopcion);
            string[] categoriaOpcionSubopcion = new string[3] { nombreCategoria, opcionSubopcion[0], opcionSubopcion[1] };
            return categoriaOpcionSubopcion;
        }
    }

    
}
