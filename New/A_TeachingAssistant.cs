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
    public partial class A_TeachingAssistant : Form
    {
        TeachingAssitant ta;
        public static A_TeachingAssistant cureentA_TeachingAssistant;
        public TeachingAssitant passValue
        {
            get { return ta; }
            set{ ta = value; }
        }

        public A_TeachingAssistant(TeachingAssitant ta)
        {
            InitializeComponent();
            this.ta = ta;
        }

        private void LOGOUT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BACKtpp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_B.Current.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void insertionWork_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_Insert_work_hours_for_TA x = new A_Insert_work_hours_for_TA(ta);
            x.passValue = ta;
            x.Show();
        }

        private void viewArrangment_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_Show_Schedualing_TA x = new A_Show_Schedualing_TA(ta);
            x.passValue = ta;
            x.Show();
        }

        private void A_TeachingAssistant_Load(object sender, EventArgs e)
        {
            cureentA_TeachingAssistant = this;
        }
    }
}
