using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollLibrary;
using PayrollSeedGenerator;

namespace PayrollTests
{
    [TestClass]
    public class GeneratePaycheckTest
    {
        Employee employee;

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
                StartDate = new DateTime(2019, 4, 1),
                Salary = 50_000
            };
        }

        [TestMethod]
        public void Calculates_Number_Of_Days_To_First_Paycheck()
        {
            var count = GeneratePaycheck.DaysToFirstPayday(employee);
            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void Generates_List_Of_Paydays()
        {
            var firstPayday = employee.StartDate.AddDays(4);
            var dates = GeneratePaycheck.AddDatesToList(employee, firstPayday);
            Assert.AreEqual(1, dates.Count);
        }

        [TestMethod]
        public void Generates_A_List_Of_Paychecks()
        {
            var firstPayday = employee.StartDate.AddDays(4);
            var dates = GeneratePaycheck.AddDatesToList(employee, firstPayday);
            var paychecks = GeneratePaycheck.GenerateChecks(employee, dates);

            Assert.AreEqual(1, paychecks.Count);
            Assert.AreEqual(employee.Id, paychecks[0].EmployeeId);
        }
    }
}
