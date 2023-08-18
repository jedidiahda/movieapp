using Microsoft.EntityFrameworkCore;
using MovieWebApp.Models;
using MovieWebApp.Repository;

var builder = WebApplication.CreateBuilder(args);
var specificOrigins = "_specificOrigins";
var connectionString = builder.Configuration.GetConnectionString("MovieDB");

builder.Services.AddDbContext<MovieDbContext>(
    options => options.UseSqlServer(connectionString));

//builder.Services.AddDbContext<MovieDbContextDerive>(
//    options => options.UseSqlServer(connectionString));

//builder.Services.AddMvc().AddXmlSerializerFormatters();
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<IDVDCatalogRepository, DVDCatalogRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IWatchlistRepository, WatchlistRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<ICustomerDeliveryRepository, CustomerDeliveryRepository>();

builder.Services.AddControllers()
        .AddNewtonsoftJson(
            options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: specificOrigins,
                      policy =>
                      {
                          policy
                            .AllowAnyOrigin()
                             .AllowAnyMethod()
                             .AllowAnyHeader();
                      });

});



// Add services to the container.

builder.Services.AddControllers();

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

app.UseCors(specificOrigins);




app.UseAuthorization();

app.MapControllers();

app.Run();
