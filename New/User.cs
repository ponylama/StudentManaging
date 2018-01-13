using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New
{
    public class User
    {
        protected int ID;
        protected string FirstName;
        protected string LastName;
        protected string Password;
        protected Department department;
        
        public User()
        {
            this.department = new Department();
        }
        public User(int id, string firstName, string lastName)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public User(int id, string firstName, string lastName,string pass,Department dept)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = pass;
            this.department = new Department();
            this.department = dept;
        }

        public void setFirstName(string name)
        {
            this.FirstName = name;
        }

        public string getFirstName()
        {
            return this.FirstName;
        }

        public void setLastName(string name)
        {
            this.LastName = name;
        }

        public string getLastName()
        {
            return this.LastName;
        }

        public void setID(int id)
        {
            this.ID = id;
        }
        public int getID()
        {
            return this.ID;
        }

        public void setdeparName(string name)
        {
            if (name != null)
            {
                this.department.setDepName(name);
            }
        }

        public string getdeparName()
        {
            if (this.department.getDepName() != null)
                return this.department.getDepName();
            return null;

        }
        
        public string mergetoOne(string first, string last)
        {
            return first +" " + last;
        }     

        
             
    }
}
