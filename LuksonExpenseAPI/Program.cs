using LuksonExpense.Application;
using LuksonExpense.Infrastructure;
using LuksonExpenseAPI;
using LuksonExpenseAPI.Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services
            .AddPresentation(builder.Configuration)
            .AddApplication(builder.Configuration)
            .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment() || true) //Deshabilitar, solo para testing...
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.RunMigrations();

app.Run();
