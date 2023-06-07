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
        private string descripcionOperador { get; set; }
        // private string detalleAccionRequerida { get; set; }
        private TimeSpan duracion { get; set; } 
        // private bool encuestaEnviada { get; set; } // revisar si es bool
        // private string observacionAuditor { get; set; }
        private Accion accionRequerida { get; set; }
        private Cliente cliente { get; set; }
        //private Usuario operador { get; set; } //son necesarios el operador, el auditor, y la respuestaDeEncuesta?
        // private Usuario auditor { get; set; }
        private OpcionLlamada opcionSeleccionada { get; set; }
        private SubopcionLlamada subopcionSeleccionada { get; set; }
        private List<CambioEstado> cambioEstado { get; set; }

        public string DescripcionOperador { get => descripcionOperador; set => descripcionOperador = value; }
        public TimeSpan Duracion { get => duracion; set => duracion = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public OpcionLlamada OpcionSeleccionada { get => opcionSeleccionada; set => opcionSeleccionada = value; }
        public SubopcionLlamada SubopcionSeleccionada { get => subopcionSeleccionada; set => subopcionSeleccionada = value;  }
        public List<CambioEstado> CambioEstado { get => cambioEstado; set => cambioEstado = value; }



        public Llamada(string descripcionOperador, Accion accionRequerida, Cliente cliente, OpcionLlamada opcionSeleccionada, SubopcionLlamada subopcionSeleccionada, List<CambioEstado> cambioEstado)
        {
            this.descripcionOperador = descripcionOperador;
            this.accionRequerida = accionRequerida;
            this.cliente = cliente;
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

        public void cancelarLlamada (DateTime fechaHoraActual, Estado estado)
        {
            crearNuevoCambioEstado(fechaHoraActual, estado);
        }

    }
}
