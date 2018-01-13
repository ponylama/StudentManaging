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
    public partial class ForgetPassword_B : Form
    {
        StudentClass S1;
        Lecturer lec;  // type == 2
        ProfessorClass P1; // type == 2
        TeachingAssitant ta; // type == 3
        HeadDepartment hd;  // type == 4
        Secretary sec;   // type == 7

        public ForgetPassword_B()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            if (ID_Box.TextLength != 9)
            {
                MessageBox.Show("ooops Wrong ID please try again");
                ID_Box.Text = "";
            }
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

                string command = "select * from Users where ID = '" + ID_Box.Text + "' and FirstName = '" + FirstNameBox.Text + "' and LastName = '" + LastNameBox.Text + "'";
                SqlCommand cmd = new SqlCommand(command, connect);
                SqlDataReader dataRead;
                dataRead = cmd.ExecuteReader();
                int type = 0;
                string Messenge1 = "", Messenge2 = "";
                while (dataRead.Read())
                {
                    type = Convert.ToInt32(dataRead["Type"]);
                    int id = Convert.ToInt32(dataRead["ID"]);
                    string ln = (dataRead["LastName"].ToString());
                    string fn = (dataRead["FirstName"].ToString());
                    string depa = (dataRead["Departments"].ToString());
                    if (type == 1)
                    {
                        // 317509073/

                        //int id = Convert.ToInt32(dataRead["ID"]);
                        //string ln = (dataRead["LastName"].ToString());
                        //string fn = (dataRead["FirstName"].ToString());
                        string year = (dataRead["Year"].ToString());
                        //string depa = (dataRead["Departments"].ToString());
                        int semester = Convert.ToInt32(dataRead["Semester"]);
                        S1 = new StudentClass(id, fn, ln, type, year, semester, depa);
                        string readMassange = "select * from Messege_Box where ID = '" + S1.getID().ToString() + "'";
                        SqlCommand ReadMessageCommand = new SqlCommand(readMassange, connect);
                        SqlDataReader messangeRead;
                        messangeRead = ReadMessageCommand.ExecuteReader();
                        while (messangeRead.Read())
                        {
                            Messenge1 = (messangeRead["S_Messege"].ToString());
                            Messenge2 = (messangeRead["L_Messege"].ToString());
                        }

                    }

                    if (type == 2) // to create the object Lecturer
                    {
                        int pid = Convert.ToInt32(dataRead["ID"]);
                        string pln = (dataRead["LastName"].ToString());
                        string pfn = (dataRead["FirstName"].ToString());
                        string pdepa = (dataRead["Departments"].ToString());
                        P1 = new ProfessorClass(pid, pln, pfn, type, pdepa);
                        string readMassange = "select * from Messege_Box where ID = '" + P1.getID().ToString() + "'";
                        SqlCommand ReadMessageCommand = new SqlCommand(readMassange, connect);
                        SqlDataReader messangeRead;
                        messangeRead = ReadMessageCommand.ExecuteReader();
                        while (messangeRead.Read())
                        {
                            Messenge1 = (messangeRead["S_Messege"].ToString());
                            Messenge2 = (messangeRead["L_Messege"].ToString());
                        }
                        lec = new Lecturer();
                        this.lec.setLastName(ln);
                        this.lec.setFirstName(fn);
                        this.lec.setID(id);
                        this.lec.setdeparName(depa);
                    }


                    if (type == 3) // to create the object TeachingAssitant
                    {

                        ta = new TeachingAssitant();
                        this.ta.setLastName(ln);
                        this.ta.setFirstName(fn);
                        this.ta.setID(id);
                        this.ta.setdeparName(depa);
                    }

                    if (type == 4) // to create the object HeadDepartmrent
                    {
                        hd = new HeadDepartment();
                        this.hd.setLastName(ln);
                        this.hd.setFirstName(fn);
                        this.hd.setID(id);
                        this.hd.setdeparName(depa);
                    }

                    if (type == 7)
                    {
                        sec = new Secretary();
                        this.sec.setLastName(ln);
                        this.sec.setFirstName(fn);
                        this.sec.setID(id);
                        this.sec.setdeparName(depa);
                    }
                }
                if (type == 1)
                {
                    MessageBox.Show("wellcome " + S1.getFirstName() + " to student menu your ID " + S1.getID() + "");
                    this.Hide();
                    Student_Menu_B student = new Student_Menu_B();
                    if (Messenge1 != "" || Messenge2 != "")
                        student.Massange = true;
                    connect.Close();
                    student.passValue = S1;
                    dataRead.Close();
                    student.Show();
                }
                else if (type == 2)
                {

                    MessageBox.Show("wellcome " + P1.getFirstName() + " to Lecturer Menu your ID " + P1.getID() + "");
                    this.Hide();
                    //Proffesor_Menu_B professor = new Proffesor_Menu_B();
                    A_LecturerMenu lecMenu = new A_LecturerMenu(lec);
                    lecMenu.passValue = P1;
                    connect.Close();
                    dataRead.Close();
                    lecMenu.ShowDialog();
                    /*
                    this.Hide();
                    A_LecturerMenu lecMenu = new A_LecturerMenu(lec);
                    lecMenu.ShowDialog();
                    */
                    //MessageBox.Show("Connceted Professor");
                    //this.Hide();
                    //Proffesor_Menu_B professor = new Proffesor_Menu_B();
                    //professor.Show();
                    // קבוצה B שימו לב !!!!!!!!
                    // אתם צריכים לשנות את הסוג של פרופסור אצלכם ל-2 ולשנות את זה בכל מקום! גם בקוד וגם בדטהבייס 
                    // ואז לשלוח אותו לפורם הבא: A_lecturerMenu  אחרי שתאחדו את הדרישות שלכם בפורם הזה
                }

                else if (type == 3)
                {
                    this.Hide();
                    MessageBox.Show("wellcome " + ta.getFirstName() + " to Teaching Assistant Menu your ID " + ta.getID() + "");
                    A_TeachingAssistant taMenu = new A_TeachingAssistant(ta);
                    taMenu.passValue = ta;
                    connect.Close();
                    dataRead.Close();
                    taMenu.ShowDialog();



                    //change branch B ---  type of proffesor to type 2
                    //MessageBox.Show("Connceted Professor");
                    //this.Hide();
                    //Proffesor_Menu_B professor = new Proffesor_Menu_B();
                    //professor.Show();
                }
                else if (type == 4)
                {
                    this.Hide();
                    //HeadDepartment hd = new HeadDepartment();
                    A_DepartmentHead hdMenu = new A_DepartmentHead();
                    hdMenu.passValue = hd;
                    connect.Close();
                    dataRead.Close();
                    hdMenu.ShowDialog();

                }
                else if (type == 5)
                {
                    MessageBox.Show("Connceted secretary");
                    this.Hide();
                    Secretary_Menu_B secretary = new Secretary_Menu_B();
                    secretary.Show();
                }
                else if (type == 6)
                {
                    MessageBox.Show("Connceted TECH");
                    this.Hide();
                    support__manager supp = new support__manager();
                    supp.Show();
                }
                else if (type == 7)
                {
                    this.Hide();

                    MessageBox.Show("wellcome " + sec.getFirstName() + " to Secretary Menu your ID " + sec.getID() + "");
                    A_menuForSecretary secMenu = new A_menuForSecretary();
                    // secMenu.passValue = sec;
                    //connect.Close();
                    //dataRead.Close();
                    secMenu.Show();
                }
                else
                {
                    MessageBox.Show("Cant Find Your user please contact tech support");
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_B log = new Login_B();
            log.Show();
        }

        private void ID_Box_TextChanged(object sender, EventArgs e)
        {
            string tString = ID_Box.Text;
            if (tString.Trim() == "") return;
            if (tString.Length > 9)
            {
                MessageBox.Show("Please enter a valid number");
                ID_Box.Text = "";
                return;
            }

            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    MessageBox.Show("Please enter NUMBERS only");
                    ID_Box.Text = "";
                    return;
                }

            }
        }
    }
}
