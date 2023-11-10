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
        private TimeSpan duracion { get; set; } 
        private Accion accionRequerida { get; set; }
        private Cliente cliente { get; set; }
        private OpcionLlamada opcionSeleccionada { get; set; }
        private SubopcionLlamada subopcionSeleccionada { get; set; }
        private List<CambioEstado> cambioEstado { get; set; }

        //Estado actual
        private Estado estadoActual;


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
            this.estadoActual = cambioEstado.ElementAt(0).Estado;
        }


        //patron
        public void contestarLlamada(DateTime fechaHoraActual)
        {
            estadoActual.contestarLlamada(fechaHoraActual, this);
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
        public void finalizarLlamada(DateTime fechaHoraActual, String respuestaOperador)
        {
            estadoActual.finalizarLlamada(fechaHoraActual, this, respuestaOperador);
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

        public void calcularDuracion()
        {
            DateTime inicio = new DateTime();
            DateTime fin = new DateTime();


            //REVISAR POR QUË TIENE LA MISMA HORA
            for (int i = 0; i < this.cambioEstado.Count ; i++)
            {
                if (cambioEstado.ElementAt(i).Estado.Nombre == "EnCurso") { inicio = cambioEstado.ElementAt(i).FechaHoraInicio; }
                if (cambioEstado.ElementAt(i).Estado.Nombre == "Finalizada") { fin = cambioEstado.ElementAt(i).FechaHoraInicio; }
            }
            duracion = fin.Subtract(inicio);

        }




        /*    CAMBIAR LA CANCELACION
        public void cancelarLlamada (DateTime fechaHoraActual, Estado estado)
        {
            crearNuevoCambioEstado(fechaHoraActual, estado);
        }
        */
    }
}
