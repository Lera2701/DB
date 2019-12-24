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
    public partial class Journal : Form
    {
        public const string ConnectionString = @"Data Source=DESKTOP-NUVBV6D\SQLEXPRESS;Initial Catalog=Preventorium1;Integrated Security=True;Connect Timeout=30";
        
        public Journal()
        {
            InitializeComponent();
        }

        private void Journal_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "preventorium1DataSet.Journal". При необходимости она может быть перемещена или удалена.
            this.journalTableAdapter.Fill(this.preventorium1DataSet.Journal);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                //"SELECT Journal.Room_Number as Number, COUNT(*) as CurrentLiving FROM Patient INNER JOIN Journal INNER JOIN Room ON Room.Room_ID = Journal.Room_Number AND Journal.Room_Number = Room.Room_ID ON Patient.Patient_ID = Journal.Patient_ID GROUP BY Journal.Room_Number "
                con.Open();
                string s = @"SELECT r.Room_ID, (r.Bunk_Number - COUNT(j.Room_Number)) FROM Room r
                            left join Journal j on j.Room_Number = r.Room_ID
                            group by r.Bunk_Number, r.Room_ID
                            having r.Bunk_Number > COUNT(j.Room_Number)";

                SqlCommand command = new SqlCommand(s, con);
                SqlDataReader reader = command.ExecuteReader();

                comboBox1.ValueMember = "Id";
                comboBox1.DisplayMember = "Label";

                while (reader.Read())
                {
                    var roomId = reader.GetInt32(0);
                    var freeNum = reader.GetInt32(1);

                    comboBox1.Items.Add(new { Id = roomId, Label = $"Комната {roomId} - {freeNum}" });
                }

                con.Close();

            }
        }

        private void СохранитьToolStripButton_Click(object sender, EventArgs e)
        { 
            try
            {
                this.Validate();
                this.journalBindingSource.EndEdit();
                this.journalTableAdapter.Update(this.preventorium1DataSet.Journal);
                MessageBox.Show("Updated successfully");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Update failed");
            }
        }

        List<int> indexes = new List<int>();

        public void Button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            indexes.Add(i);
                            dataGridView1.Rows[i].Selected = true;
                            i++;

                        }
                }
            }
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int[] arr = indexes.ToArray();
            int k = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                k = arr[i];
                dataGridView1.Rows[k].Selected = false;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
