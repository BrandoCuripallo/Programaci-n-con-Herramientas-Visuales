namespace Login
{
    partial class FrmAdministrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdministrador));
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlLogistica = new System.Windows.Forms.Panel();
            this.btnRecepcionistas = new System.Windows.Forms.Button();
            this.btnCirugias = new System.Windows.Forms.Button();
            this.btnEspecialidades = new System.Windows.Forms.Button();
            this.btnMedicos = new System.Windows.Forms.Button();
            this.pnlFarmacia = new System.Windows.Forms.Panel();
            this.btnFacturacion = new System.Windows.Forms.Button();
            this.btnMedicamentos = new System.Windows.Forms.Button();
            this.btnFarmaceuticos = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlPacientes = new System.Windows.Forms.Panel();
            this.btnOperaciones = new System.Windows.Forms.Button();
            this.btnRegistros = new System.Windows.Forms.Button();
            this.btnRecetasMedicas = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnHistoriasClinicas = new System.Windows.Forms.Button();
            this.btnLogista = new System.Windows.Forms.Button();
            this.btnFarmacia = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.tmrFecha = new System.Windows.Forms.Timer(this.components);
            this.tmrMostrar = new System.Windows.Forms.Timer(this.components);
            this.tmrOcultar = new System.Windows.Forms.Timer(this.components);
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlPie.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlLogistica.SuspendLayout();
            this.pnlFarmacia.SuspendLayout();
            this.pnlPacientes.SuspendLayout();
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
            this.pnlBarra.TabIndex = 1;
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
            this.pnlPie.TabIndex = 2;
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
            this.pnlMenu.Controls.Add(this.pnlLogistica);
            this.pnlMenu.Controls.Add(this.pnlFarmacia);
            this.pnlMenu.Controls.Add(this.btnMenu);
            this.pnlMenu.Controls.Add(this.btnSalir);
            this.pnlMenu.Controls.Add(this.pnlPacientes);
            this.pnlMenu.Controls.Add(this.btnLogista);
            this.pnlMenu.Controls.Add(this.btnFarmacia);
            this.pnlMenu.Controls.Add(this.btnPacientes);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 43);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(50, 476);
            this.pnlMenu.TabIndex = 3;
            // 
            // pnlLogistica
            // 
            this.pnlLogistica.BackColor = System.Drawing.Color.Teal;
            this.pnlLogistica.Controls.Add(this.btnRecepcionistas);
            this.pnlLogistica.Controls.Add(this.btnCirugias);
            this.pnlLogistica.Controls.Add(this.btnEspecialidades);
            this.pnlLogistica.Controls.Add(this.btnMedicos);
            this.pnlLogistica.Location = new System.Drawing.Point(0, 185);
            this.pnlLogistica.Name = "pnlLogistica";
            this.pnlLogistica.Size = new System.Drawing.Size(167, 169);
            this.pnlLogistica.TabIndex = 0;
            this.pnlLogistica.Visible = false;
            // 
            // btnRecepcionistas
            // 
            this.btnRecepcionistas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecepcionistas.FlatAppearance.BorderSize = 0;
            this.btnRecepcionistas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnRecepcionistas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecepcionistas.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecepcionistas.ForeColor = System.Drawing.Color.Snow;
            this.btnRecepcionistas.Image = ((System.Drawing.Image)(resources.GetObject("btnRecepcionistas.Image")));
            this.btnRecepcionistas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecepcionistas.Location = new System.Drawing.Point(0, 0);
            this.btnRecepcionistas.Name = "btnRecepcionistas";
            this.btnRecepcionistas.Size = new System.Drawing.Size(167, 43);
            this.btnRecepcionistas.TabIndex = 7;
            this.btnRecepcionistas.Text = "Recepcionistas";
            this.btnRecepcionistas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecepcionistas.UseVisualStyleBackColor = true;
            this.btnRecepcionistas.Click += new System.EventHandler(this.btnRecepcionistas_Click);
            // 
            // btnCirugias
            // 
            this.btnCirugias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCirugias.FlatAppearance.BorderSize = 0;
            this.btnCirugias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnCirugias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCirugias.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCirugias.ForeColor = System.Drawing.Color.Snow;
            this.btnCirugias.Image = ((System.Drawing.Image)(resources.GetObject("btnCirugias.Image")));
            this.btnCirugias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCirugias.Location = new System.Drawing.Point(0, 126);
            this.btnCirugias.Name = "btnCirugias";
            this.btnCirugias.Size = new System.Drawing.Size(167, 43);
            this.btnCirugias.TabIndex = 6;
            this.btnCirugias.Text = "Cirugias";
            this.btnCirugias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCirugias.UseVisualStyleBackColor = true;
            this.btnCirugias.Click += new System.EventHandler(this.btnCirugias_Click);
            // 
            // btnEspecialidades
            // 
            this.btnEspecialidades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEspecialidades.FlatAppearance.BorderSize = 0;
            this.btnEspecialidades.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnEspecialidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEspecialidades.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEspecialidades.ForeColor = System.Drawing.Color.Snow;
            this.btnEspecialidades.Image = ((System.Drawing.Image)(resources.GetObject("btnEspecialidades.Image")));
            this.btnEspecialidades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEspecialidades.Location = new System.Drawing.Point(0, 84);
            this.btnEspecialidades.Name = "btnEspecialidades";
            this.btnEspecialidades.Size = new System.Drawing.Size(167, 43);
            this.btnEspecialidades.TabIndex = 5;
            this.btnEspecialidades.Text = "Especialidades";
            this.btnEspecialidades.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEspecialidades.UseVisualStyleBackColor = true;
            this.btnEspecialidades.Click += new System.EventHandler(this.btnEspecialidades_Click);
            // 
            // btnMedicos
            // 
            this.btnMedicos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMedicos.FlatAppearance.BorderSize = 0;
            this.btnMedicos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnMedicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicos.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicos.ForeColor = System.Drawing.Color.Snow;
            this.btnMedicos.Image = ((System.Drawing.Image)(resources.GetObject("btnMedicos.Image")));
            this.btnMedicos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedicos.Location = new System.Drawing.Point(0, 42);
            this.btnMedicos.Name = "btnMedicos";
            this.btnMedicos.Size = new System.Drawing.Size(167, 43);
            this.btnMedicos.TabIndex = 4;
            this.btnMedicos.Text = "Medicos";
            this.btnMedicos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMedicos.UseVisualStyleBackColor = true;
            this.btnMedicos.Click += new System.EventHandler(this.btnMedicos_Click);
            // 
            // pnlFarmacia
            // 
            this.pnlFarmacia.BackColor = System.Drawing.Color.Teal;
            this.pnlFarmacia.Controls.Add(this.btnFacturacion);
            this.pnlFarmacia.Controls.Add(this.btnMedicamentos);
            this.pnlFarmacia.Controls.Add(this.btnFarmaceuticos);
            this.pnlFarmacia.Location = new System.Drawing.Point(0, 142);
            this.pnlFarmacia.Name = "pnlFarmacia";
            this.pnlFarmacia.Size = new System.Drawing.Size(167, 127);
            this.pnlFarmacia.TabIndex = 7;
            this.pnlFarmacia.Visible = false;
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturacion.FlatAppearance.BorderSize = 0;
            this.btnFacturacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturacion.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturacion.ForeColor = System.Drawing.Color.Snow;
            this.btnFacturacion.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturacion.Image")));
            this.btnFacturacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturacion.Location = new System.Drawing.Point(0, 84);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Size = new System.Drawing.Size(167, 43);
            this.btnFacturacion.TabIndex = 6;
            this.btnFacturacion.Text = "Facturacion";
            this.btnFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFacturacion.UseVisualStyleBackColor = true;
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click);
            // 
            // btnMedicamentos
            // 
            this.btnMedicamentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMedicamentos.FlatAppearance.BorderSize = 0;
            this.btnMedicamentos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnMedicamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicamentos.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicamentos.ForeColor = System.Drawing.Color.Snow;
            this.btnMedicamentos.Image = ((System.Drawing.Image)(resources.GetObject("btnMedicamentos.Image")));
            this.btnMedicamentos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedicamentos.Location = new System.Drawing.Point(0, 42);
            this.btnMedicamentos.Name = "btnMedicamentos";
            this.btnMedicamentos.Size = new System.Drawing.Size(167, 43);
            this.btnMedicamentos.TabIndex = 5;
            this.btnMedicamentos.Text = "Medicamentos";
            this.btnMedicamentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMedicamentos.UseVisualStyleBackColor = true;
            this.btnMedicamentos.Click += new System.EventHandler(this.btnMedicamentos_Click);
            // 
            // btnFarmaceuticos
            // 
            this.btnFarmaceuticos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFarmaceuticos.FlatAppearance.BorderSize = 0;
            this.btnFarmaceuticos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnFarmaceuticos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFarmaceuticos.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFarmaceuticos.ForeColor = System.Drawing.Color.Snow;
            this.btnFarmaceuticos.Image = ((System.Drawing.Image)(resources.GetObject("btnFarmaceuticos.Image")));
            this.btnFarmaceuticos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFarmaceuticos.Location = new System.Drawing.Point(0, 0);
            this.btnFarmaceuticos.Name = "btnFarmaceuticos";
            this.btnFarmaceuticos.Size = new System.Drawing.Size(167, 43);
            this.btnFarmaceuticos.TabIndex = 4;
            this.btnFarmaceuticos.Text = "Farmaceuticos";
            this.btnFarmaceuticos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFarmaceuticos.UseVisualStyleBackColor = true;
            this.btnFarmaceuticos.Click += new System.EventHandler(this.btnFarmaceuticos_Click);
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
            this.btnSalir.Location = new System.Drawing.Point(0, 185);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(190, 43);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlPacientes
            // 
            this.pnlPacientes.BackColor = System.Drawing.Color.Teal;
            this.pnlPacientes.Controls.Add(this.btnOperaciones);
            this.pnlPacientes.Controls.Add(this.btnRegistros);
            this.pnlPacientes.Controls.Add(this.btnRecetasMedicas);
            this.pnlPacientes.Controls.Add(this.btnCitas);
            this.pnlPacientes.Controls.Add(this.btnHistoriasClinicas);
            this.pnlPacientes.Location = new System.Drawing.Point(0, 99);
            this.pnlPacientes.Name = "pnlPacientes";
            this.pnlPacientes.Size = new System.Drawing.Size(167, 210);
            this.pnlPacientes.TabIndex = 8;
            this.pnlPacientes.Visible = false;
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
            this.btnOperaciones.Location = new System.Drawing.Point(0, 167);
            this.btnOperaciones.Name = "btnOperaciones";
            this.btnOperaciones.Size = new System.Drawing.Size(167, 43);
            this.btnOperaciones.TabIndex = 8;
            this.btnOperaciones.Text = "Operaciones";
            this.btnOperaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOperaciones.UseVisualStyleBackColor = true;
            this.btnOperaciones.Click += new System.EventHandler(this.btnOperaciones_Click);
            // 
            // btnRegistros
            // 
            this.btnRegistros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistros.FlatAppearance.BorderSize = 0;
            this.btnRegistros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnRegistros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistros.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistros.ForeColor = System.Drawing.Color.Snow;
            this.btnRegistros.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistros.Image")));
            this.btnRegistros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistros.Location = new System.Drawing.Point(0, 0);
            this.btnRegistros.Name = "btnRegistros";
            this.btnRegistros.Size = new System.Drawing.Size(167, 43);
            this.btnRegistros.TabIndex = 7;
            this.btnRegistros.Text = "Registros";
            this.btnRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegistros.UseVisualStyleBackColor = true;
            this.btnRegistros.Click += new System.EventHandler(this.btnRegistros_Click);
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
            this.btnRecetasMedicas.Location = new System.Drawing.Point(0, 124);
            this.btnRecetasMedicas.Name = "btnRecetasMedicas";
            this.btnRecetasMedicas.Size = new System.Drawing.Size(167, 43);
            this.btnRecetasMedicas.TabIndex = 6;
            this.btnRecetasMedicas.Text = "Recetas";
            this.btnRecetasMedicas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnCitas.Location = new System.Drawing.Point(0, 86);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(167, 43);
            this.btnCitas.TabIndex = 5;
            this.btnCitas.Text = "Citas";
            this.btnCitas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCitas.UseVisualStyleBackColor = true;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // btnHistoriasClinicas
            // 
            this.btnHistoriasClinicas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistoriasClinicas.FlatAppearance.BorderSize = 0;
            this.btnHistoriasClinicas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnHistoriasClinicas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistoriasClinicas.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistoriasClinicas.ForeColor = System.Drawing.Color.Snow;
            this.btnHistoriasClinicas.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoriasClinicas.Image")));
            this.btnHistoriasClinicas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistoriasClinicas.Location = new System.Drawing.Point(0, 43);
            this.btnHistoriasClinicas.Name = "btnHistoriasClinicas";
            this.btnHistoriasClinicas.Size = new System.Drawing.Size(167, 43);
            this.btnHistoriasClinicas.TabIndex = 4;
            this.btnHistoriasClinicas.Text = "Historia Clinica";
            this.btnHistoriasClinicas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHistoriasClinicas.UseVisualStyleBackColor = true;
            this.btnHistoriasClinicas.Click += new System.EventHandler(this.btnHistoriasClinicas_Click);
            // 
            // btnLogista
            // 
            this.btnLogista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogista.FlatAppearance.BorderSize = 0;
            this.btnLogista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLogista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnLogista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogista.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogista.ForeColor = System.Drawing.Color.Snow;
            this.btnLogista.Image = ((System.Drawing.Image)(resources.GetObject("btnLogista.Image")));
            this.btnLogista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogista.Location = new System.Drawing.Point(0, 142);
            this.btnLogista.Name = "btnLogista";
            this.btnLogista.Size = new System.Drawing.Size(190, 43);
            this.btnLogista.TabIndex = 3;
            this.btnLogista.Text = "Logistica";
            this.btnLogista.UseVisualStyleBackColor = true;
            this.btnLogista.Click += new System.EventHandler(this.btnLogista_Click);
            // 
            // btnFarmacia
            // 
            this.btnFarmacia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFarmacia.FlatAppearance.BorderSize = 0;
            this.btnFarmacia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFarmacia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnFarmacia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFarmacia.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFarmacia.ForeColor = System.Drawing.Color.Snow;
            this.btnFarmacia.Image = ((System.Drawing.Image)(resources.GetObject("btnFarmacia.Image")));
            this.btnFarmacia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFarmacia.Location = new System.Drawing.Point(0, 99);
            this.btnFarmacia.Name = "btnFarmacia";
            this.btnFarmacia.Size = new System.Drawing.Size(190, 43);
            this.btnFarmacia.TabIndex = 2;
            this.btnFarmacia.Text = "Farmacia";
            this.btnFarmacia.UseVisualStyleBackColor = true;
            this.btnFarmacia.Click += new System.EventHandler(this.btnFarmacia_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPacientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Font = new System.Drawing.Font("AVGmdBU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPacientes.ForeColor = System.Drawing.Color.Snow;
            this.btnPacientes.Image = ((System.Drawing.Image)(resources.GetObject("btnPacientes.Image")));
            this.btnPacientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPacientes.Location = new System.Drawing.Point(0, 56);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(190, 43);
            this.btnPacientes.TabIndex = 1;
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // tmrFecha
            // 
            this.tmrFecha.Enabled = true;
            this.tmrFecha.Interval = 1000;
            this.tmrFecha.Tick += new System.EventHandler(this.tmrFecha_Tick);
            // 
            // tmrMostrar
            // 
            this.tmrMostrar.Interval = 10;
            this.tmrMostrar.Tick += new System.EventHandler(this.tmrMostrar_Tick);
            // 
            // tmrOcultar
            // 
            this.tmrOcultar.Interval = 10;
            this.tmrOcultar.Tick += new System.EventHandler(this.tmrOcultar_Tick);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.White;
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(50, 43);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(794, 476);
            this.pnlContenedor.TabIndex = 4;
            // 
            // FrmAdministrador
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
            this.Name = "FrmAdministrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAdministrador";
            this.Load += new System.EventHandler(this.FrmAdministrador_Load);
            this.pnlBarra.ResumeLayout(false);
            this.pnlBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlLogistica.ResumeLayout(false);
            this.pnlFarmacia.ResumeLayout(false);
            this.pnlPacientes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBarra;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Panel pnlLogistica;
        private System.Windows.Forms.Button btnMedicos;
        private System.Windows.Forms.Button btnLogista;
        private System.Windows.Forms.Button btnFarmacia;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEspecialidades;
        private System.Windows.Forms.Panel pnlFarmacia;
        private System.Windows.Forms.Button btnFacturacion;
        private System.Windows.Forms.Button btnMedicamentos;
        private System.Windows.Forms.Button btnFarmaceuticos;
        private System.Windows.Forms.Button btnCirugias;
        private System.Windows.Forms.Panel pnlPacientes;
        private System.Windows.Forms.Button btnRecetasMedicas;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnHistoriasClinicas;
        private System.Windows.Forms.Button btnRecepcionistas;
        private System.Windows.Forms.Button btnRegistros;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer tmrFecha;
        private System.Windows.Forms.Timer tmrMostrar;
        private System.Windows.Forms.Timer tmrOcultar;
        private System.Windows.Forms.Button btnOperaciones;
        public System.Windows.Forms.Panel pnlContenedor;
    }
}