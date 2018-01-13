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

    public partial class StudentDisplayDetails_B : Form
    {
        StudentClass SD;
        public StudentDisplayDetails_B()
        {
            InitializeComponent();
        }
        public StudentClass passValue
        {
            get { return SD; }
            set { SD = value; }
        }

        public StudentDisplayDetails_B(StudentClass Student)
        {
            InitializeComponent();
            Student.getFirstName();
            //DisplayLable_B.Text = Student.getID().ToString() ;
        }


        private void StudentDisplayDetails_B_Load(object sender, EventArgs e)
        {

            string Messenge1 = null, Messenge2 = null;
            SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                // output the error to see what's going on
                MessageBox.Show(ex.Message);
            }
            if (connect.State == System.Data.ConnectionState.Open)
            {
                string command = "select * from Messege_Box where ID = '" + SD.getID().ToString() + "'";
                SqlCommand cmd = new SqlCommand(command, connect);
                SqlDataReader dataRead;
                dataRead = cmd.ExecuteReader();
                while (dataRead.Read())
                {
                    Messenge1 = (dataRead["S_Messege"].ToString());
                    Messenge2 = (dataRead["L_Messege"].ToString());
                }
                if (Messenge1 != "" || Messenge2 != "")
                {
                    if (Messenge1 != "" && Messenge2 != "")
                    {
                        Massange1_.Show();
                        Massange2_.Show();
                        Massange1_.Text = Messenge1;
                        Massange2_.Text = Messenge2;
                    }
                    else if (Messenge1 != "")
                    {
                        Massange1_.Show();
                        Massange1_.Text = Messenge1;
                    }
                    else if (Messenge2 != "")
                    {
                        Massange1_.Show();
                        Massange1_.Text = Messenge2;
                    }
                    Clear_Massange.Show();
                }
                else
                    Massange1_.Show();
            }
            ID_.Text = SD.getID().ToString();
            FirstName_.Text =  SD.getFirstName().ToString();
            LastName_.Text = SD.getLasttName().ToString();
            Year_.Text = SD.getYear().ToString();
            Department_.Text = SD.getDepartment().ToString();
            Semester_.Text = SD.getSemester().ToString();
        }

        private void DisplayStudent_B_TextChanged(object sender, EventArgs e)
        {

        }

        private void DisplayLable_B_Click(object sender, EventArgs e)
        {

        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Clear_Massange_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                // output the error to see what's going on
                MessageBox.Show(ex.Message);
            }
            if (connect.State == System.Data.ConnectionState.Open)
            {
                string command = "update Messege_Box set S_Messege = NULL, L_Messege = NULL where ID='" + SD.getID().ToString() + "'";
                SqlCommand cmd = new SqlCommand(command, connect);
                cmd.ExecuteReader();
                MessageBox.Show("Messange deleted");
                Massange1_.Text = "no massanges";
                Massange2_.Hide();
                Clear_Massange.Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FirstName__Click(object sender, EventArgs e)
        {

        }
    }
}
