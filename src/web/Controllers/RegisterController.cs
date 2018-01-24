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
        public IActionResult Confirmation(RegisterModel registerModel)
        {
            ViewData["RegisterModel"] = new RegisterModel() {
                txt_CardID = registerModel.txt_CardID,
                txt_CardNo = registerModel.txt_CardNo,
                txt_BirthDate = registerModel.txt_BirthDate,
                txt_MobileNo = registerModel.txt_MobileNo
            };
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SaveData(RegisterModel registerModel)
        {
            var memberService = new MemberService();
            memberService.Register(registerModel);

            return RedirectToAction("Complete");
        }

        public IActionResult Complete()
        {
            return View();
        }

    }
}
