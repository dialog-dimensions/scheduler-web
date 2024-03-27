namespace SchedulerWeb.Services.Api.Interfaces;

public interface IAuthenticationService
{
    Task<bool> LoginAsync(string id, string password);
    Task<string?> RegisterAsync(string id, string phone, string password, string confirmPassword);
}