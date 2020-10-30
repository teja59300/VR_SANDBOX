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
        public static async Task SeedData(DataContext context,
            UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id = "a",
                        DisplayName = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com"
                    },
                    new AppUser
                    {
                        Id = "b",
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com"
                    },
                    new AppUser
                    {
                        Id = "c",
                        DisplayName = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (!context.Activities.Any())
            {
                var activities = new List<Activity>
                {
                    new Activity
                    {
                        Name = "F_1",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity 1",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Done",
                        NoOfAcres = "2",
                        Amount = "1000",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(-2)
                            }
                        }
                    },
                    new Activity
                    {
                        Name = "F_2",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity  2 is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Done",
                        NoOfAcres = "2",
                        Amount = "1000",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(-1)
                            },
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(-1)
                            },
                        }
                    },
                    new Activity
                    {
                        Name = "F_3",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity  3 is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Done",
                        NoOfAcres = "2",
                        Amount = "1000",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(1)
                            },
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(1)
                            },
                        }
                    },
                    new Activity
                    {
                        Name = "F_4",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity 4 is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Done",
                        NoOfAcres = "2",
                        Amount = "1000",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(2)
                            },
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(2)
                            },
                        }
                    },
                    new Activity
                    {
                        Name = "F_5",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity 5 is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Done",
                        NoOfAcres = "2",
                        Amount = "1000",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(3)
                            },
                            new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(3)
                            },
                        }
                    },
                    new Activity
                    {
                        Name = "F_6",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity  6 is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Done",
                        NoOfAcres = "2",
                        Amount = "1000",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(4)
                            }
                        }
                    },
                    new Activity
                    {
                        Name = "F_7",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity 7 is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Done",
                        NoOfAcres = "2",
                        Amount = "1000",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(5)
                            },
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(5)
                            },
                        }
                    },
                    new Activity
                    {
                        Name = "F_8",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity  8 is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Done",
                        NoOfAcres = "2",
                        Amount = "1000",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(6)
                            },
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(6)
                            },
                        }
                    },
                    new Activity
                    {
                        Name = "F_9",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity 9 is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Done",
                        NoOfAcres = "2",
                        Amount = "1000",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(7)
                            },
                            new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(7)
                            },
                        }
                    },
                    new Activity
                    {
                        Name = "F_10",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity 10 is ready to do",
                        PhoneNumber = "1234567890",
                        Address = "Alampuram",
                        Status = "Done",
                        NoOfAcres = "2",
                        Amount = "1000",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(8)
                            },
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(8)
                            },
                        }
                    }
                };

                await context.Activities.AddRangeAsync(activities);
                await context.SaveChangesAsync();
            }
        }
    }
}