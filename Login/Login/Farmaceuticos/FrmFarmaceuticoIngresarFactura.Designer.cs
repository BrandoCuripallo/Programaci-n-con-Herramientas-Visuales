﻿namespace Login.Farmaceuticos
{
    partial class FrmFarmaceuticoIngresarFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFarmaceuticoIngresarFactura));
            this.btnImprimir = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.cbxProductos = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblMedicamento = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dtpFechaEmision = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtApellidoPaterno = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtApellidoMaterno = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(601, 367);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(116, 33);
            this.btnImprimir.TabIndex = 50;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblStock);
            this.panel4.Controls.Add(this.txtStock);
            this.panel4.Controls.Add(this.btnEliminar);
            this.panel4.Controls.Add(this.btnAgregar);
            this.panel4.Controls.Add(this.lblCantidad);
            this.panel4.Controls.Add(this.cbxProductos);
            this.panel4.Controls.Add(this.txtCantidad);
            this.panel4.Controls.Add(this.lblMedicamento);
            this.panel4.Controls.Add(this.txtTotal);
            this.panel4.Controls.Add(this.dgvProductos);
            this.panel4.Controls.Add(this.dtpFechaEmision);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.txtNumeroFactura);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Location = new System.Drawing.Point(383, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(726, 298);
            this.panel4.TabIndex = 49;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Bell MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.lblStock.Location = new System.Drawing.Point(557, 65);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(43, 19);
            this.lblStock.TabIndex = 74;
            this.lblStock.Text = "Stock";
            // 
            // txtStock
            // 
            this.txtStock.Enabled = false;
            this.txtStock.Location = new System.Drawing.Point(650, 65);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(51, 20);
            this.txtStock.TabIndex = 73;
            this.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(573, 193);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(116, 33);
            this.btnEliminar.TabIndex = 72;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Enabled = false;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(573, 140);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(116, 33);
            this.btnAgregar.TabIndex = 44;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Bell MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.lblCantidad.Location = new System.Drawing.Point(557, 101);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(66, 19);
            this.lblCantidad.TabIndex = 71;
            this.lblCantidad.Text = "Cantidad";
            // 
            // cbxProductos
            // 
            this.cbxProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProductos.FormattingEnabled = true;
            this.cbxProductos.Location = new System.Drawing.Point(570, 34);
            this.cbxProductos.Name = "cbxProductos";
            this.cbxProductos.Size = new System.Drawing.Size(148, 21);
            this.cbxProductos.TabIndex = 70;
            this.cbxProductos.SelectedIndexChanged += new System.EventHandler(this.cbxProductos_SelectedIndexChanged);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(650, 101);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(51, 20);
            this.txtCantidad.TabIndex = 69;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lblMedicamento
            // 
            this.lblMedicamento.AutoSize = true;
            this.lblMedicamento.Font = new System.Drawing.Font("Bell MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.lblMedicamento.Location = new System.Drawing.Point(472, 34);
            this.lblMedicamento.Name = "lblMedicamento";
            this.lblMedicamento.Size = new System.Drawing.Size(92, 19);
            this.lblMedicamento.TabIndex = 68;
            this.lblMedicamento.Text = "Medicamento";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(629, 261);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(89, 20);
            this.txtTotal.TabIndex = 67;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(30, 101);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(491, 180);
            this.dgvProductos.TabIndex = 66;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            // 
            // dtpFechaEmision
            // 
            this.dtpFechaEmision.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy HH:mm:ss";
            this.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaEmision.Location = new System.Drawing.Point(166, 62);
            this.dtpFechaEmision.Name = "dtpFechaEmision";
            this.dtpFechaEmision.Size = new System.Drawing.Size(279, 20);
            this.dtpFechaEmision.TabIndex = 65;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Bell MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.label20.Location = new System.Drawing.Point(291, 6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(182, 19);
            this.label20.TabIndex = 35;
            this.label20.Text = "DATOS DE LA FACTURA";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Bell MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.label14.Location = new System.Drawing.Point(22, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(130, 19);
            this.label14.TabIndex = 50;
            this.label14.Text = "Número de Factura";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Enabled = false;
            this.txtNumeroFactura.Location = new System.Drawing.Point(295, 34);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(70, 20);
            this.txtNumeroFactura.TabIndex = 51;
            this.txtNumeroFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Bell MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.label15.Location = new System.Drawing.Point(22, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 19);
            this.label15.TabIndex = 52;
            this.label15.Text = "Fecha";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Bell MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.label17.Location = new System.Drawing.Point(569, 264);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 19);
            this.label17.TabIndex = 54;
            this.label17.Text = "Total $";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(941, 320);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnBuscar);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtCedula);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtTelefono);
            this.panel3.Controls.Add(this.txtNombres);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtDireccion);
            this.panel3.Controls.Add(this.txtApellidoPaterno);
            this.panel3.Controls.Add(this.txtCorreo);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtApellidoMaterno);
            this.panel3.Location = new System.Drawing.Point(7, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(369, 283);
            this.panel3.TabIndex = 47;
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(162, 42);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(21, 21);
            this.btnBuscar.TabIndex = 45;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Bell MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.label12.Location = new System.Drawing.Point(9, 254);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 19);
            this.label12.TabIndex = 24;
            this.label12.Text = "Teléfono";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Bell MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.label13.Location = new System.Drawing.Point(93, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(173, 19);
            this.label13.TabIndex = 18;
            this.label13.Text = "DATOS DEL PACIENTE";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Bell MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.label11.Location = new System.Drawing.Point(9, 220);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 19);
            this.label11.TabIndex = 24;
            this.label11.Text = "Dirección";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bell MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cédula";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(189, 43);
            this.txtCedula.MaxLength = 10;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(163, 20);
            this.txtCedula.TabIndex = 1;
            this.txtCedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bell MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(9, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombres";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Location = new System.Drawing.Point(252, 254);
            this.txtTelefono.MaxLength = 10;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 13;
            // 
            // txtNombres
            // 
            this.txtNombres.Enabled = false;
            this.txtNombres.Location = new System.Drawing.Point(153, 76);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(199, 20);
            this.txtNombres.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bell MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.label3.Location = new System.Drawing.Point(9, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Apellido Paterno";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(181, 219);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(171, 20);
            this.txtDireccion.TabIndex = 11;
            // 
            // txtApellidoPaterno
            // 
            this.txtApellidoPaterno.Enabled = false;
            this.txtApellidoPaterno.Location = new System.Drawing.Point(153, 108);
            this.txtApellidoPaterno.Name = "txtApellidoPaterno";
            this.txtApellidoPaterno.Size = new System.Drawing.Size(199, 20);
            this.txtApellidoPaterno.TabIndex = 5;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Enabled = false;
            this.txtCorreo.Location = new System.Drawing.Point(153, 182);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(199, 20);
            this.txtCorreo.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bell MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.label4.Location = new System.Drawing.Point(9, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Apellido Materno";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bell MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.label6.Location = new System.Drawing.Point(9, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Correo Electrónico";
            // 
            // txtApellidoMaterno
            // 
            this.txtApellidoMaterno.Enabled = false;
            this.txtApellidoMaterno.Location = new System.Drawing.Point(153, 145);
            this.txtApellidoMaterno.Name = "txtApellidoMaterno";
            this.txtApellidoMaterno.Size = new System.Drawing.Size(199, 20);
            this.txtApellidoMaterno.TabIndex = 7;
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(777, 367);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 33);
            this.btnCancelar.TabIndex = 46;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(429, 367);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(116, 33);
            this.btnGuardar.TabIndex = 45;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmFarmaceuticoIngresarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1117, 460);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmFarmaceuticoIngresarFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación";
            this.Load += new System.EventHandler(this.FrmFarmaceuticoIngresarFactura_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Label lblStock;
        public System.Windows.Forms.TextBox txtStock;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btnAgregar;
        public System.Windows.Forms.Label lblCantidad;
        public System.Windows.Forms.ComboBox cbxProductos;
        public System.Windows.Forms.TextBox txtCantidad;
        public System.Windows.Forms.Label lblMedicamento;
        public System.Windows.Forms.TextBox txtTotal;
        public System.Windows.Forms.DataGridView dgvProductos;
        public System.Windows.Forms.DateTimePicker dtpFechaEmision;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtTelefono;
        public System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtDireccion;
        public System.Windows.Forms.TextBox txtApellidoPaterno;
        public System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtApellidoMaterno;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnGuardar;
    }
}