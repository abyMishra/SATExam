using CommonLibrary;
using DataModels.Common;
using DestinationService.BusinessLogic;
using DestinationService.DataAccess;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<DBSettings>(builder.Configuration.GetSection("MongoDB"));
//builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddTransient<IDestinationBusinessLogic, DestinationBusinessLogic>();
builder.Services.AddSingleton<DestinationDataAccess>();
builder.Services.AddTransient<ICommonMethods, PasswordBycrpt>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, config) =>
 {
     config.ReadFrom.Configuration(context.Configuration);
 });

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
