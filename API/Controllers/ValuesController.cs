using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Domain;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly AppDbContext _context;

        public ValuesController(ILogger<ValuesController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
            var res = await _context.Values.ToListAsync();
            return Ok(res);
        }        
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            var res = await _context.Values.FindAsync(id);
            return Ok(res);
        }
    }
}
