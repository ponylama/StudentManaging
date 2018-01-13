using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New
{
    public class StudentClass
    {
        private int ID;
        private String FirstName;
        private String LastName;
        private String Year;
        //new yaharin - also added sets and gets
        private int Semester;
        private String Department;
        //
        private int Type;
        //need to add to data base
        //private int Semester;
        //rivate String Department;


        public StudentClass(int ID, String FirstName, String LastName,int Type, String Year,int semester,String department)
        {
            SetID(ID);
            SetFirstName(FirstName);
            SetLastName(LastName);
            SetYear(Year);
            SetType(Type); // student
            SetSemester(semester);
            SetDepartment(department);
        }

        
        //Set's && Get's
        //ID
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

        //Year

        public String getYear()
        {
            return Year;
        }
        public void SetYear(String Y)
        {
            Year = Y;
        }
        public int getType()
        {
            return Type;
        }
        public void SetType(int T)
        {
            Type = T;
        }
        //Semester
        public int getSemester()
        {
            return Semester;
        }

        public void SetSemester(int S)
        {
            Semester = S;
        }

        //Department

        public String getDepartment()
        {
            return Department;
        }
        public void SetDepartment(String D)
        {
            Department = D;
        }
    }


}


