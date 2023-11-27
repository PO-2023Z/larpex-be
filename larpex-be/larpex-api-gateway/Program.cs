using larpex_events.Persistance;
using larpex_events.Services.Interface;
using larpex_payment_adapter.Persistence;
using larpex_payment_adapter.Services.Implementation;
using larpex_payment_adapter.Services.Interface;

using larpex_events.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using larpex_db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c => {
    c.SwaggerDoc("v1", new OpenApiInfo() { Title = "LarpexAPI", Version = "v1"});
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. <br/><br/> Enter 'Bearer' [space] and then your token in the text input <br/><br/> Example: Bearer 1232131231fdsf",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<String>()    
        }
    }); 
});

builder.Services.AddScoped<IPaymentsAdapterService, PaymentsAdapterService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IEventsRepository, EventsRepository>();
builder.Services.AddScoped<IEventsEmployeeService, EventEmployeeService>();
builder.Services.AddScoped<IEventsOrganiserService, EventOrganiserService>();
builder.Services.AddScoped(sp => new HttpClient
    { BaseAddress = new Uri("https://larpex-external-payments.azurewebsites.net/api/") });

builder.Services.AddDbContext<larpex_db.LarpexdbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("LarpexContext"));
});

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