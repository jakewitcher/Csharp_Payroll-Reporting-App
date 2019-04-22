using System;
using System.Collections.Generic;
using System.Text;
using Payroll;

namespace PayrollUI
{
    public class PayrollStatisticsReportDisplay : ReportDisplay
    {
        public void QueryUserPayrollStatistics()
        {
            QueryUserForPayrollStatisticsPrintingRequest();
            ProcessPayrollStatisticsPrintingQueryResponse(Console.ReadLine());
            QueryUserToContinueSession("payroll statistics");
        }
        private void QueryUserForPayrollStatisticsPrintingRequest()
        {
            Console.WriteLine("Would you like to see the payroll statistics for all departments or for a specific department?");
            Console.WriteLine("(A) All (S) Specific");
        }

        private void ProcessPayrollStatisticsPrintingQueryResponse(string response)
        {
            switch (response.ToUpper())
            {
                case "A":
                    Console.Clear();
                    DisplayAllDepartmentPayrollStatistics();
                    break;

                case "S":
                    Console.Clear();
                    DisplayDepartmentPayrollStatistics(QueryUserForDepartmentName());
                    break;

                default:
                    Console.WriteLine("That's not even an option. Try again.");
                    QueryUserPayrollStatistics();
                    break;
            }
        }

        private void DisplayDepartmentPayrollStatistics(string result)
        {
            var statistics = PayrollStatisticsReport.GetDepartmentPayrollStatistics(result);
            DisplayReportTitle($"PAYROLL STATISTICS");
            Console.WriteLine();
            DisplayDepartmentStatistics(statistics);
        }



        private void DisplayAllDepartmentPayrollStatistics()
        {
            var statistics = PayrollStatisticsReport.GetAllPayrollStatistics();
            DisplayReportTitle("PAYROLL STATISTICS");
            Console.WriteLine();
            DisplayDepartmentStatistics(statistics);
 
        }

        private void DisplayDepartmentStatistics(SortedDictionary<string, PayrollStatistics> statistics)
        {
            foreach (var stat in statistics)
            {
                Console.WriteLine($"{stat.Key}");
                PrintThinLine();
                Console.WriteLine($"Total Annual Payroll: {stat.Value.SalarySum}");
                Console.WriteLine($"Average Annual Payroll: {stat.Value.SalaryAverage}");
                Console.WriteLine($"Total Biweekly Payroll: {stat.Value.BiWeeklySum}");
                Console.WriteLine($"Average Biweekly Payroll: {stat.Value.BiWeeklyAverage}");
                Console.WriteLine($"Salary Range: {stat.Value.MinSalary} - {stat.Value.MaxSalary}");
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
