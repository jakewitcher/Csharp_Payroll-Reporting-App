using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll;
using PayrollLibrary;

namespace PayrollTests
{
    [TestClass]
    public class ReportingTest
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod]
        public void Returns_Nth_Highest_Paid_Employees()
        {
            var result = Reporting.CalculateHighestPaidEmployees(10);
            Assert.AreEqual(10, result.Count);
            Assert.AreEqual(118_523M, result[0].Salary);
            Assert.IsTrue(IsHighestSalary(result));
        }

        [TestMethod]
        public void Returns_Nth_Most_Veteran_Employees()
        {
            var result = Reporting.CalculateMostVeteran_Employees(10);
            Assert.AreEqual(10, result.Count);
            Assert.AreEqual(new DateTime(2017, 11, 20), result[0].StartDate);
            Assert.IsTrue(IsOldestStartDate(result));
        }

        [TestMethod]
        public void Return_Nth_Most_Recent_Paychecks_For_Nth_Lowest_Paid_Employees()
        {
            var result = Reporting.CalculateMostRecentPaychecks(10, 2);
            Assert.AreEqual(20, result.Count);
            Assert.AreEqual(new DateTime(2019, 3, 22), result[0].IssueDate);
        }

        private bool IsHighestSalary(List<Employee> employees)
        {
            bool result = true;
            var first = employees[0];
            var list = employees.Skip(1);

            foreach (var employee in list)
            {
                if (first.Salary < employee.Salary)
                {
                    result = false;
                }
            }
            return result;
        }

        private bool IsOldestStartDate(List<Employee> employees)
        {
            bool result = true;
            var first = employees[0];
            var list = employees.Skip(1);

            foreach (var employee in list)
            {
                if (first.StartDate < employee.StartDate)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
