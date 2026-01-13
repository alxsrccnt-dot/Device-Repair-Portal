using Application;
using Carter;
using Infrastructure;
using UserServices;
using UserServices.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCarter();
builder.Services.AddCustomAuthentification(builder.Configuration);
builder.Services.AddWebServices();

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastucture(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapCarter();

app.Run();