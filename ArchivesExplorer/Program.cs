using ArchivesExplorer.Configuration;
using ArchivesExplorer.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersExtensions();
builder.Services.AddDataContext(builder.Configuration);
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddHelpers(builder.Configuration);
builder.Services.AddBusinessLogic();
builder.Services.AddSwaggerExtension();
builder.Services.AddConfiguredAutoMapper();
builder.Services.AddExceptionResolvers();
builder.Services.AddConfigurationOptions(builder.Configuration);


var app = builder.Build();

app.UseCustomCorsExtension();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();

app.Run();
