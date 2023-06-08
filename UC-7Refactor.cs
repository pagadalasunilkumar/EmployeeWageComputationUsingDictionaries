using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputationUsingDictionaries
{
    internal class UC_7Refactor
    {
        private Dictionary<int, string> attendanceStatus = new Dictionary<int, string>()
    {
        { 0, "Absent" },
        { 1, "Full-time" },
        { 2, "Part-time" }
    };

        private int wagePerHour = 20;
        private int fullDayHours = 8;
        private int partTimeHours = 4;
        private int maxWorkingHours = 100;
        private int maxWorkingDays = 20;

        // Method to calculate the monthly wage
        public int CalculateMonthlyWage()
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
            // Create an instance of the Employee class
            Employee employee = new Employee();

            // Calculate the monthly wage using the class method
            int monthlyWage = employee.CalculateMonthlyWage();

            // Display the welcome message and the calculated monthly wage
            Console.WriteLine("Welcome to Employee Wage Computation Program on Master Branch");
            Console.WriteLine("Monthly Wage: $" + monthlyWage);
        }
    }
}
