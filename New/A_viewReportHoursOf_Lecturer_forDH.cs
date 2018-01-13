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
    public partial class A_viewReportHoursOf_Lecturer_forDH : Form
    {
        public static A_viewReportHoursOf_Lecturer_forDH currentA_viewReportHoursOf_Lecturer_forDH;
        HeadDepartment dep;

        public HeadDepartment passValue
        {
            get { return dep; }
            set { dep = value; }
        }

        public A_viewReportHoursOf_Lecturer_forDH(HeadDepartment hd)
        {
            InitializeComponent();
           // this.dep = new HeadDepartment();
            this.dep = hd;
        }

        private void button_BACK_Click(object sender, EventArgs e)
        {
            this.Hide();
            //A_DHview back = new A_DHview();
            A_DHview.currentA_DHview.Show();
        }

        private void button_view_Click(object sender, EventArgs e)
        {
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            SqlDataAdapter da;

            if (String.IsNullOrEmpty(textBox_deptID.Text))
            {
                MessageBox.Show("*** ID department required! ***");
                this.textBox_deptID.Clear();

                this.Hide();
                //A_viewReportHoursOf_Lecturer_forDH view = new A_viewReportHoursOf_Lecturer_forDH();
                A_viewReportHoursOf_Lecturer_forDH.currentA_viewReportHoursOf_Lecturer_forDH.Show();

            }

            bool deptExist = false;

            cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            cn.Open();
            cmd = new SqlCommand("select IDdepartment FROM Departments", cn);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["IDdepartment"].ToString() == textBox_deptID.Text)
                {
                    deptExist = true;
                    break;
                }

            }
            dr.Close();
            cn.Close();

            if (deptExist)
            {
                //means that department exist


                cmd = new SqlCommand("select ID,name,month,year,hoursAmount FROM staffHours WHERE Type = '2' AND IDdepartment = '" + textBox_deptID.Text + "' AND month = '" + numericUpDown_month.Value + "' AND year = '" + numericUpDown_year.Value + "'", cn);
                DataTable data = new DataTable();

                da = new SqlDataAdapter(cmd);
                da.Fill(data);

                DataView dv = new DataView(data);

                dataGridView_staffHoursTable.DataSource = dv;


            }
            else
            {
                //means that department does not exist - no need to show report
                MessageBox.Show("Sorry, this department does NOT exist!");
                textBox_deptID.Clear();

            }


        }

        private void A_viewReportHoursOf_Lecturer_forDH_Load(object sender, EventArgs e)
        {
            currentA_viewReportHoursOf_Lecturer_forDH = this;
        }
    }

}

