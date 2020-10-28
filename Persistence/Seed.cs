using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        
        public static async Task SeedData(DataContext context,UserManager<AppUser> userManager )
        {
            if(!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Surya",
                        UserName = "surya",
                        Email = "surya@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Teja",
                        UserName = "Teja",
                        Email = "Teja@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "SuryaTeja",
                        UserName = "suryaTeja",
                        Email = "suryaTeja@test.com"
                    }

                };
                foreach(var user in users)
                {
                   await userManager.CreateAsync(user,"Pa$$w0rd");
                }
            }
            
            if(!context.Activities.Any())
            {
                var activities = new List<Activity>()
                {
                    new Activity
                    {
                        Name = "F_1",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Done",
                        NoOfAcres = "2",
                        Amount = "1000"
                    },
                    new Activity
                    {
                        Name = "F_2",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Scheduled",
                        NoOfAcres = "2",
                        Amount = "1000"
                    },
                    new Activity
                    {
                        Name = "F_3",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Scheduled",
                        NoOfAcres = "3",
                        Amount = "1500"
                    },
                    new Activity
                    {
                        Name = "F_4",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Agreed",
                        NoOfAcres = "1",
                        Amount = "500"
                    },
                    new Activity
                    {
                        Name = "F_5",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Agreed",
                        NoOfAcres = "1",
                        Amount = "500"
                    },
                    new Activity
                    {
                        Name = "F_6",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Rejected",
                        NoOfAcres = "2",
                        Amount = "1000"
                    },
                    new Activity
                    {
                        Name = "F_7",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Rejected",
                        NoOfAcres = "2",
                        Amount = "1000"
                    },
                    new Activity
                    {
                        Name = "F_8",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Missed",
                        NoOfAcres = "2",
                        Amount = "1000"
                    },
                    new Activity
                    {
                        Name = "F_9",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Missed",
                        NoOfAcres = "2",
                        Amount = "1000"
                    },
                    new Activity
                    {
                        Name = "F_10",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Others",
                        NoOfAcres = "2",
                        Amount = "1000"
                    }
                };
                
                context.Activities.AddRange(activities);
                context.SaveChanges();

            }
            if(!context.Financials.Any())
            {
                var financials = new List<Financial>()
                {
                    new Financial
                    {
                        TotalAcres=10,
                        TotalAmount=5000,
                        TotalExpenses=500,
                        NetProfit=4500,
                    }
                };
                context.Financials.AddRange(financials);
                context.SaveChanges();
            }
        }
    }
}