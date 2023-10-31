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

        internal List<Job> getJobs()
        {
            return Jobs.ToList();   
            throw new NotImplementedException();
        }
    }
    public class Job
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int companyid { get; set; }

    }

  
}
