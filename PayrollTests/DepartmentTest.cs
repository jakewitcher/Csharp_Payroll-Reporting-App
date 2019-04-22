using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollLibrary;

namespace PayrollTests
{
    [TestClass]
    public class DepartmentTest
    {
        Department department;
        Employee employee;
        Employee employee2;

        [TestInitialize]
        public void TestInitialize()
        {
            department = new Department
            {
                Name = "IT",
                Id = 789,
            };

            employee = new Employee
            {
                Id = 123,
                FirstName = "John",
                LastName = "Galt",
                Department = "IT",
                Title = "Software Developer",
                StartDate = new DateTime(2019, 3, 5),
                Salary = 50_000
            };

            employee2 = new Employee
            {
                Id = 101112,
                FirstName = "Howard",
                LastName = "Roark",
                Department = "IT",
                Title = "Software Architect",
                StartDate = new DateTime(2015, 7, 25),
                Salary = 80_000
            };
        }

        [TestMethod]
        public void Creates_New_Department()
        {
            Assert.IsNotNull(department);
        }

        [TestMethod]
        public void Has_A_Name_Property()
        {
            Assert.AreEqual("IT", department.Name);
        }

        [TestMethod]
        public void Has_An_Id_Property()
        {
            Assert.AreEqual(789, department.Id);
        }

        [TestMethod]
        public void Has_An_Employee_Roster_Property()
        {
            Assert.IsTrue(department.EmployeeRoster.GetType() == typeof(HashSet<Employee>));
        }

        [TestMethod]
        public void Adds_A_New_Employee_To_The_Roster()
        {
            department.AddEmployeeToRoster(employee);
            Assert.AreEqual(1, department.EmployeeRoster.Count);
        }

        [TestMethod]
        public void Removes_An_Employee_From_The_Roster()
        {
            department.AddEmployeeToRoster(employee);
            department.AddEmployeeToRoster(employee2);
            Assert.AreEqual(2, department.EmployeeRoster.Count);

            department.RemoveEmployeeFromRoster(employee2);
            Assert.AreEqual(1, department.EmployeeRoster.Count);
        }
    }
}
