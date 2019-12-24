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
    public partial class PAddition : Form
    {
        public const string ConnectionString = @"Data Source=DESKTOP-NUVBV6D\SQLEXPRESS;Initial Catalog=Preventorium1;Integrated Security=True;Connect Timeout=30";
        public PAddition()
        {
            InitializeComponent();
        }

        private void PAddition_Load(object sender, EventArgs e)
        {

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
    }
}
