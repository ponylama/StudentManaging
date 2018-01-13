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
    public partial class User_Ditetails_B : Form
    {
        List<int> CoursesForStudent = new List<int>(); // create list of courses that student is signed to

        public User_Ditetails_B()
        {
            InitializeComponent();
        }


        private void Last_Name_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Password_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void First_Name_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkData_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
            connect.Open();
            if (connect.State == System.Data.ConnectionState.Open)
            {
                string command = "select * from Users where ID = '" + ID_Box.Text + "'";
                SqlCommand cmd = new SqlCommand(command, connect);
                SqlDataReader dataRead;
                dataRead = cmd.ExecuteReader();
                while (dataRead.Read())
                {
                    Last_Name_Box.Text = (dataRead["LastName"].ToString());
                    First_Name_Box.Text = (dataRead["FirstName"].ToString());
                    Password_Box.Text = (dataRead["Password"].ToString());
                    Year_Box.Text = (dataRead["Year"].ToString());
                }

                // find courses assined
                string FindStudentCourses = "select * from StudentsCourses "; // search on CoursePlacement
                SqlCommand cmdCourses = new SqlCommand(FindStudentCourses, connect); // check specific course
                SqlDataReader dataReadcourse;
                dataReadcourse = cmdCourses.ExecuteReader();
                
                //get courses
                while (dataReadcourse.Read())
                {
                    int id = Convert.ToInt32(dataReadcourse["ID"]); // gets id
                    int idfrombox = Convert.ToInt32(ID_Box.Text);
                    if (idfrombox == id) // check if 'this' is in course
                    {
                        int courseassigned = Convert.ToInt32(dataReadcourse["IDcourse"]);
                        CoursesForStudent.Add(courseassigned); // add course to list of courses to student
                    }
                }

            }
            for (int i=0; i < CoursesForStudent.Count; i++)
                this.listBox1.Items.Add(CoursesForStudent[i]);

            connect.Close();
        }

        private void Year_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void User_Ditetails_B_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
