using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mixandmatchv2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : Controller    
    {   private readonly MMContext _context;
        public JobsController(MMContext context) 
        {
            _context = context;
        }

        // GET: JobsController/Details/5
        [HttpGet("details",Name ="getjob")]
        public IActionResult  Details(int id)
        {
           Job job = _context.GetJob(id);
            if(job == null)
            {
                return NotFound("the job not found");
            }
            return Ok(job);
        }
        [HttpGet("list", Name = "getjoblist")] // Add a new route for listing all jobs
        public IActionResult ListJobs()
        {
            List<Job> jobs = _context.getJobs(); // Replace with your method to fetch all jobs
            return Ok(jobs);
        }
        //[HttpGet(Name)]
        //public IActionResult Jobs()
        //{
        //    return Ok(_context.getJobs());
        //}

    }
}
