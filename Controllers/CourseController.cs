using CRUD_Operations.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operations.Models
{
    public class CourseController : Controller
    {
        ICourseRepo courseRepo;

        public CourseController(ICourseRepo _courseRepo)
        {
            courseRepo = _courseRepo;
        }

        public IActionResult Index()
        {
            var courses = courseRepo.GetAll();
            return View(courses);
        }

        public IActionResult Details(int id)
        {
            var course = courseRepo.GetById(id);
            if (course == null)
                return NotFound();
            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                courseRepo.Add(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public IActionResult Edit(int id)
        {
            var course = courseRepo.GetById(id);
            if (course == null)
                return NotFound();
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                courseRepo.Update(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = courseRepo.GetById(id);
            if (course == null)
                return NotFound();
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            courseRepo.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
