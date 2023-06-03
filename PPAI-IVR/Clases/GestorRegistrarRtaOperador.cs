using PPAI_IVR.Pantalla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_IVR.Clases
{
    public class GestorRegistrarRtaOperador
    {
        private Llamada llamada { get; set; }
        private Opcion opcion { get; set; }
        private Categoria categoria { get; set; }
        private Subopcion subopcion { get; set; }
        private Cliente cliente { get; set; }
        private Estado estadoEnCurso { get; set; }
        private Estado estadoFinalizada { get; set; }
        private List<Estado> estados { get; set; }
        private DateTime fechaHoraActual { get; set; }
        public PantallaRegistrarRtaOperador pantalla { get; set; }
        private List<Accion> acciones { get; set; }
        private string respuestaOperador { get; set; }
        private string accionSeleccionada { get; set; }
        public SegundaPantalla segundaPantalla { get; set; }


        public GestorRegistrarRtaOperador(Llamada llamada, Categoria categoria, List<Estado> estados, List<Accion> acciones) 
        {
            this.llamada = llamada;
            this.opcion = llamada.opcionSeleccionada;
            this.categoria = categoria;
            this.subopcion = llamada.subopcionSeleccionada;
            this.cliente = llamada.cliente;
            this.pantalla = new PantallaRegistrarRtaOperador(this);
            this.estados = estados;
            this.acciones = acciones;
            this.segundaPantalla = new SegundaPantalla(this);
        }
        public GestorRegistrarRtaOperador(Llamada llamada)
        {
            this.llamada = llamada;
        }

        public void registrarRespuestaOperador()
        {
            identificarOpcion(llamada);
        }

        public void identificarOpcion(Llamada llamada) { 
            if (subopcion.nombre == "Comunicarse con responsable de atención al cliente")
            {
                buscarEstadoEnCurso();
            }
        }

        // Método que busca el estado EnCurso para luego crear el cambio de estado.
        public void buscarEstadoEnCurso()
        {
            foreach (Estado estado in estados)
            {
                bool res = estado.esEnCurso();
                
                if (res)
                {
                    estadoEnCurso = estado;
                    break;
                }
            }

            fechaHoraActual = obtenerFechaHoraActual();
            actualizarEstadoLlamadaAEnCurso(estadoEnCurso);

        }

        public DateTime obtenerFechaHoraActual()
        {
            return DateTime.Now;

        }

        public void actualizarEstadoLlamadaAEnCurso(Estado nuevoEstado)
        {
            llamada.contestarLlamada(fechaHoraActual, nuevoEstado);
            buscarDatosLlamada(llamada);

        }

        // Método que obtiene el nombre de la categoría, opción y subopción seleccionadas.
        public void buscarDatosLlamada(Llamada seleccionadaLlamada)
        {
            string nombreCliente = seleccionadaLlamada.buscarDatosLlamada();
            string[] categoriaOpcionSubopcion = this.categoria.mostrarDatosCategoriaOpcionSubopcion(seleccionadaLlamada.opcionSeleccionada, seleccionadaLlamada.subopcionSeleccionada);

            pantalla.mostrarDatosLlamada(categoriaOpcionSubopcion, nombreCliente, seleccionadaLlamada);
            buscarValidaciones();
        }

        // Método que busca los nombres de las validaciones a realizar
        public void buscarValidaciones()
        {
            List<Validacion> validacionesRequeridas = subopcion.getValidacionesSubopcion();
            List<string> nombresValidaciones = new List<string>(); // hago la lista con los nombres para cumplir con el diag. de secuencia (tiene el método a
            //Validacion getValidacion().
            for (int i = 0; i < validacionesRequeridas.Count; i++)
            {
                nombresValidaciones.Add(validacionesRequeridas[i].getValidacion());
                
            };

            pantalla.mostrarDatosValidaciones(nombresValidaciones);

        }

        
        //MÉTODOS DEL LOOP PARA CADA RESPUESTA
        public bool tomarRespuestasValidaciones(string[] respuestas)
        {
            return validarRespuestas(respuestas);
        }

        public bool validarRespuestas(string[] respuestas)
        {
            int contador = 0;
            foreach (string res in respuestas)
            {
                if (llamada.validarRespuesta(res))
                {
                    contador++;
                };
            }
            if (contador == respuestas.Length)
            {
                return true;
            }
            return false;
        }
        
        public void tomarRespuestaOperador(string respuestaOperador)
        {
            this.respuestaOperador = respuestaOperador;
        }
                
        public List<string> buscarAcciones()
        {
            List<string> nombresAcciones = new List<string>();
            foreach (Accion accion in this.acciones)
            {
                nombresAcciones.Add(accion.getDescripcion());  //Hago una lista con los nombre de las acciones para cumplir con el diagrama de secuencia 
                // que tiene el método a Accion getDescrpcion().
            }
            return nombresAcciones;
        }

        public void tomarSeleccionAccion(string accion)
        {
            this.accionSeleccionada = accion;  // El caso de uso 28 se encarga de registrarla (asignarla a la llamada)
            segundaPantalla.solicitarConfirmacion();

        }

        public void tomarConfirmacion(bool confirmacion)
        {
            if (llamarCU28RegistrarAccion())
            {
                buscarEstadoFinalizada();
            };
        }

        public bool llamarCU28RegistrarAccion()
        {
            MessageBox.Show("¡El CU28 se ejecutó con éxito!");
            return true;    // RESOLVER ALTERNATIVA A3 !!!!!!

        }

        public void buscarEstadoFinalizada()
        {
            foreach (Estado estado in estados)
            {
                bool res = estado.esFinalizada();
                if (res)
                {
                    estadoFinalizada = estado;
                    break;
                }
            }

            fechaHoraActual = obtenerFechaHoraActual();
            actualizarEstadoLlamadaAFinalizada(estadoFinalizada);
        }

        public void actualizarEstadoLlamadaAFinalizada(Estado nuevoEstado)
        {
            llamada.finalizarLlamada(fechaHoraActual, nuevoEstado);
            llamada.setDescripcionOperador(respuestaOperador);

            CambioEstado primero = llamada.cambioEstado.ElementAt(0);

            CambioEstado ultimo = llamada.cambioEstado.ElementAt(llamada.cambioEstado.Count - 1 );
            llamada.calcularDuracion(primero.fechaHoraInicio, ultimo.fechaHoraInicio);


            // Prueba para mostrar que se crearon los cambios de estado, se seteo de la desc. del operador y la duración de la llamada.
            List<CambioEstado> lista = llamada.cambioEstado;
            MessageBox.Show(" Descripción operador: " + llamada.descripcionOperador +
                "\n Duración de la llamada: " + llamada.duracion.ToString("hh':'mm':'ss") +
                "\n Cantidad de cambios de estados: " + lista.Count.ToString(), "Datos de la llamada finalizada");

            
            finCU();
        }

        public void finCU()
        {
            pantalla.Close();
            segundaPantalla.Close();
        }




    }
}
