using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HideBullet
{
    public partial class Form1 : Form

    {
        public Form1()
        {
            InitializeComponent();
        }
        public string TextBosMsg
        {
            set
            {
                label3.Text = value;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form2 f = new Form2();//產生Form2的物件，才可以使用它所提供的Method  
                f.Owner = this;
                this.Visible = false;
                f.Visible = true;
            }
        }       
    }

}
