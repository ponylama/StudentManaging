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
    public partial class Professor_Student_List_B : Form
    {
        public static Professor_Student_List_B CURRENTProfessor_Student_List_B;
        int CourseID = 0;
        ProfessorClass pc;
        public string Connecting_String = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;MultipleActiveResultSets=true;User ID=P17;Password=Hadas@2017";
        public ProfessorClass profValue
        {
            get { return pc; }
            set { pc = value; }
        }
        List<int> Courses = new List<int>();
        List<string> CoursesName = new List<string>();
        List<int> StudentsID = new List<int>();
        public Professor_Student_List_B()
        {
            InitializeComponent();
        }

        private void Professor_Student_List_B_Load(object sender, EventArgs e)
        {
            int profID = Convert.ToInt32(pc.getID());
            string FindStaffCourses = "select * from StaffCourses where ID = '" + profID + "'";
            SqlConnection connect = new SqlConnection(Connecting_String);
            SqlCommand cmdStaffCourses = new SqlCommand(FindStaffCourses, connect);
            SqlDataReader dataReadcourse;
            connect.Open();
            if (connect.State == System.Data.ConnectionState.Open)
            {
                dataReadcourse = cmdStaffCourses.ExecuteReader();
                while (dataReadcourse.Read())
                {
                    CourseID = dataReadcourse.GetInt32(2);
                }
                connect.Close();

                SqlConnection connect2 = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
                connect2.Open();
                if (connect2.State == System.Data.ConnectionState.Open)
                {
                    string find_students = "select * from StudentsCourses ";
                    SqlCommand cmdfind = new SqlCommand(find_students, connect2);
                    dataReadcourse = cmdfind.ExecuteReader();
                    while (dataReadcourse.Read())
                    {
                        if (Convert.ToInt32(dataReadcourse["IDcourse"]) == CourseID)
                        {

                            StudentsID.Add(Convert.ToInt32(dataReadcourse["ID"]));
                        }
                    }
                    if (StudentsID.Count != 0)
                    {
                        for (int i = 0; i < StudentsID.Count; i++)
                        {
                            listBox1.Items.Add(StudentsID[i]);
                        }
                    }
                    else
                        MessageBox.Show("nobody registered to this cours please select another");
                }
                connect2.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
