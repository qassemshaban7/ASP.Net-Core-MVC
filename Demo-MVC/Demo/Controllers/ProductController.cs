using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class ProductController : Controller
    {
        //1/Public
        //2/cant static 
        //3/cant be overload action
        public IActionResult ShowProduct()
        {
            Product product = new Product() {
                Id = 1,
            NAme="Iphone",
            Image="1.jpg",
            PRice=4000
            };
            return View("Show",product);//view="Show",Model=product
        }
        //product/ShowProduct Action
        //public ContentResult ShowProduct()
        //{
        //    //declare
        //    ContentResult result = new ContentResult();
        //    //set value
        //    result.Content = "My First Action";
        //   //returen
        //    return result;
        //}

        //public ViewResult getView()
        //{
        //    //DEclate
        //    ViewResult result = new ViewResult();
        //    //set
        //    result.ViewName = "View1";
        //    //return
        //    return result;
        //}
        //public JsonResult getJson()
        //{
        //    //DEclate
        //    //JsonResult result = new JsonResult(new {ID=1,Name="Ahmed" });

        //    //return
        //    return Json(new { ID = 1, Name = "Ahmed" });
        //}


        public IActionResult get(int id)
        {
            if (id % 2 == 0)
            {
                return Content("Hiiii");
            }
            else
            {
                return View("View1");
            }
        }

        //Content string ==>ContentREsukt
        //View HTML      ==>ViewReuslt
        //redirect another web app ==>REdirectREsult
        //json           ==>JsonREsult
        //File           ==>FileREsult
        //JAvascript     ==>JAvascriptREsult
    }
}
