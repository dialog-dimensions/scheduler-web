using Microsoft.JSInterop;
using SchedulerWeb.Services.RuntimeUtils.Interfaces;

namespace SchedulerWeb.Services.RuntimeUtils.Classes;

public class JsRegistry(IJSRuntime jsRuntime) : IJsRegistry
{
    public async Task RegisterItemAsync<T>(string argName, T value)
    {
        await jsRuntime.InvokeVoidAsync("localStorage.setItem", argName, value);
    }

    public async Task<T> FetchItemAsync<T>(string argName)
    {
        return await jsRuntime.InvokeAsync<T>("localStorage.getItem", argName);
    }
}
