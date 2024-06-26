﻿using SchedulerWeb.Models.DTOs.Interfaces;
using SchedulerWeb.Models.Entities;

namespace SchedulerWeb.Models.DTOs.Entities;

public class FlatScheduleDto : IDto<Schedule, FlatScheduleDto>
{
    public DeskDto Desk { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int ShiftDuration { get; set; }
    public bool IsFullyScheduled { get; set; }

    public static FlatScheduleDto FromEntity(Schedule entity) => new()
    {
        Desk = DeskDto.FromEntity(entity.Desk),
        StartDateTime = entity.StartDateTime,
        EndDateTime = entity.EndDateTime,
        ShiftDuration = entity.ShiftDuration,
        IsFullyScheduled = entity.IsFullyScheduled
    };

    public Schedule ToEntity()
    {
        var desk = Desk.ToEntity();
        var result = new Schedule
        {
            Desk = desk,
            StartDateTime = StartDateTime,
            EndDateTime = EndDateTime,
            ShiftDuration = ShiftDuration,
            IsFullyScheduled = IsFullyScheduled
        };

        var shiftStartDateTime = StartDateTime;
        var shiftEndDateTime = StartDateTime.AddHours(ShiftDuration);
        while (shiftStartDateTime < EndDateTime)
        {
            result.Add(new Shift {Desk = desk, StartDateTime = shiftStartDateTime, EndDateTime = shiftEndDateTime});
            shiftStartDateTime = shiftEndDateTime;
            shiftEndDateTime = shiftEndDateTime.AddHours(ShiftDuration);
        }

        return result;
    }
}
