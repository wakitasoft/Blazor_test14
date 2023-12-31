using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor_test14.Client;
// ↓ここを追加！！
using Blazor_test14.Client.Util;
using Blazor_test14.Client.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("Blazor_test14.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// ↓ここを追加！！
builder.Services.AddHttpClient<PublicClient>("BlazorArticleApp.AnonymousAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));


// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Blazor_test14.ServerAPI"));

// ↓ここを追加！！
builder.Services.AddScoped<IArticleService, ArticleService>();

// ↓ここを追加！！
builder.Services.AddScoped<IPublicArticleService, PublicArticleService>();


builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://WAKITASoft2.onmicrosoft.com/https://WAKITASoft2.onmicrosoft.com/f5e19c62-e42a-492e-a0f6-a6bc9b369d82/API.Access2");
});

await builder.Build().RunAsync();
