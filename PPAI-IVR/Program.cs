using PPAI_IVR.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAI_IVR.Datos;
using System.Reflection.Emit;

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

            DatosCreados datos = new DatosCreados();
            Llamada llamadaSeleccionada = new Llamada("", null, datos.clientes[0], datos.opciones[0], datos.opciones[0].Subopcion[2], datos.cambiosEstado);


            GestorRegistrarRtaOperador gestor = new GestorRegistrarRtaOperador(llamadaSeleccionada, datos.categorias[0], datos.estados, datos.acciones);
            //PantallaRegistrarRtaOperador pantalla = new PantallaRegistrarRtaOperador(llamadaSeleccionada);
            
            
            gestor.registrarRespuestaOperador();

            Application.Run(gestor.Pantalla);

        
        }
    }
}
