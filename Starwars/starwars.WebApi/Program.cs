using starwars.BusinessLogic;
using starwars.DataAccess;
using starwars.Domain;
using starwars.IBusinessLogic;
using starwars.IDataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StarwarsContext>();

builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IGenericRepository<Character>, CharacterManagment>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();

