using MediatR;
using Microsoft.EntityFrameworkCore;
using PurchaseOrder.Application.IRepository;

using PurchaseOrder.Infrastucture;
using PurchaseOrder.Infrastucture.Repository;


var AllowOrgins = "_AlowOrgins";
var builder = WebApplication.CreateBuilder(args);

//Register Configration
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

//
builder.Services.AddScoped<IPOMasterRepository , POMasterRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierDetailsRepository>();
builder.Services.AddScoped<ILoginRepositary, LoginRepositary>();

//Add Database Service
builder.Services.AddDbContext<PurchaseOrderDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
opt => opt.MigrationsAssembly("PurchaseOrder.API")));

builder.Services.AddControllers();
builder.Services.AddCors(Options =>
{
    Options.AddPolicy(name: AllowOrgins,
    builder =>
    {
        builder.WithOrigins("http://localhost:4200", "http://localhost:56714")
        .AllowAnyHeader()
        .AllowAnyMethod();

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(AllowOrgins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
