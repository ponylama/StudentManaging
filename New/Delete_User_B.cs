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
    
    public partial class Delete_User_B : Form
    {
        List<string> Name_List = new List<string>();
        List<int> ID_List = new List<int>();
        public Delete_User_B()
        {
            InitializeComponent();
        }
       
        private void button_Yellow1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Delete_User_click_Click(object sender, EventArgs e)
        {

            SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
            connect.Open();
            if (connect.State == System.Data.ConnectionState.Open)
            {
                if (User_List.SelectedIndex == -1)
                    MessageBox.Show("Please select an Item first!");
                else
                {
                    if (MessageBox.Show("Are you sure you want to Delete This user", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        MessageBox.Show("Canselling");
                    }
                    else
                    {
                        string Delete_From_UsersDepartment = "DELETE from UsersDepartment where ID = '" + ID_List[User_List.SelectedIndex] + "'";
                        SqlCommand cmd3 = new SqlCommand(Delete_From_UsersDepartment, connect);
                        cmd3.ExecuteNonQuery();
                        
                        string Delete_From_Messege_Box = "DELETE from Messege_Box where ID = '" + ID_List[User_List.SelectedIndex] + "'";
                        SqlCommand cmd2 = new SqlCommand(Delete_From_Messege_Box, connect);
                        cmd2.ExecuteNonQuery();

                        string Delete_From_Users = "DELETE from Users where ID = '" + ID_List[User_List.SelectedIndex] + "'";
                        SqlCommand cmd = new SqlCommand(Delete_From_Users, connect);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            connect.Close();
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
                    ID_List.Add(id);
                    Name_List.Add(name);// add course to list of courses to student
                    this.User_List.Items.Add(id + "\t" + name);
                }
            }
            connect.Close();
        }

        private void Delete_User_B_Load(object sender, EventArgs e)
        {

        }

        private void Are_You_Shure_CheckedChanged(object sender, EventArgs e)
        {
            if (Are_You_Shure.Checked)
                Delete_Button.Show();
            else
                Delete_Button.Hide();
        }
    }
}
