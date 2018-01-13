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
    public partial class Show_Schedualing_lecturer : Form
    {
        public static Show_Schedualing_lecturer currentShow_Schedualing_lecturer;
        Lecturer lec;
        SqlConnection cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");

        public Lecturer passValue 
        {
            get { return lec; }
            set { lec = value; }
        }

        public Show_Schedualing_lecturer(Lecturer lec)
        {
            InitializeComponent();
            this.lec = lec;
            name.Text = "Hello " + lec.getFirstName().ToString() + "!";
            SqlDataAdapter sda = new SqlDataAdapter("SELECT ID, day, courseName, class, timeStart, timeEnd FROM schedualing WHERE ID LIKE'" + lec.getID().ToString() + "%'", cn);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_LecturerMenu.CIRRENTA_LecturerMenu.Show(); 
        }

        private void Show_Schedualing_lecturer_Load(object sender, EventArgs e)
        {
            currentShow_Schedualing_lecturer = this;
        }
    }
}
