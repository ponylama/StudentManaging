using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace New
{
    public class Student : User
    {
        private string year;
        private int credits;
        private int coursesAmount;
        private Course[] coursesList;
        private string depName;

        public Student()
        {
            this.credits = 0;
            this.coursesAmount = 0;
            //this.coursesList = new  Course [this.coursesAmount];
            //need to allocate it when first insert course
            this.coursesList = null;

            //this.grades = new ArrayList();
            //need to allocate it when first insert course



        }

        public Student(int id)
        {
            this.ID = id;
            this.credits = 0;
            this.coursesAmount = 0;
            this.coursesList = null;

        }


        public void setYear(string y)
        {
            this.year = y;
        }

        public string getYear()
        {
            return this.year;
        }

        public void setDep(string d)
        {
            this.depName = d;
        }

        public string getdepName()
        {
            return this.depName;
        }

    }
}
