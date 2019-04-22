using System;
using System.Collections.Generic;
using System.Linq;
using PayrollData;
using PayrollLibrary;

namespace PayrollSeedGenerator
{
    public static class GenerateEmployee
    {
        private static List<string> FirstNames = new List<string>
        {
            "Sophia", "Olivia", "Emma", "Ava", "Isabella", "Aria", "Riley", "Amelia", "Mia", "Layla", "Jackson", "Liam", "Noah",
            "Aiden", "Caden", "Grayson", "Lucas", "Mason", "Oliver", "Elijah", "Zoe", "Mila", "Charlotte", "Harper", "Lily",
            "Chloe", "Aaliyah", "Adalyn", "Evenlyn", "Avery", "Aubrey", "Ella", "Logan", "Carter", "Ethan", "Muhammad", "Jayden",
            "Michael", "James", "Sebastian", "Alexander", "Mateo", "Jacob", "Ryan", "Camilla", "Benjamin", "Nora", "Daniel",
            "Scarlett", "Maya", "William", "Jack", "Julian", "Emily", "Abigail", "Leo", "Jayce", "Madison", "Eliana", "Caleb"
        };

        private static List<string> LastNames = new List<string>
        {
            "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas",
            "Jackson", "White", "Harris", "Martin", "Hall", "Allen", "Young", "Hernandez", "King", "Wright", "Lopez", "Hill", "Scott",
            "Green", "Adams", "Baker", "Gonzalez", "Nelson", "Carter", "Mitchell", "Stewart", "Sanchez", "Morris", "Rogers", "Reed",
            "Cook", "Morgan", "Bell", "Murphy", "Bailey", "Rivera", "Cooper", "Richardson", "Cox", "Howard", "Ward", "Price", "Bennet",
            "Wood", "Barnes", "Ross", "Henderson", "Coleman", "Jenkins", "Perry", "Powell", "Long", "Patterson", "Hughes", "Flores"
        };

        private static List<string> DepartmentNames = new List<string>
        {
            "Marketing", "Sales", "IT", "Logistics", "Merchandising", "Buying",
            "Product Development", "Customer Service", "Accounting"
        };

        private static List<string> TitleNames = new List<string>
        { "Junior", "Senior", "Executive", "Associate", "Manager", "Assistant" };


        public static List<Employee> GenerateEmployeeList(int amount)
        {
            var result = new List<Employee>();
            for (int i = 0; i < amount; i++)
            {
                var employee = new Employee
                {
                    FirstName = GenerateName(FirstNames),
                    LastName = GenerateName(LastNames),
                    Salary = GenerateSalary(),
                    StartDate = GenerateStartDate(),
                    Title = GenerateName(TitleNames),
                    Department = GenerateName(DepartmentNames),
                };
                result.Add(employee);

            }

            return result;
        }

        public static void InsertEmployees(List<Employee> employees, PayrollContext context)
        {
            var departments = context.Departments.ToList();
            foreach (var employee in employees)
            {
                int id = departments.Where(d => d.Name == employee.Department).First().Id;
                employee.DepartmentId = id;
            }
            context.AddRange(employees);
            context.SaveChanges();
        }

        private static DateTime GenerateStartDate()
        {
            var rndm = new Random();
            int year = rndm.Next(2016, 2019);
            int month = rndm.Next(1, 13);
            int day = rndm.Next(1, 29);

            return new DateTime(year, month, day);

        }

        private static decimal GenerateSalary()
        {
            var rndm = new Random();
            return rndm.Next(40_000, 120_000);
        }

        private static string GenerateName(List<string> names)
        {
            var rndm = new Random();
            int index = rndm.Next(0, names.Count);
            return names.ElementAt(index);
        }
    }
}
