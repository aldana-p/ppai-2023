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
        private int idLlamada { get; set; }
        private string descripcionOperador { get; set; }
        private TimeSpan duracion { get; set; } 
        private Accion accionRequerida { get; set; }
        private Cliente cliente { get; set; }
        private OpcionLlamada opcionSeleccionada { get; set; }
        private SubopcionLlamada subopcionSeleccionada { get; set; }
        private List<CambioEstado> cambioEstado { get; set; }

        //Estado actual
        private Estado estadoActual;

        public int IdLlamada { get => idLlamada; set => idLlamada = value; }
        public string DescripcionOperador { get => descripcionOperador; set => descripcionOperador = value; }
        public TimeSpan Duracion { get => duracion; set => duracion = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public OpcionLlamada OpcionSeleccionada { get => opcionSeleccionada; set => opcionSeleccionada = value; }
        public SubopcionLlamada SubopcionSeleccionada { get => subopcionSeleccionada; set => subopcionSeleccionada = value;  }
        public List<CambioEstado> CambioEstado { get => cambioEstado; set => cambioEstado = value; }


        

        public Llamada(int id, string descripcionOperador, Accion accionRequerida, Cliente cliente, OpcionLlamada opcionSeleccionada, SubopcionLlamada subopcionSeleccionada, List<CambioEstado> cambioEstado)
        {
            this.idLlamada = id;
            this.descripcionOperador = descripcionOperador;
            this.accionRequerida = accionRequerida;
            this.cliente = cliente;
            this.opcionSeleccionada = opcionSeleccionada;
            this.subopcionSeleccionada = subopcionSeleccionada;
            this.cambioEstado = cambioEstado;
            this.estadoActual = cambioEstado.ElementAt(0).Estado;
        }


        //patron
        public void contestarLlamada(DateTime fechaHoraActual)
        {
            estadoActual.contestarLlamada(fechaHoraActual, this, true);
        }


        //patron
        public void setEstadoActual(Estado estado)
        {
            estadoActual = estado;
        }
        public void agregarCambioEstado(CambioEstado cambio)
        {
            cambioEstado.Add(cambio);
        }
        public void finalizarLlamada(DateTime fechaHoraActual, String respuestaOperador, bool conf)
        {
            estadoActual.finalizarLlamada(fechaHoraActual, this, respuestaOperador, conf);
        }


        public string buscarDatosLlamada()
        {
            return this.cliente.getNombre();
        }

        
        public bool validarRespuesta(string respuesta)
        {
            return cliente.validarRespuestaCliente(respuesta);
        }
        

        //patron
        public void setDescripcionOperador(string descripcion)
        {
            descripcionOperador = descripcion;
        }
        //patron
        public void setDuracion(TimeSpan duracionLlamada)
        {
            duracion = duracionLlamada;
        }

        public void cancelarLlamada(DateTime fechaHoraActual, bool conf)
        {
            estadoActual.cancelarLlamada(fechaHoraActual, this, conf);
        }
    }
}
