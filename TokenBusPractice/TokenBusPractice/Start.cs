using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TokenBusPractice
{
    //初始界面类
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();          
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new MultiFormApplictionStart();
        }

        private void Start_Load(object sender, EventArgs e)
        {

        }
    }
}
