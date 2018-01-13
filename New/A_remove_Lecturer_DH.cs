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
    public partial class A_remove_Lecturer_DH : Form
    {
        public static A_remove_Lecturer_DH currentA_remove_Lecturer_DH;
        HeadDepartment dep;

        public A_remove_Lecturer_DH(HeadDepartment hd)
        {
            InitializeComponent();
           // this.dep = new HeadDepartment();
            this.dep = hd;
        }

        private void button_SUBMIT_Click(object sender, EventArgs e)
        {
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;

            bool flag = false;
            bool coursFlag = false;

            if (String.IsNullOrEmpty(textBox_lecturerID.Text)) // check if the field is empty
            {
                MessageBox.Show("All fields REQIRED! please try again");
                //in case its empty
                this.Hide();
                //A_remove_Lecturer_DH rem = new A_remove_Lecturer_DH();
                A_remove_Lecturer_DH.currentA_remove_Lecturer_DH.Show();

            }


            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            cn.Open();


            cmd = new SqlCommand("SELECT * FROM StaffCourses ", cn);

            dr = cmd.ExecuteReader();

            

            while (dr.Read())
            {
                
                if (dr["ID"].ToString() == textBox_lecturerID.Text)
                {
                    coursFlag = true;
                    break;
                }

            }
            dr.Close();







            cmd = new SqlCommand("SELECT * FROM Users ", cn);

            dr = cmd.ExecuteReader();

            List<string> lecName = new List<string>();

            while (dr.Read())
            {
                string UserType = dr["Type"].ToString();
                if (dr["ID"].ToString() == textBox_lecturerID.Text && UserType=="2")
                {

                    lecName.Add(dr["FirstName"].ToString());
                    flag = true;
                    break;
                }

            }
            dr.Close();
            cn.Close();

            if (coursFlag == true)
            {
                MessageBox.Show("this lecturer associated with course \n if you want to remove this lecturer you need to remove his association before.");
                this.textBox_lecturerID.Clear();
            }
            else
            {

                if (flag)
                {


                    MessageBox.Show("Lecturer ID: " + textBox_lecturerID.Text + "\n" + "Lecturer name: " + lecName[0]);
                    DialogResult dialogResult = MessageBox.Show("Sure you want to delete this Lecturer?", "Confirmation", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
                        cn.Open();

                        SqlCommand cmd2 = new SqlCommand("DELETE FROM UsersDepartment WHERE ID" + "='" + textBox_lecturerID.Text + "'", cn);
                        dr = cmd2.ExecuteReader();
                        dr.Close();
                        cmd = new SqlCommand("DELETE FROM Users WHERE ID" + "='" + textBox_lecturerID.Text + "'", cn);
                        dr = cmd.ExecuteReader();
                        dr.Close();

                        cn.Close();
                        MessageBox.Show("Lecturer [ " + lecName[0] + "] deleted SUCCESSFULLY!");
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("Lecturer [ " + lecName[0] + "] was NOT deleted");
                        this.textBox_lecturerID.Clear();
                    }


                }

                else
                {

                    MessageBox.Show("Lecturer was NOT found!!!!");
                    this.textBox_lecturerID.Clear();

                }
            }

        }

        private void button_BACK_Click(object sender, EventArgs e)
        {
            this.Hide();
            //A_DHremove back = new A_DHremove();
            A_DHremove.currentA_DHremove.Show(); 
           
        }

        private void A_remove_Lecturer_DH_Load(object sender, EventArgs e)
        {
            currentA_remove_Lecturer_DH = this;
        }
    }
}
