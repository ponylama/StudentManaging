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
    public partial class Secretary_Menu_B : Form
    {
        User sec;
        public User passsec
        {
            get { return sec; }
            set { sec = value; }
        }
        public Secretary_Menu_B()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void User_Details_Click(object sender, EventArgs e)
        {
            User_Ditetails_B details = new User_Ditetails_B();
            this.Hide();
            details.Show();

        }

        private void Secretary_Menu_B_Load(object sender, EventArgs e)
        {
            Hello.Text = "Hello " + Convert.ToString(sec.getFirstName()) + "!";
            Hello.Show();
        }

    

        private void Student_Placement_to_Course_Click(object sender, EventArgs e)
        {
            Student_Placement_to_Course_Secretary_B B = new Student_Placement_to_Course_Secretary_B();
            this.Hide();
            B.Show();

        }

        private void Exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Delete_a_Student_from_Course_Click(object sender, EventArgs e)
        {
            Delete_a_Student_From_Course_Secretary_B DSC = new Delete_a_Student_From_Course_Secretary_B();
            DSC.Show();
        }

        private void Change_Students_Lab_Click(object sender, EventArgs e)
        {
            Student_Placement_to_Lab_Secretary_B PL = new Student_Placement_to_Lab_Secretary_B();
            PL.Show();
        }

        private void Change_Students_Lecture_Click(object sender, EventArgs e)
        {
            Student_Placement_to_Lec_Secretary_B PLE = new Student_Placement_to_Lec_Secretary_B();
            PLE.Show();
        }

        private void Change_Student_Practice_Click(object sender, EventArgs e)
        {
            Student_Placement_to_Practice_Secretary_B PP = new Student_Placement_to_Practice_Secretary_B();
            PP.Show();
        }

        private void Add_student_Click(object sender, EventArgs e)
        {

        }

        private void send_personal_Button_Click(object sender, EventArgs e)
        {
            sending_Personal_message_B message = new sending_Personal_message_B();
            message.type = "Secretary";
            message.Show();
        }

        private void Send_Mass_Message_Click(object sender, EventArgs e)
        {
            send_mass_Message_secretary_B message = new send_mass_Message_secretary_B();
            message.Show();
        }

        private void Students_Courses_Watch_Click(object sender, EventArgs e)
        {
            View_Courses VC = new View_Courses();
            VC.Show();
        }

        private void Hello_Click(object sender, EventArgs e)
        {

        }
    }
}
