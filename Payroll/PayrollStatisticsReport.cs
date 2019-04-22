using System.Collections.Generic;
using System.Linq;
using PayrollData;
using PayrollLibrary;

namespace Payroll
{
    public static class PayrollStatisticsReport
    {
        public static SortedDictionary<string, PayrollStatistics> GetAllPayrollStatistics()
        {
            var result = new SortedDictionary<string, PayrollStatistics>();
            var context = new PayrollContext();
            var departments = (from department in context.Departments
                               orderby department.Name
                               select department.Name).ToList();

            foreach (var department in departments)
            {
                result.Add(department, GetPayrollStatistics(department));
            }

            return result;
        }

        public static SortedDictionary<string, PayrollStatistics> GetDepartmentPayrollStatistics(string departmentName)
        {
            var result = new SortedDictionary<string, PayrollStatistics>();
            result.Add(departmentName, GetPayrollStatistics(departmentName));
            return result;
        }

        private static PayrollStatistics GetPayrollStatistics(string departmentName)
        {
            var context = new PayrollContext();
            var employees = (from employee in context.Employees
                    where employee.Department == departmentName
                    select employee).ToList();
            return CalculateStatistics(employees);
        }

        public static PayrollStatistics CalculateStatistics(List<Employee> employees)
        {
            return employees.Aggregate(new PayrollStatistics(), (acc, e) => acc.Accumulate(e), acc => acc.Compute());
        }
    }
}
