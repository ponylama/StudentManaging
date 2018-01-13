using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            //theme_B theme = new theme_B();
            //theme.Show();
            Login_B Login = new Login_B();
            Login.ShowDialog();
        }

        private void Student_Menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student_Menu_B student = new Student_Menu_B();
            student.Show();
        }

        private void Secretary_Menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Secretary_Menu_B secretary = new Secretary_Menu_B();
            secretary.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Blue2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_User_B new_user = new Add_User_B();
            new_user.Show();
        }
        private void delete_button_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Delete_User_B user_delete = new Delete_User_B();
            user_delete.Show();
        }

        private void Change_pass_Click(object sender, EventArgs e)
        {
            this.Hide();
            Change_password_B pass = new Change_password_B();
            pass.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void support_Click(object sender, EventArgs e)
        {
            this.Hide();
            support__manager support = new support__manager();
            support.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Change_User_Name changee = new Change_User_Name();
            changee.Show();

        }
    }
    public static class Return_Connection_String_Class
    {
        public static string Return_Connection_String()
        {
            string Connecting_String = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;MultipleActiveResultSets=true;User ID=P17;Password=Hadas@2017";
            return Connecting_String;
        }
    }
}
