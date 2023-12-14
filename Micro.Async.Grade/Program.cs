using Micro.Async.Grade;
using Micro.Async.Grade.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GradeDBContext>(opt =>
opt.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=GradeDB;Trusted_Connection=True;"));
builder.Services.AddScoped<IMessageBroker, MessageBroker>();
builder.Services.AddControllers();
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
