using SchedulerWeb.Models.DTOs.Interfaces;
using SchedulerWeb.Models.Entities;

namespace SchedulerWeb.Models.DTOs.Entities;

public class ShiftDto : IDto<Shift, ShiftDto>
{
    public DeskDto Desk { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime ScheduleStart { get; set; }
    public EmployeeDto? Employee { get; set; }
    
    public static ShiftDto FromEntity(Shift entity) => new()
    { 
        Desk = DeskDto.FromEntity(entity.Desk),
        StartDateTime = entity.StartDateTime, 
        EndDateTime = entity.EndDateTime, 
        Employee = entity.Employee is null ? null : EmployeeDto.FromEntity(entity.Employee),
        ScheduleStart = entity.ScheduleStart
    };

    public Shift ToEntity() => new()
    {
        Desk = Desk.ToEntity(),
        StartDateTime = StartDateTime,
        EndDateTime = EndDateTime,
        Employee = Employee?.ToEntity(),
        ScheduleStart = ScheduleStart
    };
}
