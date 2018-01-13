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
    public partial class A_queryStudentSecretary : Form
    {
        public A_queryStudentSecretary currentA_queryStudentSecretary;
        public A_queryStudentSecretary()
        {
            InitializeComponent();
        }
        DataTable data;

        private void button1_search_Click(object sender, EventArgs e)
        {
            // new cj=hanges
            int parsedValue;
            if (!int.TryParse(studentID_text.Text, out parsedValue))
            {
                MessageBox.Show("Course ID & Department ID can NOT contain letters! numbers only!");
                studentID_text.Clear();
                this.Hide();
                Aqueries quer = new Aqueries();
                quer.ShowDialog();


            }


            bool search = false;
            SqlConnection cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            cn.Open();
            //SqlCommand cmd = new SqlCommand("select ID,FirstName,LastName,Year,Type from Users where ID ='" + this.studentID_text.Text + "'", cn);
            SqlCommand cmd = new SqlCommand("select U.ID,U.Type,U.FirstName,U.LastName,U.[Year],D.Name from Users U ,UsersDepartment UD ,Departments D where U.ID=UD.ID and UD.IDdepartment=D.IDdepartment and U.ID ='" + this.studentID_text.Text + "'", cn);
            //SqlCommand cmd = new SqlCommand("select U.ID,U.Type,U.FirstName,U.LastName,U.[Year],D.Name,C.Name from Users U ,UsersDepartment UD ,Departments D ,Courses C,StudentsCourses SC where ((U.ID=UD.ID and UD.IDdepartment=D.IDdepartment and U.ID=SC.ID and C.IDcourse=SC.IDcourse) or (U.ID=UD.ID and UD.IDdepartment=D.IDdepartment)) and U.ID ='" + this.studentID_text.Text + "'", cn);

            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            String IDStudent, userType;

            while (dr.Read())
            {
                IDStudent = dr["ID"].ToString();
                userType = dr["Type"].ToString();
                // ~~~~~~~~~~ TO CHECK HOW NOT SHOW IN THE TABLE THE TYPE ~~~~~~~~~~~
                if (IDStudent == studentID_text.Text && userType == "1")  // if the input ID correct (in the Data Base)
                {
                    search = true;
                    break;
                }
            }

            dr.Close();
            cn.Close();

            if (search) // success - ID Student found
            {
                MessageBox.Show("Search SUCCESS!!!");
                //check for the table of courses

                cn.Open();
                //cmd = new SqlCommand("select U.ID,C.Name ,C.IDcourse from Users U  , Courses C, StudentsCourses SC where  U.ID = SC.ID and C.IDcourse = SC.IDcourse", cn);
                cmd = new SqlCommand("select * from StudentsCourses SC where SC.ID ='" + this.studentID_text.Text + "'", cn);
                dr = cmd.ExecuteReader();

                String IDCourse, idStu;
                bool flagCourse = false;
                while (dr.Read())
                {
                    idStu = dr["ID"].ToString();
                    IDCourse = dr["IDcourse"].ToString();
                    if (idStu == studentID_text.Text && IDCourse != null)
                    {
                        flagCourse = true;
                        break;
                    }
                }
                dr.Close();
                cn.Close();

                if (flagCourse)
                {
                    // for if have a courses
                    cmd = new SqlCommand("select U.ID,U.Type,U.FirstName,U.LastName,U.[Year],D.Name,C.Name, C.Credits from Users U ,UsersDepartment UD ,Departments D ,Courses C,StudentsCourses SC where U.ID=UD.ID and UD.IDdepartment=D.IDdepartment and U.ID=SC.ID and C.IDcourse=SC.IDcourse and U.ID ='" + this.studentID_text.Text + "'", cn);


                    data = new DataTable();
                    // for fill the table
                    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                    adapter1.Fill(data);   // fill the new data table
                    //to show specific course with the detail that secretary choose
                    DataView dav = new DataView(data);
                    dav.RowFilter = "Convert(ID, 'System.String') LIKE '%" + studentID_text.Text + "%'";
                    dataGridView1.DataSource = dav;
                }
                else
                {
                    // dont have courses
                    MessageBox.Show("There are not courses belongs to this student!");

                    cmd = new SqlCommand("select U.ID,U.Type,U.FirstName,U.LastName,U.[Year],D.Name from Users U ,UsersDepartment UD ,Departments D where U.ID=UD.ID and UD.IDdepartment=D.IDdepartment and U.ID ='" + this.studentID_text.Text + "'", cn);

                    data = new DataTable();
                    // for fill the table
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(data);   // fill the new data table

                    //to show specific course with the detail that secretary choose
                    DataView dv = new DataView(data);
                    dv.RowFilter = "Convert(ID, 'System.String') LIKE '%" + studentID_text.Text + "%'";
                    dataGridView1.DataSource = dv;

                }
            }


            //if (search) // success - ID Student found
            //{
            //    cmd = new SqlCommand("select U.ID,U.Type,U.FirstName,U.LastName,U.[Year],D.Name,C.Name from Users U ,UsersDepartment UD ,Departments D ,Courses C,StudentsCourses SC where U.ID=UD.ID and UD.IDdepartment=D.IDdepartment and U.ID=SC.ID and C.IDcourse=SC.IDcourse and U.ID ='" + this.studentID_text.Text + "'", cn);
            //    data = new DataTable();
            //    // for fill the table
            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //    adapter.Fill(data);   // fill the new data table

            //    MessageBox.Show("Search SUCCESS!!!");
            //    //to show specific course with the detail that secretary choose
            //    DataView dv = new DataView(data);
            //    dv.RowFilter = "Convert(ID, 'System.String') LIKE '%" + studentID_text.Text + "%'";
            //    dataGridView1.DataSource = dv;
            //    // check for the table of courses
            //    //cn.Open();
            //    //cmd = new SqlCommand("select U.ID,C.Name ,C.IDcourse from Users U  , Courses C, StudentsCourses SC where  U.ID = SC.ID and C.IDcourse = SC.IDcourse", cn);
            //    ////SqlDataReader dr;
            //    //dr = cmd.ExecuteReader();

            //    //String IDCourse;
            //    //bool flagCourse = false;
            //    //while (dr.Read())
            //    //{
            //    //    IDCourse = dr["IDcourse"].ToString();
            //    //    if (IDCourse != null)
            //    //    {
            //    //        flagCourse = true;
            //    //        break;
            //    //    }
            //    //}
            //    //dr.Close();
            //    //cn.Close();

            //    //if (flagCourse)
            //    //{ // for 
            //    //    data = new DataTable();
            //    //    // for fill the table
            //    //    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            //    //    adapter1.Fill(data);   // fill the new data table
            //    //    //to show specific course with the detail that secretary choose
            //    //    DataView dav = new DataView(data);
            //    //    dav.RowFilter = "Convert(ID, 'System.String') LIKE '%" + studentID_text.Text + "%'";
            //    //    dataGridView2.DataSource = dav;
            //    //}
            //}
            else
                MessageBox.Show("Search FAILED !!!");

            this.studentID_text.Clear();


            //bool search = false;
            //SqlConnection cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            //cn.Open();
            ////SqlCommand cmd = new SqlCommand("select ID,FirstName,LastName,Year,Type from Users where ID ='" + this.studentID_text.Text + "'", cn);
            //SqlCommand cmd = new SqlCommand("select U.ID,U.Type,U.FirstName,U.LastName,U.[Year],D.Name from Users U ,UsersDepartment UD ,Departments D where U.ID=UD.ID and UD.IDdepartment=D.IDdepartment and U.ID ='" + this.studentID_text.Text + "'", cn);
            ////SqlCommand cmd = new SqlCommand("select U.ID,U.Type,U.FirstName,U.LastName,U.[Year],D.Name,C.Name from Users U ,UsersDepartment UD ,Departments D ,Courses C,StudentsCourses SC where ((U.ID=UD.ID and UD.IDdepartment=D.IDdepartment and U.ID=SC.ID and C.IDcourse=SC.IDcourse) or (U.ID=UD.ID and UD.IDdepartment=D.IDdepartment)) and U.ID ='" + this.studentID_text.Text + "'", cn);

            //SqlDataReader dr;
            //dr = cmd.ExecuteReader();

            //String IDStudent, userType;

            //while (dr.Read())
            //{
            //    IDStudent = dr["ID"].ToString();
            //    userType = dr["Type"].ToString();
            //    // ~~~~~~~~~~ TO CHECK HOW NOT SHOW IN THE TABLE THE TYPE ~~~~~~~~~~~
            //    if (IDStudent == studentID_text.Text && userType == "1")  // if the input ID correct (in the Data Base)
            //    {
            //        search = true;
            //        break;
            //    }
            //}

            //dr.Close();
            //cn.Close();

            //if (search) // success - ID Student found
            //{
            //    MessageBox.Show("Search SUCCESS!!!");
            //    //check for the table of courses

            //   cn.Open();
            //    //cmd = new SqlCommand("select U.ID,C.Name ,C.IDcourse from Users U  , Courses C, StudentsCourses SC where  U.ID = SC.ID and C.IDcourse = SC.IDcourse", cn);
            //    cmd = new SqlCommand("select * from StudentsCourses SC where SC.ID ='" + this.studentID_text.Text + "'", cn);
            //    dr = cmd.ExecuteReader();

            //    String IDCourse, idStu;
            //    bool flagCourse = false;
            //    while (dr.Read())
            //    {
            //        idStu = dr["ID"].ToString();
            //        IDCourse = dr["IDcourse"].ToString();
            //        if (idStu== studentID_text.Text && IDCourse != null)
            //        {
            //            flagCourse = true;
            //            break;
            //        }
            //    }
            //    dr.Close();
            //    cn.Close();

            //    if (flagCourse)
            //    { 
            //      // for if have a courses
            //      cmd = new SqlCommand("select U.ID,U.Type,U.FirstName,U.LastName,U.[Year],D.Name,C.Name, C.Credits from Users U ,UsersDepartment UD ,Departments D ,Courses C,StudentsCourses SC where U.ID=UD.ID and UD.IDdepartment=D.IDdepartment and U.ID=SC.ID and C.IDcourse=SC.IDcourse and U.ID ='" + this.studentID_text.Text + "'", cn);


            //        data = new DataTable();
            //        // for fill the table
            //        SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            //        adapter1.Fill(data);   // fill the new data table
            //        //to show specific course with the detail that secretary choose
            //        DataView dav = new DataView(data);
            //        dav.RowFilter = "Convert(ID, 'System.String') LIKE '%" + studentID_text.Text + "%'";
            //        dataGridView1.DataSource = dav;
            //    }
            //    else
            //    {
            //        // dont have courses
            //        MessageBox.Show("There are not courses belongs to this student!");

            //        cmd = new SqlCommand("select U.ID,U.Type,U.FirstName,U.LastName,U.[Year],D.Name from Users U ,UsersDepartment UD ,Departments D where U.ID=UD.ID and UD.IDdepartment=D.IDdepartment and U.ID ='" + this.studentID_text.Text + "'", cn);

            //        data = new DataTable();
            //        // for fill the table
            //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //        adapter.Fill(data);   // fill the new data table

            //        //to show specific course with the detail that secretary choose
            //        DataView dv = new DataView(data);
            //        dv.RowFilter = "Convert(ID, 'System.String') LIKE '%" + studentID_text.Text + "%'";
            //        dataGridView1.DataSource = dv;

            //    }
            //}


            ////if (search) // success - ID Student found
            ////{
            ////    cmd = new SqlCommand("select U.ID,U.Type,U.FirstName,U.LastName,U.[Year],D.Name,C.Name from Users U ,UsersDepartment UD ,Departments D ,Courses C,StudentsCourses SC where U.ID=UD.ID and UD.IDdepartment=D.IDdepartment and U.ID=SC.ID and C.IDcourse=SC.IDcourse and U.ID ='" + this.studentID_text.Text + "'", cn);
            ////    data = new DataTable();
            ////    // for fill the table
            ////    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            ////    adapter.Fill(data);   // fill the new data table

            ////    MessageBox.Show("Search SUCCESS!!!");
            ////    //to show specific course with the detail that secretary choose
            ////    DataView dv = new DataView(data);
            ////    dv.RowFilter = "Convert(ID, 'System.String') LIKE '%" + studentID_text.Text + "%'";
            ////    dataGridView1.DataSource = dv;
            ////    // check for the table of courses
            ////    //cn.Open();
            ////    //cmd = new SqlCommand("select U.ID,C.Name ,C.IDcourse from Users U  , Courses C, StudentsCourses SC where  U.ID = SC.ID and C.IDcourse = SC.IDcourse", cn);
            ////    ////SqlDataReader dr;
            ////    //dr = cmd.ExecuteReader();

            ////    //String IDCourse;
            ////    //bool flagCourse = false;
            ////    //while (dr.Read())
            ////    //{
            ////    //    IDCourse = dr["IDcourse"].ToString();
            ////    //    if (IDCourse != null)
            ////    //    {
            ////    //        flagCourse = true;
            ////    //        break;
            ////    //    }
            ////    //}
            ////    //dr.Close();
            ////    //cn.Close();

            ////    //if (flagCourse)
            ////    //{ // for 
            ////    //    data = new DataTable();
            ////    //    // for fill the table
            ////    //    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            ////    //    adapter1.Fill(data);   // fill the new data table
            ////    //    //to show specific course with the detail that secretary choose
            ////    //    DataView dav = new DataView(data);
            ////    //    dav.RowFilter = "Convert(ID, 'System.String') LIKE '%" + studentID_text.Text + "%'";
            ////    //    dataGridView2.DataSource = dav;
            ////    //}
            ////}
            //else
            //    MessageBox.Show("Search FAILED !!!");

            //this.studentID_text.Clear();
        }

        private void backtpp_btn_Click(object sender, EventArgs e)
        {
            Aqueries.currentAqueries.Show();
            // Back to previous page
            this.Hide();
           
        }

        private void A_queryStudentSecretary_Load(object sender, EventArgs e)
        {
            currentA_queryStudentSecretary = this;
        }
    }
}
