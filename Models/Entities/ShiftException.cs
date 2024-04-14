using SchedulerWeb.Enums;

namespace SchedulerWeb.Models.Entities;

public class ShiftException
{
    private Shift _shift;
    public Shift Shift
    {
        get => _shift;
        set
        {
            _shift = value;
            ShiftStart = value.StartDateTime;
            Desk = value.Desk;
        }
    }
    
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
    public DateTime ShiftStart { get; set; }
    
    
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
    
    public ExceptionType ExceptionType { get; set; }
    
    public string? Reason { get; set; }
}
