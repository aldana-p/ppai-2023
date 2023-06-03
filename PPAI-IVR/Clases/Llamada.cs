using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_IVR.Clases
{
    public class Llamada
    {
        public string descripcionOperador { get; set; }
        private string detalleAccionRequerida { get; set; }
        public TimeSpan duracion { get; set; } 
        private bool encuestaEnviada { get; set; } // revisar si es bool
        private string observacionAuditor { get; set; }
        private Accion accionRequerida { get; set; }
        public Cliente cliente { get; set; }
        private Usuario operador { get; set; } //son necesarios el operador, el auditor, y la respuestaDeEncuesta?
        private Usuario auditor { get; set; }
        public Opcion opcionSeleccionada { get; set; }
        public Subopcion subopcionSeleccionada { get; set; }
        public List<CambioEstado> cambioEstado { get; set; }


        public Llamada(string descripcionOperador, Accion accionRequerida, Cliente cliente, Usuario operador, Opcion opcionSeleccionada, Subopcion subopcionSeleccionada, List<CambioEstado> cambioEstado)
        {
            this.descripcionOperador = descripcionOperador;
            this.accionRequerida = accionRequerida;
            this.cliente = cliente;
            this.operador = operador;
            this.opcionSeleccionada = opcionSeleccionada;
            this.subopcionSeleccionada = subopcionSeleccionada;
            this.cambioEstado = cambioEstado;
        }

        public void contestarLlamada(DateTime fechaHoraActual, Estado estado)
        {
            crearNuevoCambioEstado(fechaHoraActual, estado);
        }

        public void crearNuevoCambioEstado(DateTime fechaHoraActual, Estado estado)
        {
            CambioEstado nuevoEstado = new CambioEstado(fechaHoraActual, estado);
            cambioEstado.Add(nuevoEstado);
            
        }

        public string buscarDatosLlamada()
        {
            return this.cliente.getNombre();
        }

        
        public bool validarRespuesta(string respuesta)
        {
            return cliente.validarRespuestaCliente(respuesta);
        }




        public void finalizarLlamada(DateTime fechaHoraActual, Estado estado)
        {
            crearNuevoCambioEstado(fechaHoraActual, estado);
        }

        public void setDescripcionOperador(string descripcion)
        {
            descripcionOperador = descripcion;
        }

        public void calcularDuracion(DateTime horaInicio, DateTime horaFin)
        {
            duracion = horaFin.Subtract(horaInicio);
        }


    }
}
