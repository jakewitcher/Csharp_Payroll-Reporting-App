using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollLibrary;

namespace PayrollTests
{
    [TestClass]
    public class PaycheckTest
    {
        Paycheck paycheck;
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

            paycheck = new Paycheck
            {
                Id = 1,
                EmployeeId = employee.Id,
                IssueDate = new DateTime(2019, 3, 17),
                Amount = employee.BiWeeklyGrossPay
            };
        }

        [TestMethod]
        public void Creates_New_Paycheck()
        {
            Assert.IsNotNull(paycheck);
        }

        [TestMethod]
        public void Has_An_Id_Property()
        {
            Assert.AreEqual(1, paycheck.Id);
        }

        [TestMethod]
        public void Has_An_Employee_Id_Property()
        {
            Assert.AreEqual(123, paycheck.EmployeeId);
        }

        [TestMethod]
        public void Has_An_Issue_Date_Property()
        {
            var date = new DateTime(2019, 3, 17);
            Assert.AreEqual(date, paycheck.IssueDate);
        }

        [TestMethod]
        public void Has_An_Amount_Property()
        {
            Assert.AreEqual(961.54M, paycheck.Amount);
        }
    }
}
