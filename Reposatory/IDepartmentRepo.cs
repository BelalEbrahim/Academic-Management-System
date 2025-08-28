using CRUD_Operations.Data;
using CRUD_Operations.Models;

namespace CRUD_Operations.Reposatory
{
    public interface IDepartmentRepo
    {
        public List<Department> GetAll ();
        public Department GetById (int id);
        public void Added (Department department);
        public void Update (Department department);
        public void DeleteById(int id);

    }

    public class DepartmentRepo : IDepartmentRepo
    {

        ITIContext db; // new ITIContext();
        public DepartmentRepo(ITIContext _db)
        {
            db = _db;
        }

        public void Added(Department department)
        {
            db.Add(department);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var department = db.Departments.FirstOrDefault(a => a.DeptId == id);
            if (department != null)
            {
                // Soft delete
                department.status = false;
                db.SaveChanges();
            }
        }

        public List<Department> GetAll()
        {
            // Only retrieve departments with status = true (not deleted)
            return db.Departments.Where(a => a.status == true).ToList();
        }

        public Department GetById(int id)
        {
            return db.Departments.FirstOrDefault(a => a.DeptId == id && a.status == true);
        }

        public void Update(Department department)
        {
            var existingDepartment = db.Departments.FirstOrDefault(a => a.DeptId == department.DeptId);

            if (existingDepartment != null)
            {
                // Update fields
                existingDepartment.DeptName = department.DeptName;
                existingDepartment.Capacity = department.Capacity;
                existingDepartment.status = department.status;

                db.SaveChanges();
            }
        }
    }

    public class DepartmentRepo2 : IDepartmentRepo
    {
        static List<Department> db = new List<Department>()
        { 
            new Department(){DeptName = "kkkk",Capacity=3 ,status=true,DeptId=90}

        };
        public void Added(Department department)
        {
            db.Add(department); 
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            return db;
        }

        public Department GetById(int id)
        {
            return db.FirstOrDefault(a => a.DeptId == id);
        }

        public void Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
