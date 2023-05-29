using PPAI_IVR.Base_de_datos;
using PPAI_IVR.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_IVR
{
    public partial class PantallaRegistrarRtaOperador : Form
    {
        public PantallaRegistrarRtaOperador()
        {
            InitializeComponent();
            
        }

        private void PantallaRegistrarRtaOperador_Load(object sender, EventArgs e)
        { //Creacion estados
            Estado estadoIniciada = new Estado("Iniciada");
            Estado estadoEnCurso = new Estado("EnCurso");
            Estado estadoFinalizada = new Estado("Finalizada");
            Estado estadoCancelada = new Estado("Cancelada");
            List<Estado> estados = new List<Estado>();
            estados.Add(estadoIniciada);
            estados.Add(estadoEnCurso);
            estados.Add(estadoFinalizada);
            estados.Add(estadoCancelada);



            //Creacion Clientes
            Cliente cliente1 = new Cliente(123123, "Aldana");
            Cliente cliente2 = new Cliente(456456, "Virginia");


            //Crear Acciones
            Accion accion = new Accion("Anular tarjera");

            //Crear tipos informacion
            TipoInformacion tipoInfo1 = new TipoInformacion("fechaNacimiento");
            TipoInformacion tipoInfo2 = new TipoInformacion("codPostal");
            TipoInformacion tipoInfo3 = new TipoInformacion("cantidadHijos");

            //Opciones Validacion
            OpcionValidacion opVal1 = new OpcionValidacion(true, "3/10/89");
            OpcionValidacion opVal2 = new OpcionValidacion(false, "12/5/89");
            OpcionValidacion opVal3 = new OpcionValidacion(false, "5/8/89");
            List<OpcionValidacion> listaOpVal1 = new List<OpcionValidacion>();
            listaOpVal1.Add(opVal1);
            listaOpVal1.Add(opVal2);
            listaOpVal1.Add(opVal3);

            OpcionValidacion opVal4 = new OpcionValidacion(true, "5012");
            OpcionValidacion opVal5 = new OpcionValidacion(false, "5000");
            OpcionValidacion opVal6 = new OpcionValidacion(false, "5011");
            List<OpcionValidacion> listaOpVal2 = new List<OpcionValidacion>();
            listaOpVal2.Add(opVal4);
            listaOpVal2.Add(opVal5);
            listaOpVal2.Add(opVal6);

            Validacion val1 = new Validacion("", "Validar fecha nacimiento", listaOpVal1, tipoInfo1);
            Validacion val2 = new Validacion("", "Validar código postal", listaOpVal2, tipoInfo2);
            List<Validacion> listaValidacion1 = new List<Validacion>();
            listaValidacion1.Add(val1);
            listaValidacion1.Add(val2);

            List<Validacion> listaValidacion2 = new List<Validacion>();
            listaValidacion2.Add(val1);

            //Creacion subopciones
            Subopcion subop1 = new Subopcion("Cuenta con los datos de la tarjer", 1, listaValidacion1);
            Subopcion subop2 = new Subopcion("No cuenta con los datos de la tarjer", 2, listaValidacion2);
            Subopcion subop3 = new Subopcion("Comunicarse con responsable de atención al cliente", 3, listaValidacion2);
            List<Subopcion> listaSubop1 = new List<Subopcion>();
            listaSubop1.Add(subop1);
            listaSubop1.Add(subop2);
            listaSubop1.Add(subop3);

            //Creacion opciones
            Opcion op1 = new Opcion("Informar robo y solicitar nueva tarjeta", 1, listaSubop1);
            Opcion op2 = new Opcion("Informar robo y anular tarjeta", 2, listaSubop1);
            Opcion op3 = new Opcion("Finalizar llamada", 3, listaSubop1);
            List<Opcion> listaOp1 = new List<Opcion>();
            listaOp1.Add(op1);
            listaOp1.Add(op2);
            listaOp1.Add(op3);

            //Creacion categorias
            Categoria cat1 = new Categoria("Informar robo", 1, listaOp1);
            Categoria cat2 = new Categoria("Tarjeta bloqueada", 2, listaOp1);


            //Creacion Cambios Estado
            CambioEstado ce1 = new CambioEstado(DateTime.Now, estadoIniciada);

            List<CambioEstado> listaCambiosEstado = new List<CambioEstado>();
            listaCambiosEstado.Add(ce1);


            Usuario operador = new Usuario("NombreOperador");

            //Creacion LLamada

            Llamada llamadaSeleccionada = new Llamada("", null, cliente1, operador, op1, subop3, listaCambiosEstado);



            GestorRegistrarRtaOperador gestor = new GestorRegistrarRtaOperador(llamadaSeleccionada, cat1, this, estados);
            GestorRegistrarRtaOperador.registrarRespuestaOperador(llamadaSeleccionada, cat1, this, gestor);



            gestor.buscarDatosLlamada(llamadaSeleccionada);



        }


        private void button1_Click_1(object sender, EventArgs e)
        {
        }
    }
}
