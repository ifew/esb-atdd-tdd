using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using api.Models;

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
            //return new ObjectResult("1") ;
        }

        [HttpGet("all", Name = "GetAll")]
        public IEnumerable<Member> GetAll()
        {
            return _service.List_Members();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel registerModel)
        {
            var data = new Member
            {
                Fullname = "Call from API",
                Card_no = registerModel.txt_CardNo,
                Personal_id = registerModel.txt_CardID,
                Birthday = DateTime.Parse(registerModel.txt_BirthDate),
                Mobilephone = registerModel.txt_MobileNo
            };

            return new ObjectResult(data); 
        }
        
    }
}
