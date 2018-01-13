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
    public partial class A_schedForSecretary : Form
    {
        
        public static A_schedForSecretary currentA_schedForSecretary;
        public A_schedForSecretary()
        {
            InitializeComponent();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_menuForSecretary.CurrentA_menuForSecretary.Show(); 
        }

        private void button_EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_schedual_LecturerForDept_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_sched_lecturerDept_secretary schedlec=new A_sched_lecturerDept_secretary();
            schedlec.ShowDialog();
        }

        private void button_schedual_TA_forDEpt_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_sched_TA_Dept_secretary schedTA=new A_sched_TA_Dept_secretary();
            schedTA.ShowDialog();
        }

        private void button_schedual_classes_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_schedClasses schadClass=new A_schedClasses();
            schadClass.ShowDialog();
        }

        private void button_schedual_lecturers_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_schedulingLecturers_secretary schadlec=new A_schedulingLecturers_secretary();
            schadlec.ShowDialog();
        }

        private void button_schedual_TA_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_schedualingTeachingAssistants_secretary schadTA=new A_schedualingTeachingAssistants_secretary();
            schadTA.ShowDialog();
        }

        private void button_schedual_exams_classes_Click(object sender, EventArgs e)
        {

            this.Hide();
            A_ScaduilngClassForExam_Secretary schadex =new A_ScaduilngClassForExam_Secretary();
            schadex.ShowDialog();
        }

        private void A_schedForSecretary_Load(object sender, EventArgs e)
        {
            currentA_schedForSecretary = this;
        }
    }
}
