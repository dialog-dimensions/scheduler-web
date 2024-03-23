using SchedulerWeb.Enums;
using SchedulerWeb.Models.DTOs.Interfaces;
using SchedulerWeb.Models.Entities;

namespace SchedulerWeb.Models.DTOs.Entities;

public class ShiftExceptionDto : IDto<ShiftException, ShiftExceptionDto>
{
    public DateTime ShiftKey { get; set; }
    public int EmployeeId { get; set; }
    public ExceptionType ExceptionType { get; set; }
    public string? Reason { get; set; }


    public static ShiftExceptionDto FromEntity(ShiftException entity) => new()
    {
        ShiftKey = entity.ShiftKey,
        EmployeeId = entity.EmployeeId,
        ExceptionType = entity.ExceptionType,
        Reason = entity.Reason
    };

    public ShiftException ToEntity() => new()
    {
        ShiftKey = ShiftKey,
        EmployeeId = EmployeeId,
        ExceptionType = ExceptionType,
        Reason = Reason
    };
}
