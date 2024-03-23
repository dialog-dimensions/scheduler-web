using SchedulerWeb.Enums;
using SchedulerWeb.Models.Entities;

namespace SchedulerWeb.Models.UiModels;

public class GridSlot
{
    public DateTime StartDateTime { get; set; }
    public ExceptionType ExceptionType { get; set; }
    public Employee? Employee { get; set; }
}
