using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class PassDataController : Controller
    {
        public IActionResult SetCookie()
        {
            string name = "ahmed";
            int age = 23;
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTimeOffset.Now.AddDays(1);

            Response.Cookies.Append("StudentName", name, cookieOptions);//presistent cookie
            Response.Cookies.Append("age", age.ToString());//session cookie
            return Content("Cookie Save");
        }

        public IActionResult GetCookie()
        {
            string name = Request.Cookies["StudentName"];
            return Content($"Cookie { name}");
        }


        public IActionResult SetSesstion()
        {
            HttpContext.Session.SetString("Name", "Ahmed");
            HttpContext.Session.SetString("Address", "Assiut");
            HttpContext.Session.SetInt32("age", 22);
            return Content("Session Data SAve");
        }

        public IActionResult GetSession()
        {
            string name=HttpContext.Session.GetString("Name");
            string add= HttpContext.Session.GetString("Address");
            int age = HttpContext.Session.GetInt32("age").Value;

            return Content($"GEt data from session{name},{add},{age}");
        }


        public IActionResult First()
        {
            TempData["Msg"] = "Hello From TempData";
            return Content("TempData Saved");
        
        }

        public IActionResult Second()
        {
            string message = "Empty";
            
            if (TempData.ContainsKey("Msg") == true)
            {
                message = TempData["Msg"].ToString();//normal read
                TempData.Keep("Msg");//keep all;
                //message = TempData.Peek("Msg").ToString();

            }
            return Content($"Second {message}");
        }
        public IActionResult Third()
        {
            string message = TempData["Msg"].ToString();
            return Content($"Third {message}");
        }
    }
}
