using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New
{
   public class Employee: User
    {
        protected int seniority;
        protected double salary;
        
        public Employee()
        {

        }
        public Employee(int seniority)
        {
            this.seniority = seniority;
        }

        public double salaryCalc(int hoursAmount,double perHour)
        {

            return hoursAmount * perHour;
        }

        public bool setSalary(int hoursAmount, double perHour)
        {
            if (perHour > 0)
            {
                salary = this.salaryCalc(hoursAmount, perHour);
                return true;
            }
            else return false;
        }

        public int getSeniority()
        {
            return seniority;
        }

        public float calculatePrecentHoursWorkForWeek(int hoursAmount, int days)
        {
            // return precent of hours work per week
            float result = 0;
            if (days <= 7)
                result = (hoursAmount * days) / 100;
            return result;
        }

        public float calcultePrecentHoursWorkMonth(int hoursAmount, int days)
        {
            // return precent of hours work per month
            float result = 0;
            if (days <= 31)
                result = (hoursAmount * days) / 100;
            return result;
        }

        public bool checkLimithours(int currentHours)
        {
            if (currentHours > 184)
                return false;
            return true;
        }
    }

}
