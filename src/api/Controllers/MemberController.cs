using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

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
            return new string[] { "value1", "value2" };
        }

        //[Route("all")]
        //public IActionResult All()
        //{
        //    JsonResult result = Json(_service.Members.ToList());
        //    return result;
        //}

        [HttpGet("/info/{id}")]
        public IActionResult GetInfo(string id)
        {
            var result = _service.Get_Member_Information_By_ID(id);
            return new ObjectResult(result);
        }
    }
}
