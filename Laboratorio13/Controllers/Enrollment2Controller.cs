using Laboratorio13.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Enrollment2Controller : ControllerBase
    {
        private readonly SchoolContext _context;
        public Enrollment2Controller(SchoolContext context) { 
            _context = context;
        }

        [HttpPost]
        public void Insert() { }
    }
}
