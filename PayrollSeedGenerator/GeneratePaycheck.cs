using System;
using System.Collections.Generic;
using System.Text;
using PayrollLibrary;
using System.Linq;
using PayrollData;

namespace PayrollSeedGenerator
{
    public static class GeneratePaycheck
    {
        public static List<Paycheck> GeneratePaycheckList(Employee employee)
        {
            int count = DaysToFirstPayday(employee);
            var checkDate = employee.StartDate.AddDays(count);
            var dates = AddDatesToList(employee, checkDate);

            return GenerateChecks(employee, dates);
        }

        public static void InsertPaychecks(PayrollContext context)
        {
            var query = context.Employees.ToList();
            foreach (var employee in query)
            {
                var paycheckList = GeneratePaycheck.GeneratePaycheckList(employee);
                employee.PaycheckHistory.AddRange(paycheckList);
            }
            context.SaveChanges();
        }

        public static List<Paycheck> GenerateChecks(Employee employee, List<DateTime> dates)
        {
            var result = new List<Paycheck>();
            result.AddRange(from date in dates
                            let check = new Paycheck
                            {
                                EmployeeId = employee.Id,
                                IssueDate = date,
                                Amount = employee.BiWeeklyGrossPay
                            }
                            select check);
            return result;
        }

        public static List<DateTime> AddDatesToList(Employee employee, DateTime checkDate)
        {
            var dates = new List<DateTime>();
            var currentDate = new DateTime(2019, 4, 16);
            if (checkDate < currentDate)
            {
                while (checkDate < currentDate)
                {
                    dates.Add(checkDate);
                    checkDate = checkDate.AddDays(28);
                }
            }

            return dates;
        }

        public static int DaysToFirstPayday(Employee employee)
        {
            int count = 0;
            DateTime dateTracker = employee.StartDate;

            while (dateTracker.DayOfWeek != DayOfWeek.Friday)
            {
                count++;
                dateTracker = dateTracker.AddDays(1);
            }

            return count;
        }
    }
}
