using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.Models;
using web.Services;

namespace web.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Confirmation(Member member)
        {
            ViewData["memberModel"] = member;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SaveData(Member member)
        {
            var memberService = new MemberService();
            Member memberData = memberService.Register(member);
            
            //return Json(memberData);
            return RedirectToAction("Complete", new { id = memberData.Id });
        }

        [HttpGet]
        public IActionResult Complete(string id)
        {
            var memberService = new MemberService();
            ViewData["memberModel"] = memberService.Get_Member_Info(id);

            return View();
        }

    }
}
