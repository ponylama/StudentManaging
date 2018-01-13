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
    public partial class A_InsertConditionTermsForCourse : Form
    {
        public static A_InsertConditionTermsForCourse currentA_InsertConditionTermsForCourse;
        SqlConnection cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
        public A_InsertConditionTermsForCourse Currentinsert;
        public A_InsertConditionTermsForCourse()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {

            SqlCommand cmd;
            SqlDataReader dr;
            bool PreCon = false;
            bool IsCourse = false;



            if (String.IsNullOrWhiteSpace(comboBox1_CourseName.Text) || String.IsNullOrWhiteSpace(comboBox2PreCondition.Text))
            {
                MessageBox.Show("The COURSE field REQIRED!! please try again");
                this.comboBox1_CourseName.Items.Clear();
                this.comboBox2PreCondition.Items.Clear();
                this.Hide();
                A_InsertConditionTermsForCourse.currentA_InsertConditionTermsForCourse.Show();
            }


            cn.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select *from [Courses]";
            cmd.Connection = cn;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {


                if (dr["Name"].ToString() == comboBox1_CourseName.Text)//if the course exist
                {
                    IsCourse = true;

                    //NO MACH PRE CONDITON OR NO PRE-CON EXIST.
                    if (dr["PreCondition"].ToString() == "")
                    {
                        PreCon = true;
                        break;
                    }
                }
              

            }
            dr.Close();
            cn.Close();

            if (!PreCon)
            {
                MessageBox.Show("the pre conditon allready exist!!");
                this.comboBox1_CourseName.Items.Clear();
                this.comboBox2PreCondition.Items.Clear();
               
            }


            if (PreCon && IsCourse)
            {
                cn.Open();
                cmd.CommandType = CommandType.Text;
                cmd = new SqlCommand("UPDATE  Courses SET PreCondition='" + comboBox2PreCondition.Text + "' WHERE Name='" + comboBox1_CourseName.Text + "'", cn);
                cmd.Parameters.AddWithValue("@PreCondition", comboBox2PreCondition.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Record inserted successfully");
                this.comboBox1_CourseName.Items.Clear();
                this.comboBox2PreCondition.Items.Clear();

               this.Hide();
                A_menuForSecretary.CurrentA_menuForSecretary.Show();


            }
            if (!IsCourse&& PreCon)
            {
                MessageBox.Show("no recored found for this course - not register in the db!!");
                this.comboBox1_CourseName.Items.Clear();
                this.comboBox2PreCondition.Items.Clear();
               
            }

            if (IsCourse && !PreCon)
            {
                MessageBox.Show(" already has a pre condition'"+ dr["PreCondition"].ToString()+"!!");
                this.comboBox1_CourseName.Items.Clear();
                this.comboBox2PreCondition.Items.Clear();
               
            }
        }

        private void A_InsertConditionTermsForCourse_Load(object sender, EventArgs e)
        {
            currentA_InsertConditionTermsForCourse = this;
            comboBox1_CourseName.Items.Clear();
            comboBox2PreCondition.Items.Clear();
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Name from Courses";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1_CourseName.Items.Add(dr["Name"].ToString());
                comboBox2PreCondition.Items.Add(dr["Name"].ToString());

            }
            cn.Close();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            A_insertForSecretary.CURRENTA_insertForSecretary.Show();
            this.Hide();
        }
    }
}










