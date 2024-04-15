using Ekz.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace Ekz;

public class AppDb : DbContext
{
    public static readonly MySqlConnectionStringBuilder StringBuilder = new()
    {
        Server = "10.10.1.24",
        UserID = "user_01pro",
        Password = "user01pro",
        Database = "pro1_2"
    };

    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Position> Positions { get; set; } = null!;
    public DbSet<Team> Teams { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseMySql(StringBuilder.ConnectionString,
            ServerVersion.AutoDetect(StringBuilder.ConnectionString));
    }
}