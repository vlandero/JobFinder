using Microsoft.EntityFrameworkCore;
using Tema.Models.Companies;
using Tema.Models.Jobs;
using Tema.Models.ManyToMany;
using Tema.Models.Users;

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
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(s => s.Company)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Seeker>()
                .HasOne(s => s.CompanyCreated)
                .WithOne(c => c.Creator)
                .HasForeignKey<Company>(c => c.CreatorId);

            modelBuilder.Entity<Seeker>()
                .HasOne(s => s.Company)
                .WithMany(f => f.Employees)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Seeker>()
                .HasMany(s => s.Jobs)
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
