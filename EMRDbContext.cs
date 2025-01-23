using EMR_Final.Models;
using Microsoft.EntityFrameworkCore;

public class EMRDbContext : DbContext
{
    public EMRDbContext(DbContextOptions<EMRDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Patient> Patients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Map the entity to the exact table name in PostgreSQL
        modelBuilder.Entity<User>().ToTable("users");

        // Map the Patient entity to the patient_details table
        modelBuilder.Entity<Patient>().ToTable("patient_details");
    }

    
}
