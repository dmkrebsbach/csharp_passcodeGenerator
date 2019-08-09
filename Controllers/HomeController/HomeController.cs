using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http; // FOR USE OF SESSIONS
using Microsoft.AspNetCore.Mvc;


namespace RandomPasscode.Controllers
{
    public class Home : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("passcode", 1);
            int? passcode_int = HttpContext.Session.GetInt32("passcode");
            ViewBag.passcode_int = passcode_int;
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[14];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            ViewBag.Example = finalString;
            return View("Index");
        }
    }
}