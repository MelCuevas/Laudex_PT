// ---------------------------------------------------------------------------------- 
// Copyright (c) Laudex
// Licensed under the MIT License
// ----------------------------------------------------------------------------------

namespace Laudex.DataAccess;

public class LaudexDbContext : DbContext
{
    private readonly AppSettings appSettings;
    public DbSet<LaudexTaskModel> Tasks { get; set; }
    public DbSet<LaudexStatuses> Statuses { get; set; }

    public LaudexDbContext(AppSettings appSettings)
    {
        this.appSettings = appSettings;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(appSettings.SqlConnectionString);

        base.OnConfiguring(optionsBuilder);
    }
}