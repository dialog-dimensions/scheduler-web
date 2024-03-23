using Microsoft.JSInterop;
using SchedulerWeb.Services.RuntimeUtils.Interfaces;

namespace SchedulerWeb.Services.RuntimeUtils.Classes;

public class JsRegistry : IJsRegistry
{
    private readonly IJSRuntime _jsRuntime;

    public JsRegistry(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task RegisterItemAsync<T>(string argName, T value)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", argName, value);
    }

    public async Task<T> FetchItemAsync<T>(string argName)
    {
        return await _jsRuntime.InvokeAsync<T>("localStorage.getItem", argName);
    }
}