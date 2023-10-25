using Microsoft.EntityFrameworkCore;

namespace mixandmatchv2
{
    public class MMContext : DbContext
    {
        static readonly string connectionString = "Server=localhost; Port=3308;User ID=root;Password=password123;Database=temp";
        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public Job GetJob(Guid jobId)
        {
            return Jobs.FirstOrDefault(x => x.jobid == jobId);
        }

    }
    public class Job
    {
        public Guid jobid { get; set; }
        public string jobname { get; set; }
        public string jobdescription { get; set; }
        public string jobtype { get; set; }

    }

  
}
