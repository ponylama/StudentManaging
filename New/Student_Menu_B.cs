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
    public partial class Student_Menu_B : Form
    {
        StudentClass SD;
        public static Student_Menu_B currStudentForm;
        public bool Massange = false;

        public StudentClass passValue
        {
            get { return SD; }
            set { SD = value; }
        }
        public Student_Menu_B()
        {
            InitializeComponent();
           
        }

        

        public void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Cursor = Cursors.Hand;
        }

        public void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Cursor = Cursors.Default;
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
         
        }

        private void Student_Menu_B_Load(object sender, EventArgs e)
        {
            MessangePic.Hide();
            currStudentForm = this;
            if (Massange)
                MessangePic.Show();
            if (SD != null)
                HelloMassange.Text = "Hello " + SD.getFirstName() + " your ID " + SD.getID() + "";
        }

        private void showprofile_Click(object sender, EventArgs e)
        {
            StudentDisplayDetails_B S = new StudentDisplayDetails_B();
            MessangePic.Hide();
            S.passValue = SD;
            S.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Student_Self_Placement SSP = new Student_Self_Placement();
            SSP.studValue = SD;
            SSP.Show();


            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //show_list
            StudentScheduleView_B Schedule = new StudentScheduleView_B();
            Schedule.passValue = SD;
            Schedule.Show();
        }

        private void MessangePic_Click(object sender, EventArgs e)
        {
            MessageBox.Show("you got new message please see student details...");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            // what should i put here to show form1 again
            Login_B.Current.ShowDialog();
        }
    }

}