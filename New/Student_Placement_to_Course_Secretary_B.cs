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

    //DONE
    public partial class Student_Placement_to_Course_Secretary_B : Form
    {

        public string Connecting_String = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;MultipleActiveResultSets=true;User ID=P17;Password=Hadas@2017";
        StudentClass sd;
        //public string Connecting_String = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;MultipleActiveResultSets=true;User ID=P17;Password=Hadas@2017";
        public StudentClass studValue
        {
            get { return sd; }
            set { sd = value; }
        }


        public Student_Placement_to_Course_Secretary_B()
        {
            InitializeComponent();

            Fill_Student_Box();
            AllCourses_Box.Hide();
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
            string Query = "select * from Courses  ;";
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
                    string ItemInList = CourseID.ToString() + "-" + Convert.ToString(Courses_Name_ID(CourseID));
                    if (is_listed_to_Course(currStudent, CourseID) == false)
                    {
                      
                            //if (check_pre_courses(CourseID))
                            {
                                AllCourses_Box.Items.Add(ItemInList);
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Test
        public string Courses_Name_ID(int courseid)
        {
            //get course name
            string Query = "select * from Courses where IDcourse = '" + courseid + "'";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string CourseName = myReader.GetString(1);
                    return CourseName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }

        public int Convert_NameCourse_to_IDcourse(string NameCourse)
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
                    return myReader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        public bool is_listed_to_Course(int currStudent, int CourseID)
        {
            int Flag = 0;
            string Query = "select * from StudentsCourses where ID = '" + currStudent + "' ;";
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
                    if (course.Equals(CourseID.ToString()))
                    {
                        Flag = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (Flag == 1)
            {
                return true;
            }
            //MessageBox.Show("Student is Not Listed To This Course! - Please Go back and list him!!");
            Save.Hide();
            return false;

            /*
            int num = 0;
            string Query = "select * from StudentsCourses where ID = '" + currStudent + "' and IDcourse = '" +CourseID+"'";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    num= Convert.ToInt32(myReader["Num"]);
                    string course = Convert.ToString(myReader.GetInt32(2));
                    //MessageBox.Show(Convert_NameCourse_to_IDcourse(currLec).ToString());
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (num == 0)
                return false;
            return true;
            */
        }
    
     
        
        //בדיקות - האם הקורס הינו במחלקה? יוצגו קורסים רק אשר רלוונטים לסטודנט
        public bool is_Course_in_Department_of_student(int CourseID, int currStudentDep)
        {
            //int idStudentdep = get_department_id(currStudentDep);
            string Query = "select * from CoursesDepartment where IDcourse = '" + CourseID + "' and IDdepartment = '" + currStudentDep + "'";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;
            
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        
        public int get_department_id(string Namedepartment)
        {
            string Query = "select * from Departments where Name = '" + Namedepartment + "' ";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    return myReader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
        
        public string get_student_department(int currStudent)
        {
            string Query = "select * from Users where ID = '" + currStudent + "'";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    return myReader["Departments"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }

        public bool check_pre_courses(int currCourseID)
        {
            //אם לקורס יש קדם-קורס אז שלא יכליל אותו - אלא אם כן יש לו את הקורס קדם בשיבוצים
            string Query = "select * from Courses where IDcourse = '" + currCourseID + "'";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;
            int Flag = 0;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string preCon = myReader["PreCondition"].ToString();
                    if (is_listed_to_Course(currStudent,Convert_NameCourse_to_IDcourse(preCon)))
                    {
                        //MessageBox.Show("is listed to " + preCon);
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
            return false;
        }

        private void Chosing_a_Course_Click(object sender, EventArgs e)
        {

        }

        private void AllCourses_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currSelectionCourse = AllCourses_Box.SelectedItem.ToString();
            currCourse = Convert.ToInt32(currSelectionCourse.Substring(0, currSelectionCourse.IndexOf('-')));

            //MessageBox.Show(currCourse.ToString());

        }

        private void Student_Placement_to_Course_Secretary_B_Load(object sender, EventArgs e)
        {

        }
       
        private void Save_Click(object sender, EventArgs e)
        {
            Upload_Course();
        }

        private void AllStudents_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            currStudent = Convert.ToInt32(AllStudents_Box.SelectedItem.ToString());
            Fill_Course_Box();
            AllCourses_Box.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void Upload_Course()
        {
            //Upload to Database 
            string Query = "insert into StudentsCourses (Num,ID,IDcourse) values(@max, @currStudent,@currCourse)";

            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            conDatabase.Open();
            SqlCommand readMaxNum = new SqlCommand("SELECT MAX(Num) as Max_NUM FROM StudentsCourses", conDatabase);
            readMaxNum.CommandType = CommandType.Text;
            int max = (Int32.Parse(readMaxNum.ExecuteScalar().ToString())) + 1;

            SqlCommand cmd = new SqlCommand(Query, conDatabase);
           
            try
            {           
                cmd.Parameters.Add("@max", SqlDbType.Int);
                cmd.Parameters["@max"].Value = max;
                cmd.Parameters.Add("@currStudent", SqlDbType.Int);
                cmd.Parameters["@currStudent"].Value = currStudent;
                cmd.Parameters.Add("@currCourse", SqlDbType.Int);
                cmd.Parameters["@currCourse"].Value = currCourse;
          
                MessageBox.Show("Saved");
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
            Secretary_Menu_B S = new Secretary_Menu_B();
            S.Show();
    
        }
    }
    
}
