using EnterpriseAI.Infrastructure.Configuration;
using EnterpriseAI.Application.Interfaces;
using EnterpriseAI.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<AzureOpenAIOptions>(
builder.Configuration.GetSection("AzureOpenAI"));


builder.Services.AddSingleton<IAzureOpenAIService>(sp =>
{
    var configuration =
    sp.GetRequiredService<IConfiguration>();
    var options =
    configuration
    .GetSection("AzureOpenAI")
    .Get<AzureOpenAIOptions>()
    ?? throw new InvalidOperationException(
    "Azure OpenAI configuration is missing.");
    return new AzureOpenAIService(options);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
