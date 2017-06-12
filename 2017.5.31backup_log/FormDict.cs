using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WindowsForms.func;

namespace WindowsForms
{
   
    public partial class FormDict : Form
    {
        const int MODE_ITEM = 0;
        const int MODE_SAMPLE_CLASS = 1;
        const int MODE_SAMPLE = 2;
        const int MODE_SOURCE = 3;
        const int MODE_RESULT_UNIT = 4;
        const int MODE_RESULT_DX = 5;
        int currMode;


      

        public FormDict()
        {
            InitializeComponent();  
        }

        private void FormDict_Load(object sender, EventArgs e)
        {
            Database db = new Database();
            ArrayList list = db.query();
            MessageBox.Show(list.Count + "");
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            currMode = tabControl.SelectedIndex;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            switch (currMode)
            {
                case MODE_ITEM:
                   
                    break;
                case MODE_SAMPLE_CLASS:
                   
                    break;
                case MODE_SAMPLE:
                   
                    break;
                case MODE_SOURCE:
                   
                    break;
                case MODE_RESULT_UNIT:
                   
                    break;
                case MODE_RESULT_DX:
                  
                    break;
            }

          
        }

        private void tabResultDx_Click(object sender, EventArgs e)
        {

        }

        
    }
}
