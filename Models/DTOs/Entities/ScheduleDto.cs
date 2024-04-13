using SchedulerWeb.Models.DTOs.Interfaces;
using SchedulerWeb.Models.Entities;

namespace SchedulerWeb.Models.DTOs.Entities;

public class ScheduleDto : List<ShiftDto>, IDto<Schedule, ScheduleDto>
{
    public DateTime? StartDateTime => this.MinBy(s => s.StartDateTime)?.StartDateTime;
    public DateTime? EndDateTime => this.MaxBy(s => s.EndDateTime)?.EndDateTime;

    public int? ShiftDuration => StartDateTime.HasValue & EndDateTime.HasValue
        ? (int)double.Round(EndDateTime!.Value.Subtract(StartDateTime!.Value).TotalHours / Count)
        : null;

    public DateTime StartDateTime => FirstShift.StartDateTime;
    public DateTime EndDateTime => LastShift.EndDateTime;
    public int ShiftDuration => (int)(Duration.TotalHours / Count);
    public bool IsFullyScheduled => this.All(shift => shift.Employee is not null);
    
    private ShiftDto FirstShift => this.MinBy(s => s.StartDateTime)!;
    private ShiftDto LastShift => this.MaxBy(s => s.StartDateTime)!;
    private ShiftDto SomeShift => this[0];
    private TimeSpan Duration => EndDateTime.Subtract(StartDateTime);
    
    public static ScheduleDto FromEntity(Schedule entity)
    {
        var result = new ScheduleDto();
        result.AddRange(entity.Select(ShiftDto.FromEntity));
        return result;
    }
    
    public Schedule ToEntity()
    {
        var result = new Schedule
        {
            StartDateTime = StartDateTime!.Value, 
            EndDateTime = EndDateTime!.Value, 
            ShiftDuration = ShiftDuration!.Value
        };
        
        result.AddRange(this.Select(shiftDto => new Shift
        {
            StartDateTime = shiftDto.StartDateTime,
            EndDateTime = shiftDto.EndDateTime,
            ScheduleStart = StartDateTime,
            Employee = shiftDto.Employee?.ToEntity()
        }));

        return result;
    }
}