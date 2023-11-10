﻿using System;
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
        //private List<Estado> estados { get; set; }
        private DateTime fechaHoraActual { get; set; }
        private PantallaRegistrarRtaOperador pantalla { get; set; }
        private List<Accion> acciones { get; set; }
        private string respuestaOperador { get; set; }
        private string accionSeleccionada { get; set; }

        public PantallaRegistrarRtaOperador Pantalla { get => pantalla; set => pantalla = value; }



        public GestorRegistrarRtaOperador(Llamada llamada, CategoriaLlamada categoria, List<Accion> acciones)
        {
            this.llamada = llamada;
            this.opcion = llamada.OpcionSeleccionada;
            this.categoria = categoria;
            this.subopcion = llamada.SubopcionSeleccionada;
            this.cliente = llamada.Cliente;
            this.pantalla = new PantallaRegistrarRtaOperador(this);
            //this.estados = estados;
            this.acciones = acciones;
        }

        public void registrarRespuestaOperador()
        {
            identificarOpcion(llamada);
        }

        public void identificarOpcion(Llamada llamada)
        {
            
            if (subopcion.Nombre == "Comunicarse con atención al cliente")
            {
                actualizarEstadoLlamadaAEnCurso(llamada);  //patrón
            }
        }

        public DateTime obtenerFechaHoraActual()
        {
            return DateTime.Now;

        }

        //patrón
        public void actualizarEstadoLlamadaAEnCurso(Llamada llamada) 
        {
            fechaHoraActual = obtenerFechaHoraActual();
            llamada.contestarLlamada(fechaHoraActual);
            buscarDatosLlamada(llamada);
        }

        // Método que obtiene el nombre de la categoría, opción y subopción seleccionadas.
        public void buscarDatosLlamada(Llamada seleccionadaLlamada)
        {
            string nombreCliente = seleccionadaLlamada.buscarDatosLlamada();
            string[] categoriaOpcionSubopcion = this.categoria.mostrarDatosCategoriaOpcionSubopcion(seleccionadaLlamada.OpcionSeleccionada, seleccionadaLlamada.SubopcionSeleccionada);

            buscarValidaciones(categoriaOpcionSubopcion, nombreCliente, seleccionadaLlamada);
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
                //patron
                llamada.finalizarLlamada(fechaHoraActual, respuestaOperador);
                finCU();

            };
        }

        public bool llamarCU28RegistrarAccion()
        {
            MessageBox.Show("¡El CU 28:Registrar acción requerida se ejecutó con éxito!");
            return true;  

        }


      

        /*    VER CANCELACION
        public void buscarEstadoCancelada()
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

            fechaHoraActual = obtenerFechaHoraActual();
            actualizarEstadoLlamadaACancelado(estadoCancelado);
        }

        public void actualizarEstadoLlamadaACancelado(Estado nuevoEstado)
        {
            llamada.cancelarLlamada(fechaHoraActual, nuevoEstado);
            List<CambioEstado> lista = llamada.CambioEstado;
            Console.WriteLine(" Estado actual de la Llamada: " + lista[2].Estado.Nombre);
        }


        */

        public void finCU()
        {
            pantalla.Close();
        }


    }
}
