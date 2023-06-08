using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputationUsingDictionaries
{
    internal class UC_3PartTime
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

            // Generate random attendance status (0, 1, or 2)
            Random random = new Random();
            int attendanceValue = random.Next(0, 3);

            // Check the attendance status using the dictionary
            string attendance = attendanceStatus[attendanceValue];

            // Calculate the daily wage
            int wagePerHour = 20;
            int fullDayHours = 8;
            int partTimeHours = 4;
            int dailyWage = 0;

            if (attendance == "Full-time")
            {
                dailyWage = wagePerHour * fullDayHours;
            }
            else if (attendance == "Part-time")
            {
                dailyWage = wagePerHour * partTimeHours;
            }

            // Display the welcome message, attendance status, and daily wage
            Console.WriteLine("Welcome to Employee Wage Computation Program on Master Branch");
            Console.WriteLine("Attendance: " + attendance);
            Console.WriteLine("Daily Wage: $" + dailyWage);
        }
    }
}
