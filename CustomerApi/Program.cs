using CustomerBL;
using CustomerDL;
using CustomerModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Setting up dependencies:
builder.Services.AddScoped<IRepository<Customer>, SQLCustomerRepository>(repo => new SQLCustomerRepository(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<ICustomerBL, CustomersBL>();

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
