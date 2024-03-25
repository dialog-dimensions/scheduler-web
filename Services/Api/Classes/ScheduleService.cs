using System.Net;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using SchedulerWeb.Models.DTOs.Entities;
using SchedulerWeb.Models.Entities;
using SchedulerWeb.Services.Api.BaseClasses;
using SchedulerWeb.Services.Api.Interfaces;

namespace SchedulerWeb.Services.Api.Classes;

public class ScheduleService : ApiService, IScheduleService
{
    public ScheduleService(IJSRuntime jsRuntime, HttpClient client) : base(client, jsRuntime)
    {

    }
    
    
    public async Task<Schedule?> GetScheduleToFileAsync()
    {
        await ConfigureAsync();
        
        const string uri = "api/Schedule/NearestIncomplete";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return null;
            }
            
            var dto = await response.Content.ReadFromJsonAsync<FlatScheduleDto>();
            return dto?.ToEntity();
        }

        throw new HttpRequestException("Unable to retrieve schedule.");
    }

    public async Task<Schedule?> GetCurrentScheduleAsync()
    {
        await ConfigureAsync();

        const string uri = "api/Schedule/Current";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return null;
            }
            
            var dto = await response.Content.ReadFromJsonAsync<ScheduleDto>();
            return dto?.ToEntity();
        }
        
        throw new HttpRequestException("Unable to retrieve schedule.");
    }

    public async Task<Schedule?> GetNextScheduleAsync()
    {
        await ConfigureAsync();

        const string uri = "api/Schedule/Next";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return null;
            }
            
            var dto = await response.Content.ReadFromJsonAsync<ScheduleDto>();
            return dto?.ToEntity();
        }

        throw new HttpRequestException("Unable to retrieve schedule.");
    }
}
