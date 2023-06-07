using PPAI_IVR.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR.Datos
{
    public class DatosCreados
    {
        public List<Accion> acciones;
        public List<Estado> estados;
        public List<Cliente> clientes;
        public List<OpcionLlamada> opciones;
        public List<CategoriaLlamada> categorias;
        public List<CambioEstado> cambiosEstado;

        public DatosCreados()
        {
            //Crear acciones
            Accion accion1 = new Accion("Comunicar saldo");
            Accion accion2 = new Accion("Dar de baja a tarjeta");
            Accion accion3 = new Accion("Denunciar robo");
            List<Accion> acciones = new List<Accion>();
            acciones.Add(accion1);
            acciones.Add(accion2);
            acciones.Add(accion3);

            this.acciones = acciones;

            //Creacion estados
            Estado estadoIniciada = new Estado("Iniciada");
            Estado estadoEnCurso = new Estado("EnCurso");
            Estado estadoFinalizada = new Estado("Finalizada");
            Estado estadoCancelada = new Estado("Cancelado");
            List<Estado> estados = new List<Estado>();
            estados.Add(estadoIniciada);
            estados.Add(estadoEnCurso);
            estados.Add(estadoFinalizada);
            estados.Add(estadoCancelada);

            this.estados = estados;

            InformacionCliente infoCliente1 = new InformacionCliente("10/10/2000");
            InformacionCliente infoCliente2= new InformacionCliente("5012");
            InformacionCliente infoCliente3 = new InformacionCliente("0");
            List<InformacionCliente> informaciones = new List<InformacionCliente>();
            informaciones.Add(infoCliente1);
            informaciones.Add(infoCliente2);
            informaciones.Add(infoCliente3);

            //Creacion Clientes
            Cliente cliente1 = new Cliente(123123, "Gómez Juan", informaciones);
            List<Cliente> clientes = new List<Cliente>();
            clientes.Add(cliente1);

            this.clientes = clientes;


            /*
            //Crear tipos informacion
            TipoInformacion tipoInfo1 = new TipoInformacion("fechaNacimiento");
            TipoInformacion tipoInfo2 = new TipoInformacion("codPostal");
            TipoInformacion tipoInfo3 = new TipoInformacion("cantidadHijos");
            List<TipoInformacion> tiposInfo = new List<TipoInformacion>();
            tiposInfo.Add(tipoInfo1);
            tiposInfo.Add(tipoInfo2);
            tiposInfo.Add(tipoInfo3);

            //Opciones Validacion  (no es necesario)
            
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
            */


            Validacion val1 = new Validacion("Validar fecha nacimiento");
            Validacion val2 = new Validacion("Validar código postal");
            List<Validacion> listaValidacion1 = new List<Validacion>();
            listaValidacion1.Add(val1);
            listaValidacion1.Add(val2);

            List<Validacion> listaValidacion2 = new List<Validacion>();
            listaValidacion2.Add(val1);

            //Creacion subopciones
            SubopcionLlamada subop1 = new SubopcionLlamada("Cuenta con los datos de la tarjeta", 1, listaValidacion1);
            SubopcionLlamada subop2 = new SubopcionLlamada("No cuenta con los datos de la tarjeta", 2, listaValidacion1);
            SubopcionLlamada subop3 = new SubopcionLlamada("Comunicarse con responsable de atención al cliente", 3, listaValidacion1);
            List<SubopcionLlamada> listaSubop1 = new List<SubopcionLlamada>();
            listaSubop1.Add(subop1);
            listaSubop1.Add(subop2);
            listaSubop1.Add(subop3);

            //Creacion opciones
            OpcionLlamada op1 = new OpcionLlamada("Informar robo y solicitar nueva tarjeta", 1, listaSubop1);
            OpcionLlamada op2 = new OpcionLlamada("Informar robo y anular tarjeta", 2, listaSubop1);
            OpcionLlamada op3 = new OpcionLlamada("Finalizar llamada", 3, listaSubop1);
            List<OpcionLlamada> listaOp1 = new List<OpcionLlamada>();
            listaOp1.Add(op1);
            listaOp1.Add(op2);
            listaOp1.Add(op3);

            this.opciones = listaOp1;

            //Creacion categorias
            CategoriaLlamada cat1 = new CategoriaLlamada("Informar robo", 1, listaOp1);
            CategoriaLlamada cat2 = new CategoriaLlamada("Tarjeta bloqueada", 2, listaOp1);
            List<CategoriaLlamada> categorias = new List<CategoriaLlamada>();
            categorias.Add(cat1);
            categorias.Add(cat2);
  
            this.categorias = categorias;
                
            //Creacion Cambios Estado
            CambioEstado ce1 = new CambioEstado(DateTime.Now, estadoIniciada);

            List<CambioEstado> listaCambiosEstado = new List<CambioEstado>();
            listaCambiosEstado.Add(ce1);

            this.cambiosEstado = listaCambiosEstado;

        }
    }
}
