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
    public partial class support__manager : Form
    {
        public support__manager()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void Create_user_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void createuserclick_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Add_User_B new_user = new Add_User_B();
            new_user.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Change_password_B ch = new Change_password_B();
            ch.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            // what should i put here to show form1 again
            Login_B.Current.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Delete_User_B user_delete = new Delete_User_B();
            user_delete.Show();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            Change_User_Name change = new Change_User_Name();
            change.Show();
        }
    }
}
