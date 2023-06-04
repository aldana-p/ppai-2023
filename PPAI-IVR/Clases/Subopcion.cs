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
        private string nombre { get; set; }
        private int nroOrden { get; set; }
        private List<Validacion> validacionesRequeridas { get; set; }

        public string Nombre { get => nombre; set => nombre = value; }
        public List<Validacion> ValidacionesRequeridas { get => validacionesRequeridas; set => validacionesRequeridas = value; }

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
