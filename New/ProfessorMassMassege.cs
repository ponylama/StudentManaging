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
    public partial class ProfessorMassMassege : Form
    {
        int CourseID = 0;
        int profID = 0;
        ProfessorClass pc;
        //public string Connecting_String = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;MultipleActiveResultSets=true;User ID=P17;Password=Hadas@2017";

        public ProfessorClass profValue
        {
            get { return pc; }
            set { pc = value; }
        }
        List<int> Courses = new List<int>();
        List<string> CoursesName = new List<string>();
        List<int> StudentsID = new List<int>();
        public ProfessorMassMassege()
        {
            InitializeComponent();
        }

        private void ProfessorMassMassege_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
            connect.Open();

            if (connect.State == System.Data.ConnectionState.Open)
            {
                int profID = Convert.ToInt32(pc.getID());
                string FindStaffCourses = "select * from StaffCourses where ID = '" + profID + "' "; // search on Courses
                SqlCommand cmdStaffCourses = new SqlCommand(FindStaffCourses, connect);
                SqlDataReader dataReadcourse;
                dataReadcourse = cmdStaffCourses.ExecuteReader();
                while (dataReadcourse.Read())
                {
                    CourseID = dataReadcourse.GetInt32(2);
                }
            }
            connect.Close();

            SqlConnection connect2 = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
            connect2.Open();
            if (connect2.State == System.Data.ConnectionState.Open)
            {
                string FindCourses = "select * from Courses where IDcourse = '" + Convert.ToInt32(CourseID) + "'"; // search on CoursePlacement
                SqlCommand cmdCourses = new SqlCommand(FindCourses, connect2); // check specific course
                SqlDataReader dataReadcourse;
                dataReadcourse = cmdCourses.ExecuteReader();
                while (dataReadcourse.Read())
                {
                    string data = dataReadcourse.GetString(1);
                    listBox1.Items.Add(data);
                }
            }
            connect2.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                MessageBox.Show("Please select an Item first!");
            else
            {
                SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
                connect.Open();
                if (connect.State == System.Data.ConnectionState.Open)
                {
                    string find_students = "select * from StudentsCourses ";
                    SqlCommand cmdfind = new SqlCommand(find_students, connect);
                    SqlDataReader dataReadcourse;
                    dataReadcourse = cmdfind.ExecuteReader();
                    while (dataReadcourse.Read())
                    {
                        //int cours_id = Convert.ToInt32(dataReadcourse["IDcourse"]);

                        if (Convert.ToInt32(dataReadcourse["IDcourse"]) == CourseID)
                        {

                            StudentsID.Add(Convert.ToInt32(dataReadcourse["ID"]));
                        }
                    }
                    if (StudentsID.Count != 0)
                    {
                        for (int i = 0; i < StudentsID.Count; i++)
                        {
                            string command = "update Messege_Box set L_Messege = '" + textBox1.Text + "' where ID = '" + StudentsID[i] + "'";
                            SqlCommand cmd = new SqlCommand(command, connect);
                            cmd.ExecuteReader();
                        }
                        MessageBox.Show("your messege was sent to '" + StudentsID.Count + "' students");
                    }
                    else
                        MessageBox.Show("nobody registered to this cours please select another");
                }
                connect.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connect2 = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
            connect2.Open();
            if (connect2.State == System.Data.ConnectionState.Open)
            {
                string FindCourses = "select * from Courses where IDcourse = '" + Convert.ToInt32(CourseID) + "'";
                SqlCommand cmdCourses = new SqlCommand(FindCourses, connect2); // check specific course
                SqlDataReader dataReadcourse;
                dataReadcourse = cmdCourses.ExecuteReader();
                while (dataReadcourse.Read())
                {
                    string data = dataReadcourse.GetString(1);
                    listBox1.Items.Add(data);
                }
            }
            connect2.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_LecturerMenu.CIRRENTA_LecturerMenu.Show();
        }
    }
}
