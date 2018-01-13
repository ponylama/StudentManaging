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
    public partial class A_QueryLecturer_secretary : Form
    {
        public static A_QueryLecturer_secretary currA_QueryLecturer_secretary;
        DataTable data;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
        Lecturer lec = new Lecturer();

        public A_QueryLecturer_secretary()
        {
            InitializeComponent();
            Fillcombo();

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ID lecturer";
            dataGridView1.Columns[1].Name = "First name";
            dataGridView1.Columns[2].Name = "Last name";
            dataGridView1.Columns[3].Name = "Department";
            dataGridView1.Columns[4].Name = "Course";
        }

        public void Fillcombo()
        {
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
            this.lec.setdeparName(comboBox1.Text);
            try
            {
                string Query = "select * from Users U where U.Type = 2 ;";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(Query, cn);
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // to show the comboBox2 - list of lecturer
                    this.lec.setID(Int32.Parse(dr["ID"].ToString()));
                    this.comboBox1.Items.Add(this.lec.getID());
                    //this.lec.setFirstName(dr["FirstName"].ToString());
                    //this.lec.setLastName(dr["LastName"].ToString());
                    //comboBox1.Items.Add(this.lec.mergetoOne(this.lec.getFirstName(), this.lec.getLastName()));

                }
                cn.Close();
                dr.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //to clear the data grid
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            try
            {
                cn.Open();
                cmd = new SqlCommand("select U.ID , U.FirstName , U.LastName , U.Departments from Users U where U.ID = '" + this.comboBox1.Text + "'", cn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // keep the details of the Lecturer and the department
                    this.lec.setID(Int32.Parse(dr["ID"].ToString()));
                    this.lec.setFirstName(dr["FirstName"].ToString());
                    this.lec.setLastName(dr["LastName"].ToString());
                    this.lec.setdeparName(dr["Departments"].ToString());
                }

                dr.Close();
                cn.Close();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

            // now we check the courses of the Lecturer in StaffCourses
            int sizeArr = 0;
            List<string> list = new List<string>();

            try
            {
                cn.Open();
                cmd = new SqlCommand("select C.Name from Users U ,UsersDepartment UD ,Departments D ,Courses C,StaffCourses SC where U.ID=UD.ID and UD.IDdepartment=D.IDdepartment and U.ID=SC.ID and C.IDcourse=SC.IDcourse and U.ID ='" + this.lec.getID() + "' and Type = 2", cn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // check how many courses
                    sizeArr++;
                    list.Add(dr["Name"].ToString());
                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


            data = new DataTable();
            // for fill the table
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            adapter1.Fill(data);   // fill the new data table
                                   //to show specific course with the detail that secretary choose
            DataView dav = new DataView(data);
            //dav.RowFilter = "Convert(ID, 'System.String') LIKE '%" + this.lec.getID() + "%'";
            //dataGridView1.DataSource = dav;

            if (list.Count == 0)
            {
                dataGridView1.Rows.Add(lec.getID().ToString(), lec.getFirstName(), lec.getLastName(), lec.getdeparName() , "");

            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    dataGridView1.Rows.Add(lec.getID().ToString(), lec.getFirstName(), lec.getLastName(), lec.getdeparName(), list[i]);


                }
            }





        }


        // Back to previous page
        private void button2_Click(object sender, EventArgs e)
        {
            // Back to previous page
            this.Hide();
            Aqueries.currentAqueries.Show();
        }

        private void A_QueryLecturer_secretary_Load(object sender, EventArgs e)
        {
            currA_QueryLecturer_secretary = this;
        }
    }
}
