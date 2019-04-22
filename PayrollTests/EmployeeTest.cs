using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollLibrary;

namespace PayrollTests
{
    [TestClass]
    public class EmployeeTest
    {
        Employee employee;
        Paycheck paycheck1;
        Paycheck paycheck2;

        [TestInitialize]
        public void TestInitialize()
        {
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

            paycheck1 = new Paycheck
            {
                Id = 1,
                EmployeeId = employee.Id,
                IssueDate = new DateTime(2019, 3, 17),
                Amount = employee.BiWeeklyGrossPay
            };

            paycheck2 = new Paycheck
            {
                Id = 2,
                EmployeeId = employee.Id,
                IssueDate = new DateTime(2019, 4, 1),
                Amount = employee.BiWeeklyGrossPay
            };

        }

        [TestMethod]
        public void Creates_New_Employee()
        {
            Assert.IsNotNull(employee);
        }

        [TestMethod]
        public void Has_A_FirstName_Property()
        {
            Assert.AreEqual("John", employee.FirstName);
        }

        [TestMethod]
        public void Has_A_LastName_Property()
        {
            Assert.AreEqual("Galt", employee.LastName);
        }

        [TestMethod]
        public void Has_A_Department_Property()
        {
            Assert.AreEqual("IT", employee.Department);
        }

        [TestMethod]
        public void Has_An_Id_Property()
        {
            Assert.AreEqual(123, employee.Id);
        }

        [TestMethod]
        public void Has_A_Title_Property()
        {
            Assert.AreEqual("Software Developer", employee.Title);
        }

        [TestMethod]
        public void Has_A_Start_Date_Property()
        {
            var date = new DateTime(2019, 3, 5);
            Assert.AreEqual(date, employee.StartDate);
        }

        [TestMethod]
        public void Has_A_Salary_Property()
        {
            Assert.AreEqual(50_000, employee.Salary);
        }

        [TestMethod]
        public void Has_A_BiWeeklyGrossPay_Property()
        {
            var pay = decimal.Round(employee.Salary / 52, 2, MidpointRounding.AwayFromZero);
            Assert.AreEqual(pay, employee.BiWeeklyGrossPay);
        }

        [TestMethod]
        public void Has_A_Paycheck_History_Property()
        {
            Assert.IsTrue(employee.PaycheckHistory.GetType() == typeof(List<Paycheck>));
        }
    }
}
