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
    public partial class A_ScaduilngClassForExam_Secretary : Form
    {
        public static A_ScaduilngClassForExam_Secretary CURRENTA_ScaduilngClassForExam_Secretary;

        string ExD;
        string hour;
        string period;
        string ExamN;
        int count = 0;
        int index = 0;
        int tempindex = 0;
        int j = 0;
        
        SqlConnection cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
        public A_ScaduilngClassForExam_Secretary()
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



            SqlCommand cmd;
            SqlDataReader dr;

            //check that fields are not empty
            if (String.IsNullOrEmpty(comboBox2_ClassNum.Text) || String.IsNullOrEmpty(comboBox1_examName.Text) || String.IsNullOrEmpty(comboBox3_examHour.Text))
            {
                MessageBox.Show("All fields REQIRED! please try again");

                this.Hide();
                A_ScaduilngClassForExam_Secretary.CURRENTA_ScaduilngClassForExam_Secretary.Show();

            }
            if (String.IsNullOrEmpty(comboBox2_ClassNum.Text))
            {



                cn.Open();
                SqlCommand cmd1 = cn.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = cmd1.CommandText = "select ExamDate, hour from HeadDepartmentExamList where ExamName='" + comboBox1_examName.SelectedItem.ToString() + "'";
                cmd1.Connection = cn;
                dr = cmd1.ExecuteReader();


                if ((dr["ExamDate"].ToString() != "") && (dr["hour"].ToString() != ""))
                {
                    ExD = dr["ExamDate"].ToString();
                    hour = dr["hour"].ToString();
                    ExamN = dr["ExamNum"].ToString();
                }




                cn.Close();
                dr.Close();
            }
            cn.Open();
            SqlCommand cmd2 = cn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = cmd2.CommandText = "select * from [HeadDepartmentExamList]"; 
            cmd2.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
            da1.Fill(dt1);
           
            
            foreach (DataRow dr1 in dt1.Rows)
            {
                if(ExamN== dr1["ExamNum"].ToString())
                {
                   // if (dr1["ExamName"].ToString() == comboBox1_examName.SelectedItem.ToString())
                   // {
                        index = tempindex + 1;
                   // }
                    
                }
                tempindex++;
            }
            for ( j = 0; j < dt1.Rows.Count; j++)
            {
                if(j != index)
                {
                    if (dt1.Rows[j]["ExamDate"].ToString() == ExD)
                    {
                        if (dt1.Rows[j]["hour"].ToString() == hour)
                        {
                            if (dt1.Rows[j]["ExamName"].ToString() == ExamN)
                                count++;
                        }
                    } 
                }
                
            }
            cn.Close();




            if ((count == 0))
            {


                cn.Open();


                SqlDataAdapter da = new SqlDataAdapter("UPDATE HeadDepartmentExamList SET hour='" + comboBox3_examHour.SelectedItem.ToString() + "',class='" + comboBox2_ClassNum.SelectedItem.ToString() + "'WHERE ExamName='" + comboBox1_examName.SelectedItem.ToString() + "'", cn);
                da.SelectCommand.ExecuteNonQuery();

                SqlDataAdapter da2 = new SqlDataAdapter("UPDATE Classes SET examsPeriod='" + "V" + "'WHERE NumClass='" + comboBox2_ClassNum.SelectedItem.ToString() + "'", cn);
                da2.SelectCommand.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show(" The Exam has been signed in Class successfully!!");
                this.Hide();
                comboBox2_ClassNum.Items.Clear();
                comboBox1_examName.Items.Clear();
                comboBox3_examHour.Items.Clear();
                A_ScaduilngClassForExam_Secretary sec = new A_ScaduilngClassForExam_Secretary();/*.CURRENTA_ScaduilngClassForExam_Secretary.Show()*/
                sec.ShowDialog();
            }
            else
            {



                MessageBox.Show(" Exam collisin , Schedual Class for Exam has FAILED!");
                A_ScaduilngClassForExam_Secretary.CURRENTA_ScaduilngClassForExam_Secretary.Show();
            }
        }

        private void A_ScaduilngClassForExam_Secretary_Load(object sender, EventArgs e)
        {
            CURRENTA_ScaduilngClassForExam_Secretary = this;
            comboBox1_examName.Items.Clear();
            comboBox2_ClassNum.Items.Clear();
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ExamName from HeadDepartmentExamList";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1_examName.Items.Add(dr["ExamName"].ToString());

            }
            cn.Close();


            cn.Open();
            SqlCommand cmd1 = cn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select *from [Classes]";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            
            
           
            foreach (DataRow dr in dt1.Rows )
            {
                period = Convert.ToString(dr["examsPeriod"].ToString());
                if (period != "")
                {
                        comboBox2_ClassNum.Items.Add(dr["NumClass"].ToString());
                }
                else
                {
                    continue;
                }

            }
            cn.Close();


        }

      
    }
}
