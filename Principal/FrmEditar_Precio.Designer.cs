
namespace Principal
{
    partial class FrmEditar_Precio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id_Ingrediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo_Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbIngredientes = new System.Windows.Forms.GroupBox();
            this.txtId_Ingrediente = new System.Windows.Forms.TextBox();
            this.txtId_Ficha = new System.Windows.Forms.TextBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBuscarIngrediente = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNombreIngrediente = new System.Windows.Forms.TextBox();
            this.gbProveedor = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPorciones = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscarPlatillo = new System.Windows.Forms.Button();
            this.txtId_Platillo = new System.Windows.Forms.TextBox();
            this.txtId_Precio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombrePlatillo = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbIngredientes.SuspendLayout();
            this.gbProveedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Principal.Properties.Resources.REGRESAR;
            this.btnCancelar.Location = new System.Drawing.Point(523, 535);
            this.btnCancelar.Text = "       Regresar";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Ingrediente,
            this.Nombre,
            this.Cantidad,
            this.Precio,
            this.Costo_Total});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.Location = new System.Drawing.Point(24, 295);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(601, 222);
            this.dataGridView1.TabIndex = 75;
            // 
            // Id_Ingrediente
            // 
            this.Id_Ingrediente.HeaderText = "Id_Ingrediente";
            this.Id_Ingrediente.Name = "Id_Ingrediente";
            this.Id_Ingrediente.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Ingrediente";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad (gr/ml)";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio (Kg/Lt)";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Costo_Total
            // 
            this.Costo_Total.HeaderText = "Costo Total";
            this.Costo_Total.Name = "Costo_Total";
            this.Costo_Total.ReadOnly = true;
            // 
            // gbIngredientes
            // 
            this.gbIngredientes.Controls.Add(this.txtId_Ingrediente);
            this.gbIngredientes.Controls.Add(this.txtId_Ficha);
            this.gbIngredientes.Controls.Add(this.btnQuitar);
            this.gbIngredientes.Controls.Add(this.btnInsertar);
            this.gbIngredientes.Controls.Add(this.txtPrecio);
            this.gbIngredientes.Controls.Add(this.label7);
            this.gbIngredientes.Controls.Add(this.btnBuscarIngrediente);
            this.gbIngredientes.Controls.Add(this.label8);
            this.gbIngredientes.Controls.Add(this.txtCantidad);
            this.gbIngredientes.Controls.Add(this.label9);
            this.gbIngredientes.Controls.Add(this.txtNombreIngrediente);
            this.gbIngredientes.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbIngredientes.Location = new System.Drawing.Point(24, 149);
            this.gbIngredientes.Name = "gbIngredientes";
            this.gbIngredientes.Size = new System.Drawing.Size(601, 132);
            this.gbIngredientes.TabIndex = 74;
            this.gbIngredientes.TabStop = false;
            this.gbIngredientes.Text = "Lista de Ingredientes:";
            // 
            // txtId_Ingrediente
            // 
            this.txtId_Ingrediente.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId_Ingrediente.Location = new System.Drawing.Point(24, 45);
            this.txtId_Ingrediente.Multiline = true;
            this.txtId_Ingrediente.Name = "txtId_Ingrediente";
            this.txtId_Ingrediente.Size = new System.Drawing.Size(28, 29);
            this.txtId_Ingrediente.TabIndex = 70;
            this.txtId_Ingrediente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtId_Ingrediente.Visible = false;
            // 
            // txtId_Ficha
            // 
            this.txtId_Ficha.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId_Ficha.Location = new System.Drawing.Point(198, 45);
            this.txtId_Ficha.Multiline = true;
            this.txtId_Ficha.Name = "txtId_Ficha";
            this.txtId_Ficha.Size = new System.Drawing.Size(28, 29);
            this.txtId_Ficha.TabIndex = 66;
            this.txtId_Ficha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtId_Ficha.Visible = false;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnQuitar.BackColor = System.Drawing.Color.AliceBlue;
            this.btnQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.Image = global::Principal.Properties.Resources.QUITAR;
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.Location = new System.Drawing.Point(553, 84);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(28, 28);
            this.btnQuitar.TabIndex = 67;
            this.btnQuitar.UseVisualStyleBackColor = false;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInsertar.BackColor = System.Drawing.Color.AliceBlue;
            this.btnInsertar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertar.Image = global::Principal.Properties.Resources.INSERTAR;
            this.btnInsertar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsertar.Location = new System.Drawing.Point(553, 45);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(28, 28);
            this.btnInsertar.TabIndex = 65;
            this.btnInsertar.UseVisualStyleBackColor = false;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(306, 81);
            this.txtPrecio.Multiline = true;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(88, 31);
            this.txtPrecio.TabIndex = 63;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(320, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 21);
            this.label7.TabIndex = 62;
            this.label7.Text = "Precio:";
            // 
            // btnBuscarIngrediente
            // 
            this.btnBuscarIngrediente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarIngrediente.BackColor = System.Drawing.Color.AliceBlue;
            this.btnBuscarIngrediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarIngrediente.Image = global::Principal.Properties.Resources.LUPA;
            this.btnBuscarIngrediente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarIngrediente.Location = new System.Drawing.Point(256, 87);
            this.btnBuscarIngrediente.Name = "btnBuscarIngrediente";
            this.btnBuscarIngrediente.Size = new System.Drawing.Size(28, 25);
            this.btnBuscarIngrediente.TabIndex = 1;
            this.btnBuscarIngrediente.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(417, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 21);
            this.label8.TabIndex = 5;
            this.label8.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(416, 81);
            this.txtCantidad.Multiline = true;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(82, 31);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(94, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 21);
            this.label9.TabIndex = 3;
            this.label9.Text = "Ingrediente:";
            // 
            // txtNombreIngrediente
            // 
            this.txtNombreIngrediente.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreIngrediente.Location = new System.Drawing.Point(24, 81);
            this.txtNombreIngrediente.Multiline = true;
            this.txtNombreIngrediente.Name = "txtNombreIngrediente";
            this.txtNombreIngrediente.ReadOnly = true;
            this.txtNombreIngrediente.Size = new System.Drawing.Size(221, 31);
            this.txtNombreIngrediente.TabIndex = 2;
            this.txtNombreIngrediente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbProveedor
            // 
            this.gbProveedor.Controls.Add(this.label3);
            this.gbProveedor.Controls.Add(this.txtPorciones);
            this.gbProveedor.Controls.Add(this.txtCategoria);
            this.gbProveedor.Controls.Add(this.label4);
            this.gbProveedor.Controls.Add(this.btnBuscarPlatillo);
            this.gbProveedor.Controls.Add(this.txtId_Platillo);
            this.gbProveedor.Controls.Add(this.txtId_Precio);
            this.gbProveedor.Controls.Add(this.label2);
            this.gbProveedor.Controls.Add(this.txtNombrePlatillo);
            this.gbProveedor.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(120)))), ((int)(((byte)(123)))));
            this.gbProveedor.Location = new System.Drawing.Point(24, 20);
            this.gbProveedor.Name = "gbProveedor";
            this.gbProveedor.Size = new System.Drawing.Size(601, 115);
            this.gbProveedor.TabIndex = 73;
            this.gbProveedor.TabStop = false;
            this.gbProveedor.Text = "Platillo: Información";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(290, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 21);
            this.label3.TabIndex = 69;
            this.label3.Text = "Porciones:";
            // 
            // txtPorciones
            // 
            this.txtPorciones.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorciones.Location = new System.Drawing.Point(383, 74);
            this.txtPorciones.Multiline = true;
            this.txtPorciones.Name = "txtPorciones";
            this.txtPorciones.Size = new System.Drawing.Size(69, 31);
            this.txtPorciones.TabIndex = 68;
            this.txtPorciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCategoria
            // 
            this.txtCategoria.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoria.Location = new System.Drawing.Point(383, 28);
            this.txtCategoria.Multiline = true;
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.ReadOnly = true;
            this.txtCategoria.Size = new System.Drawing.Size(200, 31);
            this.txtCategoria.TabIndex = 63;
            this.txtCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(291, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 21);
            this.label4.TabIndex = 62;
            this.label4.Text = "Categoría:";
            // 
            // btnBuscarPlatillo
            // 
            this.btnBuscarPlatillo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarPlatillo.BackColor = System.Drawing.Color.AliceBlue;
            this.btnBuscarPlatillo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPlatillo.Image = global::Principal.Properties.Resources.LUPA;
            this.btnBuscarPlatillo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarPlatillo.Location = new System.Drawing.Point(241, 31);
            this.btnBuscarPlatillo.Name = "btnBuscarPlatillo";
            this.btnBuscarPlatillo.Size = new System.Drawing.Size(28, 25);
            this.btnBuscarPlatillo.TabIndex = 0;
            this.btnBuscarPlatillo.UseVisualStyleBackColor = false;
            // 
            // txtId_Platillo
            // 
            this.txtId_Platillo.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId_Platillo.Location = new System.Drawing.Point(198, 26);
            this.txtId_Platillo.Multiline = true;
            this.txtId_Platillo.Name = "txtId_Platillo";
            this.txtId_Platillo.Size = new System.Drawing.Size(28, 29);
            this.txtId_Platillo.TabIndex = 7;
            this.txtId_Platillo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtId_Platillo.Visible = false;
            // 
            // txtId_Precio
            // 
            this.txtId_Precio.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId_Precio.Location = new System.Drawing.Point(164, 26);
            this.txtId_Precio.Multiline = true;
            this.txtId_Precio.Name = "txtId_Precio";
            this.txtId_Precio.Size = new System.Drawing.Size(28, 29);
            this.txtId_Precio.TabIndex = 6;
            this.txtId_Precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtId_Precio.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(20, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Platillo:";
            // 
            // txtNombrePlatillo
            // 
            this.txtNombrePlatillo.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombrePlatillo.Location = new System.Drawing.Point(21, 70);
            this.txtNombrePlatillo.Multiline = true;
            this.txtNombrePlatillo.Name = "txtNombrePlatillo";
            this.txtNombrePlatillo.ReadOnly = true;
            this.txtNombrePlatillo.Size = new System.Drawing.Size(248, 31);
            this.txtNombrePlatillo.TabIndex = 2;
            this.txtNombrePlatillo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(235)))));
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(165, 534);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(132, 31);
            this.txtTotal.TabIndex = 76;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(82)))), ((int)(((byte)(86)))));
            this.label6.Location = new System.Drawing.Point(20, 538);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 21);
            this.label6.TabIndex = 77;
            this.label6.Text = "Precio Invertido:";
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditar.BackColor = System.Drawing.Color.AliceBlue;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = global::Principal.Properties.Resources.EDITAR;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(414, 535);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(102, 30);
            this.btnEditar.TabIndex = 78;
            this.btnEditar.Text = "         Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // FrmEditar_Precio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 581);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gbIngredientes);
            this.Controls.Add(this.gbProveedor);
            this.Name = "FrmEditar_Precio";
            this.Text = "FrmEditar_Precio";
            this.Load += new System.EventHandler(this.FrmEditar_Precio_Load);
            this.Controls.SetChildIndex(this.gbProveedor, 0);
            this.Controls.SetChildIndex(this.gbIngredientes, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtTotal, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbIngredientes.ResumeLayout(false);
            this.gbIngredientes.PerformLayout();
            this.gbProveedor.ResumeLayout(false);
            this.gbProveedor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Ingrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo_Total;
        private System.Windows.Forms.GroupBox gbIngredientes;
        public System.Windows.Forms.TextBox txtId_Ingrediente;
        public System.Windows.Forms.TextBox txtId_Ficha;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnInsertar;
        public System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBuscarIngrediente;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtNombreIngrediente;
        private System.Windows.Forms.GroupBox gbProveedor;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPorciones;
        public System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscarPlatillo;
        public System.Windows.Forms.TextBox txtId_Platillo;
        public System.Windows.Forms.TextBox txtId_Precio;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtNombrePlatillo;
        public System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEditar;
    }
}