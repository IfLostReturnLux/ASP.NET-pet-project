using Microsoft.EntityFrameworkCore;

namespace Diplom
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=diplom", new MySqlServerVersion(new Version(8, 0, 36)));
            base.OnConfiguring(optionsBuilder);

        }
        public class LoginData
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
        }

        public class UserData
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Role { get; set; }
            public string Name { get; set; }
        }
        public class Role
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }

        public DbSet<LoginData> logindata { get; set; }
        public DbSet<UserData> users { get; set; }
        public DbSet<Role> rolelist { get; set; }
    }
}
