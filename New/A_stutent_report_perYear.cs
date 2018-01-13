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

    public partial class A_stutent_report_perYear : Form
    {
        public static A_stutent_report_perYear currentA_stutent_report_perYear;
        HeadDepartment dep;

        SqlConnection cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");

        public HeadDepartment passValue
        {
            get { return dep; }
            set { dep = value; }
        }

        public A_stutent_report_perYear(HeadDepartment hd)
        {
            InitializeComponent();
            //this.dep = new HeadDepartment();
            this.dep = hd;
        }

        private void backtpp_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            //A_DHview back = new A_DHview();
            A_DHview.currentA_DHview.Show(); 
        }

        private void Year_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT ID, FirstName, LastName, Year, Departments, Semester FROM Users WHERE Departments LIKE'" + dep_naem.Text + "%' AND Type='1' AND Year LIKE'"+Year.Text+"%'", cn);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

        }

        private void dep_naem_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT ID, FirstName, LastName, Year, Departments, Semester FROM Users WHERE Departments LIKE'" + dep_naem.Text + "%' AND Type='1' AND Year LIKE'" + Year.Text + "%'", cn);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void A_stutent_report_perYear_Load(object sender, EventArgs e)
        {
            currentA_stutent_report_perYear = this;
        }
    }
}
