namespace Login.Doctores
{
    partial class FrmDoctor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDoctor));
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlHistoriasClinicas = new System.Windows.Forms.Panel();
            this.pnlOperaciones = new System.Windows.Forms.Panel();
            this.pnlRecetas = new System.Windows.Forms.Panel();
            this.pnlCitas = new System.Windows.Forms.Panel();
            this.btnOperaciones = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnRecetasMedicas = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnHistoriasClinicas = new System.Windows.Forms.Button();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.tmrFecha = new System.Windows.Forms.Timer(this.components);
            this.tmrMostrar = new System.Windows.Forms.Timer(this.components);
            this.tmrOcultar = new System.Windows.Forms.Timer(this.components);
            this.pnlBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlPie.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBarra
            // 
            this.pnlBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.pnlBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBarra.Controls.Add(this.lblNombre);
            this.pnlBarra.Controls.Add(this.btnMinimizar);
            this.pnlBarra.Controls.Add(this.btnCerrar);
            this.pnlBarra.Controls.Add(this.pictureBox1);
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Location = new System.Drawing.Point(0, 0);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new System.Drawing.Size(844, 43);
            this.pnlBarra.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(44, 13);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(155, 18);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "NOMBRE USUARIO";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(790, 3);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(25, 25);
            this.btnMinimizar.TabIndex = 6;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(817, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(24, 24);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPie.Controls.Add(this.lblFecha);
            this.pnlPie.Controls.Add(this.lblHora);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 519);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(844, 34);
            this.pnlPie.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(11, 8);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(198, 18);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "miércoles, 01 diciembre 2018";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.White;
            this.lblHora.Location = new System.Drawing.Point(752, 6);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(72, 21);
            this.lblHora.TabIndex = 0;
            this.lblHora.Text = "00:00:00";
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMenu.BackColor = System.Drawing.Color.Turquoise;
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Controls.Add(this.pnlHistoriasClinicas);
            this.pnlMenu.Controls.Add(this.pnlOperaciones);
            this.pnlMenu.Controls.Add(this.pnlRecetas);
            this.pnlMenu.Controls.Add(this.pnlCitas);
            this.pnlMenu.Controls.Add(this.btnOperaciones);
            this.pnlMenu.Controls.Add(this.btnMenu);
            this.pnlMenu.Controls.Add(this.btnSalir);
            this.pnlMenu.Controls.Add(this.btnRecetasMedicas);
            this.pnlMenu.Controls.Add(this.btnCitas);
            this.pnlMenu.Controls.Add(this.btnHistoriasClinicas);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 43);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(50, 476);
            this.pnlMenu.TabIndex = 4;
            // 
            // pnlHistoriasClinicas
            // 
            this.pnlHistoriasClinicas.BackColor = System.Drawing.Color.Orange;
            this.pnlHistoriasClinicas.Location = new System.Drawing.Point(0, 99);
            this.pnlHistoriasClinicas.Name = "pnlHistoriasClinicas";
            this.pnlHistoriasClinicas.Size = new System.Drawing.Size(8, 43);
            this.pnlHistoriasClinicas.TabIndex = 12;
            this.pnlHistoriasClinicas.Visible = false;
            // 
            // pnlOperaciones
            // 
            this.pnlOperaciones.BackColor = System.Drawing.Color.Orange;
            this.pnlOperaciones.Location = new System.Drawing.Point(0, 185);
            this.pnlOperaciones.Name = "pnlOperaciones";
            this.pnlOperaciones.Size = new System.Drawing.Size(8, 43);
            this.pnlOperaciones.TabIndex = 11;
            this.pnlOperaciones.Visible = false;
            // 
            // pnlRecetas
            // 
            this.pnlRecetas.BackColor = System.Drawing.Color.Orange;
            this.pnlRecetas.Location = new System.Drawing.Point(0, 142);
            this.pnlRecetas.Name = "pnlRecetas";
            this.pnlRecetas.Size = new System.Drawing.Size(8, 43);
            this.pnlRecetas.TabIndex = 10;
            this.pnlRecetas.Visible = false;
            // 
            // pnlCitas
            // 
            this.pnlCitas.BackColor = System.Drawing.Color.Orange;
            this.pnlCitas.Location = new System.Drawing.Point(0, 56);
            this.pnlCitas.Name = "pnlCitas";
            this.pnlCitas.Size = new System.Drawing.Size(8, 43);
            this.pnlCitas.TabIndex = 9;
            this.pnlCitas.Visible = false;
            // 
            // btnOperaciones
            // 
            this.btnOperaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOperaciones.FlatAppearance.BorderSize = 0;
            this.btnOperaciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnOperaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOperaciones.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperaciones.ForeColor = System.Drawing.Color.Snow;
            this.btnOperaciones.Image = ((System.Drawing.Image)(resources.GetObject("btnOperaciones.Image")));
            this.btnOperaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOperaciones.Location = new System.Drawing.Point(8, 185);
            this.btnOperaciones.Name = "btnOperaciones";
            this.btnOperaciones.Size = new System.Drawing.Size(190, 43);
            this.btnOperaciones.TabIndex = 8;
            this.btnOperaciones.Text = "Operaciones";
            this.btnOperaciones.UseVisualStyleBackColor = true;
            this.btnOperaciones.Click += new System.EventHandler(this.btnOperaciones_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.Location = new System.Drawing.Point(4, 16);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(34, 34);
            this.btnMenu.TabIndex = 0;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.Snow;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(0, 228);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(190, 43);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRecetasMedicas
            // 
            this.btnRecetasMedicas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecetasMedicas.FlatAppearance.BorderSize = 0;
            this.btnRecetasMedicas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnRecetasMedicas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecetasMedicas.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecetasMedicas.ForeColor = System.Drawing.Color.Snow;
            this.btnRecetasMedicas.Image = ((System.Drawing.Image)(resources.GetObject("btnRecetasMedicas.Image")));
            this.btnRecetasMedicas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecetasMedicas.Location = new System.Drawing.Point(8, 142);
            this.btnRecetasMedicas.Name = "btnRecetasMedicas";
            this.btnRecetasMedicas.Size = new System.Drawing.Size(190, 43);
            this.btnRecetasMedicas.TabIndex = 6;
            this.btnRecetasMedicas.Text = "Recetas";
            this.btnRecetasMedicas.UseVisualStyleBackColor = true;
            this.btnRecetasMedicas.Click += new System.EventHandler(this.btnRecetasMedicas_Click);
            // 
            // btnCitas
            // 
            this.btnCitas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCitas.FlatAppearance.BorderSize = 0;
            this.btnCitas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCitas.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCitas.ForeColor = System.Drawing.Color.Snow;
            this.btnCitas.Image = ((System.Drawing.Image)(resources.GetObject("btnCitas.Image")));
            this.btnCitas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCitas.Location = new System.Drawing.Point(8, 56);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(190, 43);
            this.btnCitas.TabIndex = 5;
            this.btnCitas.Text = "Citas";
            this.btnCitas.UseVisualStyleBackColor = true;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // btnHistoriasClinicas
            // 
            this.btnHistoriasClinicas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistoriasClinicas.FlatAppearance.BorderSize = 0;
            this.btnHistoriasClinicas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnHistoriasClinicas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistoriasClinicas.Font = new System.Drawing.Font("AVGmdBU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistoriasClinicas.ForeColor = System.Drawing.Color.Snow;
            this.btnHistoriasClinicas.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoriasClinicas.Image")));
            this.btnHistoriasClinicas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistoriasClinicas.Location = new System.Drawing.Point(8, 99);
            this.btnHistoriasClinicas.Name = "btnHistoriasClinicas";
            this.btnHistoriasClinicas.Size = new System.Drawing.Size(190, 43);
            this.btnHistoriasClinicas.TabIndex = 4;
            this.btnHistoriasClinicas.Text = "Historias Clinicas";
            this.btnHistoriasClinicas.UseVisualStyleBackColor = true;
            this.btnHistoriasClinicas.Click += new System.EventHandler(this.btnHistoriasClinicas_Click);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.White;
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(50, 43);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(794, 476);
            this.pnlContenedor.TabIndex = 5;
            // 
            // tmrFecha
            // 
            this.tmrFecha.Enabled = true;
            this.tmrFecha.Interval = 1000;
            this.tmrFecha.Tick += new System.EventHandler(this.tmrFecha_Tick);
            // 
            // tmrMostrar
            // 
            this.tmrMostrar.Tick += new System.EventHandler(this.tmrMostrar_Tick);
            // 
            // tmrOcultar
            // 
            this.tmrOcultar.Tick += new System.EventHandler(this.tmrOcultar_Tick);
            // 
            // FrmDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(844, 553);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlPie);
            this.Controls.Add(this.pnlBarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDoctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDoctor";
            this.Load += new System.EventHandler(this.FrmDoctor_Load);
            this.pnlBarra.ResumeLayout(false);
            this.pnlBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBarra;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnOperaciones;
        private System.Windows.Forms.Button btnRecetasMedicas;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnHistoriasClinicas;
        public System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Timer tmrFecha;
        private System.Windows.Forms.Timer tmrMostrar;
        private System.Windows.Forms.Timer tmrOcultar;
        private System.Windows.Forms.Panel pnlOperaciones;
        private System.Windows.Forms.Panel pnlRecetas;
        private System.Windows.Forms.Panel pnlCitas;
        private System.Windows.Forms.Panel pnlHistoriasClinicas;
    }
}