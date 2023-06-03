using PPAI_IVR.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_IVR
{
    public partial class PantallaRegistrarRtaOperador : Form
    {
        public GestorRegistrarRtaOperador gestor;
        public PantallaRegistrarRtaOperador(GestorRegistrarRtaOperador gestor)
        {
            this.gestor = gestor;
            InitializeComponent();
        }

        private void PantallaRegistrarRtaOperador_Load(object sender, EventArgs e)
        {
        }

        private void mostrarValidaciones_Click(object sender, EventArgs e)
        {
            gbValidaciones.Visible = true;
        }

        private void btnIngresarRta1_Click(object sender, EventArgs e)
        {
            lblRta1.Visible = true;
            txtRtaValidacion1.Visible = true;
        }
        private void btnIngresarRta2_Click(object sender, EventArgs e)
        {
            lblRta2.Visible = true;
            txtRtaValidacion2.Visible = true;
        }

        private void btnIngresarRta3_Click(object sender, EventArgs e)
        {
            lblRta3.Visible = true;
            txtRtaValidacion3.Visible = true;
        }

        public void mostrarDatosLlamada(string[] categoriaOpcionSubopcion, string nombreCliente, Llamada selecLlamada)
        {
            txtNombreCliente.Text = nombreCliente;

            cmbCategoria.Text = categoriaOpcionSubopcion[0];
            cmbOpcion.Text = categoriaOpcionSubopcion[1];
            cmbSubopcion.Text = categoriaOpcionSubopcion[2];

            gbValidaciones.Visible = true;
        }

        public void mostrarDatosValidaciones(List<string> nombresValidaciones)
        {
            //MEJORAR ? 
            int cantidadValidaciones = nombresValidaciones.Count;
            if (cantidadValidaciones == 0)
            {
                gbValidaciones.Visible = false;
            }
            else
            {
                if (cantidadValidaciones == 1)
                {
                    gbValidacion1.Visible = true;
                    gbValidacion2.Visible = false;
                    gbValidacion3.Visible = false;
                    txtValidacion1.Text = nombresValidaciones[0];

                }
                else
                {
                    if (cantidadValidaciones == 2)
                    {
                        gbValidacion1.Visible = true;
                        gbValidacion2.Visible = true;
                        gbValidacion3.Visible = false;
                        txtValidacion1.Text = nombresValidaciones[0];
                        txtValidacion2.Text = nombresValidaciones[1];

                    }
                    else
                    {
                        if (cantidadValidaciones == 3)
                        {
                            gbValidacion1.Visible = true;
                            gbValidacion2.Visible = true;
                            gbValidacion3.Visible = true;
                            txtValidacion1.Text = nombresValidaciones[0];
                            txtValidacion2.Text = nombresValidaciones[1];
                            txtValidacion3.Text = nombresValidaciones[2];

                        }
                    }
                }
            }
        }

        private void tomarRespuestas(object sender, EventArgs e)
        {
            string[] respuestas = new string[0];
            if (gbValidaciones.Visible == true)
            {
                if (gbValidacion1.Visible == true && gbValidacion2.Visible == false && gbValidacion3.Visible == false)
                {
                    respuestas = new string[1] { txtRtaValidacion1.Text };
                }
                if (gbValidacion1.Visible == true && gbValidacion2.Visible == true && gbValidacion3.Visible == false)
                {
                    respuestas = new string[2] { txtRtaValidacion1.Text, txtRtaValidacion2.Text };
                }
                if (gbValidacion1.Visible == true && gbValidacion2.Visible == true && gbValidacion3.Visible == true)
                {
                    respuestas = new string[3] { txtRtaValidacion1.Text, txtRtaValidacion2.Text, txtRtaValidacion3.Text };
                }
            }

            bool res = gestor.tomarRespuestasValidaciones(respuestas);
            if (res)
            {

                List<string> acciones = gestor.buscarAcciones();
                foreach (string accion in acciones)
                {
                    cmbAcciones.Items.Add(accion);
                }
                gbRespuestaOperador.Visible = true;

            }
            else
            {
                // Corregir condiciones (si los txt estaban vacíos por ejemplo)
                MessageBox.Show("Validaciones INCORRECTAS.\nIngrese el valor correcto", "Validacion Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRtaValidacion1.Clear();
                txtRtaValidacion2.Clear();
                txtRtaValidacion3.Clear();
            }

        }

        private void btnRegistrarRtaOperador_Click(object sender, EventArgs e)
        {
            tomarRespuestaOperador();
        }

        public void tomarRespuestaOperador()
        {
            gestor.tomarRespuestaOperador(txtRespuestaOperador.Text);

            tomarSeleccionAccion();

        }

        public void tomarSeleccionAccion()
        {
            gestor.tomarSeleccionAccion(cmbAcciones.SelectedText);
        }

        public void solicitarConfirmacion()
        {
            bool confirmacion = false;
            DialogResult result = MessageBox.Show("¿Desea confirmar la operación realizada?", "Confirmación", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                confirmacion = true;
            }

            confirmar(confirmacion);
        }

        public void confirmar(bool confirmacion)
        {
            gestor.tomarConfirmacion(confirmacion);
        }

    }
}
