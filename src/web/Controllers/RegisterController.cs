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
            memberService.Register(member);

            return RedirectToAction("Complete");
        }

        public IActionResult Complete()
        {
            return View();
        }

    }
}
