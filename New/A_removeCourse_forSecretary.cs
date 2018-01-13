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
    public partial class A_removeCourse_forSecretary : Form
    {
        public static A_removeCourse_forSecretary currentA_removeCourse_forSecretary;
        public A_removeCourse_forSecretary()
        {
            InitializeComponent();
        }

        private void button_SUBMIT_Click(object sender, EventArgs e)
        {
            // new change 
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;

            bool deptFlag = false;
            bool courseFlag = false;
            bool courseBelongDept = false;
            bool ifUsers = false;
            bool NotOnlyDept = false; //in order to know if this course belong ONLY to this department

            //check if any of the fields is empty
            if (String.IsNullOrEmpty(textBox_courseID.Text) || String.IsNullOrEmpty(textBox_deptID.Text))
            {
                MessageBox.Show("All fields REQIRED! please try again");
                textBox_deptID.Clear();
                textBox_courseID.Clear();
                this.Hide();
                A_removeCourse_forSecretary sec = new A_removeCourse_forSecretary();
                sec.ShowDialog();

            }

            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            cn.Open();

            cmd = new SqlCommand("SELECT Departments.IDdepartment,Courses.IDcourse FROM Departments,Courses ", cn);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["IDdepartment"].ToString() == textBox_deptID.Text)//check department exist
                    deptFlag = true;
                if (dr["IDcourse"].ToString() == textBox_courseID.Text)//check this course exist
                    courseFlag = true;



            }
            dr.Close();
            cn.Close();


            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            cn.Open();

            cmd = new SqlCommand("SELECT * FROM CoursesDepartment ", cn);

            dr = cmd.ExecuteReader();
            while (dr.Read())//here we check if course belong to this department
            {
                if (dr["IDdepartment"].ToString() == textBox_deptID.Text)
                {
                    if (dr["IDcourse"].ToString() == textBox_courseID.Text)
                    {
                        courseBelongDept = true; // if weve got here - means that course belong to this department
                        break;
                    }
                }

            }
            dr.Close();
            cn.Close();

            if (deptFlag && courseFlag && courseBelongDept)//means that - department exist and course exist and course belong to this department
            {
                cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                cn.Open();

                cmd = new SqlCommand("SELECT IDcourse FROM StudentsCourses ", cn);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["IDcourse"].ToString() == textBox_courseID.Text)//check if there are some students that are allready signed up for this course 
                    {
                        ifUsers = true;//there are students that signed up for this course - means that we can't delete it
                        break;
                    }


                }
                dr.Close();
                cn.Close();

                if (!ifUsers)
                {
                    //meaning that there are no users to this course and can be deleted

                    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                    cn.Open();

                    cmd = new SqlCommand("SELECT * FROM CoursesDepartment ", cn);

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr["IDcourse"].ToString() == textBox_courseID.Text)
                        {
                            if (dr["IDdepartment"].ToString() != textBox_deptID.Text)
                            {
                                NotOnlyDept = true;//means that this course does not belong only to this department
                                break;
                            }
                        }

                    }
                    dr.Close();
                    cn.Close();
                    if (NotOnlyDept)
                    {
                        //need to be deleted only from CoursesDepartment
                        DialogResult dialogResult = MessageBox.Show("Sure you want to delete this course?", "Confirmation", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes) //in case user want to deletet this course
                        {
                            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                            cn.Open();

                            cmd = new SqlCommand("DELETE FROM CoursesDepartment WHERE IDcourse ='" + textBox_courseID.Text + "'and IDdepartment ='" + textBox_deptID.Text + "'", cn);

                            dr = cmd.ExecuteReader();

                            dr.Close();
                            cn.Close();

                            MessageBox.Show(" *** Course deleted SUCCESSFULLY ***");
                            this.Hide();
                            //A_removeForSecretary.currentA_removeForSecretary.Show();
                            this.Hide();
                            A_removeForSecretary sec = new A_removeForSecretary();
                            sec.ShowDialog();

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            MessageBox.Show(" *** Course was NOT deleted from the system ***");
                            this.Hide();
                            //A_removeForSecretary.currentA_removeForSecretary.Show();
                            this.Hide();
                            A_removeForSecretary sec = new A_removeForSecretary();
                            sec.ShowDialog();
                        }


                    }

                    else
                    {

                        //need to be deleted from CoursesDepartment & Courses

                        DialogResult dialogResult = MessageBox.Show("Sure you want to delete this course?", "Confirmation", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                            cn.Open();

                            //delete course from CoursesDepartment Table
                            cmd = new SqlCommand("DELETE FROM CoursesDepartment WHERE IDcourse ='" + textBox_courseID.Text + "'and IDdepartment ='" + textBox_deptID.Text + "'", cn);
                            dr = cmd.ExecuteReader();

                            dr.Close();
                            cn.Close();

                            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                            cn.Open();

                            //delete course from Courses Table
                            cmd = new SqlCommand("DELETE FROM Courses WHERE IDcourse ='" + textBox_courseID.Text + "'", cn);
                            dr = cmd.ExecuteReader();

                            dr.Close();
                            cn.Close();

                            MessageBox.Show("*** Course deleted SUCCESSFULLY ***");
                            this.Hide();
                            A_removeForSecretary sec = new A_removeForSecretary();
                            sec.ShowDialog();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            MessageBox.Show(" *** Course was NOT deleted from the system ***");
                            textBox_courseID.Clear();
                            textBox_deptID.Clear();
                            //A_removeForSecretary.currentA_removeForSecretary.Show();
                            this.Hide();
                            A_removeForSecretary sec = new A_removeForSecretary();
                            sec.ShowDialog();
                        }

                    }

                }

                else
                {
                    //meaning that there are users signed up for this course and can NOT be deleted!!!!
                    MessageBox.Show("There are some active users that belong to this course and can not be deleted! ");//change after - only for me to know
                    MessageBox.Show(" *** Delete course operation FAILED ***");
                    this.textBox_courseID.Clear();
                    this.textBox_deptID.Clear();
                }

            }

            else
            {
                if (!deptFlag)
                {
                    MessageBox.Show("This department does NOT exists!");
                    this.textBox_courseID.Clear();
                    this.textBox_deptID.Clear();
                    this.Hide();
                    A_removeForSecretary sec = new A_removeForSecretary();
                    sec.ShowDialog();

                }
                else if (!courseFlag)
                {
                    MessageBox.Show("This course does NOT exists!");
                    this.textBox_courseID.Clear();
                    this.textBox_deptID.Clear();
                }
                else if (!courseBelongDept)
                {
                    MessageBox.Show("This course does NOT belong to this department!");
                    this.textBox_courseID.Clear();
                    this.textBox_deptID.Clear();

                }
                MessageBox.Show(" *** Delete course operation FAILED ***");
              
            }





            //SqlConnection cn;
            //SqlCommand cmd;
            //SqlDataReader dr;

            //bool deptFlag = false;
            //bool courseFlag = false;
            //bool courseBelongDept = false;
            //bool ifUsers = false;
            //bool NotOnlyDept = false; //in order to know if this course belong ONLY to this department

            ////check if any of the fields is empty
            //if (String.IsNullOrEmpty(textBox_courseID.Text) || String.IsNullOrEmpty(textBox_deptID.Text))
            //{
            //    MessageBox.Show("All fields REQIRED! please try again");

            //    this.Hide();
            //    A_removeCourse_forSecretary sec = new A_removeCourse_forSecretary();
            //    sec.ShowDialog();

            //}

            //cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();

            //cmd = new SqlCommand("SELECT Departments.IDdepartment,Courses.IDcourse FROM Departments,Courses ", cn);

            //dr = cmd.ExecuteReader();

            //while(dr.Read())
            //{
            //    if (dr["IDdepartment"].ToString() == textBox_deptID.Text)//check department exist
            //        deptFlag = true;
            //    if (dr["IDcourse"].ToString() == textBox_courseID.Text)//check this course exist
            //        courseFlag = true;



            //}
            //dr.Close();
            //cn.Close();


            //cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();

            //cmd = new SqlCommand("SELECT * FROM CoursesDepartment ", cn);

            //dr = cmd.ExecuteReader();
            //while(dr.Read())//here we check if course belong to this department
            //{
            //    if (dr["IDdepartment"].ToString() == textBox_deptID.Text)
            //    {
            //        if(dr["IDcourse"].ToString() == textBox_courseID.Text)
            //        {
            //            courseBelongDept = true; // if weve got here - means that course belong to this department
            //            break;
            //        }
            //    }

            //}
            //dr.Close();
            //cn.Close();

            //if (deptFlag && courseFlag && courseBelongDept)//means that - department exist and course exist and course belong to this department
            //{
            //    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //    cn.Open();

            //    cmd = new SqlCommand("SELECT IDcourse FROM StudentsCourses ", cn);

            //    dr = cmd.ExecuteReader();
            //    while(dr.Read())
            //    {
            //        if (dr["IDcourse"].ToString() == textBox_courseID.Text)//check if there are some students that are allready signed up for this course 
            //        {
            //            ifUsers = true;//there are students that signed up for this course - means that we can't delete it
            //            break;
            //        }


            //    }
            //    dr.Close();
            //    cn.Close();

            //    if(!ifUsers)
            //    {
            //        //meaning that there are no users to this course and can be deleted

            //        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //        cn.Open();

            //        cmd = new SqlCommand("SELECT * FROM CoursesDepartment ", cn);

            //        dr = cmd.ExecuteReader();
            //        while(dr.Read())
            //        {
            //            if(dr["IDcourse"].ToString() == textBox_courseID.Text)
            //            {
            //                if(dr["IDdepartment"].ToString() != textBox_deptID.Text)
            //                {
            //                    NotOnlyDept = true;//means that this course does not belong only to this department
            //                    break;
            //                }
            //            }

            //        }
            //        dr.Close();
            //        cn.Close();
            //        if (NotOnlyDept)
            //        {
            //            //need to be deleted only from CoursesDepartment
            //            DialogResult dialogResult = MessageBox.Show("Sure you want to delete this course?", "Confirmation", MessageBoxButtons.YesNo);
            //            if (dialogResult == DialogResult.Yes) //in case user want to deletet this course
            //            {
            //                cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //                cn.Open();

            //                cmd = new SqlCommand("DELETE FROM CoursesDepartment WHERE IDcourse ='" + textBox_courseID.Text + "'and IDdepartment ='" + textBox_deptID.Text + "'", cn);

            //                dr = cmd.ExecuteReader();

            //                dr.Close();
            //                cn.Close();

            //                MessageBox.Show(" *** Course deleted SUCCESSFULLY ***");
            //                this.Hide();
            //                A_removeForSecretary.currentA_removeForSecretary.Show();

            //            }
            //            else if (dialogResult == DialogResult.No)
            //            {
            //                MessageBox.Show(" *** Course was NOT deleted from the system ***");
            //                this.Hide();
            //                A_removeForSecretary.currentA_removeForSecretary.Show();
            //            }


            //        }

            //        else
            //        {

            //            //need to be deleted from CoursesDepartment & Courses

            //            DialogResult dialogResult = MessageBox.Show("Sure you want to delete this course?", "Confirmation", MessageBoxButtons.YesNo);
            //            if (dialogResult == DialogResult.Yes)
            //            {
            //                cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //                cn.Open();

            //                //delete course from CoursesDepartment Table
            //                cmd = new SqlCommand("DELETE FROM CoursesDepartment WHERE IDcourse ='" + textBox_courseID.Text + "'and IDdepartment ='" + textBox_deptID.Text + "'", cn);
            //                dr = cmd.ExecuteReader();

            //                dr.Close();
            //                cn.Close();

            //                cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //                cn.Open();

            //                //delete course from Courses Table
            //                cmd = new SqlCommand("DELETE FROM Courses WHERE IDcourse ='" + textBox_courseID.Text + "'", cn);
            //                dr = cmd.ExecuteReader();

            //                dr.Close();
            //                cn.Close();

            //                MessageBox.Show("*** Course deleted SUCCESSFULLY ***");
            //                this.Hide();
            //                A_removeForSecretary sec = new A_removeForSecretary();
            //                sec.ShowDialog();
            //            }
            //            else if (dialogResult == DialogResult.No)
            //            {
            //                MessageBox.Show(" *** Course was NOT deleted from the system ***");
            //                this.Hide();
            //                A_removeForSecretary.currentA_removeForSecretary.Show();
            //            }

            //        }

            //    }

            //    else
            //    {
            //        //meaning that there are users signed up for this course and can NOT be deleted!!!!
            //        MessageBox.Show("There are some active users that belong to this course and can not be deleted! ");//change after - only for me to know
            //        MessageBox.Show(" *** Delete course operation FAILED ***");
            //        this.textBox_courseID.Clear();
            //        this.textBox_deptID.Clear();
            //    }

            //}

            //else
            //{
            //    if (!deptFlag)
            //    {
            //        MessageBox.Show("This department does NOT exists!");
            //        this.textBox_courseID.Clear();
            //        this.textBox_deptID.Clear();
            //    }
            //    if(!courseFlag)
            //    {
            //        MessageBox.Show("This course does NOT exists!");
            //        this.textBox_courseID.Clear();
            //        this.textBox_deptID.Clear();
            //    }
            //    if(!courseBelongDept)
            //    {
            //        MessageBox.Show("This course does NOT belong to this department!");
            //        this.textBox_courseID.Clear();
            //        this.textBox_deptID.Clear();

            //    }
            //    MessageBox.Show(" *** Delete course operation FAILED ***");

            //}



        }

        private void button_BACK_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_removeForSecretary.currentA_removeForSecretary.Show();
        }

        private void A_removeCourse_forSecretary_Load(object sender, EventArgs e)
        {
            currentA_removeCourse_forSecretary = this;
        }
    }
}
