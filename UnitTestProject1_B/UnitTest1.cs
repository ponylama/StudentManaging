using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using New;

namespace UnitTestProject1_B
{
    [TestClass]
    public class UnitTest1
    {
        Student_Self_Placement SSP = new Student_Self_Placement();

        // Ovelap
        int id_F = 204688599;
        int start_F = 19;
        int End_F = 21;
        string day_F = "Sunday";
        //Not Overlap
        int id_T = 204688599;
        int start_T = 15;
        int End_T = 17;
        string day_T = "Sunday";

        int IDCourse = 1250;
        [TestMethod]
        public void conver_idcourse_to_name()
        {
            Assert.AreEqual(SSP.Convert_IDcourse_to_NameCourse(IDCourse),"Hedva 1");
            Assert.AreNotEqual(SSP.Convert_IDcourse_to_NameCourse(IDCourse), "Hedv");
        }

        [TestMethod]
        public void self_is_listed_to_course()
        {
            Assert.IsTrue(SSP.is_listed_to_Course(id_T, IDCourse));
            Assert.IsFalse(SSP.is_listed_to_Course(317509073, 1267));
        }


        //Yaharin - 1
        [TestMethod]
        public void Ovelap_Lec()
        {
            Assert.IsTrue(SSP.overlap_hours_Lec(id_T, start_T, End_T, day_T) == true);
            Assert.IsTrue(SSP.overlap_hours_Lec(id_F, start_F, End_F, day_F) == false);
        }
        
        Student_Placement_to_Practice_Secretary_B SSPS = new Student_Placement_to_Practice_Secretary_B();

        int currStudent = 204688599;
        string currPraName = "Hedva 1";
        string currPraName_F = "0";
        //Yaharin - 4
        [TestMethod]
        public void is_listed_lec()
        {
            Assert.IsTrue(SSPS.is_listed_to_Lec(currStudent, currPraName) == true);
            Assert.IsTrue((SSPS.is_listed_to_Lec(currStudent, currPraName_F)) == false);
        }
        //Yaharin - 5
        [TestMethod]
        public void is_listed_Pra()
        {
            Assert.IsTrue(SSPS.is_listed_to_practice_selected(currStudent, currPraName) == true);
            Assert.IsTrue((SSPS.is_listed_to_practice_selected(currStudent, currPraName_F)) == false);
        }

        string res = "1250";
        //Yaharin - 6
        [TestMethod]
        public void convert_name_to_id_course_pra()
        {
            Assert.AreEqual(SSPS.Convert_NameCourse_to_IDcourse(currPraName), res);
            Assert.AreNotEqual(SSPS.Convert_NameCourse_to_IDcourse(currPraName_F), "1250");
        }

        Student_Placement_to_Lec_Secretary_B SPLS = new Student_Placement_to_Lec_Secretary_B();
        //Yaharin - 7
        [TestMethod]
        public void convert_name_to_id_course_lec()
        {
            Assert.AreEqual(SPLS.Convert_NameCourse_to_IDcourse(currPraName), res);
            Assert.AreNotEqual(SPLS.Convert_NameCourse_to_IDcourse(currPraName_F), "1250");
        }
        //Yaharin - 8
        [TestMethod]
        public void self_is_listed_lecture()
        {
            Assert.IsTrue(SPLS.is_listed_to_lec(currStudent, currPraName) == true);
            Assert.IsTrue(SPLS.is_listed_to_lec(currStudent, currPraName_F) == false);
        }
        //Yaharin - 9
        [TestMethod]
        public void is_listed_Course()
        {
            Assert.IsTrue(SPLS.is_listed_to_Course(currStudent, "Hedva 1") == true);
            Assert.IsTrue(SPLS.is_listed_to_Course(currStudent, currPraName_F) == false);

        }

        Student_Placement_to_Lab_Secretary_B SPLABS = new Student_Placement_to_Lab_Secretary_B();
        //Yaharin - 10
        [TestMethod]
        public void convert_name_to_id_course_lab()
        {
            Assert.AreEqual(SPLABS.Convert_NameCourse_to_IDcourse(currPraName), res);
            Assert.AreNotEqual(SPLABS.Convert_NameCourse_to_IDcourse(currPraName_F), "1250");
        }

        
        //Yaharin - 11
        [TestMethod]
        public void convert_id_to_name_course_lab()
        {
            Assert.AreEqual(SPLABS.Convert_IDcourse_to_NameCourse(IDCourse), currPraName);
            Assert.AreNotEqual(SPLABS.Convert_IDcourse_to_NameCourse(IDCourse), currPraName_F);
        }
        [TestMethod]
        public void is_listed_lec_lab()
        {
            //Not Working - Why? 
            Assert.IsTrue(SPLABS.is_listed_to_lec(currStudent, res) == true);
            Assert.IsTrue(SPLABS.is_listed_to_lec(currStudent, currPraName_F) == false);
        }
        [TestMethod]
        public void is_listed_lab()
        {
            //Not Working - Why? 
            Assert.IsTrue(SPLABS.is_listed_to_Lab(currStudent, res) == true);
        }

