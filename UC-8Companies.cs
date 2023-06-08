using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputationUsingDictionaries
{
    internal class UC_8Companies
    {// Define the dictionary to map attendance values
        private Dictionary<int, string> attendanceStatus = new Dictionary<int, string>()
    {
        { 0, "Absent" },
        { 1, "Full-time" },
        { 2, "Part-time" }
    };

        // Method to calculate the monthly wage for a company
        public int CalculateMonthlyWage(int wagePerHour, int fullDayHours, int partTimeHours, int maxWorkingHours, int maxWorkingDays)
        {
            // Generate random attendance status for each working day in the month
            Random random = new Random();
            int[] dailyAttendance = new int[maxWorkingDays];

            for (int i = 0; i < maxWorkingDays; i++)
            {
                dailyAttendance[i] = random.Next(0, 3);
            }

            // Calculate the monthly wage until the condition is reached
            int totalWage = 0;
            int totalWorkingHours = 0;
            int totalWorkingDays = 0;

            for (int i = 0; i < maxWorkingDays; i++)
            {
                if (totalWorkingHours >= maxWorkingHours || totalWorkingDays >= maxWorkingDays)
                {
                    break;
                }

                string attendance = attendanceStatus[dailyAttendance[i]];
                int dailyWage = 0;

                switch (attendance)
                {
                    case "Full-time":
                        if (totalWorkingHours + fullDayHours <= maxWorkingHours)
                        {
                            dailyWage = wagePerHour * fullDayHours;
                            totalWorkingHours += fullDayHours;
                        }
                        else
                        {
                            int remainingHours = maxWorkingHours - totalWorkingHours;
                            dailyWage = wagePerHour * remainingHours;
                            totalWorkingHours = maxWorkingHours;
                        }
                        break;

                    case "Part-time":
                        if (totalWorkingHours + partTimeHours <= maxWorkingHours)
                        {
                            dailyWage = wagePerHour * partTimeHours;
                            totalWorkingHours += partTimeHours;
                        }
                        else
                        {
                            int remainingHours = maxWorkingHours - totalWorkingHours;
                            dailyWage = wagePerHour * remainingHours;
                            totalWorkingHours = maxWorkingHours;
                        }
                        break;
                }

                totalWage += dailyWage;
                totalWorkingDays++;
            }

            return totalWage;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of the Employee class for different companies
            Employee companyA = new Employee();
            Employee companyB = new Employee();

            // Calculate the monthly wage for Company A using the class method with function parameters
            int wageCompanyA = companyA.CalculateMonthlyWage(25, 8, 4, 120, 22);

            // Calculate the monthly wage for Company B using the class method with function parameters
            int wageCompanyB = companyB.CalculateMonthlyWage(30, 7, 3, 100, 20);

            // Display the welcome message and the calculated monthly wages for each company
            Console.WriteLine("Welcome to Employee Wage Computation Program on Master Branch");
            Console.WriteLine("Monthly Wage for Company A: $" + wageCompanyA);
            Console.WriteLine("Monthly Wage for Company B: $" + wageCompanyB);
        }
    }
}
