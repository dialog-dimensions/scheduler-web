using System.Net.Http.Headers;
using Microsoft.JSInterop;

namespace SchedulerWeb.Services.Api.BaseClasses;

public abstract class ApiService
{
    protected readonly HttpClient Client;
    private readonly IJSRuntime _jsRuntime;

    protected ApiService(HttpClient client, IJSRuntime jsRuntime)
    {
        Client = client;
        _jsRuntime = jsRuntime;
    }

    protected async Task ConfigureAsync()
    {
        var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}
