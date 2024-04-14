using SchedulerWeb.Models.DTOs.Interfaces;
using SchedulerWeb.Models.Entities;

namespace SchedulerWeb.Models.DTOs.Entities;

public class EmployeeDto : IDto<Employee, EmployeeDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Balance { get; set; }
    public double DifficultBalance { get; set; }
    public bool Active { get; set; }
    public string Role { get; set; }
    public UnitDto Unit { get; set; }

    public static EmployeeDto FromEntity(Employee entity)
    {
        throw new NotImplementedException();
    }

    public Employee ToEntity() => new()
    {
        Id = Id,
        Name = Name,
        Unit = Unit.ToEntity()
    };
}
