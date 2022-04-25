using GrupoA.Academic.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using GrupoA.Academic.Api.Configurations;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AcademicDbContext>();
builder.Services.AddFluentValidation();
builder.Services.AddVersioning();
builder.Services.AddMediator();
builder.Services.AddAutoMapper();
builder.Services.AddAcademicServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandlerMiddleware(app.Environment);
app.UseHttpsRedirection();
app.UseAcademicCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
