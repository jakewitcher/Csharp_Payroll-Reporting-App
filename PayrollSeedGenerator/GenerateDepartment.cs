using System.Collections.Generic;
using System.Linq;
using PayrollData;
using PayrollLibrary;

namespace PayrollSeedGenerator
{
    public static class GenerateDepartment
    {
        private static List<string> DepartmentNames = new List<string>
        {
            "Marketing", "Sales", "IT", "Logistics", "Merchandising", "Buying",
            "Product Development", "Customer Service", "Accounting"
        };

        public static List<Department> GenerateDepartmentList()
        {
            var result = new List<Department>();
            foreach (var name in DepartmentNames)
            {
                result.Add(new Department { Name = name });
            }
            return result;
        }

        public static void InsertDepartments(List<Department> departments, PayrollContext context)
        {
            context.Departments.AddRange(departments);
            context.SaveChanges();
        }

        public static void AddEmployeesToDepartmentList(PayrollContext context)
        {
            var departments = context.Departments.ToHashSet();
            var employees = context.Employees.ToList();

            foreach (var department in departments)
            {
                var departmentEmployees = from employee in employees
                                   where employee.Department == department.Name
                                   select employee;
                foreach (var employee in departmentEmployees)
                {
                    department.EmployeeRoster.Add(employee);
                }
            }
            context.SaveChanges();
        }
    }
}
