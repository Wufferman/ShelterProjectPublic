using Server.Repositories;
using Server.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserRepository, UserRepositorySQLite>();
builder.Services.AddSingleton<IShelterRepository, ShelterRepositoryMongoDB>();
builder.Services.AddSingleton<IShelterBookingRepository, ShelterBookingRepositoryMongoDB>();
builder.Services.AddSingleton<IKommuneRepository, KommuneRepositoryMongoDB>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("policy",
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                          
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
