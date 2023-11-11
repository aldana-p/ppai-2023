using PPAI_IVR.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAI_IVR.Datos;
using System.Reflection.Emit;
using System.Data;

namespace PPAI_IVR
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            DataTable llamadas = AccesoBD.ObtenerLlamadas();       //Deberíamos buscarla por id para asegurarnos de sólo obtener 1????

            
            DataTable cambiosEstado = AccesoBD.ObtenerCambiosEstados(int.Parse(llamadas.Rows[0]["idLlamada"].ToString()));
            List<CambioEstado> ce = new List<CambioEstado>();
            for (int i = 0; i < cambiosEstado.Rows.Count; i++)
            {
                if (cambiosEstado.Rows[i]["nombre"].ToString() == "Iniciada")
                {
                    Estado estado = new Iniciada("Iniciada", 1);
                    CambioEstado iniciadaCE = new CambioEstado(Convert.ToDateTime(cambiosEstado.Rows[i]["fechaHoraInicia"].ToString()), estado);
                    
                    ce.Add(iniciadaCE);
                }                
                if (cambiosEstado.Rows[i]["nombre"].ToString() == "EnCurso")
                {
                    Estado estado = new EnCurso("EnCurso", 2);
                    CambioEstado enCursoCE = new CambioEstado(Convert.ToDateTime(cambiosEstado.Rows[i]["fechaHoraInicia"].ToString()), estado);
                    ce.Add(enCursoCE);
                }
                if (cambiosEstado.Rows[i]["nombre"].ToString() == "Finalizada")
                {
                    Estado estado = new Finalizada("Finalizada", 3);
                    CambioEstado finalizadaCE = new CambioEstado(Convert.ToDateTime(cambiosEstado.Rows[i]["fechaHoraInicia"].ToString()), estado);
                    ce.Add(finalizadaCE);
                }

                //FALTA CANCELADA
            }


            DataTable dtValidaciones = AccesoBD.ObtenerValidaciones(int.Parse(llamadas.Rows[0]["subopcionSeleccionada"].ToString()));
            List<Validacion> validaciones = new List<Validacion>();
            for (int i = 0; i < dtValidaciones.Rows.Count; i++)
            {
                Validacion val = new Validacion(dtValidaciones.Rows[i]["nombre"].ToString());
                validaciones.Add(val);
            }

            SubopcionLlamada subopcionSeleccionada = new SubopcionLlamada(dtValidaciones.Rows[0]["nombreSubopcion"].ToString(), int.Parse(llamadas.Rows[0]["subopcionSeleccionada"].ToString()), validaciones);


            DataTable dtSubopciones = AccesoBD.ObtenerSubopciones(int.Parse(llamadas.Rows[0]["opcionSeleccionada"].ToString()));
            List<SubopcionLlamada> subopciones = new List<SubopcionLlamada>();
            for (int i = 0; i < dtSubopciones.Rows.Count; i++)
            {
                SubopcionLlamada subop = new SubopcionLlamada(dtSubopciones.Rows[i]["nombreSubopcion"].ToString(), int.Parse(dtSubopciones.Rows[i]["nroOrdenSubopcion"].ToString()), validaciones);
                subopciones.Add(subop);
            }

            OpcionLlamada opcionSeleccionada = new OpcionLlamada(dtSubopciones.Rows[0]["nombreOpcion"].ToString(), int.Parse(llamadas.Rows[0]["opcionSeleccionada"].ToString()), subopciones);



            DataTable informaciones = AccesoBD.ObtenerInformaciones(int.Parse(llamadas.Rows[0]["dniCliente"].ToString()));
            List<InformacionCliente> infos = new List<InformacionCliente>();
            for (int i = 0; i < informaciones.Rows.Count; i++)
            {
                InformacionCliente info = new InformacionCliente(informaciones.Rows[i]["datoAValidar"].ToString());
                infos.Add(info);
            }

            Cliente cliente = new Cliente(int.Parse(llamadas.Rows[0]["dniCliente"].ToString()), llamadas.Rows[0]["nombreCompleto"].ToString(), infos);


            Llamada llamadaSeleccionada = new Llamada(int.Parse(llamadas.Rows[0]["idLlamada"].ToString()),"", null, cliente, opcionSeleccionada, subopcionSeleccionada, ce);


            DataTable dtOpciones = AccesoBD.ObtenerOpciones(int.Parse(llamadas.Rows[0]["nroCategoria"].ToString()));
            List<OpcionLlamada> opciones = new List<OpcionLlamada>();
            for (int i = 0; i < dtOpciones.Rows.Count; i++)
            {
                OpcionLlamada op = new OpcionLlamada(dtOpciones.Rows[i]["nombreOpcion"].ToString(), int.Parse(dtOpciones.Rows[i]["nroOrdenOpcion"].ToString()), subopciones);
                opciones.Add(op);
            }
            CategoriaLlamada categoria= new CategoriaLlamada(dtOpciones.Rows[0]["nombreCategoria"].ToString(), int.Parse(llamadas.Rows[0]["nroCategoria"].ToString()), opciones);


            DataTable dtAcciones = AccesoBD.ObtenerAcciones();
            List<Accion> acciones = new List<Accion>();
            for (int i =0; i < dtAcciones.Rows.Count; i++)
            {
                Accion accion = new Accion(dtAcciones.Rows[i]["descripcion"].ToString());
                acciones.Add(accion);
            }

            GestorRegistrarRtaOperador gestor = new GestorRegistrarRtaOperador(llamadaSeleccionada, categoria, acciones);

            gestor.registrarRespuestaOperador();

            Application.Run(gestor.Pantalla);

        }
    } 
}
           