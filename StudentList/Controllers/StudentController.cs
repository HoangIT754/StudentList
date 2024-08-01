using Microsoft.AspNetCore.Mvc;
using StudentPracticeApp.Models;

namespace StudentPracticeApp.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John Doe", Age = 20 },
            new Student { Id = 2, Name = "Jane Smith", Age = 22 }
        };

        private static int currentId = 2;

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            student.Id = ++currentId;
            students.Add(student);
            return RedirectToAction("Index");
        }
    }
}


//After improve

//using Microsoft.AspNetCore.Mvc;
//using StudentPracticeApp.Models;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace StudentPracticeApp.Controllers
//{
//    public class StudentController : Controller
//    {
//        private static List<Student> students = new List<Student>
//        {
//            new Student { Id = 1, Name = "John Doe", Age = 20 },
//            new Student { Id = 2, Name = "Jane Smith", Age = 22 }
//        };

//        private static int currentId = 2;

//        public async Task<IActionResult> Index()
//        {
//            var studentList = await Task.Run(() => students.ToList());
//            return View(studentList);
//        }

//        public async Task<IActionResult> Details(int id)
//        {
//            try
//            {
//                var student = await Task.Run(() => students.FirstOrDefault(s => s.Id == id));
//                if (student == null)
//                {
//                    return NotFound();
//                }
//                return View(student);
//            }
//            catch
//            {
//                return View("Error");
//            }
//        }

//        [HttpGet]
//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(Student student)
//        {
//            try
//            {
//                student.Id = await Task.Run(() => ++currentId);
//                await Task.Run(() => students.Add(student));
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View("Error");
//            }
//        }
//    }
//}
