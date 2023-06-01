using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class OpcionValidacion
    {
        private bool correcta { get; set; }
        public string descripcion { get; set; }

        public OpcionValidacion(bool correcta, string descripcion)
        {
            this.correcta = correcta;
            this.descripcion = descripcion;
        }   

        public bool esCorrecta()
        {
            return correcta;
        }
    }
}
