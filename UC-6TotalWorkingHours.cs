using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputationUsingDictionaries
{
    internal class UC_6TotalWorkingHours
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

            // Define the constants for wage calculation and condition
            int wagePerHour = 20;
            int fullDayHours = 8;
            int partTimeHours = 4;
            int maxWorkingHours = 100;
            int maxWorkingDays = 20;

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

            // Display the welcome message, total working hours, total working days, and monthly wage
            Console.WriteLine("Welcome to Employee Wage Computation Program on Master Branch");
            Console.WriteLine("Total Working Hours: " + totalWorkingHours);
            Console.WriteLine("Total Working Days: " + totalWorkingDays);
            Console.WriteLine("Monthly Wage: $" + totalWage);
        }
    }
}
