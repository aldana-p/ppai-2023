using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class Validacion
    {
        private string nombre { get; set; }
        
        public Validacion(string nombre)
        {
            this.nombre = nombre;
        }   

        public string getValidacion()
        {
            return nombre;
        }

    }
}
