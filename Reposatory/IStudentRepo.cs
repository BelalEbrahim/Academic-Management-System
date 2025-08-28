using CRUD_Operations.Data;
using CRUD_Operations.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operations.Reposatory
{
    public interface IStudentRepo
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public void Added(Student Student);
        public void Update(Student Student);
        public void DeleteById(int id);
    }

    public class StudentRepo : IStudentRepo
    {
        ITIContext db;// new ITIContext();
        public StudentRepo(ITIContext _db)
        {
            db = _db;
        }

        public void Added(Student student)
        {
            db.Add(student);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var student = db.Students.FirstOrDefault(a => a.Id == id);
            if (student != null)
            {
                // Soft delete: set status to false
                student.status = false;
                db.SaveChanges();
            }
        }

        public List<Student> GetAll()
        {
            // Only retrieve students with status = true (not deleted)
            return db.Students.Include(s => s.Department).Where(a => a.status == true).ToList();
        }

        public Student GetById(int id)
        {
            return db.Students.SingleOrDefault(s => s.Id == id && s.status == true);
        }

        public void Update(Student student)
        {
            var existingStudent = db.Students.FirstOrDefault(s => s.Id == student.Id);

            if (existingStudent != null)
            {
                // Update fields
                existingStudent.Name = student.Name;
                existingStudent.Email = student.Email;
                existingStudent.DeptNo = student.DeptNo;
                existingStudent.status = student.status;

                db.SaveChanges();
            }
        }
    }
}