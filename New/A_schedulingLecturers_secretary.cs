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
    public partial class A_schedulingLecturers_secretary : Form
    {
        public static A_schedulingLecturers_secretary currentA_schedulingLecturers_secretary;
        DataTable data;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter sda;
        SqlConnection cn;
        Course course;
        int selectRowIndex;
        Lecturer [] arr;
        private int size = 0; // size arr Lecturer
        private int countHours = 0; // the total available hours lecturer
        List<int> lectHours = new List<int>();  // keep the available hours lecturer
        private int choosenLecturer;  // = 0 ; // index arr of lecturer

        public A_schedulingLecturers_secretary()
        {
            InitializeComponent();
            course = new Course();
            Fillcombo();
        }

        // to show in the comboBox2 the names of the departments
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
                    comboBox2.Items.Add(cName);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // to show in the combobox the name of the courses
        void Fillcombo1()
        {
            this.comboBox1.Items.Clear();
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
            string Query = "select distinct C.Name from CoursesDepartment CD, Departments D , Courses C where CD.IDdepartment = D.IDdepartment and CD.IDcourse = C.IDcourse and CD.IDdepartment ='" + this.course.getIdDep() + "'";
            //string Query = "select distinct Name from Courses C,CoursesDepartment CD  where CD.IDdepartment = '" + this.course.getIdDep()+ "'";
            cn = new SqlConnection(constring);
            cmd = new SqlCommand(Query, cn);
            //SqlDataReader dr;

            try
            {
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    this.course.setCourseName(dr["Name"].ToString());
                    //string cName = dr["Name"].ToString();
                    //cmbCourse.Items.Add(cName);
                    comboBox1.Items.Add(this.course.getCourseName());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // to show the days -comboBox3
        void Fillcombo2()
        {
            comboBox3.Items.Add("Sunday");
            comboBox3.Items.Add("Monday");
            comboBox3.Items.Add("Tuesday");
            comboBox3.Items.Add("Wednesday");
            comboBox3.Items.Add("Thursday");
            comboBox3.Items.Add("Friday");
        }

        private void A_schedulingLecturers_secretary_Load(object sender, EventArgs e)
        {
            currentA_schedulingLecturers_secretary = this;
        }

        // after the user choose department -> we check the courses that belongs to the department and show them in comboBox1
        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";

            try
            {
                string Query = "select * from Departments where Name = '" + comboBox2.Text + "' ;";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(Query, cn);
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // to save the id course
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
            Fillcombo2(); // to choose the day
            MessageBox.Show("Your department choice: " + this.course.getCdepName(), "Message");
        }

        // after the user choose department and course -> we show up a list of the lecturer Potential 
        private void button1_Click(object sender, EventArgs e)
        {
            // check input
            if (this.course.getIdDep() == 0)
            {
                MessageBox.Show("You must choose department first!", "Message");
                clearCombo();
                return;
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("You must need to choose course!", "Message");
                clearCombo();
                return;
            }
            if (this.comboBox3.SelectedItem == null)
            {
                MessageBox.Show("You must need to choose a day!", "Message");
                clearCombo();
                return;
            }
            if (this.comboBox3.SelectedItem == null && comboBox1.SelectedItem == null)
            {
                MessageBox.Show("You must need to choose day and courrse", "Message");
                clearCombo();
                return;
            }

            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";

            try
            {
                string Query = "select * from Courses where Name = '" + comboBox1.Text + "' ;";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(Query, cn);
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // to save the id course
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

            // to save the day choosen for lecturer course
            this.course.setDayL(this.comboBox3.Text);

            MessageBox.Show( "Your course choice: " + this.course.getCourseName()  +" day "+ this.course.getDayL() ,"Message");

            // now to check potentioal lecturer 
            bool checkLect = savePotentialLecturer(); 
            if (checkLect == false)
            {
                //MessageBox.Show("No lecturer assign to this course! (administrator responsibility - HD)! try another choice", "Message");
                MessageBox.Show("No lecturer assign to this course! try another choice", "Administrator responsibility - Head Department");
                clearCombo();
                return;
            }
            else // check the hours of the lecturer
            {
                isTaMatchTheDay();  // check if the lecturer match the choosen day - in the function if not match add to sched1_lecturer_A
                FillcomboLecturer();
            }

            //if (this.course.getDayL() == null)
            //    MessageBox.Show("You must need to choose a day!", "Message");
            //if (this.course.getIDcourse() == 0)
            //    MessageBox.Show("You must need to choose course!", "Message");
            //if (this.course.getDayL() == null && this.course.getIDcourse() == 0)
            //    MessageBox.Show("You must need to choose day and courrse", "Message");


        }

        // to save all the relevant lecturer in arr 
        public bool savePotentialLecturer()
        {
            //int size = 0;
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
            try
            {
                //string q = "select Departments,count(*) from Users U where type = 2 and U.Departments = '" + this.course.getCdepName() + "' group by Departments having COUNT(*) > 0";
                //string q = "select id,LastName,FirstName from Users U where type = 2 and U.Departments = '"+this.course.getCdepName()+"' ";
                //string q = "select U.ID, U.LastName, U.FirstName from Users U, StaffCourses SC where U.type = 2 and U.Departments = '" + this.course.getCdepName() + "' and SC.IDcourse = '" + this.course.getIDcourse() + "' and U.ID = SC.ID";
                string q = "select distinct U.ID, U.LastName, U.FirstName from Users U, StaffCourses SC, UsersDepartment UD where U.type = 2 and UD.IDdepartment = '" + this.course.getIdDep() + "' and SC.IDcourse = '" + this.course.getIDcourse() + "' and U.ID = SC.ID  and U.ID = UD.ID";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(q, cn);
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // to know how many match lecturer
                    this.size++;
                }
                cn.Close();
                dr.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

            arr = new Lecturer[size];
            for (int j = 0; j < size; j++)
                arr[j] = new Lecturer();

            try
            {
                //string q = "select Departments,count(*) from Users U where type = 2 and U.Departments = '" + this.course.getCdepName() + "' group by Departments having COUNT(*) > 0";
                //string q = "select U.ID, U.LastName, U.FirstName from Users U, StaffCourses SC where type = 2 and U.Departments = '" + this.course.getCdepName() + "' and SC.IDcourse = '" + this.course.getIDcourse() + "' and U.ID = SC.ID";
                //string q = "select U.ID, U.LastName, U.FirstName from Users U, StaffCourses SC where U.type = 2 and U.Departments = '" + this.course.getCdepName() + "' and SC.IDcourse = '" + this.course.getIDcourse() + "' and U.ID = SC.ID";
                string q = "select distinct U.ID, U.LastName, U.FirstName from Users U, StaffCourses SC, UsersDepartment UD where U.type = 2 and UD.IDdepartment = '" + this.course.getIdDep() + "' and SC.IDcourse = '" + this.course.getIDcourse() + "' and U.ID = SC.ID  and U.ID = UD.ID";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(q, cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    // to save the details into Lecturer arr
                    this.arr[i].setID(Int32.Parse(dr["ID"].ToString()));
                    this.arr[i].setFirstName(dr["FirstName"].ToString());
                    this.arr[i].setLastName(dr["LastName"].ToString());
                    i++;
                }
                cn.Close();
                dr.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

            // if no match lecturer
            if (size == 0)
            {
                //MessageBox.Show("No lecturer assign to this course! (administrator responsibility - HD)", "Message");
                return false;
            }
            else
            {
                //for (int i = 0; i < size; i++)
                //    MessageBox.Show(this.arr[i].getFirstName());
                return true;
            }

        }

        // check if the potentioal lecturer match to the choosen day - if need to update or to insert to sched1_lecturer_A
        public void isTaMatchTheDay()
        {
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";

            for (int i = 0; i < this.size; i++)
            {
                try
                {
                    string q = "select ID from sched1_lecturer_A SLA where ID = '" + this.arr[i].getID() + "' and day = '" + this.course.getDayL() + "';";
                    cn = new SqlConnection(constring);
                    cmd = new SqlCommand(q, cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    int flag = 0;
                    while (dr.Read())
                    {
                        flag++;
                    }
                    cn.Close();
                    dr.Close();

                    if (flag == 0)  // id and day not in the table sched1_lecturer_A - lecturer not in the table - insert him
                    {
                        // have a MessageBox - check for me !
                        //MessageBox.Show("User " + this.arr[i].getFirstName() + " in day " + this.course.getDayL() + " not in table sched1_lecturer_A", "Message");   // for me
                        bool insert = insertToSchecd1(this.arr[i]);  // insert the user - 
                        if (insert == false)
                            MessageBox.Show("insert failed", "Message");

                        //if (insert == true)  // if insert return true
                        //    MessageBox.Show("Insert the lecturer with the day to the table", "Message");
                        //else  
                        //    MessageBox.Show("insertToSchecd1() = false", "Message");

                        ////return false; // mean need to call insetToSched1()
                    }
                    //else
                    //{
                    //    findFreeHours(this.arr[i]);   // insert into a List the available hours of the lecturer - after the last choose we update in the table
                    //}
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }

           
        }

        //insert user to the table sched1_lecturer_A - lecturer that doesn't exsit in the table
        public bool insertToSchecd1(Lecturer lect)
        {
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";

            int index;
            int nextIndex = 0;

            try
            {
                string q = "select MAX(num) from sched1_lecturer_A";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(q, cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    index = Int32.Parse(dr[0].ToString()) + 1;
                    nextIndex = index; //in order to get index out of the red() loop
                }
                dr.Close();
                cn.Close();

            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }

            try
            {
                cn = new SqlConnection(constring);
                cn.Open();

                string q = "insert into [sched1_lecturer_A]  (Num,ID, lecturer,day) values(@Num , @ID, @lecturer , @Day );";
                cmd = new SqlCommand(q, cn);
                cmd.Parameters.AddWithValue("@Num", nextIndex);
                cmd.Parameters.AddWithValue("@ID", lect.getID());
                cmd.Parameters.AddWithValue("@lecturer", lect.mergetoOne(lect.getFirstName(), lect.getLastName()));
                cmd.Parameters.AddWithValue("@Day", this.course.getDayL());

                //cmd.CommandText = "SELECT SCOPE_IDENTITY()";
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                //dr = cmd.ExecuteReader();

                cn.Close();
                dr.Close();
                return true;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return false;

        }

        // to show lecturer potentioal list - comboBox5
        public void FillcomboLecturer()
        {
            for (int i = 0; i < this.size; i++)
                comboBox5.Items.Add(this.arr[i].getID());
        }
        
        // to check the available hours of the lecturer
       public void findFreeHours(Lecturer lec)
        {
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
            string Query = "SELECT * from sched1_lecturer_A WHERE lecturer ='" + lec.mergetoOne(lec.getFirstName(),lec.getLastName()) + "' and day = '"+ this.comboBox3.SelectedItem + "'";
            cn = new SqlConnection(constring);
            cmd = new SqlCommand(Query, cn);
            cn.Open();
            dr = cmd.ExecuteReader();

            List<int> availableHours = new List<int>();
            while (dr.Read())
            {
                if (dr["8"].ToString() == "")
                {
                    availableHours.Add(8);
                }
                if (dr["9"].ToString() == "")
                {
                    availableHours.Add(9);
                }
                if (dr["10"].ToString() == "")
                {
                    availableHours.Add(10);
                }
                if (dr["11"].ToString() == "")
                {
                    availableHours.Add(11);
                }
                if (dr["12"].ToString() == "")
                {
                    availableHours.Add(12);
                }
                if (dr["13"].ToString() == "")
                {
                    availableHours.Add(13);
                }
                if (dr["14"].ToString() == "")
                {
                    availableHours.Add(14);
                }
                if (dr["15"].ToString() == "")
                {
                    availableHours.Add(15);
                }
                if (dr["16"].ToString() == "")
                {
                    availableHours.Add(16);
                }
                if (dr["17"].ToString() == "")
                {
                    availableHours.Add(17);
                }
                if (dr["18"].ToString() == "")
                {
                    availableHours.Add(18);
                }
                if (dr["19"].ToString() == "")
                {
                    availableHours.Add(19);
                }
                if (dr["20"].ToString() == "")
                {
                    availableHours.Add(20);
                }
                if (dr["21"].ToString() == "")
                {
                    availableHours.Add(21);
                }
                break;

            }
            dr.Close();
            cn.Close();
            //int flag = 0;

            //List<int> lectHours = new List<int>();

            for (int i = 0; i < availableHours.Count() - 1; i++)
            {
                if (availableHours[i] == availableHours[i + 1] - 1)
                {
                    lectHours.Add(availableHours[i]);
                    if (lectHours.Contains(availableHours[i + 1]))
                    {
                        continue;
                    }
                    else
                    {
                        lectHours.Add(availableHours[i + 1]);
                    }
                    //flag++;
                    this.countHours++;
                }

            }
        }
        
        // back to previous page
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_schedForSecretary.currentA_schedForSecretary.Show();
        }

        // after the user choose lecturer id and amiunt of hours -> need to show the relevant hours for specific lecturer
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.course.getCourseID() == 0 || this.course.getCdepName() == null)
            {
                MessageBox.Show("You must first choose department -> course & day -> amount hours", "Message");
                clearCombo();
                return;
            }

            if (this.comboBox4.SelectedIndex != null)
            {
                this.comboBox4.SelectedIndex = -1;
                this.comboBox4.Items.Clear();
            }

            MessageBox.Show("Good! continue with the last choice", "Message");
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!! to check only why print 3 times all the hours !!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            int amountHours = Decimal.ToInt32(numericUpDown1.Value);
            findFreeHours(this.arr[this.choosenLecturer]);  // to show the available hours of the lecturer
            if (this.countHours >= amountHours)
            {
                
                int sizearr = lectHours.Count;
                int[] arr = lectHours.ToArray();
                bool flag = true;
                //MessageBox.Show(sizearr.ToString());
                this.comboBox4.Items.Add(arr[0].ToString());
                for (int i = 0; i < sizearr - 1; i++)
                {
                    if (arr[i] == arr[i + 1])
                    {
                        i++;
                        i += amountHours;
                        
                        try
                        {
                            this.comboBox4.Items.Add(arr[i].ToString());
                        } catch (Exception exe) {  }

                        ///////////////////////////////////////////////////////MessageBox.Show(exe.Message);//////////
                        //if (i == (sizearr - amountHours))
                        //    break;

                    }
                }
            }

            //findFreeHours(this.arr[this.choosenLecturer]);  // to show the available hours of the lecturer
        }

        // after choose the hours she want to schedual
        private void button5_Click(object sender, EventArgs e)
        {
            // check input
            if (this.course.getCourseID() == 0 || this.course.getCdepName() == null || this.comboBox4.SelectedItem == null)
            {
                MessageBox.Show("You must first choose department -> course & day -> amount hours -> hour ", "Message");
                clearCombo();
                return;
            }


            int i = 0;
            try
            {
                for (i = 0; i < this.size; i++)
                {
                    if (this.arr[i].getID() == Int32.Parse(this.comboBox5.SelectedItem.ToString()))
                        break;
                }
            } catch (Exception exe) {  }   /// MessageBox.Show(exe.Message);


            // now we need to update the 2 tables  
            updateSched1();

            bool s = checkDoubleBlock();
            if (s)
            {
                bool sc = schedualing();
                if (sc)
                {
                    //MessageBox.Show("insert to schedualing", "Message");
                    MessageBox.Show("insert success", "Message");
                }
                else
                {
                    //MessageBox.Show("not insert to schedualing", "Message");
                    MessageBox.Show("insert failed", "Message");

                }

            }
            else
                MessageBox.Show("double block - not insert to schedualing", "Message");

            clearCombo();
            return;
        }

        // update table sched1
        public void updateSched1()
        {
            string[] arrUpdate = new string[18];  // to cahnge 16 to global !!!!!!!!!!!!!!!
            arrUpdate[1] = this.arr[this.choosenLecturer].getID().ToString(); // place 1 in data table is for the ID lecturer 
            arrUpdate[2] = this.arr[this.choosenLecturer].mergetoOne(this.arr[this.choosenLecturer].getFirstName(), this.arr[this.choosenLecturer].getLastName()); // place 2 is the full name lecturer 
            arrUpdate[3] = this.course.getDayL();   // the coohsen day for the lecture

            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
            
            // to find the main key of the table
            try
            {
                string q = "select * from sched1_lecturer_A where ID = '"+ arrUpdate[1] + "' and day = '"+arrUpdate[3] +"';";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(q, cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    arrUpdate[0] = dr[i].ToString();
                    i++;
                }
                dr.Close();
                cn.Close();

            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }

            int amountHours = Decimal.ToInt32(numericUpDown1.Value);

            // to place the course in the hours that choosen by sec.
            for (int i = 4; i < 18; i++)
            {
                if (i + 4 == Int32.Parse(this.comboBox4.Text))
                {
                    arrUpdate[i] = this.course.getCourseName();
                    for (int j = 1; j < amountHours; j++)
                        arrUpdate[j + i] = this.course.getCourseName();
                    break;
                }

            }

            // to save the details from sched1_lecturer_A 
            try
            {
                string q = "select * from sched1_lecturer_A where Num = '" + arrUpdate[0] + "' ;";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(q, cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < 18; i++)
                    {
                        if (arrUpdate[i] == null)
                            arrUpdate[i] = dr[i].ToString();
                    }

                }
                dr.Close();
                cn.Close();

            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }

            // now we can to upddate the sched1_lecturer_A
            try
            {
                string q = "update sched1_lecturer_A set [8] = '" + arrUpdate[4] + "', [9] = '"+ arrUpdate[5] + "' , [10] = '"+ arrUpdate[6] + "', [11] = '" + arrUpdate[7] + "', [12] = '" + arrUpdate[8] + "', [13] = '" + arrUpdate[9] + "', [14] = '" + arrUpdate[10] + "', [15] = '" + arrUpdate[11] + "' , [16] = '" + arrUpdate[12] + "', [17] = '" + arrUpdate[13] + "', [18] = '" + arrUpdate[14] + "' , [19] = '" + arrUpdate[15] + "', [20] = '" + arrUpdate[16] + "' , [21] = '" + arrUpdate[17] + "' where  Num= '" + arrUpdate[0] + "' and ID = '" + arrUpdate[1] + "';";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(q, cn);
                cn.Open();
                dr = cmd.ExecuteReader();

                int flag = 0;
                while (dr.Read())
                {
                    flag++;
                }
                cn.Close();
                dr.Close();
                //return true;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
 
        }

        //insert details to schedualing
        public bool checkDoubleBlock()
        {

            // first we check that the user not already in the table
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";
            bool flag = true;
            try
            {
                //string q = "select * from schedualing where ID = '" + this.arr[this.choosenLecturer].getID() + "' and day = '" + this.course.getDayL() + "' and courseName = '"+this.course.getCourseName()+"';";
                string q = "select * from schedualing where ID = '" + this.arr[this.choosenLecturer].getID() + "' and day = '" + this.course.getDayL() + "' and courseName = '" + this.course.getCourseName() + "' and timeStart = '" + Decimal.ToInt32(numericUpDown1.Value) + "';";

                cn = new SqlConnection(constring);
                cmd = new SqlCommand(q, cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    flag = false; // if inside mean the lecturer already in table - double block
                }
                dr.Close();
                cn.Close();

                if (flag)   // need to insert to table schedualing
                {

                    return true;
                }
                else
                {
                    //MessageBox.Show("Double block", "Message");
                    return false;
                    
                }
            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }
            return false;  // if double block 
        }

        public bool schedualing()
        {
            string constring = "Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017";

            int index;
            int nextIndex = 0;

            try
            {
                string q = "select MAX(num) from schedualing";
                cn = new SqlConnection(constring);
                cmd = new SqlCommand(q, cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    index = Int32.Parse(dr[0].ToString()) + 1;
                    nextIndex = index; //in order to get index out of the red() loop
                }
                dr.Close();
                cn.Close();

            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }

            try
            {
                cn = new SqlConnection(constring);
                cn.Open();

                string q = "insert into schedualing  (Num,lecturer,ID, day , courseName , timeStart, timeEnd) values(@Num,  @lecturer , @ID, @Day,@courseName, @timeStart ,@timeEnd );";
                cmd = new SqlCommand(q, cn);
                cmd.Parameters.AddWithValue("@Num", nextIndex);
                cmd.Parameters.AddWithValue("@lecturer", arr[choosenLecturer].mergetoOne(arr[choosenLecturer].getFirstName(), arr[choosenLecturer].getLastName()));
                cmd.Parameters.AddWithValue("@ID", arr[choosenLecturer].getID());
                cmd.Parameters.AddWithValue("@Day", this.course.getDayL());
                cmd.Parameters.AddWithValue("@courseName", this.course.getCourseName());
                cmd.Parameters.AddWithValue("@timeStart", Int32.Parse(this.comboBox4.Text));
                cmd.Parameters.AddWithValue("@timeEnd", Int32.Parse(this.comboBox4.Text) + Decimal.ToInt32(numericUpDown1.Value));

                //cmd.CommandText = "SELECT SCOPE_IDENTITY()";
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                //dr = cmd.ExecuteReader();

                cn.Close();
                dr.Close();
                return true;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return false; // insert not success
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // to clear the combo after each wrong action of the user
        public void clearCombo()
        {
            // to clear comboBox
            //cmbDay.DataSource = null;
            this.comboBox2.SelectedIndex = -1;
            this.comboBox3.SelectedIndex = -1;
            this.comboBox1.SelectedIndex = -1;
            this.comboBox5.SelectedIndex = -1;
            this.comboBox4.SelectedIndex = -1;
            // ---------------------- //
            //this.comboBox2.Items.Clear();
            this.comboBox3.Items.Clear();
            this.comboBox1.Items.Clear();
            this.comboBox5.Items.Clear();
            this.comboBox4.Items.Clear();
        }

    }
}
