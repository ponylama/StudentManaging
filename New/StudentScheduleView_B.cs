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
    public partial class StudentScheduleView_B : Form
    {
        public StudentScheduleView_B()
        {
            InitializeComponent();

        }

        StudentClass SD; // student object
        public string Connecting_String = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;MultipleActiveResultSets=true;User ID=P17;Password=Hadas@2017";
        List<Course> ClassesRegisted = new List<Course>(); // list of classes that student is registed.\

        public StudentClass passValue // gets obj from student menu
        {
            get { return SD; }
            set { SD = value; }
        }

        public void show_table(int size)
        {
            DataTable CommunicationTable = new DataTable();
            CommunicationTable.Columns.Add("Course's ID", typeof(int));
            CommunicationTable.Columns.Add("Course's Name", typeof(string));
            CommunicationTable.Columns.Add("Lecture day", typeof(string));
            CommunicationTable.Columns.Add("Lecture begins", typeof(int));
            CommunicationTable.Columns.Add("Lecture ends", typeof(int));
            CommunicationTable.Columns.Add("Practice day", typeof(string));
            CommunicationTable.Columns.Add("Practice begins", typeof(int));
            CommunicationTable.Columns.Add("Practice ends", typeof(int));
            CommunicationTable.Columns.Add("Lab day", typeof(string));
            CommunicationTable.Columns.Add("Lab begins", typeof(int));
            CommunicationTable.Columns.Add("Lab ends", typeof(int));
            for (int i = 0; i < size; i++)
            {
                CommunicationTable.Rows.Add(ClassesRegisted[i].GetCourseID(),
                                            ClassesRegisted[i].getCourseName(),
                                            ClassesRegisted[i].GetLectureDay(),
                                            ClassesRegisted[i].GetLecBegin(),
                                            ClassesRegisted[i].GetLecEnd(),
                                            ClassesRegisted[i].GetPracticeDay(),
                                            ClassesRegisted[i].GetPracticeBegin(),
                                            ClassesRegisted[i].GetPracticeEnd(),
                                            ClassesRegisted[i].GetLabDay(),
                                            ClassesRegisted[i].GetLabBegin(),
                                            ClassesRegisted[i].GetLabEnd()
                                            );
            }
     
            // Notice this assignment:
            dataGridView1.DataSource = CommunicationTable;
        }

        private void StudentScheduleView_B_Load(object sender, EventArgs e)
        {
            show_table(BuildSchdule());
        }

        public int BuildSchdule()
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
                // find courses assined
                    string FindStudentCourses = "select * from StudentsCourses "; // search on CoursePlacement
                    SqlCommand cmdCourses = new SqlCommand(FindStudentCourses, connect); // check specific course
                    SqlDataReader dataReadcourse;
                    dataReadcourse = cmdCourses.ExecuteReader();

                    while (dataReadcourse.Read())
                    {
                        int id = Convert.ToInt32(dataReadcourse["ID"]); // gets id
                                                
                        if (SD.getID() == id) // check if 'this' is in course
                        {
                            int courseassigned = Convert.ToInt32(dataReadcourse["IDcourse"]);
                            CoursesForStudent.Add(courseassigned); // add course to list of courses to student
                            ClassesRegisted.Add(new Course(courseassigned));
                        }
                    }


                // find name
                string Findcoursesname = "select * from Courses "; // search on CoursePlacement
                SqlCommand cmdname = new SqlCommand(Findcoursesname, connect); // check specific course
                SqlDataReader dataReadname;
                dataReadname = cmdname.ExecuteReader();

                while (dataReadname.Read())
                {
                    int course_id = Convert.ToInt32(dataReadname["IDcourse"]); // gets id
                    bool flag = false;
                    for ( int i= 0; i< ClassesRegisted.Count; i++)
                        if (course_id == ClassesRegisted[i].GetCourseID())
                            flag = true;

                  if (flag) // check if 'this' is in course
                    {

                        string name = dataReadname["Name"].ToString();

                        for (int c = 0; c < ClassesRegisted.Count; c++)
                        {
                            if (ClassesRegisted[c].GetCourseID() == course_id)
                            {
                                ClassesRegisted[c].setCourseName(name);
                            }
                        }
                    }
                }


                // find lectures
                string FindStudentLec = "select * from StudentLec_B "; // search on CoursePlacement
                SqlCommand cmdLec = new SqlCommand(FindStudentLec, connect); // check specific course
                SqlDataReader dataReadLec;
                dataReadLec = cmdLec.ExecuteReader();

                while (dataReadLec.Read())
                {
                    int id = Convert.ToInt32(dataReadLec["ID_Student"]); // gets id

                    if (SD.getID() == id) // check if 'this' is in course
                    {

                        int start = Convert.ToInt32(dataReadLec["Start"]);
                        int end = Convert.ToInt32(dataReadLec["Ending"]);
                        string day  = dataReadLec["Day"].ToString();
                        int course_id= Convert.ToInt32(dataReadLec["CourseID"]);

                        for(int c=0; c<ClassesRegisted.Count; c++)
                        {
                            if(ClassesRegisted[c].GetCourseID() == course_id)
                            {
                                ClassesRegisted[c].SetLecBegin(start);
                                ClassesRegisted[c].SetLecEnd(end);
                                ClassesRegisted[c].SetLectureDay(day);
                            }
                        }

                    }
                }


                // find practices
                string FindStudentPrac = "select * from StudentPrac_B "; // search on StudentPrac
                SqlCommand cmdPrac = new SqlCommand(FindStudentPrac, connect); 
                SqlDataReader dataReadPrac;
                dataReadPrac = cmdPrac.ExecuteReader();

                while (dataReadPrac.Read())
                {
                    int id = Convert.ToInt32(dataReadPrac["ID_Student"]); // gets id

                    if (SD.getID() == id) // check if 'this' is in course
                    {
                        int start = Convert.ToInt32(dataReadPrac["Start"]);
                        int end = Convert.ToInt32(dataReadPrac["Ending"]);
                        int course_id = Convert.ToInt32(dataReadPrac["CourseID"]);
                        string day = dataReadPrac["Day"].ToString();
                        for (int c = 0; c < ClassesRegisted.Count; c++)
                        {
                            if (ClassesRegisted[c].GetCourseID() == course_id)
                            {
                                ClassesRegisted[c].SetPracticeBegin(start);
                                ClassesRegisted[c].SetPracticeEnd(end);
                                ClassesRegisted[c].SetPracticeDay(day);
                            }
                        }

                    }
                }//

                // find labs
                string FindStudentlab = "select * from StudentLab_B "; // search on StudentPrac
                SqlCommand cmdlab = new SqlCommand(FindStudentlab, connect);
                SqlDataReader dataReadlab;
                dataReadlab = cmdlab.ExecuteReader();

                while (dataReadlab.Read())
                {
                    int id = Convert.ToInt32(dataReadlab["ID_Student"]); // gets id

                    if (SD.getID() == id) // check if 'this' is in course
                    {
                        int start = Convert.ToInt32(dataReadlab["Start"]);
                        int end = Convert.ToInt32(dataReadlab["Ending"]);
                        int course_id = Convert.ToInt32(dataReadlab["CourseID"]);
                        string day = dataReadlab["Day"].ToString();
                        for (int c = 0; c < ClassesRegisted.Count; c++)
                        {
                            if (ClassesRegisted[c].GetCourseID() == course_id)
                            {
                                ClassesRegisted[c].SetLabBegin(start);
                                ClassesRegisted[c].SetLabEnd(end);
                                ClassesRegisted[c].SetLabDay(day);
                            }
                        }

                    }
                }//



            }

         return CoursesForStudent.Count();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}





