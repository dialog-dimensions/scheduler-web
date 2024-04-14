namespace SchedulerWeb.Models.Entities;

public class Shift
{
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime ScheduleKey { get; set; }
    public Employee? Employee { get; set; }
}

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
