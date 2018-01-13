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
    public partial class A_removeSchedLecturer_fromDept_forSecretary : Form
    {
        public static A_removeSchedLecturer_fromDept_forSecretary currentA_removeSchedLecturer_fromDept_forSecretary;
        public A_removeSchedLecturer_fromDept_forSecretary()
        {
            InitializeComponent();
        }

        private void button_BACK_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_removeForSecretary.currentA_removeForSecretary.Show();
        }

        private void button_SUBMIT_Click(object sender, EventArgs e)
        {
            // new change
            // new change 10.06.17
            SqlConnection cn;
            SqlCommand cmd;
            SqlCommand cmd1;

            SqlDataReader dr;

            bool deptExist = false;
            bool userExist = false;
            bool userIsLecturer = false;
            bool lectBelongDept = false;


            if (String.IsNullOrEmpty(textBox_deptID.Text) || String.IsNullOrEmpty(textBox_lecturerID.Text)) // check if the field is empty
            {
                MessageBox.Show("All fields REQIRED! please try again");
                //in case its empty
                this.Hide();
                A_removeSchedLecturer_fromDept_forSecretary.currentA_removeSchedLecturer_fromDept_forSecretary.Show();

            }

            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            cn.Open();

            cmd = new SqlCommand("SELECT * FROM Departments ", cn);

            dr = cmd.ExecuteReader();
            List<string> deptName = new List<string>();
            while (dr.Read()) // in order to check if dept exist
            {
                if (dr["IDdepartment"].ToString() == textBox_deptID.Text)
                {
                    deptExist = true;
                    deptName.Add(dr["Name"].ToString());
                    break;
                }


            }
            dr.Close();
            cn.Close();

            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            cn.Open();

            cmd = new SqlCommand("SELECT ID,Type FROM Users ", cn);

            dr = cmd.ExecuteReader();
            while (dr.Read()) //in order to check if user exist
            {
                if (dr["ID"].ToString() == textBox_lecturerID.Text)
                {
                    userExist = true;
                    if (dr["Type"].ToString() == "2")//check if user is from type lecturer(2)
                    {
                        userIsLecturer = true;
                        break;
                    }
                }
            }
            dr.Close();
            cn.Close();

            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            cn.Open();

            cmd = new SqlCommand("SELECT ID,IDdepartment FROM UsersDepartment ", cn);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["ID"].ToString() == textBox_lecturerID.Text)
                {
                    if (dr["IDdepartment"].ToString() == textBox_deptID.Text)
                    {
                        lectBelongDept = true;
                        break;
                    }
                }

            }
            dr.Close();
            cn.Close();

            //////////////////////////change

            if (deptExist && userExist && userIsLecturer && lectBelongDept)
            {
                //in that case we need to REMOVE this lecturer from department
                DialogResult dialogResult = MessageBox.Show("Sure you want to remove lecturer from department?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)//in case the choice is to delete it
                {
                    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                    cn.Open();

                    cmd = new SqlCommand("DELETE FROM UsersDepartment WHERE ID ='" + textBox_lecturerID.Text + "'", cn);
                    cmd1 = new SqlCommand("UPDATE Users SET Departments = NULL WHERE ID ='" + textBox_lecturerID.Text + "'", cn);



                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();




                    cn.Close();
                    MessageBox.Show("*** you removed lecturer from department [ " + deptName[0] + " ] SUCCESSFULLY ***");
                    this.Hide();
                    A_removeForSecretary.currentA_removeForSecretary.Show();

                }
                else if (dialogResult == DialogResult.No)//in case the choice is NOT to delete it
                {
                    MessageBox.Show("Remove lecturer from department [ " + deptName[0] + " ] was CANCELD");
                    this.Hide();
                    A_removeForSecretary.currentA_removeForSecretary.Show();
                }

            }

            else
            {
                //in that case we DONT need to REMOVE this lecturer from department
                if (!deptExist)//department does not exist
                {
                    MessageBox.Show("Sorry,this department does NOT exist!");
                    this.textBox_deptID.Clear();
                    this.textBox_lecturerID.Clear();

                }
                else if (!userExist)//user does not exist
                {
                    MessageBox.Show("Sorry,this user does NOT exist!");
                    this.textBox_deptID.Clear();
                    this.textBox_lecturerID.Clear();

                }
                else if (!userIsLecturer)//user is NOT a lecturer
                {
                    MessageBox.Show("Sorry,this user is NOT a lecturer!");
                    this.textBox_deptID.Clear();
                    this.textBox_lecturerID.Clear();
                }
                else if (!lectBelongDept)//user does not belong to this department
                {
                    MessageBox.Show("Sorry,this user does NOT belong to this department!");
                    this.textBox_deptID.Clear();
                    this.textBox_lecturerID.Clear();
                }
                MessageBox.Show("*** Remove schedual of lecturer from department FAILED!");



            }

            //// new change 10.06.17
            //SqlConnection cn;
            //SqlCommand cmd;
            //SqlCommand cmd1;

            //SqlDataReader dr;

            //bool deptExist = false;
            //bool userExist = false;
            //bool userIsLecturer = false;
            //bool lectBelongDept = false;


            //if (String.IsNullOrEmpty(textBox_deptID.Text) || String.IsNullOrEmpty(textBox_lecturerID.Text)) // check if the field is empty
            //{
            //    MessageBox.Show("All fields REQIRED! please try again");
            //    //in case its empty
            //    this.Hide();
            //    A_removeSchedLecturer_fromDept_forSecretary.currentA_removeSchedLecturer_fromDept_forSecretary.Show(); 

            //}

            //cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();

            //cmd = new SqlCommand("SELECT * FROM Departments ", cn);

            //dr = cmd.ExecuteReader();
            //List<string> deptName = new List<string>();
            //while (dr.Read()) // in order to check if dept exist
            //{
            //    if (dr["IDdepartment"].ToString() == textBox_deptID.Text)
            //    {
            //        deptExist = true;
            //        deptName.Add(dr["Name"].ToString());
            //        break;
            //    }


            //}
            //dr.Close();
            //cn.Close();

            //cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();

            //cmd = new SqlCommand("SELECT ID,Type FROM Users ", cn);

            //dr = cmd.ExecuteReader();
            //while (dr.Read()) //in order to check if user exist
            //{
            //    if (dr["ID"].ToString() == textBox_lecturerID.Text)
            //    {
            //        userExist = true;
            //        if (dr["Type"].ToString() == "2")//check if user is from type lecturer(2)
            //        {
            //            userIsLecturer = true;
            //            break;
            //        }
            //    }
            //}
            //dr.Close();
            //cn.Close();

            //cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();

            //cmd = new SqlCommand("SELECT ID,IDdepartment FROM UsersDepartment ", cn);

            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    if (dr["ID"].ToString() == textBox_lecturerID.Text)
            //    {
            //        if (dr["IDdepartment"].ToString() == textBox_deptID.Text)
            //        {
            //            lectBelongDept = true;
            //            break;
            //        }
            //    }

            //}
            //dr.Close();
            //cn.Close();

            ////////////////////////////change

            //if (deptExist && userExist && userIsLecturer && lectBelongDept)
            //{
            //    //in that case we need to REMOVE this lecturer from department
            //    DialogResult dialogResult = MessageBox.Show("Sure you want to remove lecturer from department?", "Confirmation", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)//in case the choice is to delete it
            //    {
            //        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //        cn.Open();

            //        cmd = new SqlCommand("DELETE FROM UsersDepartment WHERE ID ='" + textBox_lecturerID.Text + "'", cn);
            //        cmd1 = new SqlCommand("UPDATE Users SET Departments = NULL WHERE ID ='" + textBox_lecturerID.Text + "'", cn);



            //        cmd.ExecuteNonQuery();
            //        cmd1.ExecuteNonQuery();




            //        cn.Close();
            //        MessageBox.Show("*** you removed lecturer from department [ " + deptName[0] + " ] SUCCESSFULLY ***");
            //        this.Hide();
            //        A_removeForSecretary.currentA_removeForSecretary.Show();

            //    }
            //    else if (dialogResult == DialogResult.No)//in case the choice is NOT to delete it
            //    {
            //        MessageBox.Show("Remove lecturer from department [ " + deptName[0] + " ] was CANCELD");
            //        this.Hide();
            //        A_removeForSecretary.currentA_removeForSecretary.Show();
            //    }

            //}

            //else
            //{
            //    //in that case we DONT need to REMOVE this lecturer from department
            //    if (!deptExist)//department does not exist
            //    {
            //        MessageBox.Show("Sorry,this department does NOT exist!");
            //        this.textBox_deptID.Clear();
            //        this.textBox_lecturerID.Clear();

            //    }
            //    if (!userExist)//user does not exist
            //    {
            //        MessageBox.Show("Sorry,this user does NOT exist!");
            //        this.textBox_deptID.Clear();
            //        this.textBox_lecturerID.Clear();

            //    }
            //    if (!userIsLecturer)//user is NOT a lecturer
            //    {
            //        MessageBox.Show("Sorry,this user is NOT a lecturer!");
            //        this.textBox_deptID.Clear();
            //        this.textBox_lecturerID.Clear();
            //    }
            //    if (!lectBelongDept)//user does not belong to this department
            //    {
            //        MessageBox.Show("Sorry,this user does NOT belong to this department!");
            //        this.textBox_deptID.Clear();
            //        this.textBox_lecturerID.Clear();
            //    }
            //    MessageBox.Show("*** Remove schedual of lecturer from department FAILED!");



            //}







            //SqlConnection cn;
            //SqlCommand cmd;
            //SqlDataReader dr;

            //bool deptExist = false;
            //bool userExist = false;
            //bool userIsLecturer = false;
            //bool lectBelongDept = false;


            //if (String.IsNullOrEmpty(textBox_deptID.Text) || String.IsNullOrEmpty(textBox_lecturerID.Text)) // check if the field is empty
            //{
            //    MessageBox.Show("All fields REQIRED! please try again");
            //    //in case its empty
            //    this.Hide();
            //    A_removeSchedLecturer_fromDept_forSecretary sec = new A_removeSchedLecturer_fromDept_forSecretary();
            //    sec.ShowDialog();

            //}

            //cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();

            //cmd = new SqlCommand("SELECT * FROM Departments ", cn);

            //dr = cmd.ExecuteReader();
            //List<string> deptName = new List<string>();
            //while(dr.Read()) // in order to check if dept exist
            //{
            //    if (dr["IDdepartment"].ToString() == textBox_deptID.Text)
            //    {
            //        deptExist = true;
            //        deptName.Add(dr["Name"].ToString());
            //        break;
            //    }


            //}
            //dr.Close();
            //cn.Close();

            //cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();

            //cmd = new SqlCommand("SELECT ID,Type FROM Users ", cn);

            //dr = cmd.ExecuteReader();
            //while(dr.Read()) //in order to check if user exist
            //{
            //    if(dr["ID"].ToString() == textBox_lecturerID.Text)
            //    {
            //        userExist = true;
            //        if (dr["Type"].ToString() == "2")//check if user is from type lecturer(2)
            //        {
            //            userIsLecturer = true;
            //            break;
            //        }
            //    }
            //}
            //dr.Close();
            //cn.Close();

            //cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();

            //cmd = new SqlCommand("SELECT ID,IDdepartment FROM UsersDepartment ", cn);

            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    if(dr["ID"].ToString() == textBox_lecturerID.Text)
            //    {
            //        if(dr["IDdepartment"].ToString() == textBox_deptID.Text)
            //        {
            //            lectBelongDept = true;
            //            break;
            //        }
            //    }

            //}
            //dr.Close();
            //cn.Close();

            //if (deptExist && userExist && userIsLecturer && lectBelongDept)
            //{
            //    //in that case we need to REMOVE this lecturer from department
            //    DialogResult dialogResult = MessageBox.Show("Sure you want to remove lecturer from department?", "Confirmation", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)//in case the choice is to delete it
            //    {
            //        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //        cn.Open();

            //        cmd = new SqlCommand("DELETE FROM UsersDepartment WHERE ID ='" + textBox_lecturerID.Text + "'", cn);

            //        dr = cmd.ExecuteReader();

            //        dr.Close();
            //        cn.Close();
            //        MessageBox.Show("*** you removed lecturer from department [ " + deptName[0] + " ] SUCCESSFULLY ***");
            //        this.Hide();
            //        A_removeForSecretary sec = new A_removeForSecretary();
            //        sec.ShowDialog();

            //    }
            //    else if (dialogResult == DialogResult.No)//in case the choice is NOT to delete it
            //    {
            //        MessageBox.Show("Remove lecturer from department [ " + deptName[0] + " ] was CANCELD");
            //        this.Hide();
            //        A_removeForSecretary sec = new A_removeForSecretary();
            //        sec.ShowDialog();
            //    }

            //}

            //else
            //{
            //    //in that case we DONT need to REMOVE this lecturer from department
            //    if (!deptExist)//department does not exist
            //    {
            //        MessageBox.Show("Sorry,this department does NOT exist!");
            //        this.textBox_deptID.Clear();
            //        this.textBox_lecturerID.Clear();

            //    }
            //    if(!userExist)//user does not exist
            //    {
            //        MessageBox.Show("Sorry,this user does NOT exist!");
            //        this.textBox_deptID.Clear();
            //        this.textBox_lecturerID.Clear();

            //    }
            //    if(!userIsLecturer)//user is NOT a lecturer
            //    {
            //        MessageBox.Show("Sorry,this user is NOT a lecturer!");
            //        this.textBox_deptID.Clear();
            //        this.textBox_lecturerID.Clear();
            //    }
            //    if(!lectBelongDept)//user does not belong to this department
            //    {
            //        MessageBox.Show("Sorry,this user does NOT belong to this department!");
            //        this.textBox_deptID.Clear();
            //        this.textBox_lecturerID.Clear();
            //    }
            //    MessageBox.Show("*** Remove schedual of lecturer from department FAILED!");



            //}


        }

        private void A_removeSchedLecturer_fromDept_forSecretary_Load(object sender, EventArgs e)
        {
            currentA_removeSchedLecturer_fromDept_forSecretary = this;
        }
    }
}
