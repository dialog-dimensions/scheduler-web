using System.Net.Http.Json;
using System.Text;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using SchedulerWeb.Models.DTOs.Entities;
using SchedulerWeb.Models.Entities;
using SchedulerWeb.Services.Api.BaseClasses;
using SchedulerWeb.Services.Api.Interfaces;

namespace SchedulerWeb.Services.Api.Classes;

public class ExceptionService(HttpClient client, IJSRuntime jsRuntime)
    : ApiService(client, jsRuntime), IExceptionService
{
    public async Task<IEnumerable<ShiftException>?> GetExceptionsAsync(string deskId, DateTime scheduleStart, int employeeId)
    {
        await ConfigureAsync();
        
        var uri = $"api/ShiftException/{deskId}/{scheduleStart:s}/{employeeId}";
        var response = await Client.GetAsync(uri);
        if (!response.IsSuccessStatusCode) return null;
        var dtos = await response.Content.ReadFromJsonAsync<IEnumerable<ShiftExceptionDto>>();
        return dtos?.Select(dto => dto.ToEntity()) ?? new List<ShiftException>();

    }

    public async Task<bool> FileExceptionsAsync(IEnumerable<ShiftException> exceptions)
    {
        await ConfigureAsync();

        const string uri = "api/ShiftException";
        var dtos = exceptions.Select(ShiftExceptionDto.FromEntity).ToList();
        var content = new StringContent(JsonConvert.SerializeObject(dtos), Encoding.UTF8, "application/json");
        var response = await Client.PostAsync(uri, content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> PutExceptionsAsync(string deskId, DateTime scheduleStart, int employeeId, IEnumerable<ShiftException> exceptions)
    {
        await ConfigureAsync();

        var uri = $"api/ShiftException/{deskId}/{scheduleStart:s}/{employeeId}";
        var dtos = exceptions.Select(ShiftExceptionDto.FromEntity).ToList();
        var content = new StringContent(JsonConvert.SerializeObject(dtos), Encoding.UTF8, "application/json");
        var response = await Client.PutAsync(uri, content);
        return response.IsSuccessStatusCode;
    }
}
