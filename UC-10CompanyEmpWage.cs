using System;
using System.Collections.Generic;

namespace EmployeeWageComputationUsingDictionaries
{
    internal class UC_10CompanyEmpWage
    {
        class CompanyEmpWage
        {
            public string CompanyName { get; }
            public int WagePerHour { get; }
            public int FullDayHours { get; }
            public int PartTimeHours { get; }
            public int MaxWorkingHours { get; }
            public int MaxWorkingDays { get; }
            public int TotalWage { get; set; }

            public CompanyEmpWage(string name, int wage, int fullDay, int partTime, int maxHours, int maxDays)
            {
                CompanyName = name;
                WagePerHour = wage;
                FullDayHours = fullDay;
                PartTimeHours = partTime;
                MaxWorkingHours = maxHours;
                MaxWorkingDays = maxDays;
                TotalWage = 0;
            }
        }

        class EmpWageBuilder
        {
            private List<CompanyEmpWage> companyEmpWages;

            public EmpWageBuilder()
            {
                companyEmpWages = new List<CompanyEmpWage>();
            }

            public void AddCompanyEmpWage(string name, int wage, int fullDay, int partTime, int maxHours, int maxDays)
            {
                CompanyEmpWage companyEmpWage = new CompanyEmpWage(name, wage, fullDay, partTime, maxHours, maxDays);
                companyEmpWages.Add(companyEmpWage);
            }

            public void CalculateMonthlyWages()
            {
                foreach (CompanyEmpWage companyEmpWage in companyEmpWages)
                {
                    companyEmpWage.TotalWage = CalculateMonthlyWage(companyEmpWage.WagePerHour, companyEmpWage.FullDayHours, companyEmpWage.PartTimeHours, companyEmpWage.MaxWorkingHours, companyEmpWage.MaxWorkingDays);
                }
            }

            private int CalculateMonthlyWage(int wagePerHour, int fullDayHours, int partTimeHours, int maxWorkingHours, int maxWorkingDays)
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
                                dailyWage = wagePerHour
