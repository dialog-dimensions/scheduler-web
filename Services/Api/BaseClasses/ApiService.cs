using System.Net.Http.Headers;
using Microsoft.JSInterop;

namespace SchedulerWeb.Services.Api.BaseClasses;

public abstract class ApiService
{
    protected readonly HttpClient Client;
    protected readonly IJSRuntime JsRuntime;

    protected ApiService(HttpClient client, IJSRuntime jsRuntime)
    {
        Client = client;
        JsRuntime = jsRuntime;
    }

    protected async Task ConfigureAsync()
    {
        var token = await JsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}