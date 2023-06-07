namespace PPAI_IVR
{
    partial class PantallaRegistrarRtaOperador
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaRegistrarRtaOperador));
            this.lblDatosLlamada = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.cmbOpcion = new System.Windows.Forms.ComboBox();
            this.cmbSubopcion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtValidacion1 = new System.Windows.Forms.TextBox();
            this.gbValidaciones = new System.Windows.Forms.GroupBox();
            this.gbValidacion3 = new System.Windows.Forms.GroupBox();
            this.lblValidacionError3 = new System.Windows.Forms.Label();
            this.txtRtaValidacion3 = new System.Windows.Forms.TextBox();
            this.lblRta3 = new System.Windows.Forms.Label();
            this.txtValidacion3 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.gbValidacion2 = new System.Windows.Forms.GroupBox();
            this.lblValidacionError2 = new System.Windows.Forms.Label();
            this.txtRtaValidacion2 = new System.Windows.Forms.TextBox();
            this.lblRta2 = new System.Windows.Forms.Label();
            this.txtValidacion2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbValidacion1 = new System.Windows.Forms.GroupBox();
            this.lblValidacionError1 = new System.Windows.Forms.Label();
            this.txtRtaValidacion1 = new System.Windows.Forms.TextBox();
            this.lblRta1 = new System.Windows.Forms.Label();
            this.btnValidarRespuestas = new System.Windows.Forms.Button();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.btnRegistrarRtaOperador = new System.Windows.Forms.Button();
            this.cmbAcciones = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRespuestaOperador = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gbRespuestaOperador = new System.Windows.Forms.GroupBox();
            this.btnColgarLlamada = new System.Windows.Forms.Button();
            this.gbValidaciones.SuspendLayout();
            this.gbValidacion3.SuspendLayout();
            this.gbValidacion2.SuspendLayout();
            this.gbValidacion1.SuspendLayout();
            this.gbRespuestaOperador.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDatosLlamada
            // 
            this.lblDatosLlamada.AutoSize = true;
            this.lblDatosLlamada.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosLlamada.Location = new System.Drawing.Point(9, 11);
            this.lblDatosLlamada.Name = "lblDatosLlamada";
            this.lblDatosLlamada.Size = new System.Drawing.Size(213, 27);
            this.lblDatosLlamada.TabIndex = 0;
            this.lblDatosLlamada.Text = "Datos de la llamada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Categoría:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Opción:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Subopción:";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.Location = new System.Drawing.Point(116, 65);
            this.txtNombreCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(290, 22);
            this.txtNombreCliente.TabIndex = 5;
            // 
            // cmbOpcion
            // 
            this.cmbOpcion.Enabled = false;
            this.cmbOpcion.FormattingEnabled = true;
            this.cmbOpcion.Location = new System.Drawing.Point(116, 139);
            this.cmbOpcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbOpcion.Name = "cmbOpcion";
            this.cmbOpcion.Size = new System.Drawing.Size(290, 24);
            this.cmbOpcion.TabIndex = 7;
            // 
            // cmbSubopcion
            // 
            this.cmbSubopcion.Enabled = false;
            this.cmbSubopcion.FormattingEnabled = true;
            this.cmbSubopcion.Location = new System.Drawing.Point(116, 174);
            this.cmbSubopcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSubopcion.Name = "cmbSubopcion";
            this.cmbSubopcion.Size = new System.Drawing.Size(290, 24);
            this.cmbSubopcion.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Validación:";
            // 
            // txtValidacion1
            // 
            this.txtValidacion1.Enabled = false;
            this.txtValidacion1.Location = new System.Drawing.Point(111, 24);
            this.txtValidacion1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtValidacion1.Name = "txtValidacion1";
            this.txtValidacion1.Size = new System.Drawing.Size(223, 22);
            this.txtValidacion1.TabIndex = 12;
            // 
            // gbValidaciones
            // 
            this.gbValidaciones.Controls.Add(this.gbValidacion3);
            this.gbValidaciones.Controls.Add(this.gbValidacion2);
            this.gbValidaciones.Controls.Add(this.gbValidacion1);
            this.gbValidaciones.Controls.Add(this.btnValidarRespuestas);
            this.gbValidaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbValidaciones.Location = new System.Drawing.Point(434, 53);
            this.gbValidaciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbValidaciones.Name = "gbValidaciones";
            this.gbValidaciones.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbValidaciones.Size = new System.Drawing.Size(403, 424);
            this.gbValidaciones.TabIndex = 30;
            this.gbValidaciones.TabStop = false;
            this.gbValidaciones.Text = "VALIDACIONES";
            this.gbValidaciones.Visible = false;
            // 
            // gbValidacion3
            // 
            this.gbValidacion3.Controls.Add(this.lblValidacionError3);
            this.gbValidacion3.Controls.Add(this.txtRtaValidacion3);
            this.gbValidacion3.Controls.Add(this.lblRta3);
            this.gbValidacion3.Controls.Add(this.txtValidacion3);
            this.gbValidacion3.Controls.Add(this.label17);
            this.gbValidacion3.Location = new System.Drawing.Point(22, 254);
            this.gbValidacion3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbValidacion3.Name = "gbValidacion3";
            this.gbValidacion3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbValidacion3.Size = new System.Drawing.Size(360, 106);
            this.gbValidacion3.TabIndex = 42;
            this.gbValidacion3.TabStop = false;
            this.gbValidacion3.Text = "3° Validacion";
            // 
            // lblValidacionError3
            // 
            this.lblValidacionError3.AutoSize = true;
            this.lblValidacionError3.Location = new System.Drawing.Point(107, 75);
            this.lblValidacionError3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValidacionError3.Name = "lblValidacionError3";
            this.lblValidacionError3.Size = new System.Drawing.Size(44, 16);
            this.lblValidacionError3.TabIndex = 44;
            this.lblValidacionError3.Text = "label8";
            // 
            // txtRtaValidacion3
            // 
            this.txtRtaValidacion3.Location = new System.Drawing.Point(111, 49);
            this.txtRtaValidacion3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRtaValidacion3.Name = "txtRtaValidacion3";
            this.txtRtaValidacion3.Size = new System.Drawing.Size(223, 22);
            this.txtRtaValidacion3.TabIndex = 35;
            // 
            // lblRta3
            // 
            this.lblRta3.AutoSize = true;
            this.lblRta3.Location = new System.Drawing.Point(27, 49);
            this.lblRta3.Name = "lblRta3";
            this.lblRta3.Size = new System.Drawing.Size(76, 16);
            this.lblRta3.TabIndex = 34;
            this.lblRta3.Text = "Respuesta:";
            this.lblRta3.Visible = false;
            // 
            // txtValidacion3
            // 
            this.txtValidacion3.Enabled = false;
            this.txtValidacion3.Location = new System.Drawing.Point(111, 21);
            this.txtValidacion3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtValidacion3.Name = "txtValidacion3";
            this.txtValidacion3.Size = new System.Drawing.Size(223, 22);
            this.txtValidacion3.TabIndex = 32;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(31, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 16);
            this.label17.TabIndex = 31;
            this.label17.Text = "Validación:";
            // 
            // gbValidacion2
            // 
            this.gbValidacion2.Controls.Add(this.lblValidacionError2);
            this.gbValidacion2.Controls.Add(this.txtRtaValidacion2);
            this.gbValidacion2.Controls.Add(this.lblRta2);
            this.gbValidacion2.Controls.Add(this.txtValidacion2);
            this.gbValidacion2.Controls.Add(this.label6);
            this.gbValidacion2.Location = new System.Drawing.Point(22, 143);
            this.gbValidacion2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbValidacion2.Name = "gbValidacion2";
            this.gbValidacion2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbValidacion2.Size = new System.Drawing.Size(360, 106);
            this.gbValidacion2.TabIndex = 41;
            this.gbValidacion2.TabStop = false;
            this.gbValidacion2.Text = "2° Validacion";
            // 
            // lblValidacionError2
            // 
            this.lblValidacionError2.AutoSize = true;
            this.lblValidacionError2.Location = new System.Drawing.Point(107, 77);
            this.lblValidacionError2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValidacionError2.Name = "lblValidacionError2";
            this.lblValidacionError2.Size = new System.Drawing.Size(44, 16);
            this.lblValidacionError2.TabIndex = 43;
            this.lblValidacionError2.Text = "label8";
            // 
            // txtRtaValidacion2
            // 
            this.txtRtaValidacion2.Location = new System.Drawing.Point(111, 51);
            this.txtRtaValidacion2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRtaValidacion2.Name = "txtRtaValidacion2";
            this.txtRtaValidacion2.Size = new System.Drawing.Size(223, 22);
            this.txtRtaValidacion2.TabIndex = 35;
            // 
            // lblRta2
            // 
            this.lblRta2.AutoSize = true;
            this.lblRta2.Location = new System.Drawing.Point(29, 51);
            this.lblRta2.Name = "lblRta2";
            this.lblRta2.Size = new System.Drawing.Size(76, 16);
            this.lblRta2.TabIndex = 34;
            this.lblRta2.Text = "Respuesta:";
            this.lblRta2.Visible = false;
            // 
            // txtValidacion2
            // 
            this.txtValidacion2.Enabled = false;
            this.txtValidacion2.Location = new System.Drawing.Point(111, 23);
            this.txtValidacion2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtValidacion2.Name = "txtValidacion2";
            this.txtValidacion2.Size = new System.Drawing.Size(223, 22);
            this.txtValidacion2.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Validación:";
            // 
            // gbValidacion1
            // 
            this.gbValidacion1.Controls.Add(this.lblValidacionError1);
            this.gbValidacion1.Controls.Add(this.txtRtaValidacion1);
            this.gbValidacion1.Controls.Add(this.lblRta1);
            this.gbValidacion1.Controls.Add(this.txtValidacion1);
            this.gbValidacion1.Controls.Add(this.label7);
            this.gbValidacion1.Location = new System.Drawing.Point(22, 32);
            this.gbValidacion1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbValidacion1.Name = "gbValidacion1";
            this.gbValidacion1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbValidacion1.Size = new System.Drawing.Size(360, 106);
            this.gbValidacion1.TabIndex = 40;
            this.gbValidacion1.TabStop = false;
            this.gbValidacion1.Text = "1° Validacion";
            // 
            // lblValidacionError1
            // 
            this.lblValidacionError1.AutoSize = true;
            this.lblValidacionError1.Location = new System.Drawing.Point(107, 78);
            this.lblValidacionError1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValidacionError1.Name = "lblValidacionError1";
            this.lblValidacionError1.Size = new System.Drawing.Size(44, 16);
            this.lblValidacionError1.TabIndex = 35;
            this.lblValidacionError1.Text = "label8";
            // 
            // txtRtaValidacion1
            // 
            this.txtRtaValidacion1.Location = new System.Drawing.Point(111, 52);
            this.txtRtaValidacion1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRtaValidacion1.Name = "txtRtaValidacion1";
            this.txtRtaValidacion1.Size = new System.Drawing.Size(223, 22);
            this.txtRtaValidacion1.TabIndex = 34;
            // 
            // lblRta1
            // 
            this.lblRta1.AutoSize = true;
            this.lblRta1.Location = new System.Drawing.Point(27, 52);
            this.lblRta1.Name = "lblRta1";
            this.lblRta1.Size = new System.Drawing.Size(76, 16);
            this.lblRta1.TabIndex = 33;
            this.lblRta1.Text = "Respuesta:";
            this.lblRta1.Visible = false;
            // 
            // btnValidarRespuestas
            // 
            this.btnValidarRespuestas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidarRespuestas.Location = new System.Drawing.Point(195, 364);
            this.btnValidarRespuestas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnValidarRespuestas.Name = "btnValidarRespuestas";
            this.btnValidarRespuestas.Size = new System.Drawing.Size(187, 47);
            this.btnValidarRespuestas.TabIndex = 14;
            this.btnValidarRespuestas.Text = "Validar Información";
            this.btnValidarRespuestas.UseVisualStyleBackColor = true;
            this.btnValidarRespuestas.Click += new System.EventHandler(this.tomarRespuestas);
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Enabled = false;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(117, 102);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(289, 24);
            this.cmbCategoria.TabIndex = 32;
            // 
            // btnRegistrarRtaOperador
            // 
            this.btnRegistrarRtaOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarRtaOperador.Location = new System.Drawing.Point(591, 138);
            this.btnRegistrarRtaOperador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegistrarRtaOperador.Name = "btnRegistrarRtaOperador";
            this.btnRegistrarRtaOperador.Size = new System.Drawing.Size(187, 50);
            this.btnRegistrarRtaOperador.TabIndex = 46;
            this.btnRegistrarRtaOperador.Text = "Registrar Respuesta";
            this.btnRegistrarRtaOperador.UseVisualStyleBackColor = true;
            this.btnRegistrarRtaOperador.Click += new System.EventHandler(this.btnRegistrarRtaOperador_Click);
            // 
            // cmbAcciones
            // 
            this.cmbAcciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAcciones.FormattingEnabled = true;
            this.cmbAcciones.Location = new System.Drawing.Point(15, 164);
            this.cmbAcciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbAcciones.Name = "cmbAcciones";
            this.cmbAcciones.Size = new System.Drawing.Size(321, 24);
            this.cmbAcciones.TabIndex = 45;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 145);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 16);
            this.label13.TabIndex = 44;
            this.label13.Text = "Acciones a realizar:";
            // 
            // txtRespuestaOperador
            // 
            this.txtRespuestaOperador.Location = new System.Drawing.Point(15, 41);
            this.txtRespuestaOperador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRespuestaOperador.Name = "txtRespuestaOperador";
            this.txtRespuestaOperador.Size = new System.Drawing.Size(763, 86);
            this.txtRespuestaOperador.TabIndex = 43;
            this.txtRespuestaOperador.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 16);
            this.label12.TabIndex = 42;
            this.label12.Text = "Respuesta operador:";
            // 
            // gbRespuestaOperador
            // 
            this.gbRespuestaOperador.Controls.Add(this.btnRegistrarRtaOperador);
            this.gbRespuestaOperador.Controls.Add(this.cmbAcciones);
            this.gbRespuestaOperador.Controls.Add(this.label13);
            this.gbRespuestaOperador.Controls.Add(this.txtRespuestaOperador);
            this.gbRespuestaOperador.Controls.Add(this.label12);
            this.gbRespuestaOperador.Location = new System.Drawing.Point(38, 481);
            this.gbRespuestaOperador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbRespuestaOperador.Name = "gbRespuestaOperador";
            this.gbRespuestaOperador.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbRespuestaOperador.Size = new System.Drawing.Size(799, 207);
            this.gbRespuestaOperador.TabIndex = 47;
            this.gbRespuestaOperador.TabStop = false;
            this.gbRespuestaOperador.Visible = false;
            // 
            // btnColgarLlamada
            // 
            this.btnColgarLlamada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnColgarLlamada.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColgarLlamada.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnColgarLlamada.Location = new System.Drawing.Point(95, 233);
            this.btnColgarLlamada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnColgarLlamada.Name = "btnColgarLlamada";
            this.btnColgarLlamada.Padding = new System.Windows.Forms.Padding(1);
            this.btnColgarLlamada.Size = new System.Drawing.Size(234, 44);
            this.btnColgarLlamada.TabIndex = 48;
            this.btnColgarLlamada.Text = "Cancelar Llamada";
            this.btnColgarLlamada.UseVisualStyleBackColor = true;
            this.btnColgarLlamada.Click += new System.EventHandler(this.button1_Click);
            // 
            // PantallaRegistrarRtaOperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(871, 710);
            this.Controls.Add(this.btnColgarLlamada);
            this.Controls.Add(this.gbRespuestaOperador);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.gbValidaciones);
            this.Controls.Add(this.cmbSubopcion);
            this.Controls.Add(this.cmbOpcion);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDatosLlamada);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PantallaRegistrarRtaOperador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar respuesta de operador";
            this.Load += new System.EventHandler(this.PantallaRegistrarRtaOperador_Load);
            this.gbValidaciones.ResumeLayout(false);
            this.gbValidacion3.ResumeLayout(false);
            this.gbValidacion3.PerformLayout();
            this.gbValidacion2.ResumeLayout(false);
            this.gbValidacion2.PerformLayout();
            this.gbValidacion1.ResumeLayout(false);
            this.gbValidacion1.PerformLayout();
            this.gbRespuestaOperador.ResumeLayout(false);
            this.gbRespuestaOperador.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDatosLlamada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtNombreCliente;
        public System.Windows.Forms.ComboBox cmbOpcion;
        public System.Windows.Forms.ComboBox cmbSubopcion;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.TextBox txtValidacion1;
        private System.Windows.Forms.Label lblRta2;
        private System.Windows.Forms.Label lblRta1;
        public System.Windows.Forms.TextBox txtValidacion2;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.GroupBox gbValidaciones;
        private System.Windows.Forms.Label lblRta3;
        public System.Windows.Forms.TextBox txtValidacion3;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.GroupBox gbValidacion3;
        public System.Windows.Forms.GroupBox gbValidacion2;
        public System.Windows.Forms.GroupBox gbValidacion1;
        public System.Windows.Forms.TextBox txtRtaValidacion1;
        public System.Windows.Forms.TextBox txtRtaValidacion3;
        public System.Windows.Forms.TextBox txtRtaValidacion2;
        public System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Button btnRegistrarRtaOperador;
        private System.Windows.Forms.ComboBox cmbAcciones;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox txtRespuestaOperador;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox gbRespuestaOperador;
        private System.Windows.Forms.Button btnValidarRespuestas;
        private System.Windows.Forms.Button btnColgarLlamada;
        private System.Windows.Forms.Label lblValidacionError1;
        private System.Windows.Forms.Label lblValidacionError2;
        private System.Windows.Forms.Label lblValidacionError3;
    }
}

