using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Demo.ViewModels;
using Microsoft.EntityFrameworkCore;
using Demo.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Demo.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        //DIP
        IStudentRepository studentRepository;//Tigh Couple ==>lossly couple
        IDepartmentRepository departmentRepository;
        //DI
        public StudentController(IStudentRepository _stdRepo,IDepartmentRepository _Deptrepo)
        {
            studentRepository = _stdRepo;//new StudentMockREspotory();
            departmentRepository = _Deptrepo;//new DepartmentRepository();
        }
        
        public IActionResult TestService()
        {
            ViewBag.servicesID = studentRepository.id;
            return View();
        }


        [Route("ITI/{age}/{name}")]
        public IActionResult TestRoute(string name,int age)
        {
            return Content($"Ok {name} {age}");
        }

        public IActionResult TestAjax()
        {
            List<Student> students = studentRepository.GetAll();//context.Students.ToList();
            return View(students);//View="TestAjax" ,Model =List<studebt>
        }

        public IActionResult Testpartial(int id)
        {
            Student std = studentRepository.GetById(id);//context.Students.FirstOrDefault(s => s.Id == id);
            return PartialView("_StudentCard",std);
        }


        //Remot Attribute using Ajax Call  
        public IActionResult CheckName(string Name,string Address)
        {
            if (Name.Contains("ITI"))
                return Json(true);
            return Json(false);
        }

        [HttpGet] //anchor ,form mthod get
        public IActionResult Action1()
        {
            return Content("Action1 Get");
        }
        
        [HttpPost]//<form method="post">
        public IActionResult Action1(int id, string name)
        {
            return Content("Action1 post");
        }


        //ITIEntity context = new ITIEntity();
        public IActionResult New()
        {
            ViewData["DeptList"] = departmentRepository.GetAll();//context.Departments.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//intenal calling only "FRom the same domain
        public IActionResult New(Student newStd)
        {
           // if (newStd.Name != null)
           if(ModelState.IsValid==true)
            {
                //Custom Valuation dept_Id!=0
                if (newStd.Dept_Id != 0)
                {
                    try
                    {
                        //save
                        studentRepository.Insert(newStd);
                        return RedirectToAction("Index");
                    }catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }
                else
                {
                    //error message send view 
                    ModelState.AddModelError("", "Select Department");//div
                }
            }
            ViewData["DeptList"] = departmentRepository.GetAll();//context.Departments.ToList();
                //return View("New",newStd);
                return View(newStd);
           
        }
        public IActionResult DElete(int id)
        {
            Student std = studentRepository.GetById(id); //context.Students.FirstOrDefault(s => s.Id == id);
            return View(std);

        }

        public IActionResult ConfirmDelete(int id)
        {
            studentRepository.Delete(id);
            return RedirectToAction("Index");
        }

        //student/details/id
        public IActionResult Details(int id)
        {
            Student std = studentRepository.GetById(id);//context.Students.FirstOrDefault(s => s.Id == id);
            return View(std);
        }
        public IActionResult GetStudent()
        {
            List<string> branches = new List<string>();
            branches.Add("Alex");
            branches.Add("Assiut");
            branches.Add("Smart");
            branches.Add("Menia");

            ViewData["brc"] = branches;
            // ViewData["temp"] = 44;
            ViewBag.temp = 44;
            
            ViewBag.color = "red";

            ViewData["temp"] = 55;
            ViewData["msg"] = "Hello FRom Action";


            Student stdModel = studentRepository.GetById(1);// context.Students.FirstOrDefault();
            return View(stdModel);//view="GetStudent" Model ="student"
        }

        public IActionResult Edit(int id)
        {
            Student student = studentRepository.GetById(id);//context.Students.FirstOrDefault(s=>s.Id == id);//Model
            ViewData["DeptList"] = departmentRepository.GetAll();//context.Departments.ToList();
            return View(student);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id,Student newStd) 
        {
            
           // if (newStd.Name!=null&& newStd.Age > 10 )
           if(ModelState.IsValid==true)
            {
                //get old object
                studentRepository.Edit(id, newStd);                
                return RedirectToAction("Index");
                //save
            }
            //model 
            ViewData["DeptList"] = departmentRepository.GetAll();// context.Departments.ToList();

            return View("Edit", newStd);
        }
        
        [Authorize]
        public IActionResult Index()
        {
            string name= User.Identity.Name;
            
            string id= 
                User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return View(studentRepository.GetAllStudentsWithDepartmentData());
        }
        public IActionResult GetStudentUsingViewModel(int id,string Salary)
        {
            //get Model
            Student stdModel = studentRepository.GetById(id);//context.Students.FirstOrDefault(s=>s.Id==id);

            List<string> branches = new List<string>();
            branches.Add("Alex");
            branches.Add("Assiut");
            branches.Add("Smart");
            branches.Add("Menia");

            StudentBranchesTempMSgViewModel stdViewModel = 
                new StudentBranchesTempMSgViewModel();
            stdViewModel.StdName = stdModel.Name;
            stdViewModel.StdId = stdModel.Id;
            stdViewModel.Msg = "Hello";
            stdViewModel.Color = "blue";
            stdViewModel.Temp = 20;
            stdViewModel.Branches = branches;

            return View(stdViewModel);

        }
    }
}
