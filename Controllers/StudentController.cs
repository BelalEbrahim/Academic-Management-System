using CRUD_Operations.Data;
using CRUD_Operations.Models;
using CRUD_Operations.Reposatory;
using CRUD_Operations.veiwModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operations.Controllers
{
    

    public class StudentController : Controller
    {
        //ITIContext db = new ITIContext();
        IStudentRepo studentRepo;// new StudentRepo();
        IDepartmentRepo departmentRepo; // new DepartmentRepo();
        public StudentController(IDepartmentRepo _departmentRepo,IStudentRepo _studentRepo )
        {
            departmentRepo = _departmentRepo;
            studentRepo = _studentRepo;


        }



        public IActionResult Create()
        {
            //list
            ViewBag.depts = departmentRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student st)
        {
            
            if (ModelState.IsValid)
            {
                studentRepo.Added(st);
                return RedirectToAction("Index");
            }
            else {
                ViewBag.depts = departmentRepo.GetAll();
                return View();
            
            }
            
        }


        public IActionResult Details(int id)
        {
            var student = studentRepo.GetById(id);
            if (student == null)
            {
                return NotFound("Student not found");
            }

            var department = departmentRepo.GetById(student.DeptNo);

            var viewModel = new DetailsVeiwModel
            {
                Student = student,
                Department = department
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = studentRepo.GetById(id);
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = studentRepo.GetById(id);
            studentRepo.DeleteById(id);

            return RedirectToAction("Index");
            //db.Students.Remove(student);
            //db.SaveChanges();
        }


        public IActionResult Edit(int id)
        {
            var student = studentRepo.GetById(id);
            if (student == null)
            {
                return NotFound("Student not found");
            }

            var department = departmentRepo.GetById(student.DeptNo);

            var viewModel = new DetailsVeiwModel
            {
                Student = student,
                Department = department
            };

            // Populate ViewBag.Departments with the list of all departments
            ViewBag.Departments = departmentRepo.GetAll();

            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult Edit(DetailsVeiwModel model)
        {
            var student = studentRepo.GetById(model.Student.Id);
            if (student == null)
            {
                return NotFound("Student not found");
            }

            student.Name = model.Student.Name;
            student.Age = model.Student.Age;
            student.DeptNo = model.Student.DeptNo;

            studentRepo.Update(model.Student);
            departmentRepo.Update(model.Department);

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var students = studentRepo.GetAll();
            return View(students);
        }
        // Remote validation action
        public IActionResult VerifyEmail(string email)
        {
            var isEmailExists = studentRepo.GetAll().Any(s => s.Email == email);


            if (isEmailExists)
            {
                return Json($"The email {email} is already in use.");
            }

            return Json(true); // Return true if the email is not taken
        }








    }
}
