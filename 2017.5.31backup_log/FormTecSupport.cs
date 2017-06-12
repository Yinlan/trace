using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Trace
{
    public partial class FormTecSupport : Form
    {
        String directory;

        public FormTecSupport()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            directory = Environment.CurrentDirectory.ToString();
            FileInfo versionInfo = new FileInfo(directory + "/version.txt");
            if (!versionInfo.Exists)
            {
                versionInfo.Create();
            }

            StreamReader reader = new StreamReader(versionInfo.FullName);
            string versionCode = reader.ReadLine();
            string versionName = reader.ReadLine();
            labelVersion.Text = versionName;
            labelVersionCode.Text = versionCode;
        }

        private void FormTecSupport_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
