using SchedulerWeb.Models.DTOs.Interfaces;
using SchedulerWeb.Models.Entities;

namespace SchedulerWeb.Models.DTOs.Entities;

public class ShiftDto : IDto<Shift, ShiftDto>
{
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime ScheduleKey { get; set; }
    public EmployeeDto? Employee { get; set; }
    
    public static ShiftDto FromEntity(Shift entity) => new()
    { 
        StartDateTime = entity.StartDateTime, 
        EndDateTime = entity.EndDateTime, 
        Employee = entity.Employee is null ? null : EmployeeDto.FromEntity(entity.Employee),
        ScheduleKey = entity.ScheduleKey
    };

    public Shift ToEntity() => new()
    {
        StartDateTime = StartDateTime,
        EndDateTime = EndDateTime,
        Employee = Employee?.ToEntity(),
        ScheduleKey = ScheduleKey
    };
}
