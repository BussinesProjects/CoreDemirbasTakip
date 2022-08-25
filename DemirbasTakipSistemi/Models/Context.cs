using DemirbasTakipSistemi.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace DemirbasTakipSistemi.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-9MP8H8TU\\CEMILE; Database=DTS;integrated security=true;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<CurrentUserData> CurrentUserDatas { get; set; }
        public DbSet<PatchNote> PatchNotes { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product> ProjectProducts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
