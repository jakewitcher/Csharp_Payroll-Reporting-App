using System;
using System.Collections.Generic;

namespace PayrollLibrary
{
    public class Employee
    {
        public decimal BiWeeklyGrossPay {
            get
            {
                return decimal.Round(Salary / 52, 2, MidpointRounding.AwayFromZero);
            }
        }
        public string Department { get; set; }
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Title { get; set; }
        public List<Paycheck> PaycheckHistory { get; set; }

        public Employee()
        {
            PaycheckHistory = new List<Paycheck>();
        }
    }
}
