using System;
using System.Linq;
using PayrollData;
using PayrollSeedGenerator;

namespace PayrollUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var session = new ReportDashboardDisplay();
            session.QueryUserInitializeSession();
        }
    }
}
