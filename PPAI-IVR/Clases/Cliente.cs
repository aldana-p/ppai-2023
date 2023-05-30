using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Clases
{
    public class Cliente
    {
        private int dni;
        private string nombreCliente;
        private int nroTelefono;
        private List<InformacionCliente> info;

        public Cliente(int dni, string nombre)
        {
            this.dni = dni;
            this.nombreCliente = nombre;    
        }

        public string getNombre()
        {
            return this.nombreCliente;
        }

        /*
        public void validarRespuestaCliente()
        {
            info.esInformacionCorrecta();
        }
        */
    }
}
