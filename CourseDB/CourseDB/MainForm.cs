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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "preventorium1DataSet.Patient". При необходимости она может быть перемещена или удалена.
            this.patientTableAdapter.Fill(this.preventorium1DataSet.Patient);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "preventorium1DataSet.Room". При необходимости она может быть перемещена или удалена.
            this.roomTableAdapter.Fill(this.preventorium1DataSet.Room);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "preventorium1DataSet.Doctor". При необходимости она может быть перемещена или удалена.
            this.doctorTableAdapter.Fill(this.preventorium1DataSet.Doctor);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "preventorium1DataSet.Procedure". При необходимости она может быть перемещена или удалена.
            this.procedureTableAdapter.Fill(this.preventorium1DataSet.Procedure);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "preventorium1DataSet.Diagnosis". При необходимости она может быть перемещена или удалена.
            this.diagnosisTableAdapter.Fill(this.preventorium1DataSet.Diagnosis);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "preventorium1DataSet.Referral". При необходимости она может быть перемещена или удалена.
            this.referralTableAdapter.Fill(this.preventorium1DataSet.Referral);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "preventorium1DataSet.Patient". При необходимости она может быть перемещена или удалена.
            this.patientTableAdapter.Fill(this.preventorium1DataSet.Patient);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "preventorium1DataSet.Journal". При необходимости она может быть перемещена или удалена.
            this.journalTableAdapter.Fill(this.preventorium1DataSet.Journal);
            dataGridView1.AutoGenerateColumns = true;
        }

        private void DiagnosesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = diagnosisBindingSource;
            dataGridView1.DataSource = diagnosisBindingSource;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Visible = true;
            bindingNavigator1.Visible = true;
            label2.Visible = false;
            label1.Text = "Diagnoses";
        }

        private void ProceduresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = procedureBindingSource;
            dataGridView1.DataSource = procedureBindingSource;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Visible = true;
            bindingNavigator1.Visible = true;
            label2.Visible = false;
            label1.Text = "Procedures";
        }

        private void DoctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = doctorBindingSource;
            dataGridView1.DataSource = doctorBindingSource;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Visible = true;
            bindingNavigator1.Visible = true;
            label2.Visible = false;
            label1.Text = "Doctors";
        }

        private void PatientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = patientBindingSource;
            dataGridView1.DataSource = patientBindingSource;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Visible = true;
            bindingNavigator1.Visible = true;
            label2.Visible = false;
            label1.Text = "Patients";
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowExistingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Referrals qe = new Referrals();
            qe.Owner = this;
            qe.ShowDialog();
        }

        private void AddReferralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Referral_Addition qe = new Referral_Addition();
            qe.Owner = this;
            qe.ShowDialog();
        }

        private void JournalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Journal qe = new Journal();
            qe.Owner = this;
            qe.ShowDialog();
        }

        private void RoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = roomBindingSource;
            dataGridView1.DataSource = roomBindingSource;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Visible = true;
            bindingNavigator1.Visible = true;
            label2.Visible = false;
            label1.Text = "Rooms";
        }

        private void AddPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PAddition qe = new PAddition();
            qe.Owner = this;
            qe.ShowDialog();
        }
    }
}
