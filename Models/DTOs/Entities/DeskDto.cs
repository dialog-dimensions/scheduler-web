﻿using SchedulerWeb.Models.DTOs.Interfaces;
using SchedulerWeb.Models.Entities;

namespace SchedulerWeb.Models.DTOs.Entities;

public class DeskDto : IDto<Desk, DeskDto>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public UnitDto Unit { get; set; }
    public bool Active { get; set; }

    public static DeskDto FromEntity(Desk entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Unit = UnitDto.FromEntity(entity.Unit),
        Active = entity.Active
    };

    public Desk ToEntity() => new()
    {
        Id = Id,
        Name = Name,
        Unit = Unit.ToEntity(),
        Active = Active
    };
}
