using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private readonly MemberContext _context;

        public MemberController(MemberContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("all")]
        public IActionResult All()
        {
            JsonResult result = Json(_context.Members.ToList());
            return result;
        }

        [Route("info")]
        public IActionResult Info(string id)
        {
            var result = _context.Get_Member_Information_By_ID(id);
            return new ObjectResult(result);
        }
    }
}
