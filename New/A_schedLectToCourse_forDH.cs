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
    public partial class A_schedLectToCourse_forDH : Form
    {
        public static A_schedLectToCourse_forDH currentA_schedLectToCourse_forDH;
        HeadDepartment dep;

        public HeadDepartment passValue
        {
            get { return dep; }
            set { dep = value; }
        }

        public A_schedLectToCourse_forDH(HeadDepartment hd)
        {
            InitializeComponent();
           // this.dep = new HeadDepartment();
            this.dep = hd;
        }

        private void button_BACK_Click(object sender, EventArgs e)
        {
            this.Hide();
            //A_DHschedualing sched = new A_DHschedualing();
            A_DHschedualing.currentA_DHschedualing.Show();
        }

        private void button_SUBMIT_Click(object sender, EventArgs e)
        {
            // new changes - 10/06/17
            SqlCommand cmd;
            SqlConnection cn;
            SqlDataReader dr;

            bool courseExist = false;
            bool userExist = false;
            bool userIsLecturer = false;
            bool sameDept = false;
            bool lectSignedForCourse = false;
            bool belongToDept = false;


            //check if any field is empty
            if (String.IsNullOrEmpty(textBox_courseID.Text) || String.IsNullOrEmpty(textBox_lectID.Text))
            {
                MessageBox.Show("All fields REQIRED! please try again");

                textBox_courseID.Clear();
                textBox_lectID.Clear();
                this.Hide();
                this.Close();

                //A_schedLectToCourse_forDH sched = new A_schedLectToCourse_forDH();
                A_schedLectToCourse_forDH.currentA_schedLectToCourse_forDH.Show(); 
            }

            else
            {
                cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                cn.Open();

                cmd = new SqlCommand("SELECT Courses.IDcourse,Users.ID,Users.Type FROM Courses,Users ", cn);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["IDcourse"].ToString() == textBox_courseID.Text)
                        courseExist = true;
                    if (dr["ID"].ToString() == textBox_lectID.Text)
                    {
                        userExist = true;
                        if (dr["Type"].ToString() == "2")//check the user is lecturer
                        {
                            userIsLecturer = true;

                        }
                    }

                }
                dr.Close();
                cn.Close();


                cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                cn.Open();

                cmd = new SqlCommand("SELECT * FROM StaffCourses ", cn);


                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["ID"].ToString() == textBox_lectID.Text)
                    {
                        if (dr["IDcourse"].ToString() == textBox_courseID.Text)
                        {
                            lectSignedForCourse = true;
                        }
                    }

                }
                dr.Close();
                cn.Close();

                if (courseExist && userExist && userIsLecturer && !lectSignedForCourse)
                {
                    //need to attach course to lecturer - in case its the same department

                    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                    cn.Open();

                    int index;
                    int nextIndex = 0;

                    cmd = new SqlCommand("SELECT MAX(Num) FROM StaffCourses", cn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        index = Int32.Parse(dr[0].ToString()) + 1;
                        nextIndex = index; //in order to get index out of the red() loop

                    }
                    dr.Close();
                    cn.Close();


                    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM UsersDepartment", cn);
                    dr = cmd.ExecuteReader();

                    List<string> lectDept = new List<string>();
                    while (dr.Read())
                    {
                        if (dr["ID"].ToString() == textBox_lectID.Text)
                        {
                            lectDept.Add(dr["IDdepartment"].ToString());
                            belongToDept = true;
                            break;
                        }
                        else
                        {
                            belongToDept = false;
                        }

                    }
                    dr.Close();
                    cn.Close();

                    if (!belongToDept)
                    {
                        MessageBox.Show("this lecturer does NOT belong to any department");
                        textBox_courseID.Clear();
                        textBox_lectID.Clear();
                    }



                    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM CoursesDepartment", cn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr["IDcourse"].ToString() == textBox_courseID.Text)
                        {
                            if (dr["IDdepartment"].ToString() == lectDept[0])
                                sameDept = true;
                        }

                    }
                    dr.Close();
                    cn.Close();

                    if (sameDept)
                    {
                        //need to attach this course to this lecturer

                        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                        cn.Open();

                        cmd = new SqlCommand("INSERT INTO StaffCourses VALUES (@Num,@ID,@IDcourse)", cn);
                        cmd.Parameters.AddWithValue("@Num", nextIndex);
                        cmd.Parameters.AddWithValue("@ID", textBox_lectID.Text);
                        cmd.Parameters.AddWithValue("@IDcourse", textBox_courseID.Text);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cn.Close();

                        MessageBox.Show(" *** attach lecturer to course went SUCCESSFULL! ***");

                        this.Hide();
                        //A_DHschedualing sched = new A_DHschedualing();
                        A_DHschedualing.currentA_DHschedualing.Show();


                    }
                    else
                    {
                        //no need to attach course to lecturer
                        MessageBox.Show("this course and lecturer are from different departments");
                        textBox_courseID.Clear();
                        textBox_lectID.Clear();
                        MessageBox.Show("*** schedualing lecturer to course FAILED!!! ***");

                    }

                }

                else
                {
                    //no need to attach course to lecturer
                    if (!courseExist)//means that course NOT exist
                    {
                        MessageBox.Show("Sorry, this course does not exists");
                        textBox_courseID.Clear();
                        textBox_lectID.Clear();


                    }
                    else if (!userExist) //user does NOT exist
                    {
                        MessageBox.Show("Sorry, this user does not exists");
                        textBox_courseID.Clear();
                        textBox_lectID.Clear();

                    }
                    else if (!userIsLecturer) //user is NOT a lecturer
                    {
                        MessageBox.Show("Sorry, this user is NOT a lecturer");
                        textBox_courseID.Clear();
                        textBox_lectID.Clear();

                    }
                    else if (lectSignedForCourse)//user signed up for this course already
                    {
                        MessageBox.Show("Sorry, this lecturer is already signed up for this course!");
                        textBox_courseID.Clear();
                        textBox_lectID.Clear();

                    }
                    MessageBox.Show("*** schedualing lecturer to course FAILED!!! ***");


                }


            }








            //SqlCommand cmd;
            //SqlConnection cn;
            //SqlDataReader dr;

            //bool courseExist = false;
            //bool userExist = false;
            //bool userIsLecturer = false;
            //bool sameDept = false;
            //bool lectSignedForCourse = false;


            ////check if any field is empty
            //if (String.IsNullOrEmpty(textBox_courseID.Text) || String.IsNullOrEmpty(textBox_lectID.Text))
            //{
            //    MessageBox.Show("All fields REQIRED! please try again");


            //    this.Hide();
            //    //A_schedLectToCourse_forDH sched = new A_schedLectToCourse_forDH();
            //    A_schedLectToCourse_forDH sched = new A_schedLectToCourse_forDH(this.dep);
            //    sched.ShowDialog();
            //}



            //cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();

            //cmd = new SqlCommand("SELECT Courses.IDcourse,Users.ID,Users.Type FROM Courses,Users ", cn);

            //dr = cmd.ExecuteReader();
            //while(dr.Read())
            //{
            //    if (dr["IDcourse"].ToString() == textBox_courseID.Text)
            //        courseExist = true;
            //    if (dr["ID"].ToString() == textBox_lectID.Text)
            //    {
            //        userExist = true;
            //        if(dr["Type"].ToString() == "2")//check the user is lecturer
            //        {
            //            userIsLecturer = true;

            //        }
            //    }

            //}
            //dr.Close();
            //cn.Close();


            //cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();

            //cmd = new SqlCommand("SELECT * FROM StaffCourses ", cn);


            //dr = cmd.ExecuteReader();
            //while(dr.Read())
            //{
            //    if(dr["ID"].ToString() == textBox_lectID.Text)
            //    {
            //        if(dr["IDcourse"].ToString() == textBox_courseID.Text)
            //        {
            //            lectSignedForCourse = true;
            //        }
            //    }

            //}
            //dr.Close();
            //cn.Close();

            //if(courseExist && userExist && userIsLecturer && !lectSignedForCourse)
            //{
            //    //need to attach course to lecturer - in case its the same department

            //    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //    cn.Open();

            //    int index;
            //    int nextIndex = 0;

            //    cmd = new SqlCommand("SELECT MAX(Num) FROM StaffCourses", cn);
            //    dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        index = Int32.Parse(dr[0].ToString()) + 1;
            //        nextIndex = index; //in order to get index out of the red() loop

            //    }
            //    dr.Close();
            //    cn.Close();


            //    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //    cn.Open();
            //    cmd = new SqlCommand("SELECT * FROM UsersDepartment", cn);
            //    dr = cmd.ExecuteReader();

            //    List<string> lectDept = new List<string>();
            //    while(dr.Read())
            //    {
            //        if(dr["ID"].ToString() == textBox_lectID.Text)
            //        {
            //            lectDept.Add(dr["IDdepartment"].ToString());
            //            break;
            //        }


            //    }
            //    dr.Close();
            //    cn.Close();

            //    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //    cn.Open();
            //    cmd = new SqlCommand("SELECT * FROM CoursesDepartment", cn);
            //    dr = cmd.ExecuteReader();
            //    while(dr.Read())
            //    {
            //        if(dr["IDcourse"].ToString() == textBox_courseID.Text)
            //        {
            //            if (dr["IDdepartment"].ToString() == lectDept[0])
            //                sameDept = true;
            //        }

            //    }
            //    dr.Close();
            //    cn.Close();

            //    if(sameDept)
            //    {
            //        //need to attach this course to this lecturer

            //        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //        cn.Open();

            //        cmd = new SqlCommand("INSERT INTO StaffCourses VALUES (@Num,@ID,@IDcourse)", cn);
            //        cmd.Parameters.AddWithValue("@Num", nextIndex);
            //        cmd.Parameters.AddWithValue("@ID", textBox_lectID.Text);
            //        cmd.Parameters.AddWithValue("@IDcourse", textBox_courseID.Text);
            //        cmd.ExecuteNonQuery();
            //        cmd.Parameters.Clear();
            //        cn.Close();

            //        MessageBox.Show(" *** attach lecturer to course went SUCCESSFULL! ***");

            //        this.Hide();
            //        //A_DHschedualing sched = new A_DHschedualing();
            //        A_DHschedualing sched = new A_DHschedualing(this.dep);
            //        sched.ShowDialog();


            //    }
            //    else
            //    {
            //        //no need to attach course to lecturer
            //        MessageBox.Show("this course and lecturer are from different departments");
            //        textBox_courseID.Clear();
            //        textBox_lectID.Clear();
            //        MessageBox.Show("*** schedualing lecturer to course FAILED!!! ***");

            //    }

            //}

            //else
            //{
            //    //no need to attach course to lecturer
            //    if(!courseExist)//means that course NOT exist
            //    {
            //        MessageBox.Show("Sorry, this course does not exists");
            //        textBox_courseID.Clear();
            //        textBox_lectID.Clear();


            //    }
            //    else if(!userExist) //user does NOT exist
            //    {
            //        MessageBox.Show("Sorry, this user does not exists");
            //        textBox_courseID.Clear();
            //        textBox_lectID.Clear();

            //    }
            //    else if(!userIsLecturer) //user is NOT a lecturer
            //    {
            //        MessageBox.Show("Sorry, this user is NOT a lecturer");
            //        textBox_courseID.Clear();
            //        textBox_lectID.Clear();

            //    }
            //    else if(lectSignedForCourse)//user signed up for this course already
            //    {
            //        MessageBox.Show("Sorry, this lecturer is already signed up for this course!");
            //        textBox_courseID.Clear();
            //        textBox_lectID.Clear();

            //    }
            //    MessageBox.Show("*** schedualing lecturer to course FAILED!!! ***");


            //}


        }

        private void A_schedLectToCourse_forDH_Load(object sender, EventArgs e)
        {
            currentA_schedLectToCourse_forDH = this;
        }
    }
}
