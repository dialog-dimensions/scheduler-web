namespace SchedulerWeb.Models.Entities;

public class Employee
{
    public string Name { get; set; }
    public int Id { get; set; }

    private Unit _unit;
    public Unit Unit
    {
        get => _unit;
        set
        {
            _unit = value;
            UnitId = value.Id;
        }
    }
    public string UnitId { get; set; }
}
