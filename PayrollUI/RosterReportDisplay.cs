using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Payroll;
using PayrollLibrary;

namespace PayrollUI
{
    public class RosterReportDisplay : ReportDisplay
    {
        public void QueryUserDepartmentRoster()
        {
            QueryUserForRosterPrintingRequest();
            ProcessRosterPrintingQueryResponse(Console.ReadLine());
            QueryUserToContinueSession("department roster");
        }

        private void QueryUserForRosterPrintingRequest()
        {
            Console.WriteLine("Would you like to see a list of employees for all departments or for a specific department?");
            Console.WriteLine("(A) All (S) Specific");
        }
        
        private void ProcessRosterPrintingQueryResponse(string response)
        {
            switch (response.ToUpper())
            {
                case "A":
                    Console.Clear();
                    var departments = RosterReport.GetAllDepartmentRosters();
                    DisplayAllDepartmentRosters(departments);
                    break;

                case "S":
                    Console.Clear();
                    DisplayDepartmentRoster(QueryUserForDepartmentName());
                    break;

                default:
                    Console.WriteLine("That's not even an option. Try again.");
                    QueryUserDepartmentRoster();
                    break;
            }
        }

        private void DisplayDepartmentRoster(string result)
        {
            var department = RosterReport.GetDepartmentRoster(result);
            DisplayReportTitle("DEPARTMENT ROSTER");
            Console.WriteLine();
            DisplayRosterList(department.First());
        }

        private void DisplayAllDepartmentRosters(List<IGrouping<string, Employee>> departments)
        {
            DisplayReportTitle("DEPARTMENT ROSTER");
            Console.WriteLine();
            foreach (var department in departments)
            {
                DisplayRosterList(department);
            }
        }

        private void DisplayRosterList(IGrouping<string, Employee> department)
        {
            int count = department.Count();
            Console.WriteLine($"{department.Key} : {count} employees");
            PrintThinLine();
            foreach (var employee in department)
            {
                Console.WriteLine($"{employee.Id}\t {employee.LastName}, {employee.FirstName}");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
