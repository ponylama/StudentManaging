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
    public partial class A_removeDept_secretary : Form
    {
        public static A_removeDept_secretary currentA_removeDept_secretary;
        public A_removeDept_secretary()
        {
            InitializeComponent();
        }

        private void button_SUBMIT_Click(object sender, EventArgs e)
        {
            // new changes 10.06.17
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;

            bool deptFlag = false;
            bool userDeptFlag = false;
            bool courseBelongDept = false;

            if (String.IsNullOrEmpty(textBox_deptID.Text)) // check if the field is empty
            {
                MessageBox.Show("All fields REQIRED! please try again");
                //in case its empty
                this.Hide();
                A_removeDept_secretary.currentA_removeDept_secretary.Show(); 
            }


            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            cn.Open();

            cmd = new SqlCommand("SELECT * FROM Departments ", cn);

            dr = cmd.ExecuteReader();

            List<string> deptName = new List<string>();

            while (dr.Read())
            {
                if (dr["IDdepartment"].ToString() == textBox_deptID.Text)//check if department exist in DB
                {

                    deptName.Add(dr["Name"].ToString());
                    deptFlag = true;
                    break;
                }

            }
            dr.Close();
            cn.Close();

            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            cn.Open();

            cmd = new SqlCommand("SELECT * FROM UsersDepartment ", cn);

            dr = cmd.ExecuteReader();

            while (dr.Read())//in order to check if there are some courses that belong to this department
            {
                if (dr["IDdepartment"].ToString() == textBox_deptID.Text)
                {
                    userDeptFlag = true;//means that we found some active Users that belong to the department and we can NOT delete this department
                    break;
                }


            }
            dr.Close();
            cn.Close();



            /////////////need to add condition to check if course belong to dept

            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            cn.Open();

            cmd = new SqlCommand("SELECT * FROM CoursesDepartment ", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["IDdepartment"].ToString() == textBox_deptID.Text)
                {
                    courseBelongDept = true;
                }

            }
            dr.Close();
            cn.Close();



            if (deptFlag && !userDeptFlag && !courseBelongDept)
            {
                // in case we found the department and there are no users belong to it - we need to delete it from DB

                MessageBox.Show("Department ID: " + textBox_deptID.Text + "\n" + "Department: " + deptName[0]);
                DialogResult dialogResult = MessageBox.Show("Sure you want to delete this department?", "Confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes) // in case user want to delete department
                {
                    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                    cn.Open();


                    cmd = new SqlCommand("DELETE FROM Departments WHERE IDdepartment" + "='" + textBox_deptID.Text + "'", cn); //delete department from Departments TABLE

                    dr = cmd.ExecuteReader();

                    dr.Close();
                    cn.Close();

                    //in order to delete all courses that belong to this department if they exist
                    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                    cn.Open();


                    cmd = new SqlCommand("DELETE FROM CoursesDepartment WHERE IDdepartment" + "='" + textBox_deptID.Text + "'", cn); //delete courses belong to this department

                    dr = cmd.ExecuteReader();

                    dr.Close();
                    cn.Close();


                    MessageBox.Show("Department [ " + deptName[0] + "] deleted SUCCESSFULLY!");
                }
                if (dialogResult == DialogResult.No) // in case user DONT want to delete department
                {
                    MessageBox.Show("Department [ " + deptName[0] + "] was NOT deleted to your request");
                    this.Hide();
                    A_removeForSecretary.currentA_removeForSecretary.Show();
                }
            }

            else
            {
                // in case we have NOT found the department or there are courses that belong to this department

                if (!deptFlag)//means that department was NOT found
                {
                    MessageBox.Show("Department was NOT found!!!");
                    this.textBox_deptID.Clear();
                }


                if (userDeptFlag)//means that we found users that belong to department
                {
                    MessageBox.Show("There are active users that belong to this department");
                    this.textBox_deptID.Clear();
                }

                if (courseBelongDept)//means that there is course that belong to this department and there for why we cant delete this department
                {
                    MessageBox.Show("There are active courses that belong to this department");
                    this.textBox_deptID.Clear();
                }

                MessageBox.Show("*** Delete department operation FAILED ***");
                this.textBox_deptID.Clear();

            }










            //SqlConnection cn;
            //SqlCommand cmd;
            //SqlDataReader dr;

            //bool deptFlag = false;
            //bool userDeptFlag = false;

            //if (String.IsNullOrEmpty(textBox_deptID.Text)) // check if the field is empty
            //{
            //    MessageBox.Show("All fields REQIRED! please try again");
            //    //in case its empty
            //    this.Hide();
            //    A_removeDept_secretary rem = new A_removeDept_secretary();
            //    rem.ShowDialog();

            //}


            //cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();

            //cmd = new SqlCommand("SELECT * FROM Departments ", cn);

            //dr = cmd.ExecuteReader();

            //List<string> deptName = new List<string>();

            //while (dr.Read())
            //{
            //    if (dr["IDdepartment"].ToString() == textBox_deptID.Text)//check if department exist in DB
            //    {

            //        deptName.Add(dr["Name"].ToString());
            //        deptFlag = true;
            //        break; 
            //    }

            //}
            //dr.Close();
            //cn.Close();

            //cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();

            //cmd = new SqlCommand("SELECT * FROM UsersDepartment ", cn);

            //dr = cmd.ExecuteReader();

            //while (dr.Read())//in order to check if there are some courses that belong to this department
            //{
            //    if(dr["IDdepartment"].ToString() == textBox_deptID.Text)
            //    {
            //        userDeptFlag = true;//means that we found some active Users that belong to the department and we can NOT delete this department
            //        break;
            //    }


            //}
            //dr.Close();
            //cn.Close();

            //if (deptFlag && (!userDeptFlag))
            //{
            //    // in case we found the department and there are no users belong to it - we need to delete it from DB

            //    MessageBox.Show("Department ID: " + textBox_deptID.Text + "\n" + "Department: " +deptName[0]);
            //    DialogResult dialogResult = MessageBox.Show("Sure you want to delete this department?","Confirmation", MessageBoxButtons.YesNo);

            //    if (dialogResult == DialogResult.Yes) // in case user want to delete department
            //    {
            //        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //        cn.Open();


            //        cmd = new SqlCommand("DELETE FROM Departments WHERE IDdepartment" + "='" + textBox_deptID.Text+"'", cn); //delete department from Departments TABLE

            //        dr = cmd.ExecuteReader();

            //        dr.Close();
            //        cn.Close();

            //        //in order to delete all courses that belong to this department if they exist
            //        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //        cn.Open();


            //        cmd = new SqlCommand("DELETE FROM CoursesDepartment WHERE IDdepartment" + "='" + textBox_deptID.Text + "'", cn); //delete courses belong to this department

            //        dr = cmd.ExecuteReader();

            //        dr.Close();
            //        cn.Close();


            //        MessageBox.Show("Department [ " + deptName[0] + "] deleted SUCCESSFULLY!");
            //    }
            //    if (dialogResult == DialogResult.No) // in case user DONT want to delete department
            //    {
            //        MessageBox.Show("Department [ " + deptName[0] + "] was NOT deleted to your request");
            //        this.Hide();
            //        A_removeForSecretary sec = new A_removeForSecretary();
            //        sec.ShowDialog();
            //    }
            //}

            //else
            //{
            //    // in case we have NOT found the department or there are courses that belong to this department

            //    if (!deptFlag)//means that department was NOT found
            //    {
            //        MessageBox.Show("Department was NOT found!!!");
            //        this.textBox_deptID.Clear();
            //    }


            //    if (userDeptFlag)//means that we found users that belong to department
            //    {
            //        MessageBox.Show("There are active users that belong to this department");
            //        this.textBox_deptID.Clear();
            //    }


            //    MessageBox.Show("*** Delete department operation FAILED ***");
            //    this.textBox_deptID.Clear();

            //}

        }

        private void button_BACK_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_removeForSecretary sec = new A_removeForSecretary();
            sec.ShowDialog();
        }

        private void A_removeDept_secretary_Load(object sender, EventArgs e)
        {
            currentA_removeDept_secretary = this;
        }
    }
}
