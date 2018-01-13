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

    public partial class Form2: Form
    {
        //public string conecting_string = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017"; //connecting to p17 server
        public Form2()
        {
            InitializeComponent();
            //AmenuSecretary secretaryNenuForm = new AmenuSecretary();
            //secretaryNenuForm.ShowDialog();


            ALoginScreen logForm = new ALoginScreen();
            logForm.ShowDialog();

           // A_DepartmentHead x = new A_DepartmentHead();
            //x.Show();

            //    SqlConnection conencting = new SqlConnection(conecting_string);
            //    conencting.Open();
            //    if (conencting.State == System.Data.ConnectionState.Open)
            //    {
            //        string upload = " פקודת SQL";
            //        SqlCommand cmd = new SqlCommand(upload, conencting);
            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show(" made Successfuly");
            //    }
        }

  //      private void InitializeComponent()
     //   {
     ///      throw new NotImplementedException();
    //    }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
