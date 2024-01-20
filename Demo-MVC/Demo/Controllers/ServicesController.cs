using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class ServicesController : Controller
    {
        IWebHostEnvironment webHostEnvironment;

        public ServicesController(IWebHostEnvironment webHostEnvironment)//injection controller
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult uploadImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult uploadImage(IFormFile Image)
        {
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Image.CopyTo(fileStream);
                fileStream.Close();
            }

            return View();
        }
    }
}
