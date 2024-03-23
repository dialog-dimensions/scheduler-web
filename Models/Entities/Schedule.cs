namespace SchedulerWeb.Models.Entities;

public class Schedule : List<Shift>
{
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int ShiftDuration { get; set; }
    public bool IsFullyScheduled { get; set; }
}