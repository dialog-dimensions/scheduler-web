using Microsoft.IdentityModel.Tokens;
using SchedulerWeb.Services.RuntimeUtils.Interfaces;

namespace SchedulerWeb.Services.RuntimeUtils.Classes;

public class RuntimeTools(IJsRegistry jsRegistry, IJwtParser jwtParser) : IRuntimeTools
{
    public async Task<string?> TryGetValidTokenAsync()
    {
        var token = await jsRegistry.FetchItemAsync<string>("authToken");
        if (token.IsNullOrEmpty())
        {
            return null;
        }
        
        if (jwtParser.CurrentlyValid(token)) return token;
        await RegisterTokenAsync(string.Empty);
        return string.Empty;
    }

    public async Task<string?> TryGetIdAsync()
    {
        return await jsRegistry.FetchItemAsync<string>("id");
    }

    public async Task<string> GetHomePageUriAsync()
    {
        return await jsRegistry.FetchItemAsync<string>("homePageUri");
    }
    
    
    public async Task RegisterTokenAsync(string token)
    {
        await jsRegistry.RegisterItemAsync("authToken", token);
    }

    public async Task RegisterIdAsync(string id)
    {
        await jsRegistry.RegisterItemAsync("id", id);
    }

    public async Task RegisterHomePageUriAsync(string uri)
    {
        await jsRegistry.RegisterItemAsync("homePageUri", uri);
    }
}
