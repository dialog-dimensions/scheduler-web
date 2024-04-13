using System.Text;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using SchedulerWeb.Models;
using SchedulerWeb.Services.Api.Interfaces;

namespace SchedulerWeb.Services.Api.Classes;

public class AuthenticationService(HttpClient client, IJSRuntime jsRuntime) : IAuthenticationService
{
    public async Task<bool> LoginAsync(string id, string password)
    {
        var model = new LoginModel { Id = id, Password = password };
        const string uri = "api/User/Login";
        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        var response = await client.PostAsync(uri, content);
        if (!response.IsSuccessStatusCode) return false;
        var jwtToken = await response.Content.ReadAsStringAsync();
        await jsRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", jwtToken);
        await jsRuntime.InvokeVoidAsync("localStorage.setItem", "id", id);
        return true;
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
        var response = await client.PostAsync(uri, content);
        return response.IsSuccessStatusCode ? null : response.ReasonPhrase;
    }
}
