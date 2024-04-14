namespace SchedulerWeb.Models.Entities;

public class Schedule : List<Shift>
{
    private Desk _desk;
    public Desk Desk
    {
        get => _desk;
        set
        {
            _desk = value;
            DeskId = value.Id;
        }
    }
    public string DeskId { get; set; }
    
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int ShiftDuration { get; set; }
    public bool IsFullyScheduled { get; set; }
}