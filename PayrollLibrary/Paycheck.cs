using System;

namespace PayrollLibrary
{
    public class Paycheck
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal Amount { get; set; }
    }
}
