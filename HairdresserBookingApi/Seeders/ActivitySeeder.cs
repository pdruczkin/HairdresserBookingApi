﻿using HairdresserBookingApi.Models.Db;
using HairdresserBookingApi.Models.Entities.Api;

namespace HairdresserBookingApi.Seeders;

public class ActivitySeeder : ISeeder
{
    public void Seed(BookingDbContext dbContext)
    {
        if (dbContext.Activities.Any()) return;

        var activities = GetActivities();
        
        dbContext.Activities.AddRange(activities);
    }

    private IEnumerable<Activity> GetActivities()
    {
        var activities = new List<Activity>();

        activities.Add(new Activity()
        {
            Name = "Strzyżenie męskie",
            Description = "Szybkie męskie strzyżenie",
            IsForMan = true
        });

        activities.Add(new Activity()
        {
            Name = "Strzyżenie damskie",
            Description = "Profesjonalne strzyżenie i pielęgnacja włosów",
            IsForMan = false
        });

        activities.Add(new Activity()
        {
            Name = "Farbowanie włosów długich damskich",
            Description = "Farbowanie długich włosów",
            IsForMan = false
        });



        return activities;
    }
}