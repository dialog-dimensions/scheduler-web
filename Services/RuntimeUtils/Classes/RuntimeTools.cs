﻿using Microsoft.IdentityModel.Tokens;
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
        
        if (_jwtParser.CurrentlyValid(token)) return token;
        await RegisterTokenAsync(string.Empty);
        return string.Empty;
    }

    public async Task<string?> TryGetIdAsync()
    {
        return await _jsRegistry.FetchItemAsync<string>("id");
    }

    public async Task<string> GetHomePageUriAsync()
    {
        return await _jsRegistry.FetchItemAsync<string>("homePageUri");
    }
    
    
    public async Task RegisterTokenAsync(string token)
    {
        await _jsRegistry.RegisterItemAsync("authToken", token);
    }

    public async Task RegisterIdAsync(string id)
    {
        await _jsRegistry.RegisterItemAsync("id", id);
    }

    public async Task RegisterHomePageUriAsync(string uri)
    {
        await _jsRegistry.RegisterItemAsync("homePageUri", uri);
    }
}
