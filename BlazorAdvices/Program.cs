using BlazorAdvices.Components;
using BlazorAdvices.Components.State;
using BlazorAdvices.Data.Context;
using BlazorAdvices.Repositories;
using BlazorAdvices.Services;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();


builder.Services.AddDbContext<BlazorAdviceDbContext>(options =>
{
    options.UseSqlite("Data Source=advices.db");
});

builder.Services.AddMudServices();
builder.Services.AddHttpClient();
builder.Services.AddScoped<AdviceService>();
builder.Services.AddSingleton<AdviceState>();
builder.Services.AddScoped<AdvicesRepository>();
builder.Services.AddScoped<TranslatorService>();
builder.Services.AddScoped<OwnerAdvicesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");


app.Run();