//for (int c = 0; c < ClassesRegisted.Count; c++) // fill every object from tables
//{

//    // find lectures//
//    int i = 0; // index for list of lecturesID 
//    for (int j = 1; j != 2; j++) // run on all lec in data base
//    {
//        string FindStudentlec = "select * from Lectures_B where SerialNum = '" + j.ToString() + "'"; // search on Lectures_B classes.
//        SqlCommand cmd1 = new SqlCommand(FindStudentlec, connect); // check specific course
//        SqlDataReader dataReadLecture;
//        dataReadLecture = cmd1.ExecuteReader();
//        while (dataReadLecture.Read())
//        {
//            // run on all table and gets lecture id and time
//            String Day = dataReadLecture["Day"].ToString();
//            int CourseIDFromTable = Convert.ToInt32(dataReadLecture["CourseID"]);
//            int LectureIDfromTable = Convert.ToInt32(dataReadLecture["LectureID"]);
//            int HourBegin = Convert.ToInt32(dataReadLecture["HourBegin"]);
//            int HourEnd = Convert.ToInt32(dataReadLecture["HourEnd"]);

//            if (CoursesForStudent[i] == CourseIDFromTable)
//            {
//                //int courseIDassigned = Convert.ToInt32(dataReadLecture["CourseID"]);
//                // sets
//                ClassesRegisted[c].SetLectureID(LectureIDfromTable);
//                ClassesRegisted[c].SetLecBegin(HourBegin);
//                ClassesRegisted[c].SetLecEnd(HourEnd);
//                ClassesRegisted[c].SetLectureDay(Day);
//            }
//        }
//        i++; // inc for LecturesForStudent
//    }



