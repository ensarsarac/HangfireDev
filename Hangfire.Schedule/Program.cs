using Hangfire;
using Hangfire.Schedule.ScheduleJobs.Continuations;
using Hangfire.Schedule.ScheduleJobs.Delayeds;
using Hangfire.Schedule.ScheduleJobs.FireAndForgets;
using Hangfire.Schedule.ScheduleJobs.Managers;
using Hangfire.Schedule.ScheduleJobs.Managers.Interfaces;
using Hangfire.Schedule.ScheduleJobs.RecurringJobs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(opt =>
{
    var hangfireConnectionString = builder.Configuration.GetConnectionString("Hangfire");

    opt.UseSqlServerStorage(hangfireConnectionString);
});

builder.Services.AddHangfireServer();

builder.Services.AddSingleton<IRecurringJobs, RecurringJobs>();
builder.Services.AddSingleton<IFireAndForgetsJobs, FireAndForgetsJobs>();
builder.Services.AddSingleton<IDelayedJobs, DelayedJobs>();
builder.Services.AddSingleton<IContinuationJobs, ContinuationJobs>();

builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<ICurrencyManager, CurrencyManager>();
builder.Services.AddScoped<IEmailManager, EmailManager>();


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

app.UseHangfireDashboard();

IRecurringJobs recurringJobs = app.Services.GetService<IRecurringJobs>();
recurringJobs.GetAllProducts();
recurringJobs.GetCurrency();

IDelayedJobs delayedJobs = app.Services.GetService<IDelayedJobs>();
delayedJobs.SendEmail();

IContinuationJobs continuationJobs = app.Services.GetService<IContinuationJobs>();
continuationJobs.SendEMail();

app.Run();
