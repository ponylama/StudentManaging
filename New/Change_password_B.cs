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
    public partial class Change_password_B : Form
    {
        List<string> StudentName = new List<string>();
        List<int> StudentsID = new List<int>();
        public Change_password_B()
        {
            InitializeComponent();
        }

        private void ID_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void Change_Password_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
            connect.Open();
            if (id_list_Box.SelectedIndex != 0)
            {
                if (connect.State == System.Data.ConnectionState.Open)
                {
                    if (Password_Box.Text == password_Box2.Text)
                    {
                        if (MessageBox.Show("Are you sure you want to Change your password", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            MessageBox.Show("Canselling");
                        }
                        else
                        {
                            string command = "update Users set Password='" + Password_Box.Text + "' where ID='" + StudentsID[id_list_Box.SelectedIndex] + "'";
                            SqlCommand cmd = new SqlCommand(command, connect);
                            cmd.ExecuteReader();
                            MessageBox.Show("Password Changed");
                            this.Hide();
                        }
                    }
                    else
                        MessageBox.Show("Sorry please fill same password");
                }
            }
            else
                MessageBox.Show("please choose User");

        }

        private void button_Yellow1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Change_password_B_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
            connect.Open();
            if (connect.State == System.Data.ConnectionState.Open)
            {
                string FindCourses = "select * from Users "; // search on CoursePlacement
                SqlCommand cmdCourses = new SqlCommand(FindCourses, connect); // check specific course
                SqlDataReader dataReadcourse;
                dataReadcourse = cmdCourses.ExecuteReader();
                while (dataReadcourse.Read())
                {
                    int id = Convert.ToInt32(dataReadcourse["ID"]); // gets 
                    string name = (dataReadcourse["FirstName"].ToString());
                    StudentsID.Add(id);
                    StudentName.Add(name);// add course to list of courses to student
                    id_list_Box.Items.Add(id + "\t" + name);
                }
            }
            connect.Close();
        }
    }
}
