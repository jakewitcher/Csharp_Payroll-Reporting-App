using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollUI
{
    public class ReportDashboardDisplay : ReportDisplay
    {
        public void QueryUserInitializeSession()
        {
            QueryUserForReportingRequest();
            ProcessInitializeSessionResponse(Console.ReadLine());
        }

        private static void QueryUserForReportingRequest()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("(R) Department roster reporting, (P) Payroll reporting, (E) Employee reporting");
        }

        public void ProcessInitializeSessionResponse(string response)
        {
            switch (response.ToUpper())
            {
                case "R":
                    Console.Clear();
                    var rosterReportingSession = new RosterReportDisplay();
                    rosterReportingSession.QueryUserDepartmentRoster();
                    break;

                case "P":
                    Console.Clear();
                    var payrollStatisticsReportingSession = new PayrollStatisticsReportDisplay();
                    payrollStatisticsReportingSession.QueryUserPayrollStatistics();
                    break;

                case "E":
                    Console.WriteLine("You've chosen employee reporting but it doesn't exist yet. Try again.");
                    QueryUserInitializeSession();
                    break;

                default:
                    Console.WriteLine("That's not even an option. Try again.");
                    QueryUserInitializeSession();
                    break;
            }
        }
    }
}
