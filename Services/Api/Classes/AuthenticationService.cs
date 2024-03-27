using System.Text;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using SchedulerWeb.Models;
using SchedulerWeb.Services.Api.Interfaces;

namespace SchedulerWeb.Services.Api.Classes;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _client;
    private readonly IJSRuntime _jsRuntime;

    public AuthenticationService(HttpClient client, IJSRuntime jsRuntime)
    {
        _client = client;
        _jsRuntime = jsRuntime;
    }

    public async Task<bool> LoginAsync(string id, string password)
    {
        var model = new LoginModel { Id = id, Password = password };
        const string uri = "api/User/Login";
        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(uri, content);
        if (response.IsSuccessStatusCode)
        {
            var jwtToken = await response.Content.ReadAsStringAsync();
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", jwtToken);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "id", id);
            return true;
        }

        return false;
    }

    public async Task<string?> RegisterAsync(string id, string phone, string password, string confirmPassword)
    {
        var model = new RegistrationModel
        {
            Id = id,
            PhoneNumber = phone, 
            Password = password, 
            ConfirmPassword = confirmPassword
        };

        const string uri = "api/User/Register";
        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(uri, content);
        if (response.IsSuccessStatusCode)
        {
            return null;
        }

        return response.ReasonPhrase;
    }
}
