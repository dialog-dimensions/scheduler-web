using System.IdentityModel.Tokens.Jwt;
using SchedulerWeb.Services.RuntimeUtils.Interfaces;

namespace SchedulerWeb.Services.RuntimeUtils.Classes;

public class JwtParser : IJwtParser
{
    public DateTime ParseExpirationDateTime(string token)
    {
        if (string.IsNullOrEmpty(token)) return DateTime.MinValue;

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        return jwtToken.ValidTo;
    }

    public bool ValidThrough(string token, DateTime dateTime)
    {
        return ParseExpirationDateTime(token) > dateTime;
    }

    public bool CurrentlyValid(string token)
    {
        return ValidThrough(token, DateTime.UtcNow);
    }

    public string? GetIdFromToken(string token)
    {
        if (string.IsNullOrEmpty(token)) return null;

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        return jwtToken.Subject;
    }
}
