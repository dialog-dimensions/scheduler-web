using Microsoft.JSInterop;
using SchedulerWeb.Enums;
using SchedulerWeb.Models.Entities;
using SchedulerWeb.Models.UiModels;
using SchedulerWeb.Services.EuiTransform.Interfaces;

namespace SchedulerWeb.Services.EuiTransform.Classes;

public class EuiTransformer(IJSRuntime jsRuntime) : IEuiTransformer
{
    // Transforms the list of Shifts and ShiftExceptions into a UI-friendly structure
    public List<List<GridSlot>> TransformToUiModel(IEnumerable<Shift> shifts, IEnumerable<ShiftException> exceptions)
    {
        // Group shifts by date to determine columns
        var shiftsByDate = shifts.GroupBy(shift => shift.StartDateTime.Date)
            .OrderBy(group => group.Key)
            .ToList();

        // Initialize the grid with lists representing each date's column of shifts

        return shiftsByDate
            .Select(dateGroup => (
                from shift in dateGroup.OrderBy(s => s.StartDateTime) 
                let exception = exceptions.FirstOrDefault(e => e.ShiftStart == shift.StartDateTime) 
                let exceptionType = exception?.ExceptionType ?? ExceptionType.NoException 
                select new GridSlot
                {
                    StartDateTime = shift.StartDateTime, 
                    ExceptionType = exceptionType,
                    Desk = shift.Desk
                })
                .ToList())
            .ToList();
    }

    public async Task<List<ShiftException>> TransformToEntityModel(List<List<GridSlot>> grid)
    {
        var parseId = int.TryParse(await jsRuntime.InvokeAsync<string>("localStorage.getItem", "id"), out var userId);
        if (!parseId)
        {
            return [];
        }
        
        var exceptions = new List<ShiftException>();

        foreach (var dayColumn in grid)
        {
            exceptions.AddRange(
                from slot in dayColumn 
                where slot.ExceptionType != ExceptionType.NoException 
                select new ShiftException 
                { 
                    Desk = slot.Desk,
                    ShiftStart = slot.StartDateTime, 
                    EmployeeId = userId, 
                    ExceptionType = slot.ExceptionType 
                });
        }

        return exceptions;
    }

    public List<List<GridSlot>> TransformToViewModel(IEnumerable<Shift> shifts)
    {
        // Group shifts by date to determine columns
        var shiftsByDate = shifts.GroupBy(shift => shift.StartDateTime.Date)
            .OrderBy(group => group.Key)
            .ToList();

        // Initialize the grid with lists representing each date's column of shifts

        return shiftsByDate
            .Select(dateGroup => (
                    from shift in dateGroup.OrderBy(s => s.StartDateTime) 
                    select new GridSlot
                    {
                        Desk = shift.Desk,
                        StartDateTime = shift.StartDateTime,
                        Employee = shift.Employee
                    })
                .ToList())
            .ToList();
    }
}
