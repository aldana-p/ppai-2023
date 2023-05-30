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
        private List<Estado> estados;  
        private DateTime fechaHoraActual;
        private PantallaRegistrarRtaOperador pantalla;
        

        public GestorRegistrarRtaOperador(Llamada llamada, Categoria categoria, List<Estado> estados, PantallaRegistrarRtaOperador pantalla) //Traigo los estados para poder buscar el que necesito después (VER CÓMO RESOLVER SINO)

        {
            this.llamada = llamada;
            this.opcion = llamada.opcionSeleccionada;
            this.categoria = categoria;
            this.subopcion = llamada.subopcionSeleccionada;
            this.cliente = llamada.cliente;
            this.pantalla = pantalla;
            this.estados = estados;


        }
        /*
        // Método que tiene como parámetro la llamada, la categoría, la oción y a subopción seleccionada.
        public static void registrarRespuestaOperador(Llamada llamadaSeleccionada, Categoria categoria, PantallaRegistrarRtaOperador pantalla, GestorRegistrarRtaOperador gestor)        {
            //El gestor tiene la llamada seleccionada, la opcion seleccionada, la subopcion seleccionada y la categoria seleccionada
            
            //GestorRegistrarRtaOperador gestor = new GestorRegistrarRtaOperador(llamadaSeleccionada, categoria, pantalla);
            gestor.identificarOpcion(llamadaSeleccionada);
        }
        */

        public static void comunicarseConOperador(Llamada llamada, Categoria categoria, List<Estado> estados, PantallaRegistrarRtaOperador pantalla)
        {
            GestorRegistrarRtaOperador gestor = new GestorRegistrarRtaOperador(llamada, categoria, estados, pantalla);
            //gestor.buscarDatosLlamada(llamada);

            gestor.identificarOpcion(llamada);

        }

        public void identificarOpcion(Llamada llamada) { 
            if (subopcion.nombre == "Comunicarse con responsable de atención al cliente")
            {
                buscarEstadoEnCurso();
            }
        }

        // No funciona la creación del cambio de estado
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

            obtenerFechaHoraActual();

        }

        public void obtenerFechaHoraActual()
        {
            fechaHoraActual = DateTime.Now;
            actualizarEstadoLlamada(estadoEnCurso);

        }

        public void actualizarEstadoLlamada(Estado nuevoEstado)
        {
            llamada.contestarLlamada(fechaHoraActual, nuevoEstado);
            buscarDatosLlamada(llamada);

        }


        // Método que obtiene el nombre de la categoría, opción y subopción seleccionadas.
        public void buscarDatosLlamada(Llamada seleccionadaLlamada)
        {
            string nombreCliente = seleccionadaLlamada.buscarDatosLlamada();
            string[] categoriaOpcionSubopcion = this.categoria.mostrarDatosCategoriaOpcionSubopcion(seleccionadaLlamada.opcionSeleccionada, seleccionadaLlamada.subopcionSeleccionada);

            buscarValidaciones();

            mostrarDatosLlamada(categoriaOpcionSubopcion, nombreCliente, seleccionadaLlamada);
        }


        // Método que busca los nombres de las validaciones a realizar
        public void buscarValidaciones()
        {
            List<Validacion> validacionesRequeridas = subopcion.getValidacionesSubopcion();
            List<string> nombresValidaciones = new List<string>();
            for (int i = 0; i < validacionesRequeridas.Count; i++)
            {
                nombresValidaciones.Add(validacionesRequeridas[i].getValidacion());
                
            };

            /*A mostrar datos también le voy a tener que pasar los objetos Validacion porque necesito las opciones
            (podría haber buscando entonces sólo los objetos, pero si hago eso no cumplo con el diagrama de secuncia,
            que tiene el método getValidacion() en Validacion    --------> ver si se puede resolver de otra manera
            */

            mostrarDatosValidaciones(nombresValidaciones, validacionesRequeridas);
        }

        // Método que muestra los datos de la llamada en la pantalla
        public void mostrarDatosLlamada(string[] categoriaOpcionSubopcion, string nombreCliente, Llamada selecLlamada)
        {
            pantalla.txtNombreCliente.Text = nombreCliente;

            pantalla.cmbCategoria.SelectedText = categoriaOpcionSubopcion[0];
            pantalla.cmbOpcion.SelectedText = categoriaOpcionSubopcion[1];
            pantalla.cmbSubopcion.SelectedText = categoriaOpcionSubopcion[2];

            List<CambioEstado> lista = selecLlamada.cambioEstado;

            //Pruebas para ver que efectivamente se creo el nuevo CambioEstado
            pantalla.label10.Text = lista.Count.ToString();
            pantalla.label8.Text = lista[0].estado.nombre;
            pantalla.label9.Text = estadoEnCurso.nombre;
        }

        //Método que muestra los nombres de las validaciones a realizar (ver si hay otra forma de hacerlo sin anidar los if-else)
        public void mostrarDatosValidaciones(List<string> nombresValidaciones, List<Validacion> validaciones)
        {
            int cantidadValidaciones = nombresValidaciones.Count;
            if (cantidadValidaciones == 0)
            {
                pantalla.gbValidaciones.Visible = false;
            }
            else
            {
                if (cantidadValidaciones == 1)
                {
                    pantalla.gbValidacion1.Visible = true;
                    pantalla.gbValidacion2.Visible = false;
                    pantalla.gbValidacion3.Visible = false;

                    List<OpcionValidacion> opcionesValidacion = validaciones.ElementAt(0).opcionesValidacion;
                    pantalla.txtValidacion1.Text = nombresValidaciones.ElementAt(0);
                    pantalla.cmbOpValidacion1.Items.Add(opcionesValidacion.ElementAt(0).descripcion);
                    pantalla.cmbOpValidacion1.Items.Add(opcionesValidacion.ElementAt(1).descripcion);
                    pantalla.cmbOpValidacion1.Items.Add(opcionesValidacion.ElementAt(2).descripcion);

                }
                else
                {
                    if (cantidadValidaciones == 2)
                    {
                        pantalla.gbValidacion1.Visible = true;
                        pantalla.gbValidacion2.Visible = true;
                        pantalla.gbValidacion3.Visible = false;

                        List<OpcionValidacion> opcionesValidacion1 = validaciones.ElementAt(0).opcionesValidacion;
                        pantalla.txtValidacion1.Text = nombresValidaciones.ElementAt(0);
                        pantalla.cmbOpValidacion1.Items.Add(opcionesValidacion1.ElementAt(0).descripcion);
                        pantalla.cmbOpValidacion1.Items.Add(opcionesValidacion1.ElementAt(1).descripcion);
                        pantalla.cmbOpValidacion1.Items.Add(opcionesValidacion1.ElementAt(2).descripcion);

                        List<OpcionValidacion> opcionesValidacion2= validaciones.ElementAt(1).opcionesValidacion;
                        pantalla.txtValidacion2.Text = nombresValidaciones.ElementAt(1);
                        pantalla.cmbOpValidacion2.Items.Add(opcionesValidacion2.ElementAt(0).descripcion);
                        pantalla.cmbOpValidacion2.Items.Add(opcionesValidacion2.ElementAt(1).descripcion);
                        pantalla.cmbOpValidacion2.Items.Add(opcionesValidacion2.ElementAt(2).descripcion);

                    }
                    else
                    {
                        if (cantidadValidaciones == 3)
                        {
                            pantalla.gbValidacion1.Visible = true;
                            pantalla.gbValidacion2.Visible = true;
                            pantalla.gbValidacion3.Visible = true;
                            pantalla.txtValidacion1.Text = nombresValidaciones.ElementAt(0);
                            pantalla.txtValidacion2.Text = nombresValidaciones.ElementAt(1);
                            pantalla.txtValidacion3.Text = nombresValidaciones.ElementAt(2);
                        }
                    }
                }
            }
        }

        /*
        public void tomarRespuestas()
        {
            validarRespuestas();
        } 

        
        public void validarRespuestas()
        {
            llamada.validarRespuestaCliente();
        }
        */


      




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
