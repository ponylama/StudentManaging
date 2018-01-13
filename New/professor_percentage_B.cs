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
    public partial class professor_percentage_B : Form
    {
        ProfessorClass PC;
        List<int> Courses = new List<int>();
        List<string> CoursesName = new List<string>();
        List<int> StudentsID = new List<int>();
        public ProfessorClass passValue
        {
            get { return PC; }
            set { PC = value; }
        }


        public professor_percentage_B()
        {
            InitializeComponent();


        }
        public string Connecting_String = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;MultipleActiveResultSets=true;User ID=P17;Password=Hadas@2017";

        private void button1_Click(object sender, EventArgs e)
        {
            update();
        }

        private void professor_percentage_B_Load(object sender, EventArgs e)
        {
            Show_Courses();
        }
        public bool Show_Courses()
        {
            SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
            connect.Open();
            if (connect.State == System.Data.ConnectionState.Open)
            {
                string FindCourses = "select * from StaffCourses where ID = '" + PC.getID() + "'"; // search on CoursePlacement
                SqlCommand cmdCourses = new SqlCommand(FindCourses, connect); // check specific course
                SqlDataReader dataReadcourse;
                dataReadcourse = cmdCourses.ExecuteReader();
                while (dataReadcourse.Read())
                {
                    int id = Convert.ToInt32(dataReadcourse["IDcourse"]); // gets 
                    Courses.Add(id);
                    this.cours_List_Box.Items.Add(id);
                }
            }
            connect.Close();
            return true;
        }
        public void update()
        {
            if (cours_List_Box.SelectedIndex != -1 || id_list_Box.SelectedIndex != -1)
            {
                string Query2 = "update Professor_Box set Attendance = '" + PercentageBox.Text + "' WHERE StudentID= '" + Convert.ToInt32(id_list_Box.SelectedItem.ToString()) + "' and CourseID= '" + Convert.ToInt32(cours_List_Box.SelectedItem.ToString()) + "'";
                SqlConnection conDatabase = new SqlConnection(Connecting_String);
                SqlCommand cmdDatabase = new SqlCommand(Query2, conDatabase);
                SqlDataReader myReader;
                try
                {
                    conDatabase.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("update completed");
            }
            else
                MessageBox.Show("please choose student and cours");
        }

        private void cours_List_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_list_Box.Items.Clear();
            SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
            connect.Open();
            if (connect.State == System.Data.ConnectionState.Open)
            {
                string FindCourses = "select * from StudentLec_B where courseID = '" + Courses[cours_List_Box.SelectedIndex] + "'"; // search on CoursePlacement
                SqlCommand cmdCourses = new SqlCommand(FindCourses, connect); // check specific course
                SqlDataReader dataReadcourse;
                dataReadcourse = cmdCourses.ExecuteReader();
                while (dataReadcourse.Read())
                {
                    int studid = Convert.ToInt32(dataReadcourse["ID_Student"]); // gets 
                    StudentsID.Add(studid);
                    this.id_list_Box.Items.Add(studid);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
