using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace New
{
    public partial class Delete_a_Student_From_Course_Secretary_B : Form
    {
        public string Connecting_String = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;MultipleActiveResultSets=true;User ID=P17;Password=Hadas@2017";
        StudentClass sd;
 
        public StudentClass studValue
        {
            get { return sd; }
            set { sd = value; }
        }

        public Delete_a_Student_From_Course_Secretary_B()
        {
            InitializeComponent();
            AllCourses_Box.Hide();
            Chosing_a_Course.Hide();
            Fill_Student_Box();
        }

        //corrent selections of course and student to upload to database
        int currCourse;
        int currStudent;

        public void Fill_Student_Box()
        {
            string Query = "select * from Users where Type = 1  ;";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;

            try
            {

                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    int CourseID = myReader.GetInt32(0);
                    AllStudents_Box.Items.Add(CourseID);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Fill_Course_Box()
        {
            AllCourses_Box.Items.Clear();
            
            string Query = "select * from StudentsCourses where ID = '"+currStudent+"'  ;";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;

            try
            {

                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    int CourseID = myReader.GetInt32(2);
                    AllCourses_Box.Items.Add(CourseID);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Chosing_a_Course_Click(object sender, EventArgs e)
        {

        }

        private void AllCourses_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            currCourse = Convert.ToInt32(AllCourses_Box.SelectedItem.ToString());
        }

        private void Chose_Student_Click(object sender, EventArgs e)
        {

        }

        private void AllStudents_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            currStudent = Convert.ToInt32(AllStudents_Box.SelectedItem.ToString());
            Fill_Course_Box();
            AllCourses_Box.Show();
            Chosing_a_Course.Show();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Delete_Data(currStudent, currCourse);
            MessageBox.Show("Delete");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void Delete_Data(int currStudent, int currCourse)
        {
            Delete_Student_From_StudentCourses(currStudent, currCourse);
            Delete_From_Lec(currStudent, currCourse);
            Delete_From_Prac(currStudent, currCourse);
            Delete_From_Lab(currStudent, currCourse);
        }

        public void Delete_Student_From_StudentCourses(int currStudent, int currCourse)
        {
            string Query = "delete from StudentsCourses where ID ='" + currStudent + "' and IDcourse = '" + currCourse + "' ";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Upload to StudentLec_B
        public void Delete_From_Lec(int currStudent, int currCourse)
        {
            //Delete From Database 
            string Query = "delete from StudentLec_B where ID_Student = '" + currStudent + "' and CourseID = '" + currCourse + "' ";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        //Upload to StudentLab_B

        public void Delete_From_Lab(int currStudent, int currCourse)
        {
            //Delete From Database 
            string Query = "delete from StudentLab_B where ID_Student = '" + currStudent + "' and CourseID = '" + currCourse + "' ";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Upload to StudentPrac_B
        public void Delete_From_Prac(int currStudent, int currCourse)
        {
            //Delete From Database 
            string Query = "delete from StudentPrac_B where ID_Student = '" + currStudent + "' and CourseID = '" + currCourse + "' ";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Back_Button_Click(object sender, EventArgs e)
        {   
            this.Hide();
        }
    }
}
