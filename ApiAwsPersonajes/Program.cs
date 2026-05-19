using ApiAwsPersonajes.Data;
using ApiAwsPersonajes.Repository;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(p => p.AddPolicy("corsenabled", options =>
{
    options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddDbContext<TelevisionContext>(opt => opt.UseMySQL(builder.Configuration.GetConnectionString("MYSQL")));
builder.Services.AddTransient<PersonajesRepository>();

var app = builder.Build();



app.MapGet("/", content =>
{

    content.Response.Redirect("/scalar");
    return Task.CompletedTask;
});
    app.MapOpenApi();
app.MapScalarApiReference();
app.UseHttpsRedirection();
app.UseCors("corsenabled");
app.UseAuthorization();

app.MapControllers();

app.Run();
