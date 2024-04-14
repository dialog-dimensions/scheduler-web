using SchedulerWeb.Enums;
using SchedulerWeb.Models.DTOs.Interfaces;
using SchedulerWeb.Models.Entities;

namespace SchedulerWeb.Models.DTOs.Entities;

public class ShiftExceptionDto : IDto<ShiftException, ShiftExceptionDto>
{
    public DeskDto Desk { get; set; }
    public DateTime ShiftStart { get; set; }
    public int EmployeeId { get; set; }
    public ExceptionType ExceptionType { get; set; }
    public string? Reason { get; set; }


    public static ShiftExceptionDto FromEntity(ShiftException entity) => new()
    {
        Desk = DeskDto.FromEntity(entity.Desk),
        ShiftStart = entity.ShiftStart,
        EmployeeId = entity.EmployeeId,
        ExceptionType = entity.ExceptionType,
        Reason = entity.Reason
    };

    public ShiftException ToEntity() => new()
    {
        Desk = Desk.ToEntity(),
        ShiftStart = ShiftStart,
        EmployeeId = EmployeeId,
        ExceptionType = ExceptionType,
        Reason = Reason
    };
}
