namespace ArkanoidInterfaz
{
    partial class Menu
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btbContinuar = new System.Windows.Forms.Button();
            this.btbNuevaPartida = new System.Windows.Forms.Button();
            this.btbInstrucciones = new System.Windows.Forms.Button();
            this.btbSalir = new System.Windows.Forms.Button();
            this.TimerDeRegistro = new System.Windows.Forms.Timer(this.components);
            this.btbEstadisticas = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(223, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 63);
            this.label1.TabIndex = 20;
            this.label1.Text = "Arkanoid";
            // 
            // btbContinuar
            // 
            this.btbContinuar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btbContinuar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btbContinuar.FlatAppearance.BorderSize = 0;
            this.btbContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbContinuar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btbContinuar.Location = new System.Drawing.Point(12, 195);
            this.btbContinuar.Name = "btbContinuar";
            this.btbContinuar.Size = new System.Drawing.Size(324, 64);
            this.btbContinuar.TabIndex = 21;
            this.btbContinuar.Text = "Continuar";
            this.btbContinuar.UseVisualStyleBackColor = false;
            this.btbContinuar.Click += new System.EventHandler(this.btbContinuar_Click);
            // 
            // btbNuevaPartida
            // 
            this.btbNuevaPartida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btbNuevaPartida.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btbNuevaPartida.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btbNuevaPartida.FlatAppearance.BorderSize = 0;
            this.btbNuevaPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbNuevaPartida.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btbNuevaPartida.Location = new System.Drawing.Point(398, 195);
            this.btbNuevaPartida.Name = "btbNuevaPartida";
            this.btbNuevaPartida.Size = new System.Drawing.Size(324, 64);
            this.btbNuevaPartida.TabIndex = 22;
            this.btbNuevaPartida.Text = "Nueva Partida";
            this.btbNuevaPartida.UseVisualStyleBackColor = false;
            this.btbNuevaPartida.Click += new System.EventHandler(this.btbNuevaPartida_Click);
            // 
            // btbInstrucciones
            // 
            this.btbInstrucciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btbInstrucciones.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btbInstrucciones.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btbInstrucciones.FlatAppearance.BorderSize = 0;
            this.btbInstrucciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbInstrucciones.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btbInstrucciones.Location = new System.Drawing.Point(188, 297);
            this.btbInstrucciones.Name = "btbInstrucciones";
            this.btbInstrucciones.Size = new System.Drawing.Size(324, 64);
            this.btbInstrucciones.TabIndex = 23;
            this.btbInstrucciones.Text = "Instrucciones";
            this.btbInstrucciones.UseVisualStyleBackColor = false;
            this.btbInstrucciones.Click += new System.EventHandler(this.btbInstrucciones_Click);
            // 
            // btbSalir
            // 
            this.btbSalir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btbSalir.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btbSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btbSalir.FlatAppearance.BorderSize = 0;
            this.btbSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbSalir.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btbSalir.Location = new System.Drawing.Point(188, 475);
            this.btbSalir.Name = "btbSalir";
            this.btbSalir.Size = new System.Drawing.Size(324, 64);
            this.btbSalir.TabIndex = 24;
            this.btbSalir.Text = "Salida";
            this.btbSalir.UseVisualStyleBackColor = false;
            this.btbSalir.Click += new System.EventHandler(this.btbSalir_Click);
            // 
            // TimerDeRegistro
            // 
            this.TimerDeRegistro.Interval = 1000;
            // 
            // btbEstadisticas
            // 
            this.btbEstadisticas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btbEstadisticas.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btbEstadisticas.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btbEstadisticas.FlatAppearance.BorderSize = 0;
            this.btbEstadisticas.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbEstadisticas.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btbEstadisticas.Location = new System.Drawing.Point(188, 385);
            this.btbEstadisticas.Name = "btbEstadisticas";
            this.btbEstadisticas.Size = new System.Drawing.Size(324, 64);
            this.btbEstadisticas.TabIndex = 25;
            this.btbEstadisticas.Text = "Estadisticas";
            this.btbEstadisticas.UseVisualStyleBackColor = false;
            this.btbEstadisticas.Click += new System.EventHandler(this.btbEstadisticas_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUsuario.Location = new System.Drawing.Point(13, 13);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(58, 22);
            this.lblUsuario.TabIndex = 26;
            this.lblUsuario.Text = "label2";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(734, 561);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btbEstadisticas);
            this.Controls.Add(this.btbSalir);
            this.Controls.Add(this.btbInstrucciones);
            this.Controls.Add(this.btbNuevaPartida);
            this.Controls.Add(this.btbContinuar);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btbContinuar;
        private System.Windows.Forms.Button btbNuevaPartida;
        private System.Windows.Forms.Button btbInstrucciones;
        private System.Windows.Forms.Button btbSalir;
        private System.Windows.Forms.Timer TimerDeRegistro;
        private System.Windows.Forms.Button btbEstadisticas;
        private System.Windows.Forms.Label lblUsuario;
    }
}