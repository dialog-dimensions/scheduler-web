namespace SchedulerWeb.Models.Entities;

public class Unit
{
    public string Id { get; set; }
    public string Name { get; set; }

    private Unit? _parentUnit;
    public Unit? ParentUnit
    {
        get => _parentUnit;
        set
        {
            _parentUnit = value;
            ParentUnitId = value?.Id;
        }
    }
    public string? ParentUnitId { get; set; }
}
