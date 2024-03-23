using SchedulerWeb.Models.Entities;

namespace SchedulerWeb.Services.Api.Interfaces;

public interface IScheduleService
{
    Task<Schedule?> GetScheduleToFileAsync();
    Task<Schedule?> GetCurrentScheduleAsync();
    Task<Schedule?> GetNextScheduleAsync();
}