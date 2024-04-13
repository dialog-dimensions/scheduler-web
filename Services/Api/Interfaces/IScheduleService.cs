using SchedulerWeb.Models.Entities;

namespace SchedulerWeb.Services.Api.Interfaces;

public interface IScheduleService
{
    Task<Schedule?> GetScheduleToFileAsync(string deskId);
    Task<Schedule?> GetCurrentScheduleAsync(string deskId);
    Task<Schedule?> GetNextScheduleAsync(string deskId);
}
