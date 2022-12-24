using Microsoft.EntityFrameworkCore;
using Tema.Models.Companies;
using Tema.Models.Jobs;
using Tema.Models.ManyToMany;
using Tema.Models.Users.Finder;
using Tema.Models.Users.Seeker;

namespace Tema.Models
{
    public class MyAppContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Seeker> Seekers { get; set; }
        public DbSet<Finder> Finders { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Applicant> Applicants { get; set; }

        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seeker>(e => e.HasIndex(x => x.Email).IsUnique());
            modelBuilder.Entity<Finder>(e => e.HasIndex(x => x.Email).IsUnique());
            modelBuilder.Entity<Company>(e => e.HasIndex(x => x.Name).IsUnique());

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(s => s.Company)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Seeker>()
                .HasMany(s => s.ListedJobs)
                .WithOne(j => j.Seeker)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<Applicant>()
                .HasKey(a => new { a.FinderId, a.JobId });
            
            modelBuilder.Entity<Applicant>()
                .HasOne(a => a.Finder)
                .WithMany(f => f.JobApplications)
                .HasForeignKey(a => a.FinderId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<Applicant>()
                .HasOne(a => a.Job)
                .WithMany(j => j.Applicants)
                .HasForeignKey(a => a.JobId)
                .OnDelete(DeleteBehavior.SetNull); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
