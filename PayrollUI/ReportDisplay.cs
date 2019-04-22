using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollUI
{
    public abstract class ReportDisplay
    {
        public static void QueryUserToContinueSession(string session)
        {
            QueryUserForContinueSessionResponse(session);
            ProcessContinueSessionResponse(Console.ReadLine(), session);
        }
        private static void QueryUserForContinueSessionResponse(string session)
        {
            Console.WriteLine($"Would you like to run another {session} report?");
            Console.WriteLine("(Y) Yes, (R) Return to Dashboard, (Q) End Session");
        }

        private static void ProcessContinueSessionResponse(string response, string session)
        {
            switch (response.ToUpper())
            {
                case "Y":
                    Console.Clear();
                    ContinueSession(session);
                    break;

                case "R":
                    Console.Clear();
                    ReturnToDashboard();
                    break;

                case "Q":
                    Console.WriteLine("Ending Session");
                    break;

                default:
                    Console.WriteLine("That's not even an option. Try again.");
                    QueryUserForContinueSessionResponse(session);
                    break;
            }
        }

        private static void ReturnToDashboard()
        {
            var dashboardSession = new ReportDashboardDisplay();
            dashboardSession.QueryUserInitializeSession();
        }

        private static void ContinueSession(string session)
        {
            switch (session)
            {
                case "department roster":
                    var rosterReport = new RosterReportDisplay();
                    rosterReport.QueryUserDepartmentRoster();
                    break;

                case "payroll statistics":
                    var payrollStatisticsReport = new PayrollStatisticsReportDisplay();
                    payrollStatisticsReport.QueryUserPayrollStatistics();
                    break;

                case "default":
                    Console.WriteLine("That's not even an option. Try again.");
                    break;
            }
        }

        public string QueryUserForDepartmentName()
        {
            QueryUserForDepartmentNameResponse();
            string result = ProcessDepartmentQueryResponse(Console.ReadLine());
            return result;
        }

        public void QueryUserForDepartmentNameResponse()
        {
            Console.WriteLine("Enter the name of the department you would like to see");
            Console.WriteLine("(MA) Marketing, (S) Sales, (IT) Information Technology, (L) Logistics, (ME) Merchandising");
            Console.WriteLine("(B) Buying, (PD) Product Development, (CS) Customer Service, (A) Accounting");
        }

        public string ProcessDepartmentQueryResponse(string response)
        {
            string result = "";
            switch (response.ToUpper())
            {
                case "MA":
                    result = "Marketing";
                    break;

                case "S":
                    result = "Sales";
                    break;

                case "IT":
                    result = "IT";
                    break;

                case "L":
                    result = "Logistics";
                    break;

                case "ME":
                    result = "Merchandising";
                    break;

                case "B":
                    result = "Buying";
                    break;

                case "PD":
                    result = "Product Development";
                    break;

                case "CS":
                    result = "Customer Service";
                    break;

                case "A":
                    result = "Accounting";
                    break;

                default:
                    Console.WriteLine("That's not even an option. Try again.");
                    QueryUserForDepartmentName();
                    break;
            }
            Console.Clear();
            return result;
        }

        public void DisplayReportTitle(string title)
        {
            PrintThickLine();
            Console.WriteLine($"{title}");
            PrintThickLine();

        }
        public void PrintThinLine()
        {
            Console.WriteLine("------------------------------------------------");
        }

        public void PrintThickLine()
        {
            Console.WriteLine("================================================");
        }
    }
}
