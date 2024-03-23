using Microsoft.IdentityModel.Tokens;
using SchedulerWeb.Services.RuntimeUtils.Interfaces;

namespace SchedulerWeb.Services.RuntimeUtils.Classes;

public class RuntimeTools : IRuntimeTools
{
    private readonly IJsRegistry _jsRegistry;
    private readonly IJwtParser _jwtParser;

    public RuntimeTools(IJsRegistry jsRegistry, IJwtParser jwtParser)
    {
        _jsRegistry = jsRegistry;
        _jwtParser = jwtParser;
    }
    
    
    public async Task<string?> TryGetValidTokenAsync()
    {
        var token = await _jsRegistry.FetchItemAsync<string>("authToken");
        if (token.IsNullOrEmpty())
        {
            return null;
        }

        if (!_jwtParser.CurrentlyValid(token))
        {
            await RegisterTokenAsync(string.Empty);
            return string.Empty;
        }

        return token;
    }

    public async Task<string?> TryGetIdAsync()
    {
        return await _jsRegistry.FetchItemAsync<string>("id");
    }


    public async Task RegisterTokenAsync(string token)
    {
        await _jsRegistry.RegisterItemAsync("authToken", token);
    }

    public async Task RegisterIdAsync(string id)
    {
        await _jsRegistry.RegisterItemAsync("id", id);
    }
}
