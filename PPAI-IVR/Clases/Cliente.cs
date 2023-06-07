using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class Cliente
    {
        private int dni { get; set; }
        private string nombreCompleto { get; set; }
        //private int nroTelefono { get; set; }
        private List<InformacionCliente> informacion { get; set; }

        public Cliente(int dni, string nombre, List<InformacionCliente> infoCliente)
        {
            this.dni = dni;
            this.nombreCompleto = nombre;
            this.informacion = infoCliente;
        }

        public string getNombre()
        {
            return this.nombreCompleto;
        }

        
        public bool validarRespuestaCliente(string respuesta)
        {
            int contador = 0;
            foreach (InformacionCliente info in informacion)
            {
                if (info.esInformacionCorrecta(respuesta))
                {
                    contador++;
                    break;
                };
            }

            if (contador == 1)
            {
                return true;
            }
            return false;
        }
        
    }
}
