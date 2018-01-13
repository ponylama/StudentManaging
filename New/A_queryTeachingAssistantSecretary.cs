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
    public partial class A_queryTeachingAssistantSecretary : Form
    {
        public static A_queryTeachingAssistantSecretary currA_queryTeachingAssistantSecretary;
        DataTable data;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
        TeachingAssitant ta = new TeachingAssitant();

        public A_queryTeachingAssistantSecretary()
        {
            InitializeComponent();

            Fillcombo();

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ID teaching assistant";
            dataGridView1.Columns[1].Name = "First name";
            dataGridView1.Columns[2].Name = "Last name";
            dataGridView1.Columns[3].Name = "Department";
            dataGridView1.Columns[4].Name = "Course";
        }

        public void Fillcombo()
        {
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
            this.ta.setdeparName(comboBox1.Text);
            try
            {
                string Query = "select * from Users U where U.Type = 3 ;";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(Query, cn);
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // to show the comboBox2 - list of ta
                    this.ta.setID(Int32.Parse(dr["ID"].ToString()));
                    this.comboBox1.Items.Add(this.ta.getID());


                }
                cn.Close();
                dr.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void button1_backtpp_Click(object sender, EventArgs e)
        {
            // Back to previous page
            this.Hide();
            Aqueries.currentAqueries.Show();
        }

        private void button1_search_Click(object sender, EventArgs e)
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
                    this.ta.setID(Int32.Parse(dr["ID"].ToString()));
                    this.ta.setFirstName(dr["FirstName"].ToString());
                    this.ta.setLastName(dr["LastName"].ToString());
                    this.ta.setdeparName(dr["Departments"].ToString());
                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            // now we check the courses of the Lecturer in StaffCourses
            List<string> list = new List<string>();

            try
            {
                cn.Open();
                cmd = new SqlCommand("select C.Name from Users U ,UsersDepartment UD ,Departments D ,Courses C,StaffCourses SC where U.ID=UD.ID and UD.IDdepartment=D.IDdepartment and U.ID=SC.ID and C.IDcourse=SC.IDcourse and U.ID ='" + this.ta.getID() + "' and Type = 3", cn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // check how many courses
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
                dataGridView1.Rows.Add(ta.getID().ToString(), ta.getFirstName(), ta.getLastName(), ta.getdeparName(), "");

            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    dataGridView1.Rows.Add(ta.getID().ToString(), ta.getFirstName(), ta.getLastName(), ta.getdeparName(), list[i]);


                }
            }





        }

        private void A_queryTeachingAssistantSecretary_Load(object sender, EventArgs e)
        {
            currA_queryTeachingAssistantSecretary = this;
        }
    }
}
