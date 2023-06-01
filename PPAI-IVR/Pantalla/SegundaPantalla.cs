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

namespace PPAI_IVR.Pantalla
{
    public partial class SegundaPantalla : Form
    {
        public GestorRegistrarRtaOperador gestor;
        public SegundaPantalla(GestorRegistrarRtaOperador gestor)
        {
            InitializeComponent();
            this.gestor = gestor;
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

        private void SegundaPantalla_Load(object sender, EventArgs e)
        {
            List<string> acciones = gestor.buscarAcciones();
            foreach (string accion in acciones)
            {
                cmbAcciones.Items.Add(accion);
            }
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
