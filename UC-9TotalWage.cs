using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputationUsingDictionaries
{
    internal class UC_9TotalWage
    {
        class EmpWageBuilder
        {
            private string companyName;
            private int wagePerHour;
            private int fullDayHours;
            private int partTimeHours;
            private int maxWorkingHours;
            private int maxWorkingDays;
            private int totalWage;

            // Constructor to initialize the company details
            public EmpWageBuilder(string name, int wage, int fullDay, int partTime, int maxHours, int maxDays)
            {
                companyName = name;
                wagePerHour = wage;
                fullDayHours = fullDay;
                partTimeHours = partTime;
                maxWorkingHours = maxHours;
                maxWorkingDays = maxDays;
                totalWage = 0;
            }

            // Method to calculate the monthly wage
            public void CalculateMonthlyWage()
            {
                // Generate random attendance status for each working day in the month
                Random random = new Random();
                int[] dailyAttendance = new int[maxWorkingDays];

                for (int i = 0; i < maxWorkingDays; i++)
                {
                    dailyAttendance[i] = random.Next(0, 3);
                }

                // Calculate the monthly wage until the condition is reached
                int totalWorkingHours = 0;
                int totalWorkingDays = 0;

                for (int i = 0; i < maxWorkingDays; i++)
                {
                    if (totalWorkingHours >= maxWorkingHours || totalWorkingDays >= maxWorkingDays)
                    {
                        break;
                    }

                    string attendance = GetAttendanceStatus(dailyAttendance[i]);
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
            }

            // Method to get the attendance status based on the dictionary
            private string GetAttendanceStatus(int attendanceCode)
            {
                Dictionary<int, string> attendanceStatus = new Dictionary<int, string>()
        {
            { 0, "Absent" },
            { 1, "Full-time" },
            { 2, "Part-time" }
        };

                return attendanceStatus[attendanceCode];
            }

            // Method to display the company name and total wage
            public void DisplayTotalWage()
            {
                Console.WriteLine("Company: " + companyName);
                Console.WriteLine("Total Wage: $" + totalWage);
                Console.WriteLine();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                // Create instances of EmpWageBuilder for different companies
                EmpWageBuilder companyA = new EmpWageBuilder("Company A", 25, 8, 4, 120, 22
            }
        }
