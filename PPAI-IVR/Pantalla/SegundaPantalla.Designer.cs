namespace PPAI_IVR.Pantalla
{
    partial class SegundaPantalla
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SegundaPantalla));
            this.btnRegistrarRtaOperador = new System.Windows.Forms.Button();
            this.cmbAcciones = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRespuestaOperador = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRegistrarRtaOperador
            // 
            this.btnRegistrarRtaOperador.Location = new System.Drawing.Point(378, 249);
            this.btnRegistrarRtaOperador.Name = "btnRegistrarRtaOperador";
            this.btnRegistrarRtaOperador.Size = new System.Drawing.Size(156, 50);
            this.btnRegistrarRtaOperador.TabIndex = 41;
            this.btnRegistrarRtaOperador.Text = "Registrar respuesta";
            this.btnRegistrarRtaOperador.UseVisualStyleBackColor = true;
            this.btnRegistrarRtaOperador.Click += new System.EventHandler(this.btnRegistrarRtaOperador_Click);
            // 
            // cmbAcciones
            // 
            this.cmbAcciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAcciones.FormattingEnabled = true;
            this.cmbAcciones.Location = new System.Drawing.Point(186, 198);
            this.cmbAcciones.Name = "cmbAcciones";
            this.cmbAcciones.Size = new System.Drawing.Size(315, 24);
            this.cmbAcciones.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(46, 201);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 16);
            this.label13.TabIndex = 39;
            this.label13.Text = "Acciones a realizar:";
            // 
            // txtRespuestaOperador
            // 
            this.txtRespuestaOperador.Location = new System.Drawing.Point(186, 54);
            this.txtRespuestaOperador.Name = "txtRespuestaOperador";
            this.txtRespuestaOperador.Size = new System.Drawing.Size(315, 115);
            this.txtRespuestaOperador.TabIndex = 38;
            this.txtRespuestaOperador.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(35, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 16);
            this.label12.TabIndex = 37;
            this.label12.Text = "Respuesta operador:";
            // 
            // SegundaPantalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 326);
            this.Controls.Add(this.btnRegistrarRtaOperador);
            this.Controls.Add(this.cmbAcciones);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtRespuestaOperador);
            this.Controls.Add(this.label12);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SegundaPantalla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Respuesta del operador";
            this.Load += new System.EventHandler(this.SegundaPantalla_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrarRtaOperador;
        private System.Windows.Forms.ComboBox cmbAcciones;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox txtRespuestaOperador;
        private System.Windows.Forms.Label label12;
    }
}