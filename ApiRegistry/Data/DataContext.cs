using ApiRegistry.Models;
using System.Data.Entity;

namespace ApiRegistry.Data
{
    public class DataContext: DbContext, IDbContext
    {
        public DataContext()
            : base(nameOrConnectionString: "ApiRegistryDataContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<Models.ApiInfo> ApiInfos { get; set; }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
                HasMany(u => u.Roles).
                WithMany(r => r.Users).
                Map(
                    m =>
                    {
                        m.MapLeftKey("User_Id");
                        m.MapRightKey("Role_Id");
                        m.ToTable("UserRoles");
                    });
        } 
    }
}
