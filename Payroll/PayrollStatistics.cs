using System;
using PayrollLibrary;

namespace Payroll
{
    public class PayrollStatistics
    {
        public decimal SalaryAverage { get; set; }
        public decimal BiWeeklyAverage { get; set; }
        public decimal SalarySum { get; set; }
        public decimal BiWeeklySum { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal MinSalary { get; set; }
        public int Count { get; set; }

        public PayrollStatistics()
        {
            MaxSalary = Int32.MinValue;
            MinSalary = Int32.MaxValue;
        }

        internal PayrollStatistics Accumulate(Employee employee)
        {
            Count += 1;
            SalarySum += employee.Salary;
            MaxSalary = Math.Max(employee.Salary, MaxSalary);
            MinSalary = Math.Min(employee.Salary, MinSalary);
            return this;
        }

        internal PayrollStatistics Compute()
        {
            SalaryAverage = FormatCalculationResult(SalarySum / Count);
            BiWeeklyAverage = FormatCalculationResult(SalaryAverage);
            BiWeeklySum = FormatCalculationResult(SalarySum);
            return this;
        }

        internal decimal FormatCalculationResult(decimal result)
        {
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }
    }
}
