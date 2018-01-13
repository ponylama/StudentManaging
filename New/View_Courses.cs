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
    public partial class View_Courses : Form
    {

        public string Connecting_String = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;MultipleActiveResultSets=true;User ID=P17;Password=Hadas@2017";
        public View_Courses()
        {
            InitializeComponent();
            Fill_Student_Box();
        }

        private void Students_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Courses_Box();
        }

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
                    Students_Box.Items.Add(CourseID);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Fill_Courses_Box()
        {
            int curItem = Convert.ToInt32(Students_Box.SelectedItem.ToString());
           
            //לזכור לצרף את השמות של ההרצאות
            string Query = "select * from StudentsCourses where ID = '" + curItem + "'";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string CourseID = Convert.ToString(myReader.GetInt32(2)) + " " + Convert_IDcourse_to_NameCourse((myReader.GetInt32(2)));
                    //listView1.Items.Add(CourseID.ToString());
                    Courses.Items.Add((CourseID.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public string Convert_IDcourse_to_NameCourse(int IDCourse)
        {
            string Query = "select * from Courses where IDcourse = '" + IDCourse + "' ;";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    //MessageBox.Show(Convert.ToString(myReader.GetInt32(0)));
                    return Convert.ToString(myReader.GetString(1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Courses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
