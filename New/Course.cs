using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New
{
    public class Course
    {
        private int IDcourse;
        private string courseName;
        private Department department;
        private int StudentsAmount;   // how many students register to the course
        private Student[] StudentsCourse;  // list of the students they are in the course
        private int MaxCapacity;  // Maximum number of students that can enroll a course
        private string pre_course;
        private string blocks_course;
        private float credits;
        private int hoursLecture, hoursPractice;
        private string dayL, dayP;
        private int className;

        private int CourseID;
        // lec
        List<string> lectures = new List<string>();
        private int LectureID;
        private int LecBegin;
        private int LecEnd;
        private String LectureDay;
        //practice
        private int PracticeID;
        private int PracticeBegin;
        private int PracticeEnd;
        private String PracticeDay;
        //lab
        private int LabID;
        private int LabBegin;
        private int LabEnd;
        private String LabDay;


        public Course(int courseassigned = 0)
        {
            this.courseName = null;
            this.credits = -1;   // do not change -> depened a function! - eden
            this.pre_course = null;
            this.IDcourse = 0;
            this.StudentsAmount = 0;
            this.hoursLecture = 0;
            this.hoursPractice = 0;
            this.dayL = null;
            this.dayP = null;
            this.className = 0;
            this.department = new Department();

            //String CourseName, int CourseID, int LectureID, int LecBegin, int LecEnd, int PracticeID, int PracticeBegin, int PracticeEnd, int LabID, int LabBegin, int LabEnd
            CourseID = courseassigned;
            // lec
            LectureID = 0;
            LecBegin = 0;
            LecEnd = 0;
            LectureDay = "no day";
            //practice
            PracticeID = 0;
            PracticeBegin = 0;
            PracticeEnd = 0;
            PracticeDay = "no day";
            //lab
            LabID = 0;
            LabBegin = 0;
            LabEnd = 0;
            LabDay = "no day";
        }

        public Course(int id, string name)
        {
            this.IDcourse = id;
            this.courseName = name;
            this.credits = -1;
            this.MaxCapacity = 0;
            this.StudentsAmount = 0;
            this.department = null;
            this.StudentsCourse = null;
            this.pre_course = null;
            this.blocks_course = null;
        }
        public void setCourseName(string name)
        {
            this.courseName = name;
        }

        public string getCourseName()
        {
            return this.courseName;
        }

        public int getCourseID()
        {
            return this.IDcourse;
        }

        public void setPreCourse(string pre)
        {
            this.pre_course = pre;
        }

        public string getPreName()
        {
            return this.pre_course;
        }

        public void setBlockCourse(string block)
        {
            this.blocks_course = block;
        }

        public string getBlockCourse()
        {
            return this.blocks_course;
        }

        public void setCredits(float num)
        {
            this.credits = num;
        }

        public float getCredits()
        {
            return this.credits;
        }

        public void setIDcourse(int id)
        {
            this.IDcourse = id;
        }

        public int getIDcourse()
        {
            return this.IDcourse;
        }

        public bool setStudentsAmount(int amount)
        {
            if (amount <= 200 && amount >= 30)
            {
                this.StudentsAmount = amount;
                return true;
            }
            return false;
        }

        public int getStudentsAmount()
        {
            return this.StudentsAmount;
        }

        public void setHoursLecture(int h)
        {
            this.hoursLecture = h;
        }

        public int getHoursLecture()
        {
            return this.hoursLecture;
        }

        public void setHoursPractice(int h)
        {
            this.hoursPractice = h;
        }

        public int getHoursPractice()
        {
            return this.hoursPractice;
        }

        public string getDayL()
        {
            return this.dayL;
        }

        public string getDayP()
        {
            return this.dayP;
        }

       // public bool checkDays(string dayLect, string dayPra)
       //{
       //     if ()

       //         return false;   
       //}

        public void setDayL(string day)
        {
            this.dayL = day;
        }

        public void setDayP(string day)
        {
            this.dayP = day;
        }

        public void setClassName(int n)
        {
            this.className = n;
        }
        
        public int getClassName()
        {
            return this.className;
        }

        public void setIdDep(int id)
        {
            this.department.setIDdep(id);
        }

        public int getIdDep()
        {
            return this.department.getIDdep();
        }

        public void setCdepName(string d)
        {
            this.department.setDepName(d);
        }

        public string getCdepName()
        {
            return this.department.getDepName();
        }

        public Boolean validCapacity(int num)
        {
            if (num >= 20 && num <= 400)
                return true;
            return false;
        }

        //public bool setCourseName(String CourseName)
        //{
        //    this.CourseName = CourseName;
        //    return true;
        //}

        public bool SetCourseID(int CourseID)
        {
            this.CourseID = CourseID;
            return true;
        }

        public bool SetLectureID(int LectureID)
        {
            this.LectureID = LectureID;
            return true;
        }

        public bool SetLecBegin(int LecBegin)
        {
            this.LecBegin = LecBegin;
            return true;
        }

        public bool SetLecEnd(int LecEnd)
        {
            this.LecEnd = LecEnd;
            return true;
        }
        public bool SetLectureDay(String LectureDay)
        {
            this.LectureDay = LectureDay;
            return true;
        }

        public bool SetPracticeID(int PracticeID)
        {
            this.PracticeID = PracticeID;
            return true;
        }

        public bool SetPracticeBegin(int PracticeBegin)
        {
            this.PracticeBegin = PracticeBegin;
            return true;
        }

        public bool SetPracticeEnd(int PracticeEnd)
        {
            this.PracticeEnd = PracticeEnd;
            return true;
        }

        public bool SetPracticeDay(String PracticeDay)
        {
            this.PracticeDay = PracticeDay;
            return true;
        }

        public bool SetLabID(int LabID)
        {
            this.LabID = LabID;
            return true;
        }

        public bool SetLabBegin(int LabBegin)
        {
            this.LabBegin = LabBegin;
            return true;
        }

        public bool SetLabEnd(int LabEnd)
        {
            this.LabEnd = LabEnd;
            return true;
        }

        public bool SetLabDay(String LabDay)
        {
            this.LabDay = LabDay;
            return true;
        }

        //gets

        //public String getCourseName()
        //{
        //    return this.CourseName;
        //}

        public int GetCourseID()
        {
            return this.CourseID;
        }

        public int GetLectureID()
        {
            return this.LectureID;
        }

        public int GetLecBegin()
        {
            return this.LecBegin;
        }

        public int GetLecEnd()
        {
            return this.LecEnd;
        }

        public String GetLectureDay()
        {
            return this.LectureDay;
        }

        public int GetPracticeID()
        {
            return this.PracticeID;
        }

        public int GetPracticeBegin()
        {
            return this.PracticeBegin;
        }

        public int GetPracticeEnd()
        {
            return this.PracticeEnd;
        }

        public String GetPracticeDay()
        {
            return this.PracticeDay;
        }

        public int GetLabID()
        {
            return this.LabID;
        }

        public int GetLabBegin()
        {
            return this.LabBegin;
        }

        public int GetLabEnd()
        {
            return this.LabEnd;
        }

        public String GetLabDay()
        {
            return this.LabDay;
        }

        public string PrintToScreen()
        {
            string String_temp = GetCourseID().ToString() + "\n" + GetLectureID().ToString() + "\n" + GetLabID().ToString() + "\n" + GetPracticeID().ToString();
            return String_temp;
        }



    }
}
