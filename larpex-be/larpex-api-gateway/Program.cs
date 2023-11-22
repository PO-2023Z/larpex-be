using larpex_events.Persistance;
using larpex_events.Services.Interface;
using larpex_payment_adapter.Persistence;
using larpex_payment_adapter.Services.Implementation;
using larpex_payment_adapter.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPaymentsAdapterService, PaymentsAdapterService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IEventsRepository, EventsRepository>();
builder.Services.AddScoped(sp => new HttpClient
    { BaseAddress = new Uri("https://larpex-external-payments.azurewebsites.net/api/") });

var app = builder.Build();
app.UseCors(corsPolicyBuilder => 
    corsPolicyBuilder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

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