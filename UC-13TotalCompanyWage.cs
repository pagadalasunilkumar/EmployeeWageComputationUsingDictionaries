using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputationUsingDictionaries
{
    internal class UC_13TotalCompanyWage
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
                companyEmpWage.CalculateMonthlyWage();
            }
        }

        class CompanyEmpWage
        {
            public string CompanyName { get; }
            public int WagePerHour { get; }
            public int FullDayHours { get; }
            public int PartTimeHours { get; }
            public int MaxWorkingHours { get; }
            public int MaxWorkingDays { get; }
            public Dictionary<int, int> DailyWages { get; }
            public int TotalWage { get; private set; }

            public CompanyEmpWage(string name, int wage, int fullDay, int partTime, int maxHours, int maxDays)
            {
                CompanyName = name;
                WagePerHour = wage;
                FullDayHours = fullDay;
                PartTimeHours = partTime;
                MaxWorkingHours = maxHours;
                MaxWorkingDays = maxDays;
                DailyWages = new Dictionary<int, int>();
                TotalWage = 0;
            }

            public void CalculateMonthlyWage()
            {
                Random random = new Random();
                int[] dailyAttendance = new int[MaxWorkingDays];

                for (int i = 0; i < MaxWorkingDays; i++)
                {
                    dailyAttendance[i] = random.Next(0, 3);
                }

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

                    if (attendance == "Full-time")
                    {
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
                    }
                    else if (attendance == "Part-time")
                    {
                        if (totalWorkingHours + PartTimeHours <= MaxWorkingHours)
                        {
                            dailyWage = WagePerHour * PartTimeHours;
                            totalWorkingHours += PartTimeHours;
                        }
                        else
                        {
                            int remainingHours = MaxWorkingHours - totalWorkingHours;
                            dailyWage = WagePerHour * remainingHours;
                            totalWorkingHours = MaxWorkingHours;
                        }
                    }

                    DailyWages.Add(i + 1, dailyWage);
                    totalWage += dailyWage;
                    
    }
}
