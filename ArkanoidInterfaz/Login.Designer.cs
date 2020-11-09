namespace ArkanoidInterfaz
{
    partial class Login
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
            this.btbIniciarCuenta = new System.Windows.Forms.Button();
            this.btbRegistro = new System.Windows.Forms.Button();
            this.lblErrorDeLog = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btbIniciarCuenta
            // 
            this.btbIniciarCuenta.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btbIniciarCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbIniciarCuenta.ForeColor = System.Drawing.Color.White;
            this.btbIniciarCuenta.Location = new System.Drawing.Point(12, 244);
            this.btbIniciarCuenta.Name = "btbIniciarCuenta";
            this.btbIniciarCuenta.Size = new System.Drawing.Size(560, 103);
            this.btbIniciarCuenta.TabIndex = 4;
            this.btbIniciarCuenta.Text = "Iniciar Sesion";
            this.btbIniciarCuenta.UseVisualStyleBackColor = false;
            this.btbIniciarCuenta.Click += new System.EventHandler(this.btbIniciarCuenta_Click);
            // 
            // btbRegistro
            // 
            this.btbRegistro.BackColor = System.Drawing.SystemColors.Desktop;
            this.btbRegistro.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btbRegistro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btbRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbRegistro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btbRegistro.Location = new System.Drawing.Point(12, 370);
            this.btbRegistro.Name = "btbRegistro";
            this.btbRegistro.Size = new System.Drawing.Size(560, 61);
            this.btbRegistro.TabIndex = 5;
            this.btbRegistro.Text = "Registro";
            this.btbRegistro.UseVisualStyleBackColor = false;
            this.btbRegistro.Click += new System.EventHandler(this.btbRegistro_Click);
            // 
            // lblErrorDeLog
            // 
            this.lblErrorDeLog.AutoSize = true;
            this.lblErrorDeLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorDeLog.ForeColor = System.Drawing.Color.Red;
            this.lblErrorDeLog.Location = new System.Drawing.Point(150, 174);
            this.lblErrorDeLog.Name = "lblErrorDeLog";
            this.lblErrorDeLog.Size = new System.Drawing.Size(0, 25);
            this.lblErrorDeLog.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(29, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 31);
            this.label2.TabIndex = 16;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(29, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = "Usuario";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(212, 126);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(346, 20);
            this.txtContraseña.TabIndex = 14;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(212, 39);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(346, 20);
            this.txtUsuario.TabIndex = 13;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(584, 441);
            this.Controls.Add(this.lblErrorDeLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btbRegistro);
            this.Controls.Add(this.btbIniciarCuenta);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btbIniciarCuenta;
        private System.Windows.Forms.Button btbRegistro;
        private System.Windows.Forms.Label lblErrorDeLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
    }
}