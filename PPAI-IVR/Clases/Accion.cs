using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class Accion
    {
        private string descripcion { get; set; }

        public Accion(string descripcion)
        {
            this.descripcion = descripcion;
        }

        public string getDescripcion()
        {
            return descripcion;
        }
    }
}
