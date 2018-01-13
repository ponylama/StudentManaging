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
// 
namespace New
{
    public partial class ProfessorDisplaysDetails_B : Form
    {
        public ProfessorDisplaysDetails_B()
        {
            InitializeComponent();
            //Professor.getFirstName();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ProfessorDisplaysDetails_B_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
            connect.Open();
            //if (connect.State == System.Data.ConnectionState.Open)
            //{
            //string command = "select * from StaffCourses where ID = '" + SD.getID().ToString() + "'";
           
            }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
