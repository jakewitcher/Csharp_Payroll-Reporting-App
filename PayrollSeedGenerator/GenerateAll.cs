using PayrollData;

namespace PayrollSeedGenerator
{
    public static class GenerateAll
    {
        public static void CreateNewDatabase()
        {
            GenerateDepartments();
            GenerateEmployees();
            GeneratePaychecks();
        }

        private static void GeneratePaychecks()
        {
            var context = new PayrollContext();
            GeneratePaycheck.InsertPaychecks(context);
        }

        private static void GenerateEmployees()
        {
            var context = new PayrollContext();
            var employees = GenerateEmployee.GenerateEmployeeList(200);
            GenerateEmployee.InsertEmployees(employees, context);
        }

        private static void GenerateDepartments()
        {
            var context = new PayrollContext();
            var departments = GenerateDepartment.GenerateDepartmentList();
            GenerateDepartment.InsertDepartments(departments, context);
        }
    }
}
