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
    public partial class A_remove_TA_DH : Form
    {
        public static A_remove_TA_DH currA_remove_TA_DH;
        HeadDepartment dep;
        public A_remove_TA_DH(HeadDepartment hd)
        {
            InitializeComponent();
            //this.dep = new HeadDepartment();
            this.dep = hd;
        }

        private void button_BACK_Click(object sender, EventArgs e)
        {
            this.Hide();
            //A_DHremove back = new A_DHremove();
            A_DHremove.currentA_DHremove.Show();
        }

        private void button_SUBMIT_Click(object sender, EventArgs e)
        {
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;

            bool flag = false;
            bool coursFlag = false;

            if (String.IsNullOrEmpty(textBox_TA_ID.Text)) // check if the field is empty
            {
                MessageBox.Show("All fields REQIRED! please try again");
                //in case its empty
                this.Hide();
                //A_remove_TA_DH rem = new A_remove_TA_DH();
                A_remove_TA_DH.currA_remove_TA_DH.Show();

            }


            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            cn.Open();

            cmd = new SqlCommand("SELECT * FROM StaffCourses ", cn);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                if (dr["ID"].ToString() == textBox_TA_ID.Text)
                {
                    coursFlag = true;
                    break;
                }

            }
            dr.Close();




            cmd = new SqlCommand("SELECT * FROM Users ", cn);

            dr = cmd.ExecuteReader();

            List<string> TA_Name = new List<string>();

            while (dr.Read())
            {
                string UserType = dr["Type"].ToString();
                if (dr["ID"].ToString() == textBox_TA_ID.Text && UserType=="3")
                {

                    TA_Name.Add(dr["FirstName"].ToString());
                    flag = true;
                    break;
                }

            }
            dr.Close();
            cn.Close();

            if (coursFlag == true)
            {
                MessageBox.Show("this Teacing assistant associated with course \n if you want to remove this teaching assistant you need to remove his association before.");
                this.textBox_TA_ID.Clear();
            }
            else
            {
                if (flag)
                {


                    MessageBox.Show("Teaching Assistant ID: " + textBox_TA_ID.Text + "\n" + "Teaching Assistant name: " + TA_Name[0]);
                    DialogResult dialogResult = MessageBox.Show("Sure you want to delete this Teaching Assistant?", "Confirmation", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                        cn.Open();

                        SqlCommand cmd2 = new SqlCommand("DELETE FROM UsersDepartment WHERE ID" + "='" + textBox_TA_ID.Text + "'", cn);
                        dr = cmd2.ExecuteReader();
                        dr.Close();
                        cmd = new SqlCommand("DELETE FROM Users WHERE ID" + "='" + textBox_TA_ID.Text + "'", cn);
                        dr = cmd.ExecuteReader();
                        dr.Close();

                        cn.Close();
                        MessageBox.Show("Teaching Assistant [ " + TA_Name[0] + "] deleted SUCCESSFULLY!");
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("Teaching Assistant [ " + TA_Name[0] + "] was NOT deleted");
                        this.textBox_TA_ID.Clear();
                    }


                }

                else
                {

                    MessageBox.Show("Teaching Assistant was NOT found!!!!");
                    this.textBox_TA_ID.Clear();

                }
            }


            
        }

        private void A_remove_TA_DH_Load(object sender, EventArgs e)
        {
            currA_remove_TA_DH = this;
        }
    }
}
