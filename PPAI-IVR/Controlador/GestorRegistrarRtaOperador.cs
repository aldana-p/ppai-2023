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
        private OpcionLlamada opcion { get; set; }
        private CategoriaLlamada categoria { get; set; }
        private SubopcionLlamada subopcion { get; set; }
        private Cliente cliente { get; set; }
        private Estado estadoEnCurso { get; set; }
        private Estado estadoFinalizada { get; set; }
        private Estado estadoCancelado { get; set; }
        private List<Estado> estados { get; set; }
        private DateTime fechaHoraActual { get; set; }
        private PantallaRegistrarRtaOperador pantalla { get; set; }
        private List<Accion> acciones { get; set; }
        private string respuestaOperador { get; set; }
        private string accionSeleccionada { get; set; }

        public PantallaRegistrarRtaOperador Pantalla { get => pantalla; set => pantalla = value; }



        public GestorRegistrarRtaOperador(Llamada llamada, CategoriaLlamada categoria, List<Estado> estados, List<Accion> acciones)
        {
            this.llamada = llamada;
            this.opcion = llamada.OpcionSeleccionada;
            this.categoria = categoria;
            this.subopcion = llamada.SubopcionSeleccionada;
            this.cliente = llamada.Cliente;
            this.pantalla = new PantallaRegistrarRtaOperador(this);
            this.estados = estados;
            this.acciones = acciones;
        }
        public GestorRegistrarRtaOperador(Llamada llamada)
        {
            this.llamada = llamada;
        }

        public void registrarRespuestaOperador()
        {
            identificarOpcion(llamada);
        }

        public void identificarOpcion(Llamada llamada)
        {
            if (subopcion.Nombre == "Comunicarse con responsable de atención al cliente")
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
            string[] categoriaOpcionSubopcion = this.categoria.mostrarDatosCategoriaOpcionSubopcion(seleccionadaLlamada.OpcionSeleccionada, seleccionadaLlamada.SubopcionSeleccionada);

            buscarValidaciones(categoriaOpcionSubopcion, nombreCliente, seleccionadaLlamada);
            //pantalla.mostrarDatosLlamada(categoriaOpcionSubopcion, nombreCliente, seleccionadaLlamada);
        }

        // Método que busca los nombres de las validaciones a realizar
        public void buscarValidaciones(string[] categoriaOpcionSubopcion, string nombreCliente, Llamada selecLlamada)
        {
            List<string> validacionesRequeridas = subopcion.getValidacionesSubopcion();
            
            pantalla.mostrarDatosLlamada(categoriaOpcionSubopcion, nombreCliente, selecLlamada);
            pantalla.mostrarDatosValidaciones(validacionesRequeridas);
        }


        //MÉTODOS DEL LOOP PARA CADA RESPUESTA
        public string[] tomarRespuestasValidaciones(string[] respuestas)
        {
            return validarRespuestas(respuestas);
        }

        public string[] validarRespuestas(string[] respuestas)
        {
            string[] validaciones = new string[respuestas.Length];
            int contador = 0;

            foreach (string res in respuestas)
            {
                if (!llamada.validarRespuesta(res))
                {
                    validaciones[contador] = "Ingrese el valor correcto";
                };
                contador++;
            }
            return validaciones;
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
            pantalla.solicitarConfirmacion();

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
            MessageBox.Show("¡El CU 28:Registrar acción requerida se ejecutó con éxito!");
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

            CambioEstado primero = llamada.CambioEstado.ElementAt(1);

            CambioEstado ultimo = llamada.CambioEstado.ElementAt(llamada.CambioEstado.Count - 1);
            llamada.calcularDuracion(primero.FechaHoraInicio, ultimo.FechaHoraInicio);


            // Prueba para mostrar que se crearon los cambios de estado, se seteo de la desc. del operador y la duración de la llamada.
            List<CambioEstado> lista = llamada.CambioEstado;
            MessageBox.Show(" Descripción operador: " + llamada.DescripcionOperador +
                "\n Duración de la llamada: " + llamada.Duracion.ToString("hh':'mm':'ss") +
                "\n Cantidad de cambios de estados: " + lista.Count.ToString(), "Datos de la llamada finalizada");

            Console.WriteLine(" Descripción operador: " + llamada.DescripcionOperador +
                               "\n Duración de la llamada: " + llamada.Duracion.ToString("hh':'mm':'ss") +
                                              "\n Cantidad de cambios de estados: " + lista.Count.ToString());
            finCU();
        }

        public void buscarEstadoCancelado()
        {
            foreach (Estado estado in estados)
            {
                bool res = estado.esCancelado();
                if (res)
                {
                    estadoCancelado = estado;
                    break;
                }
            }
        }

        public void actualizarEstadoLlamadaACancelado(Estado nuevoEstado)
        {
            llamada.cancelarLlamada(fechaHoraActual, nuevoEstado);
            llamada.setDescripcionOperador(respuestaOperador);
        }

        public void cancelarLlamada()
        {
            buscarEstadoCancelado();
            fechaHoraActual = obtenerFechaHoraActual();
            actualizarEstadoLlamadaACancelado(estadoCancelado);
            List<CambioEstado> lista = llamada.CambioEstado;
            Console.WriteLine(" Estado actual de la Llamada: " + lista[2].Estado.Nombre);
                          
        }

        public void finCU()
        {
            pantalla.Close();
        }

    }
}