//    i = 0; // index for list of PracticeID 
//    for (int j = 1; j < 2; j++) // run on all practice in data base
//    {
//        string FindStudentpractice = "select * from Practices_B where SerialNum = '" + j.ToString() + "'"; // search on Practice_B classes.
//        SqlCommand cmd_practice = new SqlCommand(FindStudentpractice, connect); // check specific practice options for student
//        SqlDataReader dataReadPractice;
//        dataReadPractice = cmd_practice.ExecuteReader();
//        while (dataReadPractice.Read())
//        {
//            // run on all table and gets lecture id and time
//            String Day = dataReadPractice["Day"].ToString();
//            int CourseIDFromTable = Convert.ToInt32(dataReadPractice["CourseID"]);
//            int PracticeIDfromTable = Convert.ToInt32(dataReadPractice["PracticeID"]);
//            int HourBegin = Convert.ToInt32(dataReadPractice["HourBegin"]);
//            int HourEnd = Convert.ToInt32(dataReadPractice["HourEnd"]);

//            if (CoursesForStudent[i] == CourseIDFromTable)
//            {
//                int courseIDassigned = Convert.ToInt32(dataReadPractice["CourseID"]);
//                // sets
//                ClassesRegisted[c].SetPracticeID(PracticeIDfromTable);
//                ClassesRegisted[c].SetPracticeBegin(HourBegin);
//                ClassesRegisted[c].SetPracticeEnd(HourEnd);
//                ClassesRegisted[c].SetPracticeDay(Day);

//            }
//        }
//        i++; // inc for PracticeForStudent
//    }

//    i = 0; // index for list of LabID 
//    for (int j = 1; j < 2; j++) // run on all practice in data base
//    {
//        string FindStudentLab = "select * from Labs_B where SerialNum = '" + j.ToString() + "'"; // search on Practice_B classes.
//        SqlCommand cmd_Lab = new SqlCommand(FindStudentLab, connect); // check specific Lab options for student
//        SqlDataReader dataReadLab;
//        dataReadLab = cmd_Lab.ExecuteReader();
//        while (dataReadLab.Read())
//        {
//            // run on all table and gets lecture id and time
//            String Day = dataReadLab["Day"].ToString();
//            int CourseIDFromTable = Convert.ToInt32(dataReadLab["CourseID"]);
//            int PracticeIDfromTable = Convert.ToInt32(dataReadLab["LabID"]);
//            int HourBegin = Convert.ToInt32(dataReadLab["HourBegin"]);
//            int HourEnd = Convert.ToInt32(dataReadLab["HourEnd"]);

//            if (CoursesForStudent[i] == CourseIDFromTable)
//            {
//                int courseIDassigned = Convert.ToInt32(dataReadLab["CourseID"]);
//                // set
//                ClassesRegisted[c].SetLabID(PracticeIDfromTable);
//                ClassesRegisted[c].SetLabBegin(HourBegin);
//                ClassesRegisted[c].SetLabEnd(HourEnd);
//                ClassesRegisted[c].SetLabDay(Day);
//            }
//        }
//        i++; // inc for LabForStudent

//        //Student_SelfPlacement a = new Student_SelfPlacement();
//        //a.passValue = ClassesCanRegister;
//        //a.Show();
//        //}


//        //print to screen options
//        //MessageBox.Show(ClassesCanRegister[0].GetLecBegin().ToString());
//    }

//}