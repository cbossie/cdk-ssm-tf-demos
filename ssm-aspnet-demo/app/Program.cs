using Amazon.Extensions.Configuration.SystemsManager;
using Amazon.Extensions.NETCore.Setup;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Extensions.Caching;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var awsOptions = builder.Configuration.GetAWSOptions();
builder.Services.AddSingleton(awsOptions);


//Systems Manager Parameter Store
var parameterPrefix = builder.Configuration["parameterprefix"];
builder.Configuration.AddSystemsManager(configSource =>
{
    configSource.Path = $"/{parameterPrefix}/main";
    configSource.AwsOptions = awsOptions;
    configSource.ReloadAfter = new(0, 0, 30);    
});

builder.Configuration.AddSystemsManager(configSource =>
{
    configSource.Path = $"/{parameterPrefix}/db";
    configSource.AwsOptions = awsOptions;
});


//Secrets Manager
builder.Services.AddAWSService<IAmazonSecretsManager>(awsOptions);
builder.Services.AddSingleton<SecretCacheConfiguration>(new SecretCacheConfiguration()
{
    CacheItemTTL = 36000
});
builder.Services.AddSingleton<SecretsManagerCache>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
