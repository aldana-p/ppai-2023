using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class SubopcionLlamada
    {
        private string nombre { get; set; }
        private int nroOrden { get; set; }
        private List<Validacion> validacionesRequeridas { get; set; }

        public string Nombre { get => nombre; set => nombre = value; }
        public List<Validacion> ValidacionesRequeridas { get => validacionesRequeridas; set => validacionesRequeridas = value; }

        public SubopcionLlamada(string nombre, int nroOrden, List<Validacion> validacionesRequeridas)
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

        public List<string> getValidacionesSubopcion()
        {
            List<string> nombresValidaciones = new List<string>(); // hago la lista con los nombres para cumplir con el diag. de secuencia (tiene el método a
            //Validacion getValidacion().
            for (int i = 0; i < validacionesRequeridas.Count; i++)
            {
                nombresValidaciones.Add(validacionesRequeridas[i].getValidacion());

            };
            return nombresValidaciones;
        }

    }
}
