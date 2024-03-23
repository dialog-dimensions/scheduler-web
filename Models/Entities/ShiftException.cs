using SchedulerWeb.Enums;

namespace SchedulerWeb.Models.Entities;

public class ShiftException
{
    public DateTime ShiftKey { get; set; }

    private Shift _shift;
    public Shift Shift
    {
        get => _shift;
        set
        {
            _shift = value;
            ShiftKey = value.StartDateTime;
        }
    }

    public int EmployeeId { get; set; }

    public ExceptionType ExceptionType { get; set; }

    public string? Reason { get; set; }
}