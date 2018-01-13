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
    public partial class sending_Personal_message_B : Form
    {
        public string type = "";
        public sending_Personal_message_B()
        {
            InitializeComponent();
        }

        private void sending_Personal_message_B_Load(object sender, EventArgs e)
        {
           

        }

        private void ID_BOX_TextChanged(object sender, EventArgs e)
        {
            string tString = ID_BOX.Text;
            if (tString.Trim() == "") return;
            if (tString.Length > 9)
            {
                MessageBox.Show("Please enter a valid number");
                ID_BOX.Text = "";
                return;
            }

            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    MessageBox.Show("Please enter NUMBERS only");
                    ID_BOX.Text = "";
                    return;
                }

            }
        }

        private void Send_Button_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(Return_Connection_String_Class.Return_Connection_String());
            connect.Open();
            string command = "";
            if (type == "Secretary")
                command = "update Messege_Box set S_Messege = '" + Message_Box.Text + "' where ID = '" + ID_BOX.Text + "'";
            else if (type == "lecture")
                command = "update Messege_Box set L_Messege = '" + Message_Box.Text + "' where ID = '" + ID_BOX.Text + "'";
            else
                MessageBox.Show("sorry you doont got promissin");
            if (connect.State == System.Data.ConnectionState.Open)
            {
                string command1 = "select * from Messege_Box where ID = '" + ID_BOX.Text + "'";
                SqlCommand cmd1 = new SqlCommand(command1, connect);
                SqlDataReader dataRead;
                dataRead = cmd1.ExecuteReader();
                int type = 0;
                while (dataRead.Read())
                {
                    type = Convert.ToInt32(dataRead["Type"]);
                }
                if (type == 1 && command != "")
                {                   
                    SqlCommand cmd = new SqlCommand(command, connect);
                    cmd.ExecuteReader();
                    MessageBox.Show("your message was successfully sent");
                }
                else
                    MessageBox.Show("sorry its wrong student ID");

            }
        }

        private void Hide_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
