using EnterpriseAI.Application.Interfaces;
using EnterpriseAI.Infrastructure.Configuration;
using EnterpriseAI.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.Configure<AzureOpenAIOptions>(builder.Configuration.GetSection("AzureOpenAI"));
builder.Services.AddSingleton<IAzureOpenAIService>(sp => 
{
    var configuration = sp.GetRequiredService<IConfiguration>(); 
    var options = configuration.GetSection("AzureOpenAI").Get<AzureOpenAIOptions>() 
            ?? throw new InvalidOperationException("Azure OpenAI configuration is missing."); 
    return new AzureOpenAIService(options);
});

builder.Services.AddSingleton<IConversationService, InMemoryConversationService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
