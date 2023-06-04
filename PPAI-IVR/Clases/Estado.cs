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
        private string nombre { get; set; }

        public string Nombre { get => nombre; set => nombre = value; }

        public Estado(string nombre) //Podría usarse directamente el set ?? 
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

        public bool esCancelado()
        {
            if (this.nombre == "Cancelado")
            {
                return true;
            }
            return false;
        }


    }
}
