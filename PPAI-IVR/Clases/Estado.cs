using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class Estado
    {
        public string nombre { get; set; }

        public Estado(string nombre)
        {
            this.nombre = nombre;
        }

        
        public bool esEnCurso() 
        {
            if (this.nombre == "EnCurso")
            {
                return true;
            }
            return false;
        }

        public bool esFinalizada()
        {
            if (this.nombre == "Finalizada")
            {
                return true;
            }
            return false;
        }

    }
}
