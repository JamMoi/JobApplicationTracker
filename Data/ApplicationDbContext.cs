using Microsoft.EntityFrameworkCore;
using JobApplicationTracker.Models;


namespace JobApplicationTracker.Data
{
    // Represents the application's database context
    // EF Core uses this class to communicate with the database
    public class ApplicationDbContext : DbContext
    {
        // Receives database configuration, such as the SQL Server connection settings,
        // and passes them to the base DbContext class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Represents the JobApplications table in the database.
        // Each row corresponds to one JobApplication object
        public DbSet<JobApplication> JobApplications { get; set; }
    }
}
