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

            lblValidacionError1.Visible = false;
            lblValidacionError2.Visible = false;
            lblValidacionError3.Visible = false;

            habilitarPantalla();
        }

        public void habilitarPantalla()
        {
            this.Show();
        }

        public void mostrarDatosValidaciones(List<string> nombresValidaciones)
        {
            int cantidadValidaciones = nombresValidaciones.Count;
            if (cantidadValidaciones == 0)
            {
                gbValidaciones.Visible = false;
            }
            else
            {
                gbValidacion1.Visible = false;
                gbValidacion2.Visible = false;
                gbValidacion3.Visible = false;

                if (cantidadValidaciones >= 1)
                {
                    gbValidacion1.Visible = true;
                    txtValidacion1.Text = nombresValidaciones[0];
                }
                if (cantidadValidaciones >= 2)
                {
                    gbValidacion2.Visible = true;
                    txtValidacion2.Text = nombresValidaciones[1];
                }
                if (cantidadValidaciones >= 3)
                {
                    gbValidacion3.Visible = true;
                    txtValidacion3.Text = nombresValidaciones[2];
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

            string[] res = gestor.tomarRespuestasValidaciones(respuestas);

            //clear all error labels
            lblValidacionError1.Text = "";
            lblValidacionError1.Visible = false;
            lblValidacionError2.Text = "";
            lblValidacionError2.Visible = false;
            lblValidacionError3.Text = "";
            lblValidacionError3.Visible = false;

            bool sinErrores = true;

            for( int i = 0; i < res.Length; i++)
            {
                if (res[i] != null)
                {
                    if (i == 0)
                    {
                        lblValidacionError1.Text = res[i].ToString();
                        lblValidacionError1.Visible = true;
                        lblValidacionError1.ForeColor = Color.Red;
                        txtRtaValidacion1.Clear();
                        sinErrores = false;
                    }
                    if (i == 1)
                    {
                        lblValidacionError2.Text = res[i].ToString();
                        lblValidacionError2.Visible = true;
                        lblValidacionError2.ForeColor = Color.Red;
                        txtRtaValidacion2.Clear();
                        sinErrores = false;
                    }
                    if (i == 2)
                    {
                        lblValidacionError3.Text = res[i].ToString();
                        lblValidacionError3.Visible = true;
                        lblValidacionError3.ForeColor = Color.Red;
                        txtRtaValidacion3.Clear();
                        sinErrores = false;
                    }
                }
            } 
            if(sinErrores)
            {
                List<string> acciones = gestor.buscarAcciones();
                foreach (string accion in acciones)
                {
                      cmbAcciones.Items.Add(accion);
                }
                    gbRespuestaOperador.Visible = true;
            }
        }

        private void btnRegistrarRtaOperador_Click(object sender, EventArgs e)
        {
            if (txtRespuestaOperador.Text != "" && cmbAcciones.Text != "")
            {
                tomarRespuestaOperador();
            }
            else
            {
                MessageBox.Show("Debe ingresar una respuesta y seleccionar una acción");
            }
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
                confirmar(confirmacion);
            }
            
        }

        public void confirmar(bool confirmacion)
        {
            gestor.tomarConfirmacion(confirmacion);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gestor.cancelarLlamada();
            DialogResult result = MessageBox.Show("La llamada fue colgada por el cliente", "AVISO", MessageBoxButtons.OK);
            this.Close();
        }
    }
}
