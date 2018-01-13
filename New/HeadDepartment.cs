using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New
{
    public class HeadDepartment : Employee
    {
        private bool research;
        private int departmentID;
        private string deparName;


        public HeadDepartment()
        {
            this.deparName = null;
            this.departmentID = 0;
        }

        //public HeadDepartment(int id, string firstName, string lastName, string depName )
        //{
        //    this.ID = id;
        //    this.FirstName = firstName;
        //    this.LastName = lastName;
        //    this.deparName = depName;
        //}

        public HeadDepartment(int ID,bool b)
        {
            this.research = b;
            this.departmentID = ID;
        }

        public int getDepartmentID()
        {
            return departmentID;
        }

        public bool getResearch()
        {
            return research;
        }
    }
}
