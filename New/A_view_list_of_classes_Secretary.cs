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
    public partial class A_view_list_of_classes_Secretary : Form
    {
        public static A_view_list_of_classes_Secretary currentA_view_list_of_classes_Secretary;
        SqlConnection cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");

        public A_view_list_of_classes_Secretary()
        {
            InitializeComponent();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM schedualing", cn);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_displayMenuSecretary.CurrentA_displayMenuSecretary.Show();
        }

        private void A_view_list_of_classes_Secretary_Load(object sender, EventArgs e)
        {
            currentA_view_list_of_classes_Secretary = this;
        }
    }
}
