using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputationUsingDictionaries
{
    internal class UC_2DailyWage
    {
        static void Main(string[] args)
        {
            // Define the dictionary to map attendance values
            Dictionary<int, string> attendanceStatus = new Dictionary<int, string>()
        {
            { 0, "Absent" },
            { 1, "Present" }
        };

            // Generate random attendance status (0 or 1)
            Random random = new Random();
            int attendanceValue = random.Next(0, 2);

            // Check the attendance status using the dictionary
            string attendance = attendanceStatus[attendanceValue];

            // Calculate the daily wage
            int wagePerHour = 20;
            int fullDayHours = 8;
            int dailyWage = 0;

            if (attendance == "Present")
            {
                dailyWage = wagePerHour * fullDayHours;
            }

            // Display the welcome message, attendance status, and daily wage
            Console.WriteLine("Welcome to Employee Wage Computation Program on Master Branch");
            Console.WriteLine("Attendance: " + attendance);
            Console.WriteLine("Daily Wage: $" + dailyWage);
        }
    }
}
