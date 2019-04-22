using System.Collections.Generic;

namespace PayrollLibrary
{
    public class Department
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public HashSet<Employee> EmployeeRoster { get; set; }

        public void AddEmployeeToRoster(Employee employee)
        {
            EmployeeRoster.Add(employee);
        }

        public void RemoveEmployeeFromRoster(Employee employee)
        {
            EmployeeRoster.Remove(employee);
        }

        public Department()
        {
            EmployeeRoster = new HashSet<Employee>();
        }
    }
}
