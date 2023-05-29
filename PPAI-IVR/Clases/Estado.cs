using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR.Base_de_datos;

namespace PPAI_IVR.Clases
{
    public class Estado
    {
        public string nombre { get; set; }

        public Estado(string nombre)
        {
            this.nombre = nombre;
        }

        
        public static Estado esEnCurso(List<Estado> estados) 
        {
            Estado estadoEnCurso = null;
            foreach (Estado estado in estados)
            {
                if (estado.nombre == "EnCurso")
                {
                    estadoEnCurso = estado;
                    break;
                }
            }
            return estadoEnCurso;

            /*
            List<Estado> estados = EstadoBD.obtenerEstados();    //método que conecte con la BD y que devuelva una lista de  todos los estados
            //los recorro y le pregunto si es EnCurso
            Estado estadoEnCurso = null;
            foreach (Estado estado in estados)
            {
                if (estado.nombre == "EnCurso")
                {
                    estadoEnCurso = estado;
                    break;
                }
            }
            return estadoEnCurso;
            */

        }
        
    }
}
