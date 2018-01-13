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
    public partial class send_mass_Message_secretary_B : Form
    {
        List<int> Courses = new List<int>();
        List<string> CoursesName = new List<string>();
        List<int> StudentsID = new List<int>();
        public send_mass_Message_secretary_B()
        {
            InitializeComponent();
        }
        private void send_mass_Message_secretary_B_Load(object sender, EventArgs e)
        {

        }

        private void load_Courses_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
            connect.Open();
            if (connect.State == System.Data.ConnectionState.Open)
            {
                string FindCourses = "select * from Courses "; // search on CoursePlacement
                SqlCommand cmdCourses = new SqlCommand(FindCourses, connect); // check specific course
                SqlDataReader dataReadcourse;
                dataReadcourse = cmdCourses.ExecuteReader();
                while (dataReadcourse.Read())
                {
                    int id = Convert.ToInt32(dataReadcourse["IDcourse"]); // gets 
                    string name = (dataReadcourse["Name"].ToString());
                    Courses.Add(id);
                    CoursesName.Add(name);// add course to list of courses to student
                    this.cours_List_Box.Items.Add(id +"\t\t"+ name);
                }
            }
            connect.Close();
        }

        private void cours_List_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void send_Buttom_Click(object sender, EventArgs e)
        {
            if (cours_List_Box.SelectedIndex == -1)
                MessageBox.Show("Please select an Item first!");
            else
            {
                SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
                connect.Open();
                if (connect.State == System.Data.ConnectionState.Open)
                {
                    string find_students = "select * from StudentsCourses ";
                    SqlCommand cmdfind = new SqlCommand(find_students, connect);
                    SqlDataReader dataReadcourse;
                    dataReadcourse = cmdfind.ExecuteReader();
                    while (dataReadcourse.Read())
                    {
                        int cours_id = Convert.ToInt32(dataReadcourse["IDcourse"]);
                        if (cours_id == Courses[cours_List_Box.SelectedIndex])
                        {
                            StudentsID.Add(Convert.ToInt32(dataReadcourse["ID"]));
                        }
                    }
                    if (StudentsID.Count != 0)
                    {
                        for (int i = 0; i < StudentsID.Count; i++)
                        {
                            string command = "update Messege_Box set S_Messege = '" + message_Box.Text + "' where ID = '" + StudentsID[i] + "'";
                            SqlCommand cmd = new SqlCommand(command, connect);
                            cmd.ExecuteReader();
                        }
                        MessageBox.Show("your messege was sent to '"+ StudentsID.Count +"' students");
                    }
                    else
                        MessageBox.Show("nobody registered to this cours please select another");
                }
                connect.Close();
            }
        }
    }
}
