using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Persistence;
using RI.Novus.Core.Boundaries.Persistence;

namespace WebApiExample;

/// <summary>
/// Application main class
/// </summary>
[ExcludeFromCodeCoverage]
public static class Program
{
    private const string OriginsKey = "Origins";
    const string SqlConnectionString = "SqlServerConnection";
    
    /// <summary>
    /// Application main method
    /// </summary>
    /// <param name="args"></param>
    public static async Task Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);

        AddDbContext(builder.Services, builder.Configuration);
        AddRepositories(builder);
        
        builder.Services.AddDbContext<RINovusContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString(SqlConnectionString)));
        
        // Add services to the container.
        builder.Services.AddControllers();
        
        builder.Services.AddSwaggerGen(c =>
        {
            c.CustomSchemaIds(r => r.FullName);
        });
        
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
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
    
    private static void AddDbContext(IServiceCollection builderServices, ConfigurationManager configuration)
    {
        var migrationsAssembly = typeof(RINovusContext).GetTypeInfo().Assembly.GetName().Name;
        string? connectionString = configuration.GetConnectionString(SqlConnectionString);

        void ContextBuilder(DbContextOptionsBuilder b) =>
            b.UseSqlServer(connectionString, sql =>
            {
                sql.MigrationsAssembly(migrationsAssembly);
                sql.MigrationsHistoryTable("_EFNegotiationMigrationHistory", "rinovus");
                sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });

        builderServices.AddDbContext<RINovusContext>(ContextBuilder);
        builderServices.AddScoped<DbContext, RINovusContext>();
    }

    private static void AddRepositories(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAseguradosRepositoryDummy, AseguradosRepositoryDummy>();
        builder.Services.AddScoped<IOwnerRepositoryDummy, OwnerRepositoryDummy>();
        builder.Services.AddScoped<IPropertyRepositoryDummy, PropertyRepositoryDummy>();
    }
}