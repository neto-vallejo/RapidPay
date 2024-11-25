using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RapidPay.API.Data.Database;
using RapidPay.API.Services;
using RapidPay.API.Services.DataServices;
using RapidPay.API.Services.Services;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddDbContext<DataContext>(options => 
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("RapidPay.API.Data")));

builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

// AutoMapper
builder.Services.AddAutoMapper(mc =>
{
    mc.AddProfile(new MappingProfile());
});

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
