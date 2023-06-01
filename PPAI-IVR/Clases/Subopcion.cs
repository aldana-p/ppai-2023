using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class Subopcion
    {
        public string nombre { get; set; }
        public int nroOrden { get; set; }
        public List<Validacion> validacionesRequeridas { get; set; }

        public Subopcion(string nombre, int nroOrden, List<Validacion> validacionesRequeridas)
        {
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            this.validacionesRequeridas = validacionesRequeridas;
        }

        public string mostrarSubopcion()
        {
            return this.getNombre();
        }
        public string getNombre()
        {
            return nombre;
        }

        public List<Validacion> getValidacionesSubopcion()
        {
            return this.validacionesRequeridas;
        }

    }
}
