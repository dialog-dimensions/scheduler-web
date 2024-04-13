namespace SchedulerWeb.Services.RuntimeUtils.Interfaces;

public interface IJwtParser
{
    DateTime ParseExpirationDateTime(string token);
    bool ValidThrough(string token, DateTime dateTime);
    bool CurrentlyValid(string token);
    string? GetIdFromToken(string token);
}
