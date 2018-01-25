using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private readonly MemberService _service;

        public MemberController(MemberService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Hi this MemberService" };
        }

        [HttpGet("info/{id}", Name = "GetInfo")]
        public IActionResult GetById(string id)
        {
            var result = _service.Get_Member_Information_By_ID(id);
            return new ObjectResult(result);
        }

        [HttpGet("all", Name = "GetAll")]
        public IEnumerable<Member> GetAll()
        {
            return _service.List_Members();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Member memberInput)
        {
            var result = _service.Add_Members(memberInput);

            return new ObjectResult(result);
        }

        [HttpGet("test"), Authorize]
        public IEnumerable<string> test()
        {
            return new string[] { "Hi this MemberService" };
        }
        
    }
}
