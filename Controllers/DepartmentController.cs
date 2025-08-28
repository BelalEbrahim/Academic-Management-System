using CRUD_Operations.Data;
using CRUD_Operations.Models;
using CRUD_Operations.Reposatory;
using CRUD_Operations.veiwModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operations.Controllers
{
    public class DepartmentController : Controller
    {

        //ITIContext db = new ITIContext();
        //public IActionResult ShowCreate() { return View(); }

        IDepartmentRepo deptRep;  //new DepartmentRepo();

        public DepartmentController(IDepartmentRepo _deptrepo)
        {
            deptRep = _deptrepo;


        }
        public IActionResult Create() { return View(); }//Action selector

        [HttpPost]
        public IActionResult Create(Department dept)
        {
            //Department dept = new Department() { DeptId = deptid, DeptName = name, Capacity = capacity };
            //db.Departments.Add(dept);
            //db.SaveChanges();
            if (ModelState.IsValid)
            {
                deptRep.Added(dept);
                return RedirectToAction("Index");
            }
            
            return View(dept);
        }

        public IActionResult Details(int? id)
        {

            if (id == null)
                return BadRequest();

            Department dept = deptRep.GetById(id.Value);
            if (dept == null)
                return NotFound();
            return View(dept);
            // Student std = new Student() { Id = 10, Name = "ali", Age = 30 };
            // DetailsVeiwModel model = new DetailsVeiwModel() { Student = std, Department = dept }
            //string str = $"{dept.DeptId}: {dept.DeptName}: {dept.Capacity}";
            //ViewData["x"] = 30;
            //ViewData["y"] = 50;
            //Department dept = db.Departments.SingleOrDefault(a => a.DeptId == deptid);

            // return str;

        }
        
        public IActionResult Edit(int id)
        {
            var dept = deptRep.GetById(id);


            return View(dept);
        }

        
        [HttpPost]
        public IActionResult Edit(Department model)
        {
            
                var dept = deptRep.GetById(model.DeptId);
            dept.DeptName = model.DeptName;
                dept.Capacity = model.Capacity;
                deptRep.Update(model);
                return RedirectToAction("Index"); 
        }



        public IActionResult Delete(int id)
        {
            var dept = deptRep.GetById(id);
            // db.Departments.Remove(dept);
            // db.SaveChanges();
            // return RedirectToAction("Index");
            return View(dept);
        }
        [HttpPost, ActionName("delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            deptRep.DeleteById(id);
             return RedirectToAction("Index");
        }

            
        public IActionResult Index()
        {
            var res = deptRep.GetAll();
            return View (res);

        }
    }
}


