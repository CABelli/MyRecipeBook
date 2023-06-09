using Microsoft.EntityFrameworkCore;
using MyRecipeBook.InfraMongodb.Context;
using MyRecipeBook.InfraMongodb.InterfaceContext;
using MyRecipeBook.InfraMongodb.interfaceRepository;
using MyRecipeBook.InfraMongodb.Repository;
using MyRecipeBook.InfraMongodb.UoW;
using MyRecipeBook.InfraSqlServer.ContextSqlServer;
using MyRecipeBook.InfraSqlServer.InterfaceRepository;
using MyRecipeBook.InfraSqlServer.Repository;

var builder = WebApplication.CreateBuilder(args);

///builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
///builder.Services.AddSingleton<MongoDBService>();
/// MongoDbPersistence.Configure();
 
builder.Services.AddScoped<IMongoContext, AppDbContextMongo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();


//builder.Services.AddScoped<AppDbContextSqlServer, AppDbContextSqlServer>();
//IConfiguration configuration;
//ConfigurationManager configuration = builder.Configuration;

//builder.Services.AddDbContext<AppDbContextSqlServer>(
//    opions => opions.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
//b => b.MigrationsAssembly(typeof(AppDbContextSqlServer).Assembly.FullName)));


IConfiguration configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContextSqlServer>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<DbContext, AppDbContextSqlServer>();

builder.Services.AddScoped<IPriceProductClientRepository, PriceProductClientRepository>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
