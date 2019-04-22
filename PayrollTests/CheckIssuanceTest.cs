using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll;
using PayrollLibrary;

namespace PayrollTests
{
    [TestClass]
    public class CheckIssuanceTest
    {
        CheckIssuance session;
        Employee employee;

        [TestInitialize]
        public void TestInitialize()
        {
            employee = new Employee
            {
                FirstName = "John",
                LastName = "Galt",
                Id = 123,
                Department = "IT",
                Title = "Software Developer",
                StartDate = new DateTime(2019, 3, 5),
                Salary = 50_000
            };

            session = new CheckIssuance();
        }

        [TestMethod]
        public void Creates_Check_For_Employee()
        {
            Paycheck paycheck = session.CreateCheck(employee);
            Assert.AreEqual(employee.Id, paycheck.EmployeeId);
        }

        [TestMethod]
        public void Creates_Check_Of_Correct_Amount()
        {
            Paycheck paycheck = session.CreateCheck(employee);
            Assert.AreEqual(paycheck.Amount, employee.BiWeeklyGrossPay);
        }

        [TestMethod]
        public void Adds_Check_To_Employee_Paycheck_History()
        {
            session.AddCheckToEmployeePaycheckHistory(employee);
            Assert.AreEqual(1, employee.PaycheckHistory.Count);
        }
    }
}
