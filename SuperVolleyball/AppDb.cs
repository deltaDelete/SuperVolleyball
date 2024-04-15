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
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseMySql(StringBuilder.ConnectionString,
            ServerVersion.AutoDetect(StringBuilder.ConnectionString));
    }
}