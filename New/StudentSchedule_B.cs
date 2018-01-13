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
    public partial class StudentSchedule_B : Form
    {
        StudentClass SD; // student object
        Course a = new Course();
        List<Course> ClassesCanRegister = new List<Course>(); // create list of classes that student need to register.

        public StudentSchedule_B()
        {
            InitializeComponent();
        }
        public string Connecting_String = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;MultipleActiveResultSets=true;User ID=P17;Password=Hadas@2017";

        public string classes_show(List<Course> CP)
        {
            int len = CP.Count();
            String ToPrint = SD.getFirstName() + ", your options to register are:\n\n    Course ID | Type | Start at- | Finish at- |  " + len.ToString() + " \n";

            for (int i = 0; i < len; i++)
            {
                if (CP[i].GetLectureID() != 0)
                    ToPrint += i + 1 + " )   " + CP[i].GetCourseID() + "     | " + " Lec " + " |    " + CP[i].GetLecBegin() + "       |      " + CP[i].GetLecEnd() + "    | \n";
                if (CP[i].GetPracticeID() != 0)
                    ToPrint += i + 1 + " )   " + CP[i].GetCourseID() + "     | " + " Pra  " + " |    " + CP[i].GetPracticeBegin() + "       |      " + CP[i].GetPracticeEnd() + "    | \n";
                if (CP[i].GetLabID() != 0)
                    ToPrint += i + 1 + " )   " + CP[i].GetCourseID() + "     | " + " Lab " + " |    " + CP[i].GetLabBegin() + "       |      " + CP[i].GetLabEnd() + "    | \n";
            }

            return ToPrint;
        }



        public StudentClass passValue // gets obj from student menu
        {
            get { return SD; }
            set { SD = value; }
        }

        public void StudentSchedule_B_Load(object sender, EventArgs e)
        {
            List<int> CoursesForStudent = new List<int>(); // create list of courses that student is signed to
            
            SqlConnection connect = new SqlConnection(Connecting_String);
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                // output the error to see what's going on
                MessageBox.Show(ex.Message);
            }
            if (connect.State == System.Data.ConnectionState.Open)
            {
                for (int course = 1205; course <= 1206; course++) // run on all courses in data base
                {
                    //find courses of student//
                    string FindStudentCourses = "select * from CoursePlacement where CourseID = '" + course.ToString() + "'"; // search on CoursePlacement
                    
                    SqlCommand cmd = new SqlCommand(FindStudentCourses, connect); // check specific course
                    SqlDataReader dataReadcourse;
                    dataReadcourse = cmd.ExecuteReader();
                    while (dataReadcourse.Read())
                    {
                        int id1 = Convert.ToInt32(dataReadcourse["StudentID1"]);
                        int id2 = Convert.ToInt32(dataReadcourse["StudentID2"]);
                        int id3 = Convert.ToInt32(dataReadcourse["StudentID3"]);
                        if (SD.getID() == id1 || SD.getID() == id2 || SD.getID() == id3)
                        {
                            int courseassigned = Convert.ToInt32(dataReadcourse["CourseID"]);
                            CoursesForStudent.Add(courseassigned); // add course to list of student
                            //MessageBox.Show("found course for student to register");
                        }
                    }

                }
                // find lectures//
                int i = 0; // index for list of lecturesID 
                for (int j = 1; j < 2; j++) // run on all courses in data base
                {
                    string FindStudentlec = "select * from Lectures_B where SerialNum = '" + j.ToString() + "'"; // search on Lectures_B classes.
                    SqlCommand cmd1 = new SqlCommand(FindStudentlec, connect); // check specific course
                    SqlDataReader dataReadLecture;
                    dataReadLecture = cmd1.ExecuteReader();
                    while (dataReadLecture.Read())
                    {
                        // run on all table and gets lecture id and time
                        String Day = dataReadLecture["Day"].ToString();
                        int CourseIDFromTable = Convert.ToInt32(dataReadLecture["CourseID"]);
                        int LectureIDfromTable = Convert.ToInt32(dataReadLecture["LectureID"]);
                        int HourBegin = Convert.ToInt32(dataReadLecture["HourBegin"]);
                        int HourEnd = Convert.ToInt32(dataReadLecture["HourEnd"]);

                        if (CoursesForStudent[i] == CourseIDFromTable)
                        {
                            
                            int courseIDassigned = Convert.ToInt32(dataReadLecture["CourseID"]);
                            Course temp = new Course();
                            // set on temp
                            temp.SetCourseID(CourseIDFromTable);
                            temp.SetLectureID(LectureIDfromTable);
                            temp.SetLecBegin(HourBegin);
                            temp.SetLecEnd(HourEnd);
                            temp.SetLectureDay(Day);
                            //add
                            ClassesCanRegister.Add(temp); // add lec details to list of student
                        }
                    }
                    i++; // inc for LecturesForStudent
                }


                i = 0; // index for list of PracticeID 
                for (int j = 1; j < 2; j++) // run on all practice in data base
                {
                    string FindStudentpractice = "select * from Practices_B where SerialNum = '" + j.ToString() + "'"; // search on Practice_B classes.
                    SqlCommand cmd_practice = new SqlCommand(FindStudentpractice, connect); // check specific practice options for student
                    SqlDataReader dataReadPractice;
                    dataReadPractice = cmd_practice.ExecuteReader();
                    while (dataReadPractice.Read())
                    {
                        // run on all table and gets lecture id and time
                        String Day = dataReadPractice["Day"].ToString();
                        int CourseIDFromTable = Convert.ToInt32(dataReadPractice["CourseID"]);
                        int PracticeIDfromTable = Convert.ToInt32(dataReadPractice["PracticeID"]);
                        int HourBegin = Convert.ToInt32(dataReadPractice["HourBegin"]);
                        int HourEnd = Convert.ToInt32(dataReadPractice["HourEnd"]);

                        if (CoursesForStudent[i] == CourseIDFromTable)
                        {
                            int courseIDassigned = Convert.ToInt32(dataReadPractice["CourseID"]);
                            Course temp = new Course();
                            // set on temp
                            temp.SetCourseID(CourseIDFromTable);
                            temp.SetPracticeID(PracticeIDfromTable);
                            temp.SetPracticeBegin(HourBegin);
                            temp.SetPracticeEnd(HourEnd);
                            temp.SetPracticeDay(Day);
                            //add
                            ClassesCanRegister.Add(temp); // add lec details to list of student
                        }
                    }
                    i++; // inc for PracticeForStudent
                }


                i = 0; // index for list of LabID 
                for (int j = 1; j < 2; j++) // run on all practice in data base
                {
                    string FindStudentLab = "select * from Labs_B where SerialNum = '" + j.ToString() + "'"; // search on Practice_B classes.
                    SqlCommand cmd_Lab = new SqlCommand(FindStudentLab, connect); // check specific Lab options for student
                    SqlDataReader dataReadLab;
                    dataReadLab = cmd_Lab.ExecuteReader();
                    while (dataReadLab.Read())
                    {
                        // run on all table and gets lecture id and time
                        String Day = dataReadLab["Day"].ToString();
                        int CourseIDFromTable = Convert.ToInt32(dataReadLab["CourseID"]);
                        int PracticeIDfromTable = Convert.ToInt32(dataReadLab["LabID"]);
                        int HourBegin = Convert.ToInt32(dataReadLab["HourBegin"]);
                        int HourEnd = Convert.ToInt32(dataReadLab["HourEnd"]);

                        if (CoursesForStudent[i] == CourseIDFromTable)
                        {
                            int courseIDassigned = Convert.ToInt32(dataReadLab["CourseID"]);
                            Course temp = new Course();
                            // set on temp
                            temp.SetCourseID(CourseIDFromTable);
                            temp.SetLabID(PracticeIDfromTable);
                            temp.SetLabBegin(HourBegin);
                            temp.SetLabEnd(HourEnd);
                            temp.SetLabDay(Day);
                            //add
                            ClassesCanRegister.Add(temp); // add lec details to list of student
                        }
                    }
                    i++; // inc for LabForStudent

                    //Student_SelfPlacement a = new Student_SelfPlacement();
                    //a.passValue = ClassesCanRegister;
                    //a.Show();
                }


                //print to screen options
                //MessageBox.Show(ClassesCanRegister[0].GetLecBegin().ToString());


            }


            label1.Text = classes_show(ClassesCanRegister);
        }//end load



        public void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Student_Self_Placement SSP = new Student_Self_Placement();
            //SSP.passValue = ClassesCanRegister;
            //SSP.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
