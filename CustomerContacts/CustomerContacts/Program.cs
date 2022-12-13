using CustomerContacts.Data;
using CustomerContacts.Interfaces;
using CustomerContacts.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CustomerContacts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
Mapper.Initialize(c => c.AddProfile<MappingProfile>());
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
