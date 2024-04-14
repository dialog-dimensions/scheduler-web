namespace SchedulerWeb.Models.Entities;

public class DeskAssignment
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

    private Employee _employee;
    public Employee Employee
    {
        get => _employee;
        set
        {
            _employee = value;
            EmployeeId = value.Id;
        }
    }
    public int EmployeeId { get; set; }
}
