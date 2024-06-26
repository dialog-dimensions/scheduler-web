﻿namespace SchedulerWeb.Services.RuntimeUtils.Interfaces;

public interface IRuntimeTools
{
    // fetch the current token, if exists and valid
    Task<string?> TryGetValidTokenAsync();
    Task<string?> TryGetIdAsync();
    Task<string> GetHomePageUriAsync();
    Task RegisterTokenAsync(string token);
    Task RegisterIdAsync(string id);
    Task RegisterHomePageUriAsync(string uri);
}
