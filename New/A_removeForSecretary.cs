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
    public partial class A_removeForSecretary : Form
    {
        Secretary sec;
        public static A_removeForSecretary currentA_removeForSecretary;
        public A_removeForSecretary()
        {
            InitializeComponent();
        }
       /* public Secretary passvalue
        {

            get { return sec; }
            set { sec = value; }
        }*/


        private void button_bach_Click(object sender, EventArgs e)
        {
           
            A_menuForSecretary.CurrentA_menuForSecretary.Show();
            this.Hide();
        }

        private void button_EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_remove_dept_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_removeDept_secretary rem=new A_removeDept_secretary();
            rem.ShowDialog(); 
        }

        private void button_remove_course_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_removeCourse_forSecretary rem=new A_removeCourse_forSecretary();
            rem.ShowDialog();
        }

        private void button_remove_headDept_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_removeDH_forSecretary rem=new A_removeDH_forSecretary();
            rem.ShowDialog();
        }

        private void button_remove_sched_lecturersFromDept_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_removeSchedLecturer_fromDept_forSecretary rem=new A_removeSchedLecturer_fromDept_forSecretary();
            rem.ShowDialog(); 
        }

        private void button_rmv_TA_fromDept_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_removeSchedTA_fromDepat_forSecretary rem =new A_removeSchedTA_fromDepat_forSecretary();
            rem.ShowDialog();
        }

        private void A_removeForSecretary_Load(object sender, EventArgs e)
        {
            currentA_removeForSecretary = this;
        }
    }
}
