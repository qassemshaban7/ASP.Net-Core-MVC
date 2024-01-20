using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class BindingController : Controller
    {
        //binding/BindPremitive?name=ahmed&age=22&id=1&degrees=100&degrees=50
        //binding/BindPremitive/1?name=ahmed&age=22

        public IActionResult BindPremitive(int age,string name,int id,int []degrees)
        {
            return Content("OK");
        }
        //Bind Collection
        //binding/BindCollection?name=alaa&phones[ahmed]=1234&phones[asmaa]=7890
        public IActionResult BindCollection(string name,Dictionary<string,int> phones)
        {
            
            return Content("Ok");
        }

        //Bind Complex/Custom Type 
        public IActionResult BindComplex(string name,Department Dept)//id,name.managername
        {
            return Content("ok");
        }
    }
}
