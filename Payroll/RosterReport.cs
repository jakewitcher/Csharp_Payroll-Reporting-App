using System.Collections.Generic;
using System.Linq;
using PayrollData;
using PayrollLibrary;

namespace Payroll
{
    public static class RosterReport
    {
        public static List<IGrouping<string, Employee>> GetAllDepartmentRosters()
        {
            var context = new PayrollContext();
            return (from employee in context.Employees
                    orderby employee.LastName
                    group employee by employee.Department into department
                    orderby department.Key
                    select department).ToList();
        }

        public static List<IGrouping<string, Employee>> GetDepartmentRoster(string departmentName)
        {
            var context = new PayrollContext();
            return (from employee in context.Employees
                    where employee.Department == departmentName
                    orderby employee.LastName
                    group employee by employee.Department into department
                    select department).ToList();
        }
    }
}
