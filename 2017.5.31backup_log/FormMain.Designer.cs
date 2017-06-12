namespace Trace
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.二维码标签ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标签查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.技术支持ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.二维码标签ToolStripMenuItem,
            this.标签查询ToolStripMenuItem,
            this.关于我们ToolStripMenuItem,
            this.技术支持ToolStripMenuItem,
            this.图像测试ToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(656, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 二维码标签ToolStripMenuItem
            // 
            this.二维码标签ToolStripMenuItem.Name = "二维码标签ToolStripMenuItem";
            this.二维码标签ToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.二维码标签ToolStripMenuItem.Text = "二维码标签";
            this.二维码标签ToolStripMenuItem.Click += new System.EventHandler(this.二维码标签ToolStripMenuItem_Click);
            // 
            // 标签查询ToolStripMenuItem
            // 
            this.标签查询ToolStripMenuItem.Name = "标签查询ToolStripMenuItem";
            this.标签查询ToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.标签查询ToolStripMenuItem.Text = "标签查询";
            this.标签查询ToolStripMenuItem.Click += new System.EventHandler(this.标签查询ToolStripMenuItem_Click);
            // 
            // 关于我们ToolStripMenuItem
            // 
            this.关于我们ToolStripMenuItem.Name = "关于我们ToolStripMenuItem";
            this.关于我们ToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.关于我们ToolStripMenuItem.Text = "基础配置";
            this.关于我们ToolStripMenuItem.Click += new System.EventHandler(this.关于我们ToolStripMenuItem_Click);
            // 
            // 技术支持ToolStripMenuItem
            // 
            this.技术支持ToolStripMenuItem.Name = "技术支持ToolStripMenuItem";
            this.技术支持ToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.技术支持ToolStripMenuItem.Text = "技术支持";
            this.技术支持ToolStripMenuItem.Click += new System.EventHandler(this.技术支持ToolStripMenuItem_Click);
            // 
            // 图像测试ToolStripMenuItem
            // 
            this.图像测试ToolStripMenuItem.Name = "图像测试ToolStripMenuItem";
            this.图像测试ToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.图像测试ToolStripMenuItem.Text = "图像测试";
            this.图像测试ToolStripMenuItem.Click += new System.EventHandler(this.图像测试ToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(656, 417);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 二维码标签ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标签查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 技术支持ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像测试ToolStripMenuItem;
    }
}

