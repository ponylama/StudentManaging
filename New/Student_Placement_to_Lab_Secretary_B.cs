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
    //לזכור : לא עשיתי עדיין בדיקה האם הסטודנט משובץ כבר למעבדה
    public partial class Student_Placement_to_Lab_Secretary_B : Form
    {
        int currStudent;
        int currCourseID;
        int currCourseName;
        string currLab;
        string currLabName;
        int Ending = 0;
        int Begin = 0;
        string day;
        int index;
        int nextIndex = 0;

        public string Connecting_String = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;MultipleActiveResultSets=true;User ID=P17;Password=Hadas@2017";
        StudentClass sd;
        public StudentClass studValue
        {
            get { return sd; }
            set { sd = value; }
        }

        //All The Courses ID that the Student Is Listed To
        List<int> courses = new List<int>();


        public Student_Placement_to_Lab_Secretary_B()
        {
            InitializeComponent();
            Fill_Lab_Box();
            Fill_Student_Box();
            AllLabs_Box.Hide();
        }
        //corrent selections of course and student to upload to database
       

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

        public void Fill_Lab_Box()
        {
            string Query = "select * from Labs_B ;";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string Lab =Convert.ToString(myReader.GetInt32(1)) +":"+ Convert.ToString(myReader.GetInt32(2)) + "-" + Convert.ToString(myReader.GetInt32(3)) + "Day." + Convert.ToString(myReader.GetString(4));
                    AllLabs_Box.Items.Add(Lab);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool is_listed_to_lec(int currStudent, string currLabName)
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
                    //MessageBox.Show(currLec+"\n" + course );
                    if (course.Equals(currLabName))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //MessageBox.Show("Your Student is Not Listed To This Lecture! Please Go Back!");
            Save.Hide();
            return false;
        }

        public bool is_listed_to_Lab(int currStudent, string currLabName)
        {
            //MessageBox.Show(currLabName + " " + Convert_IDcourse_to_NameCourse(Convert.ToInt32(currLabName)));
            string Query = "select * from StudentLab_B where ID_Student = '" + currStudent + "' ;";
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
                   
                    if (course.Equals(currLabName))
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
            //MessageBox.Show("This Student Is already listed to this lab - \nStop and go Back!");
            return false;
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

        private void Chosing_a_Course_Click(object sender, EventArgs e)
        {

        }

        private void AllStudents_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            currStudent = Convert.ToInt32(AllStudents_Box.SelectedItem.ToString());
            AllLabs_Box.Show();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Upload_Lab();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AllLabs_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            currLab = AllLabs_Box.SelectedItem.ToString();
            currLabName = currLab.Substring(0, currLab.IndexOf(':'));
            //MessageBox.Show("before begin count   " + currLab.Count() + "  currLab.IndexOf(':') + 1      " + currLab.IndexOf(':') + 1 + "  currLab.IndexOf('-')  " + currLab.IndexOf('-'));

            string Begin_Temp = currLab.Substring(currLab.IndexOf(':') + 1, currLab.IndexOf('-') - currLab.IndexOf(':') - 1);
            Begin = Convert.ToInt32(Begin_Temp);
            string End_Temp = currLab.Substring(currLab.IndexOf('-') + 1, currLab.IndexOf('D') - currLab.IndexOf('-') - 1);
            Ending = Convert.ToInt32(End_Temp);
            string Day = currLab.Substring(currLab.IndexOf('.') + 1, currLab.Count() - currLab.IndexOf('.') - 1);
            //day = Day.ToCharArray();
            day = Day;
            //MessageBox.Show("after begin   " + day_temp[0].ToString());
            //MessageBox.Show(currLab+test.ToString());

            if (is_listed_to_lec(currStudent, currLabName))
            {
                MessageBox.Show("The Student Is Listed\n To this Lecture in.\n");
            }else
            {
                MessageBox.Show("Your Student is Not Listed To This Lecture! Please Go Back!");
            }

            if (is_listed_to_Lab(currStudent, currLabName) == true)
            {
                MessageBox.Show("The Student Is Listed To this Lab - \nPlease chose another.\n");
            }
            else
            {
                MessageBox.Show("The Student is Not Listed To this Lab - YAY!");
                Save.Show();
            }
        }



        //Not Working :\
        public void Upload_Lab()
        {
            //Upload to Database 
            int currCourse = Int32.Parse(this.currLabName);
            string Query = "insert into StudentLab_B (SerialNum,ID_Student,CourseID,Start,Ending,Day) values(@max, @currStudent,@currCourse,@Begin, @Ending,@day)";

            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            conDatabase.Open();
            SqlCommand readMaxNum = new SqlCommand("SELECT MAX(SerialNum) as Max_NUM FROM StudentLab_B", conDatabase);
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
        private void Go_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
