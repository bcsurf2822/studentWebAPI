using CollegeApp.Configurations;
using CollegeApp.Data;
using CollegeApp.Data.Repository;
using CollegeApp.MyLogging;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

#region Loggin Settings
// builder.Logging.ClearProviders();
// builder.Logging.AddConsole();
// builder.Logging.AddDebug(); //Built in Loggers
#endregion
#region SeriLog Settings
// Log.Logger = new LoggerConfiguration().
// MinimumLevel.Information()
//     .WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Minute)
//     .CreateLogger();

//builder.Host.UserSerilog();  Overrides built in Loggers
// builder.Logging.AddSerilog(); //Logging vs Services will do default loggin as well
#endregion


// ✅ Read the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ✅ Register your DbContext with the SQLite provider
builder.Services.AddDbContext<CollegeDBContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped(typeof(ICollegeRepository<>), typeof(CollegeRepository<>));//Generic types for dep injection

// Add services to the containers
builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters(); //Allows JSON and XML


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddTransient<IMyLogger, LogToServerMemory>();
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); // Enables controller routing like [Route("api/[controller]")]
app.Run();