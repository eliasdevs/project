using Microsoft.EntityFrameworkCore;
using AppWebCRUD.Data.models;
namespace AppWebCRUD.Data;
public class AppWebCrudContext : DbContext
{

    public AppWebCrudContext(DbContextOptions<AppWebCrudContext> options) : base(options)
    {


    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=DESKTOP-NSMGHJA;Database=AppWebCRUD;Trusted_Connection=True;TrustServerCertificate=True;", b => b.MigrationsAssembly("AppWebCRUD"));
    }

    //TODO: Add DbSets (Tables of our Data base)
    public DbSet<User>? Users { get; set; }


}
