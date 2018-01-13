using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New
{
    class Lecture
    {
        private int ID;
        private String FirstName;
        private String LastName;
        private int[] CourseId;

        public Lecture(int ID, String FirstName, String LastName, int[] CourseID)
        {
            this.ID = ID;
            this.FirstName = string.Copy(FirstName);
            this.LastName = string.Copy(LastName);
            Array.Copy(CourseID, this.CourseId, CourseID.Length);
        }
        public Lecture(int ID, String FirstName, String LastName)
        {
            this.ID = ID;
            this.FirstName = string.Copy(FirstName);
            this.LastName = string.Copy(LastName);
        }

        public int getID()
        {
            return ID;
        }
        public void SetID(int ID)
        {
            this.ID = ID;
        }
        //FirstName
        public String getFirstName()
        {
            return FirstName;
        }

        public void SetFirstName(String FN)
        {
            FirstName = FN;
        }

        //LastName
        public String getLasttName()
        {
            return LastName;
        }
        public void SetLastName(String LN)
        {
            LastName = LN;
        }
        public int[] getCourse()
        {
            return this.CourseId;
        }
        public void SetCourse(int[] course)
        {
            Array.Copy(course, this.CourseId, course.Length);
        }
    }
}
