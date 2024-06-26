﻿using System.Net;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using SchedulerWeb.Models.DTOs.Entities;
using SchedulerWeb.Models.Entities;
using SchedulerWeb.Services.Api.BaseClasses;
using SchedulerWeb.Services.Api.Interfaces;

namespace SchedulerWeb.Services.Api.Classes;

public class ScheduleService(IJSRuntime jsRuntime, HttpClient client) : ApiService(client, jsRuntime), IScheduleService
{
    public async Task<Schedule?> GetScheduleToFileAsync(string deskId)
    {
        await ConfigureAsync();
        
        var uri = $"api/Schedule/{deskId}/NearestIncomplete";
        var response = await Client.GetAsync(uri);
        if (!response.IsSuccessStatusCode) throw new HttpRequestException("Unable to retrieve schedule.");
        if (response.StatusCode == HttpStatusCode.NoContent)
        {
            return null;
        }
            
        var dto = await response.Content.ReadFromJsonAsync<FlatScheduleDto>();
        return dto?.ToEntity();

    }

    public async Task<Schedule?> GetCurrentScheduleAsync(string deskId)
    {
        await ConfigureAsync();
        
        var uri = $"api/Schedule/{deskId}/Current";
        var response = await Client.GetAsync(uri);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Unable to retrieve schedule.");
        }
        
        if (response.StatusCode == HttpStatusCode.NoContent)
        {
            return null;
        }
            
        var dto = await response.Content.ReadFromJsonAsync<ScheduleDto>();
        return dto?.ToEntity();
    }

    public async Task<Schedule?> GetNextScheduleAsync(string deskId)
    {
        await ConfigureAsync();

        var uri = $"api/Schedule/{deskId}/Next";
        var response = await Client.GetAsync(uri);
        if (!response.IsSuccessStatusCode) throw new HttpRequestException("Unable to retrieve schedule.");
        if (response.StatusCode == HttpStatusCode.NoContent)
        {
            return null;
        }
            
        var dto = await response.Content.ReadFromJsonAsync<ScheduleDto>();
        return dto?.ToEntity();

    }
}
