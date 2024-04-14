using SchedulerWeb.Models.DTOs.Interfaces;
using SchedulerWeb.Models.Entities;

namespace SchedulerWeb.Models.DTOs.Entities;

public class DeskAssignmentDto : IDto<DeskAssignment, DeskAssignmentDto>
{
    public DeskDto Desk { get; set; }
    public EmployeeDto Employee { get; set; }

    public static DeskAssignmentDto FromEntity(DeskAssignment entity) => new()
    {
        Desk = DeskDto.FromEntity(entity.Desk),
        Employee = EmployeeDto.FromEntity(entity.Employee)
    };

    public DeskAssignment ToEntity() => new()
    {
        Desk = Desk.ToEntity(),
        Employee = Employee.ToEntity()
    };
}
