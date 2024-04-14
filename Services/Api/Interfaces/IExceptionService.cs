using SchedulerWeb.Models.Entities;

namespace SchedulerWeb.Services.Api.Interfaces;

public interface IExceptionService
{
    Task<IEnumerable<ShiftException>?> GetExceptionsAsync(string deskId, DateTime scheduleStart, int employeeId);
    
    Task<bool> FileExceptionsAsync(IEnumerable<ShiftException> exceptions);

    Task<bool> PutExceptionsAsync(string deskId, DateTime scheduleStart, int employeeId, IEnumerable<ShiftException> exceptions);
}