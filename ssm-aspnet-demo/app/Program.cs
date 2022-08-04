using Amazon.Extensions.Configuration.SystemsManager;
using Amazon.Extensions.NETCore.Setup;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var awsOptions = builder.Configuration.GetAWSOptions();
builder.Services.AddSingleton(awsOptions);
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
