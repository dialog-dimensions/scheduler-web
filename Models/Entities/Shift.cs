namespace SchedulerWeb.Models.Entities;

public class Shift
{
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime ScheduleKey { get; set; }
    public Employee? Employee { get; set; }
}

