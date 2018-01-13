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

    //public struct typeP_L
    //{
    //    string name;
    //    int type;
    //};

    public partial class A_schedClasses : Form
    {
        public static A_schedClasses currentA_schedClasses;
        DataTable data;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection cn;
        Course course = new Course();
        // for the  cmbP_L
        string strP_L;
        int type_P_L = 0;
        List<int> availableHours;   // to check available hours
        int choosenClass; // the class that user choose in the end
        int amountHours = 0;  // to keep how many hours from the choosen time
        int startTime = 0;


        public A_schedClasses()
        {
            InitializeComponent();
            Fillcombo();
            Fillcombo1();

        }

        // to show in the cmbDepartment the names of the departments
        void Fillcombo()
        {
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
            string Query = "select * from Departments ";
            cn = new SqlConnection(constring);
            cmd = new SqlCommand(Query, cn);
            //SqlDataReader dr;

            try
            {
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string cName = dr["Name"].ToString();
                    cmbDepartment.Items.Add(cName);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
  
        // after choose the department -> take out all the courses of the choosen department
        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";

            try
            {
                string Query = "select * from Departments where Name = '" + cmbDepartment.Text + "' ;";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(Query, cn);
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // to save the id department
                    this.course.setCdepName(dr["Name"].ToString());
                    string id = dr["IDdepartment"].ToString();
                    this.course.setIdDep(Int32.Parse(id));
                }
                cn.Close();
                dr.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            if (this.course.getIdDep() == 0)
            {
                MessageBox.Show("You must choose department first!", "Message");
                clearCombo();
                return;
            }
            Fillcombo1(); // to show list courses
            Fillcombo2();  // to show lecture/practice
            Fillcombo3();  // to show the days
            MessageBox.Show("Your department choice: " + this.course.getCdepName(), "Message");
        }

        // to show in the cmbCourse the name of the courses
        void Fillcombo1()
        {
            this.cmbCourse.Items.Clear();
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
            string Query = "select distinct C.Name from CoursesDepartment CD, Departments D , Courses C where CD.IDdepartment = D.IDdepartment and CD.IDcourse = C.IDcourse and CD.IDdepartment ='" + this.course.getIdDep() + "'";
            cn = new SqlConnection(constring);
            cmd = new SqlCommand(Query, cn);

            try
            {
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // to save course name
                    this.course.setCourseName(dr["Name"].ToString());
                    cmbCourse.Items.Add(this.course.getCourseName());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // to show the option for lecture or practice
        void Fillcombo2()
        {
            cmbL_P.Items.Add("Lecture");
            cmbL_P.Items.Add("Practice");
        }

        // to show the days -cmbDay
        void Fillcombo3()
        {
            cmbDay.Items.Add("Sunday");
            cmbDay.Items.Add("Monday");
            cmbDay.Items.Add("Tuesday");
            cmbDay.Items.Add("Wednesday");
            cmbDay.Items.Add("Thursday");
            cmbDay.Items.Add("Friday");
        }

        // after choose course and lecture/practice
        private void button2_Click(object sender, EventArgs e)
        {
            // check input
            if (this.course.getIdDep() == 0)
            {
                MessageBox.Show("You must choose department first!", "Message");
                clearCombo();
                return;
            }
            if (cmbCourse.SelectedItem == null)
            {
                MessageBox.Show("You must need to choose course!", "Message");
                clearCombo();
                return;
            }
            if (this.cmbL_P.SelectedItem == null)
            {
                MessageBox.Show("You must need to choose a lecture or practice!", "Message");
                clearCombo();
                return;
            }
            if (this.cmbDay.SelectedItem == null)
            {
                MessageBox.Show("You must need to choose day", "Message");
                clearCombo();
                return;
            }
            if (this.cmbL_P.SelectedItem == null && cmbCourse.SelectedItem == null)
            {
                MessageBox.Show("You must need to choose lecture/practice and courrse", "Message");
                clearCombo();
                return;
            }
            if (this.cmbL_P.SelectedItem == null && cmbCourse.SelectedItem == null && this.cmbDay.SelectedItem == null)
            {
                MessageBox.Show("You must need to choose lecture/practice and courrse and day", "Message");
                clearCombo();
                return;
            }
            if (this.cmbDay.SelectedItem == null && cmbCourse.SelectedItem == null )
            {
                MessageBox.Show("You must need to choose courrse and day", "Message");
                clearCombo();
                return;
            }
            if (this.cmbDay.SelectedItem == null && cmbL_P.SelectedItem == null)
            {
                MessageBox.Show("You must need to choose lecture/practice and day", "Message");
                clearCombo();
                return;
            }
            if (this.cmbHours.SelectedIndex != null)
            {
                this.cmbHours.SelectedIndex = -1;
                this.cmbHours.Items.Clear();
            }

            // to save details course choosen
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
            try
            {
                string Query = "select * from Courses where Name = '" + cmbCourse.Text + "' ;";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(Query, cn);
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // to save the id course and the name
                    this.course.setCourseName(dr["Name"].ToString());
                    string id = dr["IDcourse"].ToString();
                    this.course.setIDcourse(Int32.Parse(id));
                }
                cn.Close();
                dr.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

            // to save the choose lecture or practice 
            this.strP_L = cmbL_P.Text;
            if (this.strP_L == "Lecture")
                this.type_P_L = 2;
            if (this.strP_L == "Practice")
                this.type_P_L = 3;

            //to save the day we get from the secretary
            this.course.setDayL(cmbDay.Text);

            // after the user choose the course and what he want to schedual (l/p) , we check 2 things:

            // 1 - if the course exists in the table schedualing - if the secretaty schedualing lecturer or teaching assistant to the choosen course
            bool checkCourse = isExistsCourse();
            if (checkCourse == false)
            {
                MessageBox.Show("The course not assigned", "administrator responsibility");
                clearCombo();
                return;
            }
            //if (checkCourse)
            //{
            //    MessageBox.Show("Course exsists in schedualing", "Message");
            //}
            //else
            //{
            //    MessageBox.Show("The course not assigned" , "administrator responsibility");
            //    clearCombo();
            //    return;
            //}

            // 2 - if in the table Courses assigned number of seats - limits of students

            int amountS = AmountSeats();
            if (amountS <=0)
            {
                MessageBox.Show("For this course not assigned seats Students", "administrator responsibility");
                clearCombo();
                return;
            }
            //if (amountS > 0)
            //{
            //    MessageBox.Show("The number seats from your choice: " + amountS ,"Message");
            //}
            //else
            //{
            //    MessageBox.Show("For this course not assigned seats Students", "administrator responsibility");
            //    clearCombo();
            //    return;
            //}

            // now we show the hours possible to the choosen details
            bool possHours = possibleHours();
            if (possHours == false)
            {
                //MessageBox.Show("No Possible Hours - FULL - Double block!", "administrator responsibility");
                MessageBox.Show("No Lecturer assign to this course!\nfirst assign lecturer to course" , "administrator responsibility");
                clearCombo();
                return;
            }
            //if (possHours)
            //{
            //    //show the list hours
            //    MessageBox.Show("Have a available hours to your choice","Message");
            //    showHours();
            //}
            //else
            //{
            //    MessageBox.Show("No Possible Hours - FULL - Double block!", "administrator responsibility");
            //    clearCombo();
            //    return;
            //}

            showHours();
            MessageBox.Show("Your choice: course "  +this.course.getCourseName()+ " and "+ this.strP_L , "Message");
        }

        // check if the choosen course exist in schedualing
        public bool isExistsCourse()
        {
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
            bool flag = false;  // not exist;

            try
            {
                //string q = "select seatsAmount from schedualing S, Courses C where S.courseName = '" +this.course.getCourseName()+ "' and S.courseName = C.Name;";
                string q = "select lecturer,teachingAssitant from schedualing where courseName = '"+this.course.getCourseName()+"' and day = '"+this.course.getDayL()+"' ";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(q, cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    if (dr["lecturer"].ToString() != null && dr["lecturer"].ToString() != "")
                    {
                        this.strP_L = dr["lecturer"].ToString();
                        //this.type_P_L = 2;
                        flag = true;
                    }
                    if (dr["teachingAssitant"].ToString() != null && dr["teachingAssitant"].ToString() != "")
                    {
                        this.strP_L = dr["teachingAssitant"].ToString();
                        //this.type_P_L = 3;
                        flag = true;
                    }
                    
                }
                dr.Close();
                cn.Close();

            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }

            return flag;
        }

        // check if assign setsAmount and return the amount
        public int AmountSeats()
        {
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
            bool flag = false;
            try
            {
                //string q = "select seatsAmount from schedualing S, Courses C where S.courseName = '" +this.course.getCourseName()+ "' and S.courseName = C.Name;";
                string q = "select seatsAmount from Courses where Name = '" + this.course.getCourseName() + "' and seatsAmount is not null ";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(q, cn);
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["seatsAmount"].ToString() != null)
                    {
                        this.course.setStudentsAmount(Int32.Parse(dr["seatsAmount"].ToString()));
                        flag = true;
                    }

                }
                dr.Close();
                cn.Close();

            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }
            if (flag == false)
                return 0;
            return this.course.getStudentsAmount();
        }

        // check if to the details that the user insert have a available hours!
        public bool possibleHours()
        {
            bool flag = false;
            if (this.type_P_L == 2)
            {
                try
                {
                    string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
                    //string Query = "SELECT timeStart, timeEnd from schedualing WHERE day ='" + this.course.getDayL() + "' and courseName = '" + this.course.getCourseName() + "' and lecturer is not null ";
                    string Query = "SELECT timeStart, timeEnd from schedualing WHERE day ='" + this.course.getDayL() + "' and courseName = '" + this.course.getCourseName() + "' and lecturer is not null ";
                    cn = new SqlConnection(constring);
                    cmd = new SqlCommand(Query, cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();

                    availableHours = new List<int>();
                    while (dr.Read())
                    {
                        if (dr["timeStart"].ToString() != null && dr["timeEnd"].ToString() != null)
                        {
                            availableHours.Add(Int32.Parse(dr["timeStart"].ToString()));
                            availableHours.Add(Int32.Parse(dr["timeEnd"].ToString()));
                            availableHours.Add(0);  // to help after to count how many hours
                            flag = true;
                        }

                        //if (dr["timeStart"].ToString() != null)
                        //{
                        //    availableHours.Add(Int32.Parse(dr["timeStart"].ToString()));
                        //    flag = true;
                        //}

                        //if (dr["timeEnd"].ToString() != null)
                        //{
                        //    availableHours.Add(Int32.Parse(dr["timeEnd"].ToString()));
                        //    flag = true;
                        //}

                    }
                    dr.Close();
                    cn.Close();
                }
                catch (Exception exe) { MessageBox.Show(exe.Message); }
            }

            if (this.type_P_L == 3)
            {
                try
                {
                    string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
                    string Query = "SELECT timeStart, timeEnd from schedualing WHERE day ='" + this.course.getDayL() + "' and courseName = '" + this.course.getCourseName() + "' and teachingAssitant is not null ";
                    cn = new SqlConnection(constring);
                    cmd = new SqlCommand(Query, cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();

                    availableHours = new List<int>();
                    while (dr.Read())
                    {
                        if (dr["timeStart"].ToString() != null && dr["timeEnd"].ToString() != null)
                        {
                            availableHours.Add(Int32.Parse(dr["timeStart"].ToString()));
                            availableHours.Add(Int32.Parse(dr["timeEnd"].ToString()));
                            availableHours.Add(0);  // to help after to count how many hours
                            flag = true;
                        }

                        //if (dr["timeStart"].ToString() != null)
                        //{
                        //    availableHours.Add(Int32.Parse(dr["timeStart"].ToString()));
                        //    flag = true;
                        //}

                        //if (dr["timeEnd"].ToString() != null)
                        //{
                        //    availableHours.Add(Int32.Parse(dr["timeEnd"].ToString()));
                        //    flag = true;
                        //}

                    }
                    dr.Close();
                    cn.Close();
                }
                catch (Exception exe) { MessageBox.Show(exe.Message); }
            }

            //int flag = 0;

            return flag;
        }

        // to show a list of hours (the timeStart)
        public void showHours()
        {
            int sizearr = availableHours.Count;
            int[] arr = availableHours.ToArray();
            for (int i=0; i < sizearr; i++)
            {
                if (i%3 == 0)
                    this.cmbHours.Items.Add(arr[i].ToString());
            }
        }

        // after choose the hours
        private void button4_Click(object sender, EventArgs e)
        {
            if (this.course.getCourseID() == 0 || this.course.getCdepName() == null || this.type_P_L == 0 || this.course.getDayL() == null)
            {
                MessageBox.Show("You must first choose department -> course & day & (lecture/practice) -> possible hours ", "Message");
                clearCombo();
                return;
            }

            bool checkClass = possibleAndShowClass();
            if (checkClass)
            {
                MessageBox.Show("Found match class", "Message");
            }
            else
            {
                MessageBox.Show("Double Block - cannot find available class to your details", "Message");
                clearCombo();
                return;
            }

        }

        // check if have possible classes - and show them
        public bool possibleAndShowClass()
        {
            bool flag = false;
            List<int> ocClasses = new List<int>();
            this.startTime = Int32.Parse(this.cmbHours.Text);
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
            try
            {
                //string Query = "SELECT distinct Numclass, Seats from sched3_class_A SCA, Courses C, Classes CS WHERE SCA.day = '" + this.course.getDayL() + "'  and C.seatsAmount = '" + this.course.getStudentsAmount() + "' and CS.Seats >= '" + this.course.getStudentsAmount() + "'; ";

                //string Query = "SELECT distinct Numclass, Seats from sched3_class_A SCA, Courses C, Classes CS , schedualing S WHERE SCA.day = '" + this.course.getDayL() + "'  and C.seatsAmount = '" + this.course.getStudentsAmount() + "' and CS.Seats >= '" + this.course.getStudentsAmount() + "' and S.timeStart='"+ this.startTime +"' and  S.class is not null and S.day = '" + this.course.getDayL() + "' and S.class=CS.Numclass; ";
                string Query = "SELECT distinct Numclass, Seats from sched3_class_A SCA, Courses C, Classes CS, schedualing S WHERE SCA.day = '" + this.course.getDayL() + "'  and C.seatsAmount =  '" + this.course.getStudentsAmount() + "'  and S.timeStart = '" + this.startTime + "' and S.class is not null and S.day='" + this.course.getDayL() + "' and S.class=CS.Numclass or CS.Seats <=  '" + this.course.getStudentsAmount() + "'   ";
                 //string Query = "SELECT * from sched3_class_A SCA, Courses C, Classes CS WHERE SCA.day ='" + this.course.getDayL() + "'  and C.seatsAmount = '"+this.course.getStudentsAmount()+ "' and CS.Seats = '" + this.course.getStudentsAmount() + "' ";
                 cn = new SqlConnection(constring);
                cmd = new SqlCommand(Query, cn);
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //cmbClass.Items.Add(dr["Numclass"].ToString());
                    //flag = true;
                    ocClasses.Add(Int32.Parse(dr["Numclass"].ToString()));
                }
                dr.Close();
                cn.Close();
            } catch (Exception e) { MessageBox.Show(e.Message); }

            //for (int i=300; i < 309; i++)
            //{
            //    for (int j=0; j < ocClasses.Count; j++)
            //    {
            //        if (ocClasses[j] == i)
            //            i++;
            //        else if (j == ocClasses.Count -1)
            //        {
            //            cmbClass.Items.Add(i);
            //            flag = true;
            //        }

            //    }
            //}
            int i = 300;
            while (i < 309)
            {
                for (int j = 0; j < ocClasses.Count; j++)
                {
                    if (ocClasses[j] == i)
                        i++;
                    else if (j == ocClasses.Count - 1)
                    {
                        cmbClass.Items.Add(i);
                        i++;
                        flag = true;
                    }
                }
            }




                //try
                //{
                //    string Query = "select NumClass from Classes ";
                //    cn = new SqlConnection(constring);
                //    cmd = new SqlCommand(Query, cn);
                //    cn.Open();
                //    dr = cmd.ExecuteReader();
                //    while (dr.Read())
                //    {
                //        for (int i = 0; i < ocClasses.Count; i++)
                //        {
                //            if (ocClasses[i] != Int32.Parse(dr["Numclass"].ToString()))
                //            {
                //                cmbClass.Items.Add(dr["Numclass"].ToString());
                //            }
                //        }
                //        //cmbClass.Items.Add(dr["Numclass"].ToString());
                //        flag = true;
                //        //ocClasses.Add(Int32.Parse(dr["Numclass"].ToString()));
                //    }
                //    dr.Close();
                //    cn.Close();
                //}
                //catch (Exception e) { MessageBox.Show(e.Message); }

                return flag;
        }

        // after choose the class
        private void button3_Click(object sender, EventArgs e)
        {
            // check input
            if (this.course.getCourseID() == 0 || this.course.getCdepName() == null || this.type_P_L == 0 || this.course.getDayL() == null)
            {
                MessageBox.Show("You must first choose department -> course & day & (lecture/practice) -> possible hours ", "Message");
                clearCombo();
                return;
            }




            // now that we know we have all the details: course, day, lecture or practice, start hour, class
            // when the user choose the class we need to save the details in 2 tables :

            // 1 - sched3_class_A
            bool checkUp = updateSchecd3();
            if (checkUp)
            {
                // 2 - schedualing
                bool checkInsert = updateSchedualing();
                if (checkInsert)
                {
                    //MessageBox.Show("Upadte + Insert Done succesfuly","Message");
                    MessageBox.Show("schedul success", "Message");
                    clearCombo();
                    return;
                }
                else
                {
                    //MessageBox.Show("not success to insert to schedualing", "Message");
                    //MessageBox.Show("schedul not success", "Message");
                    clearCombo();
                    return;
                }
            }
            else
            {
                //MessageBox.Show("not success to insert + update","Message");
                MessageBox.Show("schedul not success", "Message");

                clearCombo();
                return;
            }

        }

        // update table sched3_class_A with the columns to occupied with the details we get -> on the chhosen hour insert the course name 
        public bool updateSchecd3()
        {
            bool flag = false;
            //if (this.cmbClass.Text == null)
            //{
            //    MessageBox.Show("Follow the steps", "Message");
            //    clearCombo();
            //    return flag;
            //}
            this.choosenClass = Int32.Parse(this.cmbClass.Text);
            
            string[] arrUpdate = new string[17];  // to cahnge 16 to global !!!!!!!!!!!!!!! arrUpdate to save data and insert them after to table sched3
            arrUpdate[1] = this.choosenClass.ToString(); // place 1 in data table is for the number class 
            arrUpdate[2] = this.course.getDayL();  // place 2 is the day  
            //arrUpdate[3] = this.course.getDayL();   // the coohsen day for the lecture

            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";

            // to keep how many hours 
            int sizearr = availableHours.Count;
            int[] arr = availableHours.ToArray();

            for (int i = arr[0]; i< arr[1]; i++)
            {
                this.amountHours++;
            }


            //for (int i = 0; i < 17; i++)
            //{
            //    if (arr[i] == Int32.Parse(this.cmbHours.Text))
            //    {
            //        for (int j = i; j < 18 - i ; j++)
            //        {
            //            if (arr[j] == 0)
            //                break;
            //            this.amountHours++;
            //        }

            //    }
            //    if (this.amountHours != 0)
            //        break;
                    
            //}

            // to place the course in the hours that choosen by sec.
            for (int i = 3; i < 17; i++)
            {
                if (i + 5 == Int32.Parse(this.cmbHours.Text) )
                {
                    arrUpdate[i] = this.course.getCourseName();
                    for (int j = 1; j < amountHours; j++)
                        arrUpdate[j + i] = this.course.getCourseName();
                    break;
                }

            }

            // to save the previous details to the arrUpdate
            try
            {
                string q = "select * from sched3_class_A where day = '" + this.course.getDayL() + "' and class = '" + this.cmbClass.Text + "'  ";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(q, cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < 17; i++)
                    {
                        if (arrUpdate[i] == null || arrUpdate[i] == "")
                            arrUpdate[i] = dr[i].ToString();
                    }
                }
                cn.Close();
                dr.Close();

            }        catch (Exception ex) { MessageBox.Show(ex.Message); }


            // now we can to update the sched3_class_A
            try
            {
                string q = "update sched3_class_A set [8] = '" + arrUpdate[3] + "', [9] = '" + arrUpdate[4] + "' , [10] = '" + arrUpdate[5] + "', [11] = '" + arrUpdate[6] + "', [12] = '" + arrUpdate[7] + "', [13] = '" + arrUpdate[8] + "', [14] = '" + arrUpdate[9] + "', [15] = '" + arrUpdate[10] + "' , [16] = '" + arrUpdate[11] + "', [17] = '" + arrUpdate[12] + "', [18] = '" + arrUpdate[13] + "' , [19] = '" + arrUpdate[14] + "', [20] = '" + arrUpdate[15] + "' , [21] = '" + arrUpdate[16] + "' where day = '" + arrUpdate[2]+ "' and class = '" + arrUpdate[1] + "';";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(q, cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                flag = true;
                //int flag = 0;
                //while (dr.Read())
                //{
                //    //flag++;
                //    flag = true;
                //}
                cn.Close();
                dr.Close();
                //return true;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }



            return flag;
        }

        // after update sched3_class_A successfully we can to update table schedualing
        public bool updateSchedualing()
        {
            bool flag = false;
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
            this.startTime = Int32.Parse(this.cmbHours.Text);
            int endTime = Int32.Parse(this.cmbHours.Text) + this.amountHours;
            try
            {
                cn = new SqlConnection(constring);
                cn.Open();

                string q = "update schedualing set class = '"+this.cmbClass.Text+"' where day = '"+this.course.getDayL()+"' and courseName = '"+this.course.getCourseName()+"' and timeStart = '"+this.cmbHours.Text+"' and timeEnd = '"+endTime+"' ;";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(q, cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                flag = true;
                while (dr.Read())
                {
                    flag = true;
                }
                cn.Close();
                dr.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return flag;
        }

        // back to previous page
        private void bcktpp_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_schedForSecretary.currentA_schedForSecretary.Show(); 
        }

        private void A_schedClasses_Load(object sender, EventArgs e)
        {
            currentA_schedClasses = this;
        }

        // to clear comboBox
        public void clearCombo()
        {
            //
            //cmbDay.DataSource = null;
            this.cmbDepartment.SelectedIndex = -1;
            this.cmbL_P.SelectedIndex = -1;
            this.cmbCourse.SelectedIndex = -1;
            this.cmbDay.SelectedIndex = -1;
            this.cmbClass.SelectedIndex = -1;
            this.cmbHours.SelectedIndex = -1;
            // ---------------------- //
            //this.cmbDepartment.Items.Clear();
            this.cmbL_P.Items.Clear();
            this.cmbCourse.Items.Clear();
            this.cmbDay.Items.Clear();
            this.cmbClass.Items.Clear();
            this.cmbHours.Items.Clear();
        }

        // to check that all the user insert all the details !
        public bool checkIfEmptyDetails()
        {
            if (this.course.getCourseName() != null)
            {
                if (this.course.getStudentsAmount() != 0)
                {
                    if (this.course.getHoursLecture() != 0)
                    {
                        if (this.course.getHoursPractice() != 0)
                        {
                            if (this.course.getDayL() != null)
                            {
                                if (this.course.getDayP() != null)
                                {
                                    //MessageBox.Show("Good! all the details in!", "Message");
                                    return true;
                                }
                            }

                        }
                    }
                }
            }
            return false;
              
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
