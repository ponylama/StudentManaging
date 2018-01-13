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
    public partial class Student_Placement_to_Lec_Secretary_B : Form
    {
        int currStudent;
        //int currCourseID;
        //int currCourseName;
        string currLec;
        string currLecName;
        int ending = 0;
        int Begin = 0;
        //char []day = new char[50];
        string day;
        
        

        public string Connecting_String = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;MultipleActiveResultSets=true;User ID=P17;Password=Hadas@2017";
        StudentClass sd;
        public StudentClass studValue
        {
            get { return sd; }
            set { sd = value; }
        }

        public Student_Placement_to_Lec_Secretary_B()
        {
            InitializeComponent();
            Fill_Student_Box();
            //Fill_Lec_Box();
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
        public void Fill_Lec_Box()
        {
            string Query = "select * from schedualing where lecturer IS NOT NULL ;";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string Lec = myReader.GetString(5) + ":" + Convert.ToString(myReader.GetInt32(7)) + "-" + Convert.ToString(myReader.GetInt32(8)) + "Day."+ Convert.ToString(myReader.GetString(4));
                    //if there is Ovelap Hours - Do not Show Them
                    if (!OverLap(currStudent, Convert.ToInt32(myReader.GetInt32(7)), Convert.ToInt32(myReader.GetInt32(8)), Convert.ToString(myReader.GetString(4))))
                    {
                        AllCourses_Box.Items.Add(Lec);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Tests
        public bool is_listed_to_Course(int currStudent, string currLecName)
        {
            int Flag = 0;
            string Query = "select * from StudentsCourses where ID = '"+ currStudent +"' ;";
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
                    //MessageBox.Show(Convert_NameCourse_to_IDcourse(currLec).ToString());
                    if (course.Equals(Convert_NameCourse_to_IDcourse(currLecName)))
                    {
                        Flag = 1;     
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if(Flag == 1)
            {
                return true;
            }
            //MessageBox.Show("Student is Not Listed To This Course! - Please Go back and list him!!");
            Save.Hide();
            return false;
        }
        public bool is_listed_to_lec(int currStudent, string currLecName)
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
                    if (course.Equals(Convert_NameCourse_to_IDcourse(currLecName)))
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
            //MessageBox.Show("Your Student is Not Listed To This Lecture - YAY!");
            
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
    
        private void Chosing_a_Course_Click(object sender, EventArgs e)
        {

        }

        private void AllCourses_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            currLec = AllCourses_Box.SelectedItem.ToString();
            currLecName = currLec.Substring(0, currLec.IndexOf(':'));
            //MessageBox.Show("before begin count   " + currLec.Count() + "  currLec.IndexOf(':') + 1      " + currLec.IndexOf(':')+1 + "  currLec.IndexOf('-')  " + currLec.IndexOf('-'));

            string Begin_Temp = currLec.Substring(currLec.IndexOf(':') + 1, currLec.IndexOf('-') - currLec.IndexOf(':') - 1);
            Begin = Convert.ToInt32(Begin_Temp);
            string End_Temp = currLec.Substring(currLec.IndexOf('-') + 1, currLec.IndexOf('D') - currLec.IndexOf('-') - 1);
            ending = Convert.ToInt32(End_Temp);
            string Day = currLec.Substring(currLec.IndexOf('.') + 1, currLec.Count() - currLec.IndexOf('.') - 1);

            day = Day;

            // MessageBox.Show(is_listed_to_Course().ToString());

            if (is_listed_to_Course(currStudent, currLecName))
            {
                MessageBox.Show("The Student Is Listed\nTo the Course this Lecture in.");
                Save.Show();
            }
            else
            {
                MessageBox.Show("Your Student is Not Listed To This Course - Please Go Back and List Him/Her!");
            }
            if(is_listed_to_lec(currStudent, currLecName))
            {
                MessageBox.Show("The Student Is Listed\nTo this Lecture in.\n");
            }
            else
            {
                MessageBox.Show("Student is Not Listed To This Lecture - YaY!");
            }
        }


        private void Chose_Student_Click(object sender, EventArgs e)
        {
            
        }

        private void AllStudents_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            currStudent = Convert.ToInt32(AllStudents_Box.SelectedItem.ToString());
            Fill_Lec_Box();
            AllCourses_Box.Show();
           
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Upload_Lec();
            int temp = Convert.ToInt32(Convert_NameCourse_to_IDcourse(currLecName));
            MessageBox.Show("Saved " + temp.ToString());
            Upload_ProsseforBox(currStudent, temp);
           
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
   
        
        public void Upload_Lec()
        {
            //Upload to Database 
            int currCourse = Int32.Parse(Convert_NameCourse_to_IDcourse(this.currLecName));
            string Query = "insert into StudentLec_B (SerialNum,ID_Student,CourseID,Start,Ending,Day) values(@max, @currStudent,@currCourse,@Begin, @ending,@day)";
            
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            conDatabase.Open();
            SqlCommand readMaxNum = new SqlCommand("SELECT MAX(SerialNum) as Max_NUM FROM StudentLec_B", conDatabase);
            readMaxNum.CommandType = CommandType.Text;
            int max = (Int32.Parse(readMaxNum.ExecuteScalar().ToString())) + 1;
            
            SqlCommand cmd = new SqlCommand(Query, conDatabase);
          
            try
            {   
                //MessageBox.Show("Saved" );
                cmd.Parameters.Add("@max", SqlDbType.Int);
                cmd.Parameters["@max"].Value = max;
                cmd.Parameters.Add("@currStudent", SqlDbType.Int);
                cmd.Parameters["@currStudent"].Value = this.currStudent;
                cmd.Parameters.Add("@currCourse", SqlDbType.Int);
                cmd.Parameters["@currCourse"].Value = currCourse;
                cmd.Parameters.Add("@Begin", SqlDbType.Int);
                cmd.Parameters["@Begin"].Value = this.Begin;
                cmd.Parameters.Add("@ending", SqlDbType.Int);
                cmd.Parameters["@ending"].Value = this.ending;
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
        public void Upload_ProsseforBox(int currStudent, int currCourse)
        {
            //Upload to Database 

            string Query = "insert into Professor_Box (Num,CourseID,StudentID) values(@max,@currCourse, @currStudent)";

            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            conDatabase.Open();
            SqlCommand readMaxNum = new SqlCommand("SELECT MAX(Num) as Max_NUM FROM Professor_Box", conDatabase);
            readMaxNum.CommandType = CommandType.Text;
            int max = (Int32.Parse(readMaxNum.ExecuteScalar().ToString())) + 1;

            SqlCommand cmd = new SqlCommand(Query, conDatabase);
            //SqlDataReader myReader;
            try
            {

                cmd.Parameters.Add("@max", SqlDbType.Int);
                cmd.Parameters["@max"].Value = max;
                cmd.Parameters.Add("@currStudent", SqlDbType.Int);
                cmd.Parameters["@currStudent"].Value = currStudent;
                cmd.Parameters.Add("@currCourse", SqlDbType.Int);
                cmd.Parameters["@currCourse"].Value = currCourse;


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

        public bool OverLap(int temp, int Start, int End, string Day)
        {
            if (overlap_hours_Lec(temp, Start, End, Day))
            {
                return true;
            }
            if (overlap_hours_Pra(temp, Start, End, Day))
            {
                return true;
            }
            if (overlap_hours_Lab(temp, Start, End, Day))
            {
                return true;
            }
            return false;
        }
       
        public bool overlap_hours_Lec(int temp, int Start, int End, string Day)
        {
            //temp = sd.getID();
            //לזכור לצרף את השמות של ההרצאות
            string Query = "select * from StudentLec_B where ID_Student = '" + temp + "'";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    //MessageBox.Show(Convert.ToString(myReader.GetInt32(3)) + " " +Convert.ToString(myReader.GetString(5)));
                    int Start_lec = Convert.ToInt32(myReader.GetInt32(3));
                    int End_lec = Convert.ToInt32(myReader.GetInt32(4));
                    string Day_lec = Convert.ToString(myReader.GetString(5));
                    //MessageBox.Show(" ---" + Start_lec.ToString() + " " + Day_lec + " \n" + Start + " " + Day);
                    if (Start_lec <= Start && End_lec >= End && Day_lec.Equals(Day))
                    {
                        //MessageBox.Show("Ovelap");
                        //there is an ovelep - do not add to list
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //All Good - add to list
            return false;
        }

        public bool overlap_hours_Pra(int temp, int Start, int End, string Day)
        {
            string Query = "select * from StudentLec_B where ID_Student = '" + temp + "'";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    //MessageBox.Show(Convert.ToString(myReader.GetInt32(3)) + " " +Convert.ToString(myReader.GetString(5)));
                    int Start_lec = Convert.ToInt32(myReader.GetInt32(3));
                    int End_lec = Convert.ToInt32(myReader.GetInt32(4));
                    string Day_lec = Convert.ToString(myReader.GetString(5));
                    //MessageBox.Show(" ---" + Start_lec.ToString() + " " + Day_lec + " \n" + Start + " " + Day);
                    if (Start_lec <= Start && End_lec >= End && Day_lec.Equals(Day))
                    {
                        //MessageBox.Show("Ovelap");
                        //there is an ovelep - do not add to list
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //All Good - add to list
            return false;
        }

        public bool overlap_hours_Lab(int temp, int Start, int End, string Day)
        {
            string Query = "select * from StudentLec_B where ID_Student = '" + temp + "'";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    //MessageBox.Show(Convert.ToString(myReader.GetInt32(3)) + " " +Convert.ToString(myReader.GetString(5)));
                    int Start_lec = Convert.ToInt32(myReader.GetInt32(3));
                    int End_lec = Convert.ToInt32(myReader.GetInt32(4));
                    string Day_lec = Convert.ToString(myReader.GetString(5));
                    //MessageBox.Show(" ---" + Start_lec.ToString() + " " + Day_lec + " \n" + Start + " " + Day);
                    if (Start_lec <= Start && End_lec >= End && Day_lec.Equals(Day))
                    {
                        //MessageBox.Show("Ovelap");
                        //there is an ovelep - do not add to list
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //All Good - add to list
            return false;
        }
    }
}

