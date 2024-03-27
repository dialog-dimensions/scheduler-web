using System.Globalization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SchedulerWeb;
using SchedulerWeb.Services.Api.Classes;
using SchedulerWeb.Services.Api.Interfaces;
using SchedulerWeb.Services.EuiTransform.Classes;
using SchedulerWeb.Services.EuiTransform.Interfaces;
using SchedulerWeb.Services.RuntimeUtils.Classes;
using SchedulerWeb.Services.RuntimeUtils.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

const string apiUri = "https://scheduler82-api.azurewebsites.net/";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUri) });
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<IExceptionService, ExceptionService>();
builder.Services.AddTransient<IScheduleService, ScheduleService>();
builder.Services.AddTransient<IEuiTransformer, EuiTransformer>();
builder.Services.AddTransient<IJwtParser, JwtParser>();
builder.Services.AddTransient<IJsRegistry, JsRegistry>();
builder.Services.AddTransient<IRuntimeTools, RuntimeTools>();


var culture = new CultureInfo("he-IL");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await builder.Build().RunAsync();
