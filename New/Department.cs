using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New
{
    public class Department
    {
        private int IDdepartment;
        private string DeptName;
        private int numCourses;
        private Course[] courses;
        private int numStudents;
        private Student[] students;
        private int numLectures;
        private Lecturer[] lecturers;
        private int numTA; // teaching assistant
        private TeachingAssitant[] TAssistant;
        private HeadDepartment DeptHead;


        

        public Department()
        {
            this.DeptName = null;
            this.IDdepartment = 0;
        }

        public Department(int deptID, string deptName)
        {
            this.IDdepartment = deptID;
            this.DeptName = deptName;
            this.numCourses = 0;
            this.courses = null;
            this.numStudents = 0;
            this.students = null;
            this.numLectures = 0;
            this.lecturers = null;
            this.numTA = 0;
            this.TAssistant = null;
            this.DeptHead = null;

        }

        public void setDepName(string name)
        {
            if (name != null)
                this.DeptName = name;
        }

        public string getDepName()
        {
            if (this.DeptName != null)
                return this.DeptName;
            return null;
        }

        public void setIDdep(int id)
        {
            this.IDdepartment = id;
        }

        public int getIDdep()
        {
            return this.IDdepartment;
        }
        public int getDeptID()
        {
            return this.IDdepartment;
           

        }
    }
}
