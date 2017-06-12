namespace Trace
{
    partial class FormQrCode
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
            this.labelPickTime = new System.Windows.Forms.Label();
            this.dtpPickTime = new System.Windows.Forms.DateTimePicker();
            this.labelName = new System.Windows.Forms.Label();
            this.labelSource = new System.Windows.Forms.Label();
            this.cbxSource = new System.Windows.Forms.ComboBox();
            this.labelPIC = new System.Windows.Forms.Label();
            this.labelNC = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelLabelNum = new System.Windows.Forms.Label();
            this.tbxLabelNum = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.labelPortStatus = new System.Windows.Forms.Label();
            this.labelDBStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxPIC = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelUploadResult = new System.Windows.Forms.Label();
            this.panelProducts = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbxNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDetectTime = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.cbxAddress = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPickTime
            // 
            this.labelPickTime.AutoSize = true;
            this.labelPickTime.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPickTime.ForeColor = System.Drawing.Color.Black;
            this.labelPickTime.Location = new System.Drawing.Point(5, 62);
            this.labelPickTime.Name = "labelPickTime";
            this.labelPickTime.Size = new System.Drawing.Size(107, 25);
            this.labelPickTime.TabIndex = 0;
            this.labelPickTime.Text = "出产日期：";
            // 
            // dtpPickTime
            // 
            this.dtpPickTime.CustomFormat = "yyyy-MM-dd";
            this.dtpPickTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPickTime.Location = new System.Drawing.Point(112, 66);
            this.dtpPickTime.Name = "dtpPickTime";
            this.dtpPickTime.Size = new System.Drawing.Size(149, 21);
            this.dtpPickTime.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.ForeColor = System.Drawing.Color.Black;
            this.labelName.Location = new System.Drawing.Point(6, 10);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(69, 25);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "品名：";
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSource.ForeColor = System.Drawing.Color.Black;
            this.labelSource.Location = new System.Drawing.Point(5, 109);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(107, 25);
            this.labelSource.TabIndex = 4;
            this.labelSource.Text = "产品来源：";
            // 
            // cbxSource
            // 
            this.cbxSource.FormattingEnabled = true;
            this.cbxSource.Location = new System.Drawing.Point(112, 114);
            this.cbxSource.Name = "cbxSource";
            this.cbxSource.Size = new System.Drawing.Size(149, 20);
            this.cbxSource.TabIndex = 5;
            this.cbxSource.SelectedIndexChanged += new System.EventHandler(this.cbxSource_SelectedIndexChanged);
            // 
            // labelPIC
            // 
            this.labelPIC.AutoSize = true;
            this.labelPIC.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPIC.ForeColor = System.Drawing.Color.Black;
            this.labelPIC.Location = new System.Drawing.Point(24, 197);
            this.labelPIC.Name = "labelPIC";
            this.labelPIC.Size = new System.Drawing.Size(88, 25);
            this.labelPIC.TabIndex = 6;
            this.labelPIC.Text = "责任人：";
            // 
            // labelNC
            // 
            this.labelNC.AutoSize = true;
            this.labelNC.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNC.ForeColor = System.Drawing.Color.Black;
            this.labelNC.Location = new System.Drawing.Point(5, 239);
            this.labelNC.Name = "labelNC";
            this.labelNC.Size = new System.Drawing.Size(107, 25);
            this.labelNC.TabIndex = 8;
            this.labelNC.Text = "检测时间：";
            this.labelNC.Click += new System.EventHandler(this.labelNC_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(154, 369);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(121, 36);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "打印二维码";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(321, 369);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 36);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelLabelNum
            // 
            this.labelLabelNum.AutoSize = true;
            this.labelLabelNum.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLabelNum.ForeColor = System.Drawing.Color.Black;
            this.labelLabelNum.Location = new System.Drawing.Point(5, 276);
            this.labelLabelNum.Name = "labelLabelNum";
            this.labelLabelNum.Size = new System.Drawing.Size(107, 25);
            this.labelLabelNum.TabIndex = 12;
            this.labelLabelNum.Text = "标签数量：";
            // 
            // tbxLabelNum
            // 
            this.tbxLabelNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxLabelNum.Location = new System.Drawing.Point(112, 281);
            this.tbxLabelNum.Name = "tbxLabelNum";
            this.tbxLabelNum.Size = new System.Drawing.Size(149, 21);
            this.tbxLabelNum.TabIndex = 13;
            this.tbxLabelNum.Text = "1";
            // 
            // labelPortStatus
            // 
            this.labelPortStatus.AutoSize = true;
            this.labelPortStatus.ForeColor = System.Drawing.Color.White;
            this.labelPortStatus.Location = new System.Drawing.Point(11, 6);
            this.labelPortStatus.Name = "labelPortStatus";
            this.labelPortStatus.Size = new System.Drawing.Size(65, 12);
            this.labelPortStatus.TabIndex = 14;
            this.labelPortStatus.Text = "设备状态：";
            // 
            // labelDBStatus
            // 
            this.labelDBStatus.AutoSize = true;
            this.labelDBStatus.ForeColor = System.Drawing.Color.White;
            this.labelDBStatus.Location = new System.Drawing.Point(166, 6);
            this.labelDBStatus.Name = "labelDBStatus";
            this.labelDBStatus.Size = new System.Drawing.Size(77, 12);
            this.labelDBStatus.TabIndex = 15;
            this.labelDBStatus.Text = "数据库状态：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.panel1.Controls.Add(this.labelPortStatus);
            this.panel1.Controls.Add(this.labelDBStatus);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 27);
            this.panel1.TabIndex = 16;
            // 
            // cbxPIC
            // 
            this.cbxPIC.FormattingEnabled = true;
            this.cbxPIC.Location = new System.Drawing.Point(112, 202);
            this.cbxPIC.Name = "cbxPIC";
            this.cbxPIC.Size = new System.Drawing.Size(149, 20);
            this.cbxPIC.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.labelUploadResult);
            this.panel2.Location = new System.Drawing.Point(1, 418);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(605, 27);
            this.panel2.TabIndex = 18;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // labelUploadResult
            // 
            this.labelUploadResult.AutoSize = true;
            this.labelUploadResult.Location = new System.Drawing.Point(13, 9);
            this.labelUploadResult.Name = "labelUploadResult";
            this.labelUploadResult.Size = new System.Drawing.Size(0, 12);
            this.labelUploadResult.TabIndex = 0;
            // 
            // panelProducts
            // 
            this.panelProducts.AutoScroll = true;
            this.panelProducts.BackColor = System.Drawing.Color.Transparent;
            this.panelProducts.Location = new System.Drawing.Point(81, 14);
            this.panelProducts.Name = "panelProducts";
            this.panelProducts.Size = new System.Drawing.Size(195, 304);
            this.panelProducts.TabIndex = 19;
            this.panelProducts.Paint += new System.Windows.Forms.PaintEventHandler(this.panelProducts_Paint);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cbxAddress);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.tbxNo);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.dtpDetectTime);
            this.panel3.Controls.Add(this.tbxLabelNum);
            this.panel3.Controls.Add(this.labelPickTime);
            this.panel3.Controls.Add(this.dtpPickTime);
            this.panel3.Controls.Add(this.cbxPIC);
            this.panel3.Controls.Add(this.labelSource);
            this.panel3.Controls.Add(this.cbxSource);
            this.panel3.Controls.Add(this.labelPIC);
            this.panel3.Controls.Add(this.labelLabelNum);
            this.panel3.Controls.Add(this.labelNC);
            this.panel3.Location = new System.Drawing.Point(284, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(321, 328);
            this.panel3.TabIndex = 20;
            // 
            // tbxNo
            // 
            this.tbxNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxNo.Location = new System.Drawing.Point(112, 24);
            this.tbxNo.Name = "tbxNo";
            this.tbxNo.Size = new System.Drawing.Size(149, 21);
            this.tbxNo.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(43, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "批号：";
            // 
            // dtpDetectTime
            // 
            this.dtpDetectTime.CustomFormat = "yyyy-MM-dd";
            this.dtpDetectTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDetectTime.Location = new System.Drawing.Point(112, 243);
            this.dtpDetectTime.Name = "dtpDetectTime";
            this.dtpDetectTime.Size = new System.Drawing.Size(149, 21);
            this.dtpDetectTime.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.labelName);
            this.panel4.Controls.Add(this.panelProducts);
            this.panel4.Location = new System.Drawing.Point(1, 26);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(281, 328);
            this.panel4.TabIndex = 21;
            // 
            // cbxAddress
            // 
            this.cbxAddress.FormattingEnabled = true;
            this.cbxAddress.Location = new System.Drawing.Point(112, 158);
            this.cbxAddress.Name = "cbxAddress";
            this.cbxAddress.Size = new System.Drawing.Size(149, 20);
            this.cbxAddress.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(43, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "地址：";
            // 
            // FormQrCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(606, 446);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormQrCode";
            this.ShowIcon = false;
            this.Text = "二维码标签";
            this.Load += new System.EventHandler(this.FormQrCode_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPickTime;
        private System.Windows.Forms.DateTimePicker dtpPickTime;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.ComboBox cbxSource;
        private System.Windows.Forms.Label labelPIC;
        private System.Windows.Forms.Label labelNC;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelLabelNum;
        private System.Windows.Forms.TextBox tbxLabelNum;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label labelPortStatus;
        private System.Windows.Forms.Label labelDBStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxPIC;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelUploadResult;
        private System.Windows.Forms.Panel panelProducts;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpDetectTime;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.TextBox tbxNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxAddress;
        private System.Windows.Forms.Label label1;
    }
}