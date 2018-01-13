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
    public partial class Student_Self_Placement : Form
    {
        
        StudentClass sd;
        public string Connecting_String = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;MultipleActiveResultSets=true;User ID=P17;Password=Hadas@2017";
        public StudentClass studValue
        {
            get { return sd; }
            set { sd = value; }
        }


        //**initialization**

        public Student_Self_Placement()
        {
            InitializeComponent();
            //Present_Courses_With_Names.Text = display;
            //Present_Courses_With_Names.Show();
            Save.Hide();
            pictureBox1.Hide();
            button1.Hide();
        }

        //All The Courses ID that the Student Is Listed To
        List<int> courses = new List<int>();

        //A List Of All Courses ID - ** WITH THRERE NAMES ** - For Database compatability with branch A
        List<Course> Courses_ID_Name = new List<Course>();

        //All The Courses That The Student Has Placed Himself With
        List<Course> regiCourses = new List<Course>();
        List<int> regicourseint = new List<int>();

        //To add courses
        Course add_course;

        //For Lable - to display Courses id + Names
        string display = "";

        //NOT SURE WHAT IS THIS FUNC IS
        private void Student_Self_Placement_Load(object sender, EventArgs e)
        {

        }

        private void Student_Self_Placement_Load_1(object sender, EventArgs e)
        {
            start();
        }

        public void start()
        {
            
            int i;
            add_course = new Course();
            Fill_Courses_Box();
            for (i = 0; i < courses.Count; i++)
            {
                Courses_Name_ID(courses[i]);
            }

            for (i = 0; i < Courses_ID_Name.Count; i++)
            {
                display += Convert.ToString(Courses_ID_Name[i].GetCourseID()) + "  " + Courses_ID_Name[i].getCourseName() + "\n";
            }
            button1.Hide();
            Courses_Box.Show();
            Lectures_Box.Hide();
            Practices_Box.Hide();
            Labs_Box.Hide();
        }

        public void Fill_Courses_Box()
        {
            int temp = sd.getID();
            //count = 0;
            //לזכור לצרף את השמות של ההרצאות
            string Query = "select * from StudentsCourses where ID = '" + temp + "'";
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
                    string ItemCourses_Box = Convert.ToString(myReader.GetInt32(2)) +"-"+ Convert_IDcourse_to_NameCourse(CourseID);

                    if (!regicourseint.Contains(CourseID))
                    {
                        if (!is_listed_to_Course(sd.getID(), CourseID))
                        {
                            Courses_Box.Items.Add(ItemCourses_Box);
                            courses.Add(CourseID);
                        }
                    }
                  
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if(Courses_Box.Items.Count == 0)
            {
                MessageBox.Show("No More Courses - Please Click Save!");
                pictureBox1.Show();
                //Exit
                button1.Show();
            }
            else
            {
                MessageBox.Show("You Have " + Courses_Box.Items.Count + " Courses Left");
                Save.Hide();
                //Exit
                button1.Hide();
            }
        }

        //Test
        public bool is_listed_to_Course(int currStudent, int currCourse)
        {
            string Query = "select * from StudentLec_B where ID_Student = '" + currStudent + "' and CourseID = '"+currCourse+"'";
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
        
        //these 2 functions are for compatability with branch A
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
        public void Courses_Name_ID(int courseid)
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
                    Course temp = new Course();
                    temp.SetCourseID(courseid);
                    temp.setCourseName(CourseName);
                    Courses_ID_Name.Add(temp);
                    //Couses_Names.Items.Add(CourseName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*לבדיקת שעות חופפות נעבור על כל מאגר בנפרד - על ההרצאות, תרגולים ומעבדות 
         * ונבדוק האם הסטודנט המדובר משובץ לשיעור חופף
        */

        public bool overlap_hours_Lec(int temp, int Start,int End, string Day)
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
                    string Day_lec = Convert.ToString(myReader["Day"].ToString());
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

        public bool overlap_hours_Pra(int temp,int Start, int End, string Day)
        {  
            string Query = "select * from StudentPrac_B where ID_Student = '" + temp + "'";
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

        public bool overlap_hours_Lab(int temp, int Start,int End, string Day)
        {         
            string Query = "select * from StudentLab_B where ID_Student = '" + temp + "'";
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
        private void Courses_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Courses_Lable.Show();
            //Filling the ****LECTURE BOX*****
            int curItem = Convert.ToInt32(Courses_Box.SelectedItem.ToString().Substring(0, Courses_Box.SelectedItem.ToString().IndexOf('-')));
            //if course is pre condition 
            check_pre_courses(curItem);
           

            //MessageBox.Show(curItem.ToString());
            //Uplode data
            add_course.SetCourseID(curItem);
            int CourseToRemove = curItem;
            Lectures_Box.Items.Clear();
            string course_name = "";
            for (int i = 0; i < Courses_ID_Name.Count; i++)
            {
                if (curItem == Courses_ID_Name[i].GetCourseID())
                {
                    course_name = Courses_ID_Name[i].getCourseName();
                }
            }

            //Uplode data
            add_course.setCourseName(course_name);

            string LecID;
            string Query = "select * from schedualing where courseName = '" + course_name + "' and lecturer IS NOT NULL";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    LecID = Convert.ToString(myReader.GetInt32(7)) + "-" + Convert.ToString(myReader.GetInt32(8)+ "Day." + Convert.ToString(myReader["day"].ToString()));
                    //MessageBox.Show(Convert.ToString(myReader.GetString(4)));
                    
                    if (!overlap_hours_Lec(sd.getID(), Convert.ToInt32(myReader.GetInt32(7)), Convert.ToInt32(myReader.GetInt32(8)), Convert.ToString(myReader.GetString(4))))
                    {
                        Lectures_Box.Items.Add(LecID);
                    }   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Lectures_Box.Show();
        }


        //Precondition
        public bool check_pre_courses(int currCourseID)
        {
            //אם לקורס יש קדם-קורס אז שלא יכליל אותו - אלא אם כן יש לו את הקורס קדם בשיבוצים
            string Query = "select * from Courses where IDcourse = '" + currCourseID + "'";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;
            int Flag = 0;
            string preCon;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    preCon = myReader["PreCondition"].ToString();
                    if (!is_listed_to_Course(sd.getID(), Convert_NameCourse_to_IDcourse(preCon))&& preCon != "")
                    {
                        MessageBox.Show("Pay Attention - PreCondition -> " + preCon);
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
            return false;
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



        //EXIT BOTTUN - SORRY FORGOT TO CHANGE NAME


        private void Lectures_Box_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Filling the ****PRACTICE BOX*****
            Practices_Box.Items.Clear();
            string curItem_L = Lectures_Box.SelectedItem.ToString();
            //MessageBox.Show(Convert.ToString(curItem_L.Substring(0, curItem_L.IndexOf('-'))));
            //MessageBox.Show(Convert.ToString(curItem_L.Substring((curItem_L.IndexOf('-') + 1), curItem_L.IndexOf('D') - curItem_L.IndexOf('-') - 1)));
            //MessageBox.Show(Convert.ToString(Convert.ToString(curItem_L.Substring(curItem_L.IndexOf('.') + 1, curItem_L.Count() - curItem_L.IndexOf('.') - 1))));

            //Uplode data - Lec

            string temp_End = curItem_L.Substring((curItem_L.IndexOf('-') + 1), curItem_L.IndexOf('D') - curItem_L.IndexOf('-') - 1);
            int temp_end = Convert.ToInt32(temp_End);
            add_course.SetLecBegin(Convert.ToInt32(curItem_L.Substring(0, curItem_L.IndexOf('-'))));
            add_course.SetLecEnd(temp_end);
            add_course.SetLectureDay(Convert.ToString(curItem_L.Substring(curItem_L.IndexOf('.') + 1, curItem_L.Count() - curItem_L.IndexOf('.') - 1)));
            
            //MessageBox.Show(add_course.GetLecBegin().ToString()+"\n\n" + add_course.GetLecEnd() + "\n\n" + add_course.GetLectureDay());

            //CurItem is for uploading data
            int curItem = Convert.ToInt32(Courses_Box.SelectedItem.ToString().Substring(0, Courses_Box.SelectedItem.ToString().IndexOf('-')));
            string course_name = "";
            for (int i = 0; i < Courses_ID_Name.Count; i++)
            {
                if (curItem == Courses_ID_Name[i].GetCourseID())
                {
                    course_name = Courses_ID_Name[i].getCourseName();
                }
            }

            string Query = "select * from schedualing where courseName = '" + course_name + "' and teachingAssitant IS NOT NULL ";
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string PracID = Convert.ToString(myReader.GetInt32(7)) + "-" + Convert.ToString(myReader.GetInt32(8) + "Day." + Convert.ToString(myReader["day"].ToString()));

                    if (!overlap_hours_Pra(sd.getID(), Convert.ToInt32(myReader.GetInt32(7)), Convert.ToInt32(myReader.GetInt32(8)), Convert.ToString(myReader.GetString(4))))
                    {
                        Practices_Box.Items.Add(PracID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (Practices_Box.Items.Count == 0)
            {
                MessageBox.Show("No Practices Available");
                Labs_Box.Show();
            }
            else
            {
                Practices_Box.Show();
            }
        }


        private void Practices_Box_SelectedIndexChanged(object sender, EventArgs e)
        {

            //FILLING ****LABS BOX****
            //if there is no practices:
            if (Practices_Box.Items.Count == 0)
            {
              
                Practices_Box.Hide();
                Labs_Box.Items.Clear();
                int curItem = Convert.ToInt32(Courses_Box.SelectedItem.ToString());

                string Query = "select * from Labs_B where CourseID = '" + curItem + "' ";
                SqlConnection conDatabase = new SqlConnection(Connecting_String);
                SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
                SqlDataReader myReader;
                try
                {
                    conDatabase.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    while (myReader.Read())
                    {
                        string Lab = Convert.ToString(myReader.GetInt32(2)) + " - " + Convert.ToString(myReader.GetInt32(3));

                        if (!overlap_hours_Lab(sd.getID(), Convert.ToInt32(myReader.GetInt32(7)), Convert.ToInt32(myReader.GetInt32(8)), Convert.ToString(myReader.GetString(4))))
                        {
                            Labs_Box.Items.Add(Lab);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Labs_Box.Show();
            }
            else
            {
                //if there is practises

                //Uplode data - practice
                Labs_Box.Items.Clear();
                string curItem_P = Practices_Box.SelectedItem.ToString();

                //Uplode data - Prac
                add_course.SetPracticeBegin(Convert.ToInt32(curItem_P.Substring(0, curItem_P.IndexOf('-'))));
                string temp_End = curItem_P.Substring((curItem_P.IndexOf('-') + 1), curItem_P.IndexOf('D') - curItem_P.IndexOf('-') - 1);
                int temp_end = Convert.ToInt32(temp_End);

                add_course.SetPracticeEnd(temp_end);
                add_course.SetPracticeDay(curItem_P.Substring(curItem_P.IndexOf('.') + 1, curItem_P.Count() - curItem_P.IndexOf('.') - 1));


                int curItem = Convert.ToInt32(Courses_Box.SelectedItem.ToString().Substring(0, Courses_Box.SelectedItem.ToString().IndexOf('-')));
                string Query = "select * from Labs_B where CourseID = '" + curItem + "' ";
                SqlConnection conDatabase = new SqlConnection(Connecting_String);
                SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
                SqlDataReader myReader;
                try
                {
                    conDatabase.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    while (myReader.Read())
                    {
                        string Lab = Convert.ToString(myReader.GetInt32(2)) + "-" + Convert.ToString(myReader.GetInt32(3) + "Day." + Convert.ToString(myReader["day"].ToString()));
                        Labs_Box.Items.Add(Lab);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (Labs_Box.Items.Count == 0)
                {
                    Labs_Box.Hide();
                    MessageBox.Show("No Labs Available");
                    POPUP_Messege();         
                }
                else
                {
                    Labs_Box.Show();
                }
            }
        }

        private void Labs_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Upload Data
            string curItem_Lab = Labs_Box.SelectedItem.ToString();

            //Uplode data - LAB
           
            add_course.SetLabBegin(Convert.ToInt32(curItem_Lab.Substring(0, curItem_Lab.IndexOf('-'))));
            string temp_End = curItem_Lab.Substring((curItem_Lab.IndexOf('-') + 1), curItem_Lab.IndexOf('D') - curItem_Lab.IndexOf('-') - 1);
            int temp_end = Convert.ToInt32(temp_End);
            add_course.SetLabEnd(temp_end);
            add_course.SetLabDay(curItem_Lab.Substring(curItem_Lab.IndexOf('.') + 1, curItem_Lab.Count() - curItem_Lab.IndexOf('.') - 1));

            POPUP_Messege();
        }
       
        public void POPUP_Messege()
        {
            // Put Out Messege that there are more courses or no more courses - need to be fixed!!!!!
            string display_placement = "";

            regiCourses.Add(add_course);
            regicourseint.Add(add_course.GetCourseID());
            
            for (int i = 0; i < regiCourses.Count; i++)
            {
                display_placement =  Convert.ToString(regiCourses[i].GetCourseID()) + "\n  " +
                    "Course Name: " +
                    Convert.ToString(regiCourses[i].getCourseName()) + "\n  " +
                    "Lecture: " +
                     Convert.ToString(regiCourses[i].GetLecBegin()) + " - " +
                      Convert.ToString(regiCourses[i].GetLecEnd()) + "\n  " +
                      Convert.ToString(regiCourses[i].GetLectureDay()) + "\n  " +
                      "Practice:" +
                       Convert.ToString(regiCourses[i].GetPracticeBegin()) + " - " +
                        Convert.ToString(regiCourses[i].GetPracticeEnd()) + "\n  " +
                         Convert.ToString(regiCourses[i].GetPracticeDay()) + "\n  " +
                        "Lab: " +
                         Convert.ToString(regiCourses[i].GetLabBegin()) + " - " +
                          Convert.ToString(regiCourses[i].GetLabEnd()) + "\n  " +
                           Convert.ToString(regiCourses[i].GetLabDay()) + "\n  "
                          + "Placement Succesfull";

                /*
                display_placement = Convert.ToString(regiCourses[i].GetCourseID()) + "\n" + 
                    "Course Name: " +
                    Convert.ToString(regiCourses[i].getCourseName()) + "\n" +
                    "Lecture: " +
                     Convert.ToString(regiCourses[i].GetLecBegin()) + " - " +
                      Convert.ToString(regiCourses[i].GetLecEnd()) + "\n" +
                      "Practice:"+
                       Convert.ToString(regiCourses[i].GetPracticeBegin()) + " - " +
                        Convert.ToString(regiCourses[i].GetPracticeEnd()) + "\n" +
                        "Lab: "+
                         Convert.ToString(regiCourses[i].GetLabBegin()) + " - " +
                          Convert.ToString(regiCourses[i].GetLabEnd()) + "\n" 
                          + "Placement Succesfull";
                          */
                MessageBox.Show(display_placement);
                //Regi_Courses.Items.Add(display_placement);
                
            }

            Lectures_Box.Hide();
            Practices_Box.Hide();
            Labs_Box.Hide();
            Courses_Box.Hide();
            Courses_Box.Items.Clear();
            start();
        }

        private void Present_Courses_With_Names_Click(object sender, EventArgs e)
        {
            button1.Show();
            //Present_Courses_With_Names.Show();
        }

        public void Print_regiCourse()
        {
            string display1;
            Regi_Courses.Items.Clear();
            for (int i = 0; i < regiCourses.Count; i++)
            {
                display1 = i+"\n  " +Convert.ToString(regiCourses[i].GetCourseID()) + "\n  " +
                    "Course Name: " +
                    Convert.ToString(regiCourses[i].getCourseName()) + "\n  " +
                    "Lecture: " +
                     Convert.ToString(regiCourses[i].GetLecBegin()) + " - " +
                      Convert.ToString(regiCourses[i].GetLecEnd()) + "\n  " +
                      Convert.ToString(regiCourses[i].GetLectureDay()) + "\n  "+
                      "Practice:" +
                       Convert.ToString(regiCourses[i].GetPracticeBegin()) + " - " +
                        Convert.ToString(regiCourses[i].GetPracticeEnd()) + "\n  " +
                         Convert.ToString(regiCourses[i].GetPracticeDay()) + "\n  " +
                        "Lab: " +
                         Convert.ToString(regiCourses[i].GetLabBegin()) + " - " +
                          Convert.ToString(regiCourses[i].GetLabEnd()) + "\n  " + 
                           Convert.ToString(regiCourses[i].GetLabDay()) + "\n  " 
                          + "Placement Succesfull";

                Regi_Courses.Items.Add(display1);
            }
        }

        private void Regi_Courses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Present_regiCourse_Click(object sender, EventArgs e)
        {
            Print_regiCourse();
        }

        private void Couses_Names_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        //Upload All Data To DataBase
        public void Upload_Data()
        {
            //Upload All Data At Once! - Clicking on Save Button
            for(int i = 0; i<regiCourses.Count; i++)
            {
                Upload_ProsseforBox(sd.getID(), regiCourses[i].GetCourseID());
                Upload_Lec(sd.getID(), regiCourses[i].GetCourseID(),regiCourses[i].GetLecBegin(), regiCourses[i].GetLecEnd(), regiCourses[i].GetLectureDay());
                if(regiCourses[i].GetPracticeBegin() != 0)
                {
                    Upload_Prac(sd.getID(), regiCourses[i].GetCourseID(), regiCourses[i].GetPracticeBegin(), regiCourses[i].GetPracticeEnd(), regiCourses[i].GetPracticeDay());
                }
                if(regiCourses[i].GetLabBegin() != 0)
                {
                    Upload_Lab(sd.getID(), regiCourses[i].GetCourseID(), regiCourses[i].GetLabBegin(), regiCourses[i].GetLabEnd(), regiCourses[i].GetLabDay());
                }
            }
        }

       
        //Upload to StudentLec_B
        public void Upload_Lec(int currStudent,int currCourse, int Begin, int ending, string Day)
        {
            //Upload to Database 
            
            string Query = "insert into StudentLec_B (SerialNum,ID_Student,CourseID,Start,Ending,Day) values(@max, @currStudent,@currCourse,@Begin, @ending,@day)";
      
            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            conDatabase.Open();
            SqlCommand readMaxNum = new SqlCommand("SELECT MAX(SerialNum) as Max_NUM FROM StudentLec_B", conDatabase);
            readMaxNum.CommandType = CommandType.Text;
            int max = (Int32.Parse(readMaxNum.ExecuteScalar().ToString())) + 1;

            SqlCommand cmd = new SqlCommand(Query, conDatabase);
            //SqlDataReader myReader;
            try
            {
                //MessageBox.Show("Saved" + Day);
                cmd.Parameters.Add("@max", SqlDbType.Int);
                cmd.Parameters["@max"].Value = max;
                cmd.Parameters.Add("@currStudent", SqlDbType.Int);
                cmd.Parameters["@currStudent"].Value = currStudent;
                cmd.Parameters.Add("@currCourse", SqlDbType.Int);
                cmd.Parameters["@currCourse"].Value = currCourse;
                cmd.Parameters.Add("@Begin", SqlDbType.Int);
                cmd.Parameters["@Begin"].Value = Begin;
                cmd.Parameters.Add("@ending", SqlDbType.Int);
                cmd.Parameters["@ending"].Value = ending;
                cmd.Parameters.Add("@day", SqlDbType.VarChar);
                cmd.Parameters["@day"].Value = Day;

                cmd.ExecuteNonQuery();
                conDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Upload to StudentLab_B

        public void Upload_Lab(int currStudent, int currCourse, int Begin, int ending, string Day)
        {
            //Upload to Database 

            string Query = "insert into StudentLab_B (SerialNum,ID_Student,CourseID,Start,Ending,Day) values(@max, @currStudent,@currCourse,@Begin, @ending,@day)";

            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            conDatabase.Open();
            SqlCommand readMaxNum = new SqlCommand("SELECT MAX(SerialNum) as Max_NUM FROM StudentLab_B", conDatabase);
            readMaxNum.CommandType = CommandType.Text;
            int max = (Int32.Parse(readMaxNum.ExecuteScalar().ToString())) + 1;

            SqlCommand cmd = new SqlCommand(Query, conDatabase);
            //SqlDataReader myReader;
            try
            {
                //MessageBox.Show("Saved" + Day);
                cmd.Parameters.Add("@max", SqlDbType.Int);
                cmd.Parameters["@max"].Value = max;
                cmd.Parameters.Add("@currStudent", SqlDbType.Int);
                cmd.Parameters["@currStudent"].Value = currStudent;
                cmd.Parameters.Add("@currCourse", SqlDbType.Int);
                cmd.Parameters["@currCourse"].Value = currCourse;
                cmd.Parameters.Add("@Begin", SqlDbType.Int);
                cmd.Parameters["@Begin"].Value = Begin;
                cmd.Parameters.Add("@ending", SqlDbType.Int);
                cmd.Parameters["@ending"].Value = ending;
                cmd.Parameters.Add("@day", SqlDbType.VarChar);
                cmd.Parameters["@day"].Value = Day;

                cmd.ExecuteNonQuery();
                conDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Upload to StudentPrac_B
        public void Upload_Prac(int currStudent, int currCourse, int Begin, int ending, string Day)
        {
            //Upload to Database 

            string Query = "insert into StudentPrac_B (SerialNum,ID_Student,CourseID,Start,Ending,Day) values(@max, @currStudent,@currCourse,@Begin, @ending,@day)";

            SqlConnection conDatabase = new SqlConnection(Connecting_String);
            conDatabase.Open();
            SqlCommand readMaxNum = new SqlCommand("SELECT MAX(SerialNum) as Max_NUM FROM StudentPrac_B", conDatabase);
            readMaxNum.CommandType = CommandType.Text;
            int max = (Int32.Parse(readMaxNum.ExecuteScalar().ToString())) + 1;

            SqlCommand cmd = new SqlCommand(Query, conDatabase);
            //SqlDataReader myReader;
            try
            {
                //MessageBox.Show("Saved" + Day);
                cmd.Parameters.Add("@max", SqlDbType.Int);
                cmd.Parameters["@max"].Value = max;
                cmd.Parameters.Add("@currStudent", SqlDbType.Int);
                cmd.Parameters["@currStudent"].Value = currStudent;
                cmd.Parameters.Add("@currCourse", SqlDbType.Int);
                cmd.Parameters["@currCourse"].Value = currCourse;
                cmd.Parameters.Add("@Begin", SqlDbType.Int);
                cmd.Parameters["@Begin"].Value = Begin;
                cmd.Parameters.Add("@ending", SqlDbType.Int);
                cmd.Parameters["@ending"].Value = ending;
                cmd.Parameters.Add("@day", SqlDbType.VarChar);
                cmd.Parameters["@day"].Value = Day;

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

        private void Back_To_Main_Click(object sender, EventArgs e)
        {
            Student_Menu_B.currStudentForm.Show();
            this.Hide(); 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Save_Click_1(object sender, EventArgs e)
        {
            Upload_Data();
            MessageBox.Show("Saved");
        }
    }

}



