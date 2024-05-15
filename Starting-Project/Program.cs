using Microsoft.EntityFrameworkCore;
using Starting_Project.Data;
using Starting_Project.RepositoryLayer;
using Starting_Project.ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<IProgramSL,ProgramSL>();
builder.Services.AddScoped<IProgramRL, ProgramRL>();
builder.Services.AddScoped<ICandidateSL, CandidateSL>();
builder.Services.AddScoped<ICandidateRL, CandidateRL>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ApplicaionDBContext>(options => 
//options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnectionString")));

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
