using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculty
{
    public partial class Home_window : Form
    {
        public Home_window()
        {
            InitializeComponent();
            //TabPage tc=new TabPage();
            tabControl1.Hide();
            tabPage1.Hide();
            tabPage2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Faculty_Pannel fcp = new Faculty_Pannel();
            fcp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 student_pannel = new Form1();
            student_pannel.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            admin_login ad_login = new admin_login();
            ad_login.Show();
        }

        private void facultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            admin_login ad = new admin_login();
            ad.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Faculty_Pannel fpc = new Faculty_Pannel();

            fpc.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 stude = new Form1();
            stude.Show();
        }
    }
}
