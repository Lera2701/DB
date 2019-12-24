using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CourseDB
{
    public partial class Referral_Addition : Form
    {
        public const string ConnectionString = @"Data Source=DESKTOP-NUVBV6D\SQLEXPRESS;Initial Catalog=Preventorium1;Integrated Security=True;Connect Timeout=30";
        public Referral_Addition()
        {
            InitializeComponent();
        }

        private void Referral_Addition_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "preventorium1DataSet.Procedure". При необходимости она может быть перемещена или удалена.
            this.procedureTableAdapter.Fill(this.preventorium1DataSet.Procedure);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "preventorium1DataSet.Diagnosis". При необходимости она может быть перемещена или удалена.
            this.diagnosisTableAdapter.Fill(this.preventorium1DataSet.Diagnosis);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "preventorium1DataSet.Doctor". При необходимости она может быть перемещена или удалена.
            this.doctorTableAdapter.Fill(this.preventorium1DataSet.Doctor);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = this.Owner as MainForm;
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                string cmd = "INSERT INTO Referral VALUES (" + comboBox1.SelectedValue + ", " +
                comboBox2.SelectedValue + ", " +
                comboBox3.SelectedValue + ", " +
                textBox1.Text + ")";

                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(cmd, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                mainForm.dataGridView1.DataSource = dt;
                dt.AcceptChanges();
                sqlconn.Close();
                MessageBox.Show("Added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }
    }
}
