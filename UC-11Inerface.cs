using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputationUsingDictionaries
{
    internal class UC_11Inerface

    {
        // Define an interface for the company employee wage
        interface ICompanyEmpWage
        {
            void SetCompanyEmpWage(string name, int wage, int fullDay, int partTime, int maxHours, int maxDays);
            int CalculateMonthlyWage();
        }

        // Implement the interface in the EmpWageBuilder class
        class EmpWageBuilder : ICompanyEmpWage
        {
            private List<CompanyEmpWage> companyEmpWages;

            public EmpWageBuilder()
            {
                companyEmpWages = new List<CompanyEmpWage>();
            }

            public void SetCompanyEmpWage(string name, int wage, int fullDay, int partTime, int maxHours, int maxDays)
            {
                CompanyEmpWage companyEmpWage = new CompanyEmpWage(name, wage, fullDay, partTime, maxHours, maxDays);
                companyEmpWages.Add(companyEmpWage);
            }

            public int CalculateMonthlyWage()
            {
                int totalWage = 0;
                foreach (CompanyEmpWage companyEmpWage in companyEmpWages)
                {
                    totalWage += companyEmpWage.CalculateMonthlyWage();
                }
                return totalWage;
            }

            // Inner class representing the company employee wage details
            class CompanyEmpWage
            {
                public string CompanyName { get; }
                public int WagePerHour { get; }
                public int FullDayHours { get; }
                public int PartTimeHours { get; }
                public int MaxWorkingHours { get; }
                public int MaxWorkingDays { get; }

                public CompanyEmpWage(string name, int wage, int fullDay, int partTime, int maxHours, int maxDays)
                {
                    CompanyName = name;
                    WagePerHour = wage;
                    FullDayHours = fullDay;
                    PartTimeHours = partTime;
                    MaxWorkingHours = maxHours;
                    MaxWorkingDays = maxDays;
                }

                public int CalculateMonthlyWage()
                {
                    // Generate random attendance status for each working day in the month
                    Random random = new Random();
                    int[] dailyAttendance = new int[MaxWorkingDays];

                    for (int i = 0; i < MaxWorkingDays; i++)
                    {
                        dailyAttendance[i] = random.Next(0, 3);
                    }

                    // Calculate the monthly wage until the condition is reached
                    int totalWage = 0;
                    int totalWorkingHours = 0;
                    int totalWorkingDays = 0;

                    for (int i = 0; i < MaxWorkingDays; i++)
                    {
                        if (totalWorkingHours >= MaxWorkingHours || totalWorkingDays >= MaxWorkingDays)
                        {
                            break;
                        }

                        string attendance = GetAttendanceStatus(dailyAttendance[i]);
                        int dailyWage = 0;

                        switch (attendance)
                        {
                            case "Full-time":
                                if (totalWorkingHours + FullDayHours <= MaxWorkingHours)
                                {
                                    dailyWage = WagePerHour * FullDayHours;
                                    totalWorkingHours += FullDayHours;
                                }
                                else
                                {
                                    int remainingHours = MaxWorkingHours - totalWorkingHours;
                                    dailyWage = WagePerHour * remainingHours;
                                    totalWorkingHours = MaxWorkingHours;
                                }
                                break;

                            case "Part-time":
                                if (totalWorkingHours + PartTimeHours <=


    
                    }
                }
            }

        }
    }
}

                    
