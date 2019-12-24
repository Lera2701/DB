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
using System.IO;

namespace CourseDB
{
    public partial class Referrals : Form
    {
        public const string ConnectionString = @"Data Source=DESKTOP-NUVBV6D\SQLEXPRESS;Initial Catalog=Preventorium1;Integrated Security=True;Connect Timeout=30";
        public Referrals()
        {
            InitializeComponent();
        }

        private void Referrals_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                string cmd = "Select Referral.Referral_ID, Doctor.Specialization as Specialist, Doctor.Doctor_Name as Doctor, Diagnosis.Diagnosis_Name as Diagnosis, [Procedure].[Name] as Treatment, Referral.[Procedure_Number] as 'Procedures' " +
                "from Diagnosis inner join Referral on Diagnosis.Diagnosis_ID = Referral.Diagnosis_ID " +
                "inner join Doctor on Doctor.Doctor_ID = Referral.Doctor_ID inner join [Procedure] on [Procedure].[Procedure_ID] = Referral.[Procedure_ID] ";
                

                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(cmd, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                string cmd = "Select Doctor.Specialization as Specialist, Doctor.Doctor_Name as Doctor, " +
                "Diagnosis.Diagnosis_Name as Diagnosis, [Procedure].[Name] as Treatment, Referral.[Procedure_Number] as 'Procedures'" +
                "from Diagnosis inner join Referral on Diagnosis.Diagnosis_ID = Referral.Diagnosis_ID " +
                "inner join Doctor on Doctor.Doctor_ID = Referral.Doctor_ID inner join [Procedure] on [Procedure].[Procedure_ID] = Referral.[Procedure_ID] " +
                "where Doctor.Doctor_ID in (";
                for (int i = 0; i < checkedListBox1.CheckedIndices.Count - 1; i++)
                {
                    cmd += $"{checkedListBox1.CheckedIndices[i] + 1}, ";
                }
                cmd += $"{checkedListBox1.CheckedIndices[checkedListBox1.CheckedIndices.Count - 1] + 1}";
                cmd += ")";

                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(cmd, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                string cmd = "Select Doctor.Specialization as Specialist, Doctor.Doctor_Name as Doctor, " +
                "Diagnosis.Diagnosis_Name as Diagnosis, [Procedure].[Name] as Treatment, Referral.[Procedure_Number] as 'Procedures' " +
                "from Diagnosis inner join Referral on Diagnosis.Diagnosis_ID = Referral.Diagnosis_ID " +
                "inner join Doctor on Doctor.Doctor_ID = Referral.Doctor_ID inner join [Procedure] on [Procedure].[Procedure_ID] = Referral.[Procedure_ID]";

                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(cmd, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;

                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.Programmatic;
            dataGridView1.Sort(dataGridView1.Columns[3], ListSortDirection.Ascending);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                DialogResult dialogResult = MessageBox.Show("Do you really want to delete the selected row?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlCommand com = new SqlCommand("DELETE FROM Referral WHERE Referral_ID = @id", con);
                    int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    com.Parameters.AddWithValue("@id", id);
                    con.Open();

                    try
                    {
                        com.ExecuteNonQuery();
                        MessageBox.Show("Row`s deleted");
                        Referrals_Load(sender, e);
                        con.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Deleting`s failed!");
                    }
                }
            }
        }
    
    }
}
