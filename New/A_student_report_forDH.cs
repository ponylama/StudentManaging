
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
    public partial class A_student_report_forDH : Form
    {
        public static A_student_report_forDH currentA_student_report_forDH;
        HeadDepartment dep;
        public A_student_report_forDH(HeadDepartment hd)
        {
            InitializeComponent();
          //  this.dep = new HeadDepartment();
            this.dep = hd;
        }
        

        SqlConnection cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");

        public HeadDepartment passValue
        {
            get { return dep; }
            set { dep = value; }
        }

        private void code_text_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT ID, FirstName, LastName, Year, Departments, Semester FROM Users WHERE Departments LIKE'"+code_text.Text+"%' AND Type='1'", cn);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

        }

        private void backtpp_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            //A_DHview back = new A_DHview();
            A_DHview.currentA_DHview.Show(); 
        }

        private void A_student_report_forDH_Load(object sender, EventArgs e)
        {
            currentA_student_report_forDH = this;
        }
    }
}