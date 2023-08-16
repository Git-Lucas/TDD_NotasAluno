using System.Text.Json.Serialization;
using TDD_NotasAluno.Application;
using TDD_NotasAluno.Application.Data;
using TDD_NotasAluno.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddDbContext<EfSqlServerAdapter>();
builder.Services.AddScoped<IAlunoData, AlunoDataSqlServer>();
builder.Services.AddScoped<INotaData, NotaDataSqlServer>();
builder.Services.AddScoped<AlunoService>();

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
