﻿using System.Net.Http.Json;
using System.Text;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using SchedulerWeb.Models.DTOs.Entities;
using SchedulerWeb.Models.Entities;
using SchedulerWeb.Services.Api.BaseClasses;
using SchedulerWeb.Services.Api.Interfaces;

namespace SchedulerWeb.Services.Api.Classes;

public class ExceptionService : ApiService, IExceptionService
{
    public ExceptionService(HttpClient client, IJSRuntime jsRuntime) : base(client, jsRuntime)
    {
    }
    
    public async Task<IEnumerable<ShiftException>?> GetExceptionsAsync(DateTime scheduleKey, int employeeId)
    {
        await ConfigureAsync();
        
        var uri = $"api/ShiftException/{scheduleKey:s}/{employeeId}";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            var dtos = await response.Content.ReadFromJsonAsync<IEnumerable<ShiftExceptionDto>>();
            return dtos?.Select(dto => dto.ToEntity()) ?? new List<ShiftException>();
        }

        return null;
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
}
