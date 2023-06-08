using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputationUsingDictionaries
{
    internal class UC_5DailyWageForMonth
    {
        static void Main(string[] args)
        {
            // Define the dictionary to map attendance values
            Dictionary<int, string> attendanceStatus = new Dictionary<int, string>()
        {
            { 0, "Absent" },
            { 1, "Full-time" },
            { 2, "Part-time" }
        };

            // Define the constants for wage calculation
            int wagePerHour = 20;
            int fullDayHours = 8;
            int partTimeHours = 4;
            int workingDaysPerMonth = 20;

            // Generate random attendance status for each working day in the month
            Random random = new Random();
            int[] dailyAttendance = new int[workingDaysPerMonth];

            for (int i = 0; i < workingDaysPerMonth; i++)
            {
                dailyAttendance[i] = random.Next(0, 3);
            }

            // Calculate the monthly wage
            int totalWage = 0;

            for (int i = 0; i < workingDaysPerMonth; i++)
            {
                string attendance = attendanceStatus[dailyAttendance[i]];
                int dailyWage = 0;

                switch (attendance)
                {
                    case "Full-time":
                        dailyWage = wagePerHour * fullDayHours;
                        break;
                    case "Part-time":
                        dailyWage = wagePerHour * partTimeHours;
                        break;
                }

                totalWage += dailyWage;
            }

            // Display the welcome message, attendance status, and monthly wage
            Console.WriteLine("Welcome to Employee Wage Computation Program on Master Branch");
            Console.WriteLine("Monthly Wage: $" + totalWage);
        }
        }
    }
}
