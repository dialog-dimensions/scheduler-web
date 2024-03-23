using SchedulerWeb.Models.Entities;

namespace SchedulerWeb.Services.Api.Interfaces;

public interface IExceptionService
{
    Task<IEnumerable<ShiftException>?> GetExceptionsAsync(DateTime scheduleKey, int employeeId);
    
    Task<bool> FileExceptionsAsync(IEnumerable<ShiftException> exceptions);
}