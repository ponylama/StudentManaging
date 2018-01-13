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

namespace New
{
    public partial class secretery_GetStudentOfCourse_B : Form
    {
        List<string> StudentRegistedToCourse = new List<string>(); // create list of courses that student is signed to

        public secretery_GetStudentOfCourse_B()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void get_students_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
            connect.Open();
            if (connect.State == System.Data.ConnectionState.Open)
            {
                string FindStudentCourses = "select * from StudentsCourses "; // search on CoursePlacement
                SqlCommand cmdCourses = new SqlCommand(FindStudentCourses, connect); // check specific course
                SqlDataReader dataReadcourse;
                dataReadcourse = cmdCourses.ExecuteReader();
                while (dataReadcourse.Read())
                {
                    if (this.getID.Text == (dataReadcourse["IDcourse"].ToString()))  // look for course id
                        this.StudentRegistedToCourse.Add(dataReadcourse["ID"].ToString()); // if its equal add it to array

                }


            }
            


            DataTable CommunicationTable = new DataTable();
            CommunicationTable.Columns.Add("Student's ID", typeof(int));
            for (int i = 0; i < StudentRegistedToCourse.Count; i++)
                CommunicationTable.Rows.Add(StudentRegistedToCourse[i]);

            // Notice this assignment:
            dataGridView1.DataSource = CommunicationTable;



            connect.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }


}
