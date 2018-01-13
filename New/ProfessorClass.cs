using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New
{
    public class ProfessorClass
    {
        private int ID;
        private String FirstName;
        private String LastName;
        private String Department;
        private int Type;



        public ProfessorClass(int ID, String FirstName, String LastName, int Type, String department)
        {
            SetID(ID);
            SetFirstName(FirstName);
            SetLastName(LastName);
            SetType(Type); // student
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


        public int getType()
        {
            return Type;
        }
        public void SetType(int T)
        {
            Type = T;
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
