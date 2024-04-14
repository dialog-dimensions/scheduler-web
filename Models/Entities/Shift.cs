namespace SchedulerWeb.Models.Entities;

public class Shift
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
    public DateTime ScheduleStart { get; set; }

    private Employee? _employee;

    public Employee? Employee
    {
        get => _employee;
        set
        {
            _employee = value;
            EmployeeId = value?.Id ?? 0;
        }
    }
    public int EmployeeId { get; set; }
}
