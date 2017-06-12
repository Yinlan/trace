namespace Trace
{
    partial class FormConfig
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
            this.tabsConfig = new System.Windows.Forms.TabControl();
            this.tabProduct = new System.Windows.Forms.TabPage();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.tabBase = new System.Windows.Forms.TabPage();
            this.btnDeleteSource = new System.Windows.Forms.Button();
            this.btnEditSource = new System.Windows.Forms.Button();
            this.btnAddSource = new System.Windows.Forms.Button();
            this.dgvSource = new System.Windows.Forms.DataGridView();
            this.tabPrintConfig = new System.Windows.Forms.TabPage();
            this.cbxLabelSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSavePrintConfig = new System.Windows.Forms.Button();
            this.tbxMaxLabelNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tabsConfig.SuspendLayout();
            this.tabProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.tabBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).BeginInit();
            this.tabPrintConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsConfig
            // 
            this.tabsConfig.Controls.Add(this.tabProduct);
            this.tabsConfig.Controls.Add(this.tabBase);
            this.tabsConfig.Controls.Add(this.tabPrintConfig);
            this.tabsConfig.Location = new System.Drawing.Point(1, 1);
            this.tabsConfig.Name = "tabsConfig";
            this.tabsConfig.SelectedIndex = 0;
            this.tabsConfig.Size = new System.Drawing.Size(478, 401);
            this.tabsConfig.TabIndex = 0;
            this.tabsConfig.SelectedIndexChanged += new System.EventHandler(this.tabsConfig_SelectedIndexChanged);
            // 
            // tabProduct
            // 
            this.tabProduct.Controls.Add(this.btnDeleteProduct);
            this.tabProduct.Controls.Add(this.btnEditProduct);
            this.tabProduct.Controls.Add(this.btnAddProduct);
            this.tabProduct.Controls.Add(this.dgvProduct);
            this.tabProduct.Location = new System.Drawing.Point(4, 22);
            this.tabProduct.Name = "tabProduct";
            this.tabProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tabProduct.Size = new System.Drawing.Size(470, 375);
            this.tabProduct.TabIndex = 0;
            this.tabProduct.Text = "产品";
            this.tabProduct.Click += new System.EventHandler(this.tabProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.BackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteProduct.Enabled = false;
            this.btnDeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteProduct.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteProduct.ForeColor = System.Drawing.Color.White;
            this.btnDeleteProduct.Location = new System.Drawing.Point(319, 326);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(135, 44);
            this.btnDeleteProduct.TabIndex = 8;
            this.btnDeleteProduct.Text = "× 删除";
            this.btnDeleteProduct.UseVisualStyleBackColor = false;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnEditProduct.Enabled = false;
            this.btnEditProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProduct.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEditProduct.ForeColor = System.Drawing.Color.White;
            this.btnEditProduct.Location = new System.Drawing.Point(168, 326);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(135, 44);
            this.btnEditProduct.TabIndex = 7;
            this.btnEditProduct.Text = "~ 修改";
            this.btnEditProduct.UseVisualStyleBackColor = false;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnAddProduct.Enabled = false;
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddProduct.Location = new System.Drawing.Point(16, 326);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(135, 44);
            this.btnAddProduct.TabIndex = 6;
            this.btnAddProduct.Text = "+ 添加产品";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.BackgroundColor = System.Drawing.Color.White;
            this.dgvProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Location = new System.Drawing.Point(0, 6);
            this.dgvProduct.Name = "dgvProduct";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            this.dgvProduct.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProduct.RowTemplate.Height = 23;
            this.dgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduct.Size = new System.Drawing.Size(470, 294);
            this.dgvProduct.TabIndex = 0;
            // 
            // tabBase
            // 
            this.tabBase.Controls.Add(this.btnDeleteSource);
            this.tabBase.Controls.Add(this.btnEditSource);
            this.tabBase.Controls.Add(this.btnAddSource);
            this.tabBase.Controls.Add(this.dgvSource);
            this.tabBase.Location = new System.Drawing.Point(4, 22);
            this.tabBase.Name = "tabBase";
            this.tabBase.Padding = new System.Windows.Forms.Padding(3);
            this.tabBase.Size = new System.Drawing.Size(470, 375);
            this.tabBase.TabIndex = 1;
            this.tabBase.Text = "基地";
            this.tabBase.UseVisualStyleBackColor = true;
            this.tabBase.Click += new System.EventHandler(this.tabBase_Click);
            // 
            // btnDeleteSource
            // 
            this.btnDeleteSource.BackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSource.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteSource.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSource.Location = new System.Drawing.Point(319, 326);
            this.btnDeleteSource.Name = "btnDeleteSource";
            this.btnDeleteSource.Size = new System.Drawing.Size(135, 44);
            this.btnDeleteSource.TabIndex = 5;
            this.btnDeleteSource.Text = "× 删除";
            this.btnDeleteSource.UseVisualStyleBackColor = false;
            this.btnDeleteSource.Click += new System.EventHandler(this.btnDeleteSource_Click);
            // 
            // btnEditSource
            // 
            this.btnEditSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnEditSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSource.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEditSource.ForeColor = System.Drawing.Color.White;
            this.btnEditSource.Location = new System.Drawing.Point(168, 326);
            this.btnEditSource.Name = "btnEditSource";
            this.btnEditSource.Size = new System.Drawing.Size(135, 44);
            this.btnEditSource.TabIndex = 4;
            this.btnEditSource.Text = "~ 修改";
            this.btnEditSource.UseVisualStyleBackColor = false;
            this.btnEditSource.Click += new System.EventHandler(this.btnEditSource_Click);
            // 
            // btnAddSource
            // 
            this.btnAddSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnAddSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSource.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddSource.ForeColor = System.Drawing.Color.White;
            this.btnAddSource.Location = new System.Drawing.Point(16, 326);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(135, 44);
            this.btnAddSource.TabIndex = 3;
            this.btnAddSource.Text = "+ 添加基地";
            this.btnAddSource.UseVisualStyleBackColor = false;
            this.btnAddSource.Click += new System.EventHandler(this.btnAddSource_Click);
            // 
            // dgvSource
            // 
            this.dgvSource.AllowUserToAddRows = false;
            this.dgvSource.AllowUserToDeleteRows = false;
            this.dgvSource.BackgroundColor = System.Drawing.Color.White;
            this.dgvSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSource.Location = new System.Drawing.Point(0, 6);
            this.dgvSource.Name = "dgvSource";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            this.dgvSource.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSource.RowTemplate.Height = 23;
            this.dgvSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSource.Size = new System.Drawing.Size(470, 294);
            this.dgvSource.TabIndex = 0;
            this.dgvSource.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSource_CellContentClick);
            // 
            // tabPrintConfig
            // 
            this.tabPrintConfig.Controls.Add(this.cbxLabelSize);
            this.tabPrintConfig.Controls.Add(this.label2);
            this.tabPrintConfig.Controls.Add(this.btnSavePrintConfig);
            this.tabPrintConfig.Controls.Add(this.tbxMaxLabelNum);
            this.tabPrintConfig.Controls.Add(this.label3);
            this.tabPrintConfig.Controls.Add(this.cbxPort);
            this.tabPrintConfig.Controls.Add(this.label1);
            this.tabPrintConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPrintConfig.Name = "tabPrintConfig";
            this.tabPrintConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrintConfig.Size = new System.Drawing.Size(470, 375);
            this.tabPrintConfig.TabIndex = 2;
            this.tabPrintConfig.Text = "打印设置";
            this.tabPrintConfig.UseVisualStyleBackColor = true;
            // 
            // cbxLabelSize
            // 
            this.cbxLabelSize.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbxLabelSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxLabelSize.FormattingEnabled = true;
            this.cbxLabelSize.Items.AddRange(new object[] {
            "2.5CM * 1.5CM YB",
            "5CM * 4CM",
            "5CM * 4CM YB",
            "6CM * 9CM",
            "6CM * 9CM YB",
            "5CM * 4CM YB 2017-1"});
            this.cbxLabelSize.Location = new System.Drawing.Point(84, 78);
            this.cbxLabelSize.Name = "cbxLabelSize";
            this.cbxLabelSize.Size = new System.Drawing.Size(162, 20);
            this.cbxLabelSize.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(7, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "标签规格：";
            // 
            // btnSavePrintConfig
            // 
            this.btnSavePrintConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnSavePrintConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePrintConfig.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSavePrintConfig.ForeColor = System.Drawing.Color.White;
            this.btnSavePrintConfig.Location = new System.Drawing.Point(319, 326);
            this.btnSavePrintConfig.Name = "btnSavePrintConfig";
            this.btnSavePrintConfig.Size = new System.Drawing.Size(135, 44);
            this.btnSavePrintConfig.TabIndex = 6;
            this.btnSavePrintConfig.Text = "保存打印设置";
            this.btnSavePrintConfig.UseVisualStyleBackColor = false;
            this.btnSavePrintConfig.Click += new System.EventHandler(this.btnSavePrintConfig_Click);
            // 
            // tbxMaxLabelNum
            // 
            this.tbxMaxLabelNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxMaxLabelNum.Location = new System.Drawing.Point(146, 46);
            this.tbxMaxLabelNum.Name = "tbxMaxLabelNum";
            this.tbxMaxLabelNum.Size = new System.Drawing.Size(142, 21);
            this.tbxMaxLabelNum.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "单次最多打印标签个数：";
            // 
            // cbxPort
            // 
            this.cbxPort.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbxPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPort.FormattingEnabled = true;
            this.cbxPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20"});
            this.cbxPort.Location = new System.Drawing.Point(82, 13);
            this.cbxPort.Name = "cbxPort";
            this.cbxPort.Size = new System.Drawing.Size(162, 20);
            this.cbxPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "打印机串口：";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(324, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(479, 451);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabsConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormConfig";
            this.ShowIcon = false;
            this.Text = "基础配置";
            this.Load += new System.EventHandler(this.FormConfig_Load);
            this.tabsConfig.ResumeLayout(false);
            this.tabProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.tabBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).EndInit();
            this.tabPrintConfig.ResumeLayout(false);
            this.tabPrintConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsConfig;
        private System.Windows.Forms.TabPage tabProduct;
        private System.Windows.Forms.TabPage tabBase;
        private System.Windows.Forms.TabPage tabPrintConfig;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxMaxLabelNum;
        private System.Windows.Forms.DataGridView dgvSource;
        private System.Windows.Forms.Button btnSavePrintConfig;
        private System.Windows.Forms.Button btnAddSource;
        private System.Windows.Forms.Button btnEditSource;
        private System.Windows.Forms.Button btnDeleteSource;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.ComboBox cbxLabelSize;
        private System.Windows.Forms.Label label2;

    }
}