        Student_Placement_to_Course_Secretary_B SPCS = new Student_Placement_to_Course_Secretary_B();
        [TestMethod]
        public void is_listed_to_course()
        {
            //need to put courseid
            int courseid = 1250;
            int courseid_f = 1111;
            Assert.IsTrue(SPCS.is_listed_to_Course(currStudent, courseid) == true);
            Assert.IsTrue(SPCS.is_listed_to_Course(currStudent, courseid_f) == false);
        }

        [TestMethod]
        public void course_name_id()
        {
            int courseid = 1250;
            string res = "Hedva 1";
            string res_f = "";
            Assert.AreEqual(SPCS.Courses_Name_ID(courseid), res);
            Assert.AreNotEqual(SPCS.Courses_Name_ID(courseid), res_f);
        }


        // unit test - tal - adar - eden
        [TestMethod]
        public void TestMethod1()
        {
            //TestCtor for class Department
            Department newDept = new Department(8000, "testDept");
            Assert.IsTrue((newDept.getDeptID() == 8000) && (newDept.getDepName() == "testDept"));

        }

        [TestMethod]
        public void TestMethod2()
        {
            //check validCapacity function
            Course course = new Course();
            Assert.IsTrue(course.validCapacity(80));
        }

        [TestMethod]
        public void TestMethod3()
        {
            //check Course class Ctor
            Course course = new Course(1297, "courseName");
            string name = course.getCourseName();
            int id = course.getCourseID();
            Assert.IsTrue(name == "courseName" && id == 1297);

        }

        [TestMethod]
        public void TestMethod4()
        {
            User user = new User(201483304, "tal", "malka");
            int id = user.getID();
            string fullName = user.getFirstName() + " " + user.getLastName();
            Assert.IsTrue(id == 201483304 && fullName == "tal malka");
        }


        [TestMethod]
        public void TestMethod5()
        {
            //check salaryCalc function
            Employee emp = new Employee();
            int hoursAmount = 50;
            double perHour = 48.5;
            Assert.IsTrue(emp.salaryCalc(hoursAmount, perHour) == 50 * 48.5);
        }


        [TestMethod]
        public void TestMethod6()
        {
            //check setSalary function
            Employee emp = new Employee();
            int hoursAmount = 50;
            double perHour = 0;
            Assert.IsFalse(emp.setSalary(hoursAmount, perHour));
        }

        [TestMethod]
        public void TestMethod7()
        {
            //check c'tor
            int seniority = 5;
            Employee emp = new Employee(seniority);
            Assert.IsTrue(emp.getSeniority() == seniority);

        }

        [TestMethod]
        public void TestMethod8()
        {
            //check c'tor
            int ID = 7000;
            bool b = true;
            HeadDepartment hs = new HeadDepartment(ID, b);
            Assert.IsTrue(hs.getDepartmentID() == ID && hs.getResearch() == b);

        }

        [TestMethod]
        public void TestMethod9()
        {
            // check calculatePrecentHoursWorkForWeek function
            int hours = 35;
            int days = 6;
            Employee emp = new Employee();
            Assert.IsTrue(emp.calculatePrecentHoursWorkForWeek(hours, days) == (35 * 6) / 100);
        }

        [TestMethod]
        public void TestMethod10()
        {
            // check calcultePrecentHoursWorkMonth function
            int hours = 70;
            int days = 20;
            Employee emp = new Employee();
            Assert.IsTrue(emp.calcultePrecentHoursWorkMonth(hours, days) == (70 * 20) / 100);
        }

        [TestMethod]
        public void TestMethod11()
        {
            // check checkLimithours function
            int hoursWork = 200;
            Employee emp = new Employee();
            Assert.IsFalse(emp.checkLimithours(hoursWork));

        }

        [TestMethod]
        public void TestMethod12()
        {
            // check mergetoone2 function
            string first = "eden";
            string last = "varsulker";
            string full = "eden varsulker";
            User user = new User();
            Assert.IsTrue(user.mergetoOne(first, last) == full);

        }

    }
}
