namespace FB_Analyze
{
    using System;
    using System.Windows.Forms;
    using Facebook;
    using Facebook.MiniJSON;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public partial class FB_Analyze : Form
    {
        private const string AppId = "239010066477815";
        private const string ExtendedPermissions = "public_profile,user_friends,email";
        private string _accessToken;
        FacebookClient fbClient = new FacebookClient();
        New.StudentClass S1;
        New.Lecturer lec;  // type == 2
        New.ProfessorClass P1; // type == 2
        New.TeachingAssitant ta; // type == 3
        New.HeadDepartment hd;  // type == 4
        New.Secretary sec;   // type == 7

        public FB_Analyze()
        {
            InitializeComponent();
        }

        private void btnFacebookLogin_Click(object sender, EventArgs e)
        {
            var fbLoginDialog = new FB_LoginDialog(AppId, ExtendedPermissions);
            fbLoginDialog.ShowDialog();

            DisplayAppropriateMessage(fbLoginDialog.FacebookOAuthResult);
            this.Hide();

        }

        private void DisplayAppropriateMessage(FacebookOAuthResult facebookOAuthResult)
        {
            if (facebookOAuthResult != null)
            {
                if (facebookOAuthResult.IsSuccess)
                {
                    _accessToken = facebookOAuthResult.AccessToken;
                    var fb = new FacebookClient(facebookOAuthResult.AccessToken);
                    string Messenge1 = "", Messenge2 = "";
                    var result = fb.Get("me", new { fields = new[] { "first_name", "last_name", "name", "gender", "id", "age_range" } });
                    var cl = fb;
                    dynamic result1 = fb.Get("me?fields=id,first_name,last_name");
                    string _currentEmail = result1.email;
                    //MessageBox.Show(result1.first_name);
                    // MessageBox.Show(result1.last_name);
                    // MessageBox.Show(_currentEmail);
                    // MessageBox.Show(result1.name);
                    // MessageBox.Show(result1.id);
                    // SqlConnection sqlcon=null;
                    // General.ConnectToSql(sqlcon);
                    string connetionString = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;MultipleActiveResultSets=true;User ID=P17;Password=Hadas@2017";
                    SqlConnection sqlcon = new SqlConnection(connetionString);
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("select * from Users where FirstName='" + result1.first_name + "' and LastName= '" + result1.last_name + "'", sqlcon);
                    SqlDataReader dataRead = cmd.ExecuteReader();
                    int type = 0;
                    if (dataRead.Read() == true)
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
                            S1 = new New.StudentClass(id, fn, ln, type, year, semester, depa);
                            string readMassange = "select * from Messege_Box where ID = '" + S1.getID().ToString() + "'";
                            SqlCommand ReadMessageCommand = new SqlCommand(readMassange, sqlcon);
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
                            P1 = new New.ProfessorClass(pid, pln, pfn, type, pdepa);
                            string readMassange = "select * from Messege_Box where ID = '" + P1.getID().ToString() + "'";
                            SqlCommand ReadMessageCommand = new SqlCommand(readMassange, sqlcon);
                            SqlDataReader messangeRead;
                            messangeRead = ReadMessageCommand.ExecuteReader();
                            while (messangeRead.Read())
                            {
                                Messenge1 = (messangeRead["S_Messege"].ToString());
                                Messenge2 = (messangeRead["L_Messege"].ToString());
                            }
                            lec = new New.Lecturer();
                            this.lec.setLastName(ln);
                            this.lec.setFirstName(fn);
                            this.lec.setID(id);
                            this.lec.setdeparName(depa);
                        }


                        if (type == 3) // to create the object TeachingAssitant
                        {

                            ta = new New.TeachingAssitant();
                            this.ta.setLastName(ln);
                            this.ta.setFirstName(fn);
                            this.ta.setID(id);
                            this.ta.setdeparName(depa);
                        }

                        if (type == 4) // to create the object HeadDepartmrent
                        {
                            hd = new New.HeadDepartment();
                            this.hd.setLastName(ln);
                            this.hd.setFirstName(fn);
                            this.hd.setID(id);
                            this.hd.setdeparName(depa);
                        }

                        if (type == 7)
                        {
                            sec = new New.Secretary();
                            this.sec.setLastName(ln);
                            this.sec.setFirstName(fn);
                            this.sec.setID(id);
                            this.sec.setdeparName(depa);
                        }

                        sqlcon.Close();
                    }

                    if (type == 1)
                    {
                        New.Login_B.Current.Hide();
                        MessageBox.Show("wellcome " + S1.getFirstName() + " to student menu your ID " + S1.getID() + "");
                        this.Hide();
                        New.Student_Menu_B student = new New.Student_Menu_B();
                        if (Messenge1 != "" || Messenge2 != "")
                            student.Massange = true;
                        student.passValue = S1;
                        dataRead.Close();
                        student.Show();
                    }
                    else if (type == 2)
                    {
                        New.Login_B.Current.Hide();
                        MessageBox.Show("wellcome " + P1.getFirstName() + " to Lecturer Menu your ID " + P1.getID() + "");
                        this.Hide();
                        //Proffesor_Menu_B professor = new Proffesor_Menu_B();
                        New.A_LecturerMenu lecMenu = new New.A_LecturerMenu(lec);
                        lecMenu.passValue = P1;
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
                        New.Login_B.Current.Hide();
                        this.Hide();
                        MessageBox.Show("wellcome " + ta.getFirstName() + " to Teaching Assistant Menu your ID " + ta.getID() + "");
                        New.A_TeachingAssistant taMenu = new New.A_TeachingAssistant(ta);
                        taMenu.passValue = ta;
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
                        New.Login_B.Current.Hide();
                        this.Hide();
                        //HeadDepartment hd = new HeadDepartment();
                        New.A_DepartmentHead hdMenu = new New.A_DepartmentHead();
                        hdMenu.passValue = hd;
                        dataRead.Close();
                        hdMenu.ShowDialog();

                    }
                    else if (type == 5)
                    {
                        New.Login_B.Current.Hide();
                        MessageBox.Show("Connceted secretary");
                        this.Hide();
                        New.Secretary_Menu_B secretary = new New.Secretary_Menu_B();
                        secretary.Show();
                    }
                    else if (type == 6)
                    {
                        New.Login_B.Current.Hide();
                        MessageBox.Show("Connceted TECH");
                        this.Hide();
                        New.support__manager supp = new New.support__manager();
                        supp.Show();
                    }
                    else if (type == 7)
                    {
                        New.Login_B.Current.Hide();
                        this.Hide();

                        MessageBox.Show("wellcome " + sec.getFirstName() + " to Secretary Menu your ID " + sec.getID() + "");
                        New.A_menuForSecretary secMenu = new New.A_menuForSecretary();
                        // secMenu.passValue = sec;
                        //connect.Close();
                        //dataRead.Close();
                        secMenu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong password");
                    }
                    //    int Type = Convert.ToInt32(dr["Type"]); // gets id
                    //    int id = Convert.ToInt32(dr["ID"]);
                    //    string ln = (dr["LastName"].ToString());
                    //    string fn = (dr["FirstName"].ToString());
                    //    string depa = (dr["Departments"].ToString());
                    //    string year = (dr["Year"].ToString());
                    //    int semester = Convert.ToInt32(dr["Semester"]);

                    //    if (Type == 1)
                    //    {
                    //        New.StudentClass S1 = new New.StudentClass(id, fn, ln, Type, year, semester, depa);

                    //        this.Hide();
                    //        New.Login_B.Current.Hide();
                    //        New.Student_Menu_B st = new New.Student_Menu_B();
                    //        st.passValue = S1;
                    //        st.Show();
                    //        dr.Close();

                    //    }
                    //    //else if (dr[6].ToString() == "Lecturer")
                    //    //{
                    //    //    //this.Hide();
                    //    //    New.Lecturer.Menu Connect = new New.Lecturer.Menu();
                    //    //    Connect.Show();
                    //    //    Connect.Lecturer_Name.Text = "      " + dr[1].ToString() + " " + dr[2].ToString();
                    //    //}
                    //    //else if (dr[6].ToString() == "Teaching_Assistant")
                    //    //{
                    //    //    // this.Hide();
                    //    //    New.Teaching_Assistant.Menu Connect = new New.Teaching_Assistant.Menu();
                    //    //    Connect.Show();
                    //    //    Connect.Teaching_Assistant_Name.Text = "      " + dr[1].ToString() + " " + dr[2].ToString();
                    //    //}
                    //    //else if (dr[6].ToString() == "Secretary")
                    //    //{
                    //    //    // this.Hide();
                    //    //    New.Secretary.Menu Connect = new New.Secretary.Menu();
                    //    //    Connect.Show();
                    //    //    Connect.Secretary_Name.Text = "      " + dr[1].ToString() + " " + dr[2].ToString();
                    //    //}
                    //    //else if (dr[6].ToString() == "Student")
                    //    //{
                    //    //    New.Student.Menu Connect = new New.Student.Menu();
                    //    //    Connect.Show();
                    //    //    Connect.Student_Name.Text = "      " + dr[1].ToString() + " " + dr[2].ToString();

                    //    //}

                    //}
                    //else
                    //{
                    //    MessageBox.Show("Invalid Username or Password ");
                    //    cmd = null;
                    //}
                    //var dict = Json.Deserialize(result.ToString()) as Dictionary<string, object>;
                    //string id = dict["id"].ToString();
                    //string name = dict["name"].ToString();
                    //string Lname = dict["first_name"].ToString();
                    //string Fname = dict["last_name"].ToString();
                    //string gender = dict["gender"].ToString();
                    // MessageBox.Show(name);
                    // MessageBox.Show(Lname);
                    // MessageBox.Show(Fname);
                    // MessageBox.Show(gender);
                    // MessageBox.Show(id);


                    //btnLogout.Visible = true;

                }
                else
                {
                    MessageBox.Show(facebookOAuthResult.ErrorDescription);
                }
            }
        }

        private void FB_Analyze_Load(object sender, EventArgs e)
        {
        }
    }

    //private void ConnectToSql(SqlConnection sqlConnection, object sqlcon)
    //{
    //    throw new NotImplementedException();
    //}

    //private void btnLogout_Click(object sender, EventArgs e)
    //{
    //    var webBrowser = new WebBrowser();
    //    var fb = new FacebookClient();
    //    var logouUrl = fb.GetLogoutUrl(new { access_token = _accessToken, next = "https://www.facebook.com/connect/login_success.html" });
    //    webBrowser.Navigate(logouUrl);
    //    btnLogout.Visible = false;
    //}

}
//}
