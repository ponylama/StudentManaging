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
    public partial class Change_User_Name : Form
    {
        static int changeStatus = 0;
        List<string> Name_List = new List<string>();
        List<string> Last_Name_List = new List<string>();
        List<int> ID_List = new List<int>();
        public Change_User_Name()
        {
            InitializeComponent();
        }
        private void Change_User_Name_Load(object sender, EventArgs e)
        {
            Write_Box.Hide();
            name_Label.Hide();
            Change_button.Hide();
        }
        private void Refresh_Button_Click(object sender, EventArgs e)
        {
            ID_List.Clear();
            Name_List.Clear();
            this.User_List.Items.Clear();
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
                    string last_name = (dataReadcourse["LastName"].ToString());
                    ID_List.Add(id);
                    Last_Name_List.Add(last_name);
                    Name_List.Add(name);// add course to list of courses to student
                    this.User_List.Items.Add(id + "\t" + name +" "+last_name);
                }
            }
            connect.Close();
        }
        private void Change_LastName_Click(object sender, EventArgs e)
        {
            if (User_List.SelectedIndex == -1)
                MessageBox.Show("Please select any user first");
            else
            {
                changeStatus = 2;
                Write_Box.Show();
                name_Label.Show();
                name_Label.Text = "Please Enter new last name :";
                Change_button.Show();
            }
        }
        private void Change_Name_Click(object sender, EventArgs e)
        {
            if (User_List.SelectedIndex == -1)
                MessageBox.Show("Please select any user first");
            else
            {
                changeStatus = 1;
                Write_Box.Show();
                name_Label.Show();
                name_Label.Text = "Please Enter new first name :";
                Change_button.Show();
            }
        }

        private void Change_button_Click(object sender, EventArgs e)
        {

                SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
                connect.Open();
                if (connect.State == System.Data.ConnectionState.Open)
                {
                    string command = "";
                if (changeStatus == 1)
                {
                    command = "update Users set FirstName='" + Write_Box.Text + "' where ID='" + ID_List[User_List.SelectedIndex] + "'";
                    if (MessageBox.Show("Are you sure you want to change " + Name_List[User_List.SelectedIndex] + " to " + Write_Box.Text + "", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        MessageBox.Show("Canselling");
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand(command, connect);
                        cmd.ExecuteReader();
                        
                    }
                }
                else if (changeStatus == 2)
                {
                    command = "update Users set LastName='" + Write_Box.Text + "' where ID='" + ID_List[User_List.SelectedIndex] + "'";
                    if (MessageBox.Show("Are you sure you want to change " + Last_Name_List[User_List.SelectedIndex] + " to " + Write_Box.Text + "", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        MessageBox.Show("Canselling");
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand(command, connect);
                        cmd.ExecuteReader();
                        MessageBox.Show("your last name was changeed");
                    }
                }
            }
            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
