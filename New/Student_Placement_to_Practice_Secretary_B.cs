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
    public partial class Student_Placement_to_Practice_Secretary_B : Form
    {


        int currStudent;
        //int currCourseID;
        //int currCourseName;
        string currPra;
        string currPraName;
        int Ending = 0;
        int Begin = 0;
        string day;
        

        public string Connecting_String = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;MultipleActiveResultSets=true;User ID=P17;Password=Hadas@2017";
        StudentClass sd;
        public StudentClass studValue
        {
            get { return sd; }
            set { sd = value; }
        }

        public Student_Placement_to_Practice_Secretary_B()
        {
            InitializeComponent();
            Fill_Student_Box();
            Fill_Practice_Box();
            AllCourses_Box.Hide();
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
                    AllStudents_Box.Items.Add(CourseID);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Fill_Practice_Box()
        {
            string Query = "select * from schedualing where teachingAssitant IS NOT NULL ;";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string Lec = myReader.GetString(5) + ": " + Convert.ToString(myReader.GetInt32(7)) + "-" + Convert.ToString(myReader.GetInt32(8)) + "Day." + Convert.ToString(myReader.GetString(4));
                    AllCourses_Box.Items.Add(Lec);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string Convert_NameCourse_to_IDcourse(string NameCourse)
        {
            string Query = "select * from Courses where Name = '" + NameCourse + "' ;";
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
                    return Convert.ToString(myReader.GetInt32(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }

        public bool is_listed_to_Lec(int currStudent, string currPraName)
        {
            string Query = "select * from StudentLec_B where ID_Student = '" + currStudent + "' ;";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string course = Convert.ToString(myReader.GetInt32(2));
                    
                    if (course.Equals(Convert_NameCourse_to_IDcourse(currPraName)))
                    {
                        Save.Hide();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //MessageBox.Show("Your Student is Not Listed To This Lecture! Please Go Back!");
            
            return false;
        }

        public bool is_listed_to_practice_selected(int currStudent, string currPraName)
        {

            string Query = "select * from StudentPrac_B where ID_Student = '" + currStudent + "' ;";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string course = Convert.ToString(myReader.GetInt32(2));
                    if (course.Equals(Convert_NameCourse_to_IDcourse(currPraName)))
                    {
                        Save.Hide();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private void AllCourses_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            currPra = AllCourses_Box.SelectedItem.ToString();
            currPraName = currPra.Substring(0, currPra.IndexOf(':'));
            //MessageBox.Show("before begin count   " + currPra.Count() + "  currPra.IndexOf(':') + 1      " + currPra.IndexOf(':') + 1 + "  currPra.IndexOf('-')  " + currPra.IndexOf('-'));

            string Begin_Temp = currPra.Substring(currPra.IndexOf(':') + 1, currPra.IndexOf('-') - currPra.IndexOf(':') - 1);
            Begin = Convert.ToInt32(Begin_Temp);
            string End_Temp = currPra.Substring(currPra.IndexOf('-') + 1, currPra.IndexOf('D') - currPra.IndexOf('-') - 1);
            Ending = Convert.ToInt32(End_Temp);
            string Day = currPra.Substring(currPra.IndexOf('.') + 1, currPra.Count() - currPra.IndexOf('.') - 1);
            //day = Day.ToCharArray();
            day = Day;
            //MessageBox.Show("after begin   " + day_temp[0].ToString());
            //MessageBox.Show(currPra+test.ToString());

            if (is_listed_to_Lec(currStudent, currPraName) == true)
            {
               MessageBox.Show("The Student Is Listed To this Lecture - Continue\n");
                
            }
            else
            {
                MessageBox.Show("Your Student is Not Listed To This Lecture! Please Go Back!");
               
                
            }

            if (is_listed_to_practice_selected(currStudent, currPraName) == true)
            {
                MessageBox.Show("The Student Is Listed To this Practice - Stop and go back!\n");
            }else
            {
                MessageBox.Show("The Student is Not Listed To this Practice - YAY!");
                Save.Show();
            }
        }

        private void Chosing_a_Course_Click(object sender, EventArgs e)
        {

        }

        private void Chose_Student_Click(object sender, EventArgs e)
        {

        }

        private void AllStudents_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            currStudent = Convert.ToInt32(AllStudents_Box.SelectedItem.ToString());
            AllCourses_Box.Show();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Upload_Pra();
            MessageBox.Show("Saved");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Not Working :\
        public void Upload_Pra()
        {
            //Upload to Database 
            int currCourse = Convert.ToInt32(Convert_NameCourse_to_IDcourse(this.currPraName));
            string Query = "insert into StudentPrac_B (SerialNum,ID_Student,CourseID,Start,Ending,Day) values(@max, @currStudent,@currCourse,@Begin, @Ending,@day)";

            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            conDatabase.Open();
            SqlCommand readMaxNum = new SqlCommand("SELECT MAX(SerialNum) as Max_NUM FROM StudentPrac_B", conDatabase);
            readMaxNum.CommandType = CommandType.Text;
            int max = (Int32.Parse(readMaxNum.ExecuteScalar().ToString())) + 1;

            SqlCommand cmd = new SqlCommand(Query, conDatabase);

            try
            {
                //MessageBox.Show("Saved" + this.day.ToString());
                cmd.Parameters.Add("@max", SqlDbType.Int);
                cmd.Parameters["@max"].Value = max;
                cmd.Parameters.Add("@currStudent", SqlDbType.Int);
                cmd.Parameters["@currStudent"].Value = this.currStudent;
                cmd.Parameters.Add("@currCourse", SqlDbType.Int);
                cmd.Parameters["@currCourse"].Value = currCourse;
                cmd.Parameters.Add("@Begin", SqlDbType.Int);
                cmd.Parameters["@Begin"].Value = this.Begin;
                cmd.Parameters.Add("@Ending", SqlDbType.Int);
                cmd.Parameters["@Ending"].Value = Ending;
                cmd.Parameters.Add("@day", SqlDbType.VarChar);
                cmd.Parameters["@day"].Value = this.day;

                cmd.ExecuteNonQuery();
                conDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
