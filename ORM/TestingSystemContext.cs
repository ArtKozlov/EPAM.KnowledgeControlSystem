
using System.Data.Entity;
using ORM.Entities;

namespace ORM
{

    public class TestingSystemContext : DbContext
    {

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestResult> TestResults { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }

        static TestingSystemContext()
        {
            Database.SetInitializer(new TestingSystemDbInitializer());
        }
        public TestingSystemContext()
            : base("name=TestingSystem")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(i => i.Roles)
                .WithMany(u => u.Users)
                .Map(m =>
                {
                    m.ToTable("UserRole");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });

            modelBuilder.Entity<User>()
                .HasOptional(i => i.TestResult)
                .WithRequired(u => u.User);

            modelBuilder.Entity<Test>()
                .HasOptional(i => i.TestResult)
                .WithMany(u => u.Tests);

            modelBuilder.Entity<Test>()
                .HasMany(i => i.Questions)
                .WithRequired(u => u.Test);

            modelBuilder.Entity<Test>()
                .HasMany(i => i.Answers)
                .WithRequired(u => u.Test);
        }

        private class TestingSystemDbInitializer : DropCreateDatabaseIfModelChanges<TestingSystemContext>
        {
            protected override void Seed(TestingSystemContext db)
            {
                db.Roles.Add(new Role { Name = "Admin", Description = "This role have all feutures" });
                db.Roles.Add(new Role { Name = "Moderator", Description = "This role have much feutures" });
                db.Roles.Add(new Role { Name = "User", Description = "This role have nothing" });
                db.SaveChanges();
            }
        }
    }
}
