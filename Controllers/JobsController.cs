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
        [HttpGet(Name ="getjob")]
        public IActionResult  Details(Guid id)
        {
           Job job = _context.GetJob(id);
            return Ok(job);
        }

       
    }
}
