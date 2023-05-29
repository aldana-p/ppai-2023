using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_IVR.Clases
{
    public class GestorRegistrarRtaOperador
    {
        private Llamada llamada;
        private Opcion opcion;
        private Categoria categoria;
        private Subopcion subopcion;
        private Cliente cliente;
        private Estado estadoEnCurso;
        private List<Estado> estados;   //hace falta?
        private DateTime fechaHoraActual;
        private PantallaRegistrarRtaOperador pantalla;


        public GestorRegistrarRtaOperador(Llamada llamada, Categoria categoria, PantallaRegistrarRtaOperador pantalla, List<Estado> estados) //Traigo los estados para poder buscar el que necesito después (VER CÓMO RESOLVER SINO)

        {
            this.llamada = llamada;
            this.opcion = llamada.opcionSeleccionada;
            this.categoria = categoria;
            this.subopcion = llamada.subopcionSeleccionada;
            this.cliente = llamada.cliente;
            this.pantalla = pantalla;
            this.estados = estados;


        }
        public static void registrarRespuestaOperador(Llamada llamadaSeleccionada, Categoria categoria, PantallaRegistrarRtaOperador pantalla, GestorRegistrarRtaOperador gestor)        {
            //El gestor tiene la llamada seleccionada, la opcion seleccionada, la subopcion seleccionada y la categoria seleccionada
            
            //GestorRegistrarRtaOperador gestor = new GestorRegistrarRtaOperador(llamadaSeleccionada, categoria, pantalla);
            gestor.identificarOpcion(llamadaSeleccionada);
        }

        public void identificarOpcion(Llamada llamada) { 
            if (llamada.subopcionSeleccionada.nombre == "Comunicarse con operador")
            {
                buscarEstadoEnCurso(llamada);
            }
        }

       


        // No funciona la creación del cambio de estado
        public void buscarEstadoEnCurso(Llamada llamada)
        {

            estadoEnCurso = Estado.esEnCurso(estados);
            obtenerFechaHoraActual(llamada);

        }

        public void obtenerFechaHoraActual(Llamada llamada)
        {
            fechaHoraActual = DateTime.Now;
            actualizarEstadoLlamada(estadoEnCurso, llamada);

        }

        public void actualizarEstadoLlamada(Estado nuevoEstado,Llamada llamada)
        {
            llamada.contestarLlamada(fechaHoraActual, nuevoEstado);
            buscarDatosLlamada(llamada);

        }


        public void buscarDatosLlamada(Llamada seleccionadaLlamada)
        {
            pantalla.txtNombreCliente.Text = seleccionadaLlamada.buscarDatosLlamada();

            string[] categoriaOpcionSubopcion = this.categoria.mostrarDatosCategoriaOpcionSubopcion(seleccionadaLlamada.opcionSeleccionada, seleccionadaLlamada.subopcionSeleccionada);
            pantalla.cmbCategoria.SelectedText = categoriaOpcionSubopcion[0];
            pantalla.cmbOpcion.SelectedText = categoriaOpcionSubopcion[1];
            pantalla.cmbSubopcion.SelectedText = categoriaOpcionSubopcion[2];

            List<CambioEstado> lista = seleccionadaLlamada.cambioEstado;

            pantalla.label10.Text = lista.Count.ToString();
            pantalla.label8.Text = lista[0].estado.nombre;
            
            //pantalla.label9.Text = lista[1].estado.nombre;
        }


      




        /*


        public static Estado buscarEstadoParaAsignar(Llamada seleccionada)
        {
            Estado estado = Estado.esEnCurso();
            // Tengo que crear el CambioDeEstado asignandole el objeto estado
            DateTime fechaHoraActual = obtenerFechaHoraActual();
            seleccionada.contestar(fechaHoraActual, );
            

        }

        
        
        public void crearCambioEstado(DateTime fechaHoraActual, Estado estado, Llamada llamada)
        {
            //contestar() o pasarConOperador())
            llamada.contestar(fechaHoraActual, estado);
        }

        

        */
    }
}
