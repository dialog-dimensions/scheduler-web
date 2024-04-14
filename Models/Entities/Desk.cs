namespace SchedulerWeb.Models.Entities;

public class Desk
{
    public string Id { get; set; } 
    public string Name { get; set; }

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
    public bool Active { get; set; }
}
