using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseDB
{
    public partial class Authorization : Form
    {
        
        public Authorization()
        {
            InitializeComponent();
            AutoCompleteStringCollection source = new AutoCompleteStringCollection()
        {
            "registrartor",
            "scheduler"
        };
            textBox1.AutoCompleteCustomSource = source;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

       

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "registrartor" && textBox2.Text == Convert.ToString(123))
            {
                MainForm qe = new MainForm();
                qe.Owner = this;
                qe.label2.Text = "Welcome, registrator";

                qe.diagnosesToolStripMenuItem.Visible = false;
                qe.proceduresToolStripMenuItem.Visible = false;
                qe.doctorsToolStripMenuItem.Visible = false;
                qe.referralsToolStripMenuItem.Visible = false;

                qe.ShowDialog();
            }
            else if (textBox1.Text == "scheduler" && textBox2.Text == Convert.ToString(456))
            {
                MainForm qe = new MainForm();
                qe.Owner = this;
                qe.label2.Text = "Welcome, scheduler";

                qe.patientsToolStripMenuItem.Visible = false;
                qe.roomsToolStripMenuItem.Visible = false;
                qe.journalToolStripMenuItem.Visible = false;

                qe.ShowDialog();
            }
            else MessageBox.Show("Insert correct credentials");
        }
    }
}
