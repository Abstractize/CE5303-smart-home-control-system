using Data.Models;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace Data.Context
{
    public partial class HomeContext : ApiAuthorizationDbContext<User, Role, Guid>
    {
        public HomeContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions) { }

        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Ligth> Ligths { get; set; }
        public virtual DbSet<Door> Doors { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable(typeof(User).Name);
            modelBuilder.Entity<Role>().ToTable(typeof(Role).Name);
        }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HomeContext>
    {
        private const String CONNECTION_STRING = "Filename=../API/Data/HomeDB.db";
        public HomeContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HomeContext>();
            builder.UseSqlite(CONNECTION_STRING);
            var context = new HomeContext(builder.Options, new OperationalStoreOptionsMigrations());
            return context;
        }
    }
}
