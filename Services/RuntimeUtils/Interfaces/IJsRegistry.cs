namespace SchedulerWeb.Services.RuntimeUtils.Interfaces;

public interface IJsRegistry
{
    Task RegisterItemAsync<T>(string argName, T value);
    Task<T> FetchItemAsync<T>(string argName);
}
