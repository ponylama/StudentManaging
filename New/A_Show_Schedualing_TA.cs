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
    public partial class A_Show_Schedualing_TA : Form
    {
        public static A_Show_Schedualing_TA currA_Show_Schedualing_TA;
        TeachingAssitant ta;
        SqlConnection cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");

        public TeachingAssitant passValue
        {
            get { return ta; }
            set { ta = value; }
        }

        public A_Show_Schedualing_TA(TeachingAssitant ta)
        {
            InitializeComponent();
            this.ta = ta;
            name.Text = "Hello " + ta.getFirstName().ToString() + "!";
            SqlDataAdapter sda = new SqlDataAdapter("SELECT ID, day, courseName, class, timeStart, timeEnd FROM schedualing WHERE ID LIKE'" + ta.getID().ToString() + "%'", cn);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_TeachingAssistant.cureentA_TeachingAssistant.Show();
        }

        private void A_Show_Schedualing_TA_Load(object sender, EventArgs e)
        {
            currA_Show_Schedualing_TA = this;
        }
    }
}
