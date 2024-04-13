using SchedulerWeb.Models.Entities;
using SchedulerWeb.Models.UiModels;

namespace SchedulerWeb.Services.EuiTransform.Interfaces;

public interface IEuiTransformer
{
    List<List<GridSlot>> TransformToUiModel(IEnumerable<Shift> shifts, IEnumerable<ShiftException> exceptions);
    Task<List<ShiftException>> TransformToEntityModel(List<List<GridSlot>> grid);
    List<List<GridSlot>> TransformToViewModel(IEnumerable<Shift> shifts);
}
