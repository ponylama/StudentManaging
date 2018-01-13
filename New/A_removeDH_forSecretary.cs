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
    public partial class A_removeDH_forSecretary : Form
    {
        public static A_removeDH_forSecretary currentA_removeDH_forSecretaryy;
        public A_removeDH_forSecretary()
        {
            InitializeComponent();
        }

        private void button_SUBMIT_Click(object sender, EventArgs e)
        {
            // new change
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;

            bool deptExist = false;
            bool userExist = false;
            bool user_DH = false; //check if this user is really DH (should be type 4)
            bool DH_belongDept = false; //check if belong to fepartment

            //check if any of the fields is empty
            if (String.IsNullOrEmpty(textBox_deptID.Text) || String.IsNullOrEmpty(textBox_DH_ID.Text))
            {
                MessageBox.Show("All fields REQIRED! please try again");

                this.Hide();
                A_removeDH_forSecretary.currentA_removeDH_forSecretaryy.Show();
            }

            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            cn.Open();

            cmd = new SqlCommand("SELECT IDdepartment,Name FROM Departments ", cn);

            dr = cmd.ExecuteReader();

            List<string> deptName = new List<string>();

            while (dr.Read())//in order to check if dept exist
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
            while (dr.Read())
            {
                if (dr["ID"].ToString() == textBox_DH_ID.Text)
                {
                    userExist = true;
                    if (dr["Type"].ToString() == "4")
                    {
                        user_DH = true;
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
                if (dr["ID"].ToString() == textBox_DH_ID.Text)
                {
                    if (dr["IDdepartment"].ToString() == textBox_deptID.Text)
                    {
                        DH_belongDept = true;
                        break;
                    }
                }


            }
            dr.Close();
            cn.Close();

            if (deptExist && userExist && user_DH && DH_belongDept)
            {
                //means that we need to DELETE DH from system
                DialogResult dialogResult = MessageBox.Show("Sure you want to delete DH from system?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)// in case the choice was to delete DH
                {
                    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                    cn.Open();
                    //in order to remove from UsersDepartment table
                    cmd = new SqlCommand("DELETE FROM UsersDepartment WHERE ID ='" + textBox_DH_ID.Text + "'", cn);

                    dr = cmd.ExecuteReader();

                    dr.Close();
                    cn.Close();

                    cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                    cn.Open();
                    //in order to remove from Users table
                    cmd = new SqlCommand("DELETE FROM Users WHERE ID ='" + textBox_DH_ID.Text + "'", cn);

                    dr = cmd.ExecuteReader();

                    dr.Close();
                    cn.Close();


                    MessageBox.Show("*** You removed Department Head from [ " + deptName[0] + " ] SUCCESFULLY ***");
                }
                else if (dialogResult == DialogResult.No)// in case the choice was not to delete DH
                {
                    MessageBox.Show("Department Head was NOT remove from system!!!");
                    this.textBox_deptID.Clear();
                    this.textBox_DH_ID.Clear();
                }

                this.Hide();
                A_removeForSecretary.currentA_removeForSecretary.Show();


            }

            else
            {
                //means that we dont need to delete this DH from system
                if (!deptExist) //department does not exist
                {
                    MessageBox.Show("Sorry,this department does NOT exist!");
                    this.textBox_deptID.Clear();
                    this.textBox_DH_ID.Clear();

                }
                if (!userExist)// means that user does not exist
                {
                    MessageBox.Show("Sorry,this User does NOT exist!");
                    this.textBox_deptID.Clear();
                    this.textBox_DH_ID.Clear();
                }
                if (!user_DH)//means that user type not DH(!= 4)
                {
                    MessageBox.Show("Sorry,this user is NOT department head!");
                    this.textBox_deptID.Clear();
                    this.textBox_DH_ID.Clear();
                }
                if (!DH_belongDept)//means that user does not belong to this department
                {
                    MessageBox.Show("Sorry,this user does NOT belong to department!");
                    this.textBox_deptID.Clear();
                    this.textBox_DH_ID.Clear();
                }

                MessageBox.Show("Remove department head operation FAILED!!!");

            }


            //SqlConnection cn;
            //SqlCommand cmd;
            //SqlDataReader dr;

            //bool deptExist = false;
            //bool userExist = false;
            //bool user_DH = false; //check if this user is really DH (should be type 4)
            //bool DH_belongDept = false; //check if belong to fepartment

            ////check if any of the fields is empty
            //if (String.IsNullOrEmpty(textBox_deptID.Text) || String.IsNullOrEmpty(textBox_DH_ID.Text))
            //{
            //    MessageBox.Show("All fields REQIRED! please try again");

            //    this.Hide();
            //    A_removeDH_forSecretary.currentA_removeDH_forSecretaryy.Show(); 
            //}

            //cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();

            //cmd = new SqlCommand("SELECT IDdepartment,Name FROM Departments ", cn);

            //dr = cmd.ExecuteReader();

            //List<string> deptName = new List<string>();

            //while(dr.Read())//in order to check if dept exist
            //{
            //    if(dr["IDdepartment"].ToString() == textBox_deptID.Text)
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
            //while (dr.Read())
            //{
            //    if (dr["ID"].ToString() == textBox_DH_ID.Text)
            //    {
            //        userExist = true;
            //        if(dr["Type"].ToString() == "4")
            //        {
            //            user_DH = true;
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
            //while(dr.Read())
            //{
            //    if(dr["ID"].ToString() == textBox_DH_ID.Text)
            //    {
            //        if(dr["IDdepartment"].ToString() == textBox_deptID.Text)
            //        {
            //            DH_belongDept = true;
            //            break;
            //        }
            //    }


            //}
            //dr.Close();
            //cn.Close();

            //if (deptExist && userExist && user_DH && DH_belongDept)
            //{
            //    //means that we need to DELETE DH from system
            //    DialogResult dialogResult = MessageBox.Show("Sure you want to delete DH from system?", "Confirmation", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)// in case the choice was to delete DH
            //    {
            //        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //        cn.Open();
            //        //in order to remove from UsersDepartment table
            //        cmd = new SqlCommand("DELETE FROM UsersDepartment WHERE ID ='" + textBox_DH_ID.Text +"'", cn);

            //        dr = cmd.ExecuteReader();

            //        dr.Close();
            //        cn.Close();

            //        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //        cn.Open();
            //        //in order to remove from Users table
            //        cmd = new SqlCommand("DELETE FROM Users WHERE ID ='" + textBox_DH_ID.Text + "'", cn);

            //        dr = cmd.ExecuteReader();

            //        dr.Close();
            //        cn.Close();


            //        MessageBox.Show("*** You removed Department Head from [ " + deptName[0] + " ] SUCCESFULLY ***");
            //    }
            //    else if (dialogResult == DialogResult.No)// in case the choice was not to delete DH
            //    {
            //        MessageBox.Show("Department Head was NOT remove from system!!!");
            //        this.textBox_deptID.Clear();
            //        this.textBox_DH_ID.Clear();
            //    }

            //    this.Hide();
            //    A_removeForSecretary.currentA_removeForSecretary.Show();


            //}

            //else
            //{
            //    //means that we dont need to delete this DH from system
            //    if (!deptExist) //department does not exist
            //    {
            //        MessageBox.Show("Sorry,this department does NOT exist!");
            //        this.textBox_deptID.Clear();
            //        this.textBox_DH_ID.Clear();

            //    }
            //    if (!userExist)// means that user does not exist
            //    {
            //        MessageBox.Show("Sorry,this User does NOT exist!");
            //        this.textBox_deptID.Clear();
            //        this.textBox_DH_ID.Clear();
            //    }
            //    if (!user_DH)//means that user type not DH(!= 4)
            //    {
            //        MessageBox.Show("Sorry,this user is NOT department head!");
            //        this.textBox_deptID.Clear();
            //        this.textBox_DH_ID.Clear();
            //    }
            //    if(!DH_belongDept)//means that user does not belong to this department
            //    {
            //        MessageBox.Show("Sorry,this user does NOT belong to department!");
            //        this.textBox_deptID.Clear();
            //        this.textBox_DH_ID.Clear();
            //    }

            //    MessageBox.Show("Remove department head operation FAILED!!!");

            //}

        }

        private void button_BACK_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_removeForSecretary.currentA_removeForSecretary.Show(); 
        }

        private void A_removeDH_forSecretary_Load(object sender, EventArgs e)
        {
            currentA_removeDH_forSecretaryy = this;
        }
    }
}
