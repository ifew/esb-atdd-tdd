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
    public class UtilityController : Controller
    {
        private readonly UtilityService _service;

        public UtilityController(UtilityService service)
        {
            _service = service;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json("Hi this MemberService");
        }

        [HttpGet("list_zipcode")]
        public IEnumerable<Zipcode> ListZipcode()
        {
            return _service.ListZipcode();
        }

        [HttpGet("list_zipcode_province/{id}")]
        public IEnumerable<Zipcode> ListZipcodeProvince(string id)
        {
            return _service.ListZipcode_by_Province_Code(id);
        }

        
    }
}
