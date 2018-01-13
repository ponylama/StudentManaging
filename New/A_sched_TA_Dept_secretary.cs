﻿using System;
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
    public partial class A_sched_TA_Dept_secretary : Form
    {
        public static A_sched_TA_Dept_secretary cuurrentA_sched_TA_Dept_secretary;
        public A_sched_TA_Dept_secretary()
        {
            InitializeComponent();
        }

        private void button_BACK_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_schedForSecretary.currentA_schedForSecretary.Show();
        }

        private void button_SUBMIT_Click(object sender, EventArgs e)
        {


            // new change
            // new changes 11/06/17
            SqlConnection cn;
            SqlCommand cmd;
            SqlCommand cmd1;
            SqlDataReader dr;

            bool usersFlag = false;
            bool hasDept = false;
            bool deptExist = false;
            string followNum;
            int index = 0;
            int nextIndex = 0;

            //check that fields are not empty
            if (String.IsNullOrEmpty(textBox_DeptID.Text) || String.IsNullOrEmpty(textBox_ForID.Text))
            {
                MessageBox.Show("All fields REQIRED! please try again");

                this.Hide();
                A_sched_TA_Dept_secretary.cuurrentA_sched_TA_Dept_secretary.Show();

            }
            int parsedValue;
            if (!int.TryParse(textBox_DeptID.Text, out parsedValue) || !int.TryParse(textBox_ForID.Text, out parsedValue))
            {
                MessageBox.Show("User ID & Department ID can NOT contain letters! numbers only!");
                textBox_DeptID.Clear();
                textBox_ForID.Clear();
                this.Hide();
                A_sched_TA_Dept_secretary.cuurrentA_sched_TA_Dept_secretary.Show();

            }


            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            cn.Open();

            cmd = new SqlCommand("SELECT Users.ID,Users.Type,Departments.IDdepartment FROM Users,Departments  ", cn);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["ID"].ToString() == textBox_ForID.Text)//check if this user exist
                {
                    if (dr["Type"].ToString() == "3")//check this User is TA - TA Type is 3
                    {
                        usersFlag = true;
                    }
                }


                if (dr["IDdepartment"].ToString() == textBox_DeptID.Text)//check if this department exist
                {
                    deptExist = true;

                }
            }

            dr.Close();
            cn.Close();

            if (usersFlag && deptExist)
            {
                cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                cn.Open();

                cmd = new SqlCommand("SELECT ID FROM UsersDepartment ", cn);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["ID"].ToString() == textBox_ForID.Text)//check if allready assigned to some class
                    {
                        hasDept = true;// if it is
                        MessageBox.Show("This TA allready assigned to department");
                        MessageBox.Show("Schedual department for TA has FAILED!");
                        this.textBox_ForID.Clear();
                        this.textBox_DeptID.Clear();
                        break;

                    }

                }
                dr.Close();
                cn.Close();

                if (!hasDept)
                {
                    //in this case - we need to sign the TA to department
                    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                    cn.Open();

                    cmd = new SqlCommand("SELECT Num FROM UsersDepartment ", cn);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        //getting the last Num in table - in order to know to set next primary key
                        followNum = dr[0].ToString();

                        index = Int32.Parse(followNum) + 1;
                        nextIndex = index; //in order to get the number outside the loop

                    }
                    dr.Close();
                    cn.Close();

                    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                    cn.Open();


                    cmd = new SqlCommand("INSERT INTO UsersDepartment(Num,ID,IDdepartment) VALUES (@Num, @ID, @IDdepartment)", cn);
                    cmd.Parameters.AddWithValue("@Num", nextIndex);
                    cmd.Parameters.AddWithValue("@ID", textBox_ForID.Text);
                    cmd.Parameters.AddWithValue("@IDdepartment", textBox_DeptID.Text);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cn.Close();

                    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                    cn.Open();

                    cmd = new SqlCommand("SELECT * FROM Departments ", cn);

                    dr = cmd.ExecuteReader();
                    List<String> deptName = new List<string>();
                    while (dr.Read())
                    {
                        if (dr["IDdepartment"].ToString() == textBox_DeptID.Text)
                        {
                            deptName.Add(dr["Name"].ToString());
                        }


                    }
                    dr.Close();
                    cmd1 = new SqlCommand("UPDATE Users SET Departments ='" + deptName[0] + "'WHERE ID ='" + textBox_ForID.Text + "'", cn);

                    cmd1.ExecuteNonQuery();




                    cn.Close();
                    MessageBox.Show("*** TA has been signed up to the department SUCCESSFULLY!!! ***");
                    this.Hide();
                    A_schedForSecretary.currentA_schedForSecretary.Show();


                }
                else
                {
                    //this user has NOT found
                    if (!usersFlag)
                    {
                        MessageBox.Show("The user you were looking for is NOT exist in our database OR it's NOT a TA!");
                    }
                    if (!deptExist)
                    {
                        MessageBox.Show("This department is NOT exist in our database!");
                    }

                    MessageBox.Show("Schedual department for lecturer has FAILED!");
                    this.textBox_DeptID.Clear();
                    this.textBox_ForID.Clear();
                }

            }




            //// new changes 11/06/17
            //SqlConnection cn;
            //SqlCommand cmd;
            //SqlCommand cmd1;
            //SqlDataReader dr;

            //bool usersFlag = false;
            //bool hasDept = false;
            //bool deptExist = false;
            //string followNum;
            //int index = 0;
            //int nextIndex = 0;

            ////check that fields are not empty
            //if (String.IsNullOrEmpty(textBox_DeptID.Text) || String.IsNullOrEmpty(textBox_ForID.Text))
            //{
            //    MessageBox.Show("All fields REQIRED! please try again");

            //    this.Hide();
            //    A_sched_TA_Dept_secretary.cuurrentA_sched_TA_Dept_secretary.Show();

            //}


            //cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();

            //cmd = new SqlCommand("SELECT Users.ID,Users.Type,Departments.IDdepartment FROM Users,Departments  ", cn);

            //dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{
            //    if (dr["ID"].ToString() == textBox_ForID.Text)//check if this user exist
            //    {
            //        if (dr["Type"].ToString() == "3")//check this User is TA - TA Type is 3
            //        {
            //            usersFlag = true;
            //        }
            //    }


            //    if (dr["IDdepartment"].ToString() == textBox_DeptID.Text)//check if this department exist
            //    {
            //        deptExist = true;

            //    }
            //}

            //dr.Close();
            //cn.Close();

            //if (usersFlag && deptExist)
            //{
            //    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //    cn.Open();

            //    cmd = new SqlCommand("SELECT ID FROM UsersDepartment ", cn);

            //    dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        if (dr["ID"].ToString() == textBox_ForID.Text)//check if allready assigned to some class
            //        {
            //            hasDept = true;// if it is
            //            MessageBox.Show("This TA allready assigned to department");
            //            MessageBox.Show("Schedual department for TA has FAILED!");
            //            this.textBox_ForID.Clear();
            //            this.textBox_DeptID.Clear();
            //            break;

            //        }

            //    }
            //    dr.Close();
            //    cn.Close();

            //    if (!hasDept)
            //    {
            //        //in this case - we need to sign the TA to department
            //        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //        cn.Open();

            //        cmd = new SqlCommand("SELECT Num FROM UsersDepartment ", cn);

            //        dr = cmd.ExecuteReader();

            //        while (dr.Read())
            //        {
            //            //getting the last Num in table - in order to know to set next primary key
            //            followNum = dr[0].ToString();

            //            index = Int32.Parse(followNum) + 1;
            //            nextIndex = index; //in order to get the number outside the loop

            //        }
            //        dr.Close();
            //        cn.Close();

            //        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //        cn.Open();


            //        cmd = new SqlCommand("INSERT INTO UsersDepartment(Num,ID,IDdepartment) VALUES (@Num, @ID, @IDdepartment)", cn);
            //        cmd.Parameters.AddWithValue("@Num", nextIndex);
            //        cmd.Parameters.AddWithValue("@ID", textBox_ForID.Text);
            //        cmd.Parameters.AddWithValue("@IDdepartment", textBox_DeptID.Text);

            //        cmd.ExecuteNonQuery();
            //        cmd.Parameters.Clear();
            //        cn.Close();

            //        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //        cn.Open();

            //        cmd = new SqlCommand("SELECT * FROM Departments ", cn);

            //        dr = cmd.ExecuteReader();
            //        List<String> deptName = new List<string>();
            //        while (dr.Read())
            //        {
            //            if (dr["IDdepartment"].ToString() == textBox_DeptID.Text)
            //            {
            //                deptName.Add(dr["Name"].ToString());
            //            }


            //        }
            //        dr.Close();
            //        cmd1 = new SqlCommand("UPDATE Users SET Departments ='" + deptName[0] + "'WHERE ID ='" + textBox_ForID.Text + "'", cn);

            //        cmd1.ExecuteNonQuery();




            //        cn.Close();
            //        MessageBox.Show("*** TA has been signed up to the department SUCCESSFULLY!!! ***");
            //        this.Hide();
            //        A_schedForSecretary.currentA_schedForSecretary.Show();


            //    }
            //    else
            //    {
            //        //this user has NOT found
            //        if (!usersFlag)
            //        {
            //            MessageBox.Show("The user you were looking for is NOT exist in our database OR it's NOT a TA!");
            //        }
            //        if (!deptExist)
            //        {
            //            MessageBox.Show("This department is NOT exist in our database!");
            //        }

            //        MessageBox.Show("Schedual department for lecturer has FAILED!");
            //        this.textBox_DeptID.Clear();
            //        this.textBox_ForID.Clear();
            //    }

            //}


            //SqlConnection cn;
            //SqlCommand cmd;
            //SqlDataReader dr;

            //bool usersFlag = false;
            //bool hasDept = false;
            //bool deptExist = false;
            //string followNum;
            //int index = 0;
            //int nextIndex = 0;

            ////check that fields are not empty
            //if (String.IsNullOrEmpty(textBox_DeptID.Text) || String.IsNullOrEmpty(textBox_ForID.Text))
            //{
            //    MessageBox.Show("All fields REQIRED! please try again");

            //    this.Hide();
            //    A_sched_TA_Dept_secretary.cuurrentA_sched_TA_Dept_secretary.Show();

            //}


            //cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();

            //cmd = new SqlCommand("SELECT Users.ID,Users.Type,Departments.IDdepartment FROM Users,Departments  ", cn);

            //dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{
            //    if (dr["ID"].ToString() == textBox_ForID.Text)//check if this user exist
            //    {
            //        if (dr["Type"].ToString() == "3")//check this User is TA - TA Type is 3
            //        {
            //            usersFlag = true;
            //        }
            //    }


            //    if (dr["IDdepartment"].ToString() == textBox_DeptID.Text)//check if this department exist
            //    {
            //        deptExist = true;

            //    }
            //}

            //dr.Close();
            //cn.Close();

            //if (usersFlag && deptExist)
            //{
            //    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //    cn.Open();

            //    cmd = new SqlCommand("SELECT ID FROM UsersDepartment ", cn);

            //    dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        if (dr["ID"].ToString() == textBox_ForID.Text)//check if allready assigned to some class
            //        {
            //            hasDept = true;// if it is
            //            MessageBox.Show("This TA allready assigned to department");
            //            MessageBox.Show("Schedual department for TA has FAILED!");
            //            this.textBox_ForID.Clear();
            //            this.textBox_DeptID.Clear();
            //            break;

            //        }

            //    }
            //    dr.Close();
            //    cn.Close();

            //    if (!hasDept)
            //    {
            //        //in this case - we need to sign the TA to department
            //        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //        cn.Open();

            //        cmd = new SqlCommand("SELECT Num FROM UsersDepartment ", cn);

            //        dr = cmd.ExecuteReader();

            //        while (dr.Read())
            //        {
            //            //getting the last Num in table - in order to know to set next primary key
            //            followNum = dr[0].ToString();

            //            index = Int32.Parse(followNum) + 1;
            //            nextIndex = index; //in order to get the number outside the loop

            //        }
            //        dr.Close();
            //        cn.Close();

            //        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //        cn.Open();


            //        cmd = new SqlCommand("INSERT INTO UsersDepartment(Num,ID,IDdepartment) VALUES (@Num, @ID, @IDdepartment)", cn);
            //        cmd.Parameters.AddWithValue("@Num", nextIndex);
            //        cmd.Parameters.AddWithValue("@ID", textBox_ForID.Text);
            //        cmd.Parameters.AddWithValue("@IDdepartment", textBox_DeptID.Text);

            //        cmd.ExecuteNonQuery();
            //        cmd.Parameters.Clear();
            //        cn.Close();


            //        MessageBox.Show("*** TA has been signed up to the department SUCCESSFULLY!!! ***");
            //        this.Hide();
            //        A_schedForSecretary.currentA_schedForSecretary.Show();


            //    }
            //    else
            //    {
            //        //this user has NOT found
            //        if (!usersFlag)
            //        {
            //            MessageBox.Show("The user you were looking for is NOT exist in our database OR it's NOT a TA!");
            //        }
            //        if (!deptExist)
            //        {
            //            MessageBox.Show("This department is NOT exist in our database!");
            //        }

            //        MessageBox.Show("Schedual department for lecturer has FAILED!");
            //        this.textBox_DeptID.Clear();
            //        this.textBox_ForID.Clear();
            //    }

            //}
        }

        private void A_sched_TA_Dept_secretary_Load(object sender, EventArgs e)
        {
            cuurrentA_sched_TA_Dept_secretary = this;
        }
    }
}
