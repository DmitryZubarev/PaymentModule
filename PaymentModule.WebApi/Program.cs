using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using PaymentModule.Abstract.BankClient;
using PaymentModule.Abstract.BusinessLogic;
using PaymentModule.Abstract.Data.DataWriter;
using PaymentModule.Abstract.Data.Reporting;
using PaymentModule.BankClient;
using PaymentModule.Core.Services;
using PaymentModule.DataContext;
using PaymentModule.DataWriter;
using PaymentModule.Reporting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options => options
                    .UseNpgsql("Host=localhost;Port=5432;Database=PaymentModule;Username=postgres;Password=postgres"),
                    ServiceLifetime.Singleton);
builder.Services.AddSingleton<IDbWriterService, DataWriterService>();
builder.Services.AddScoped<IReportingService, ReportingService>();
builder.Services.AddSingleton<IBankService, BankService>();
builder.Services.AddSingleton<ISharingSessionService, ActiveSessionService>();


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

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    context.Database.EnsureCreated(); 
}

app.Run();
