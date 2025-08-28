using CRUD_Operations.Data;
using CRUD_Operations.Models;


namespace CRUD_Operations.Reposatory
{
    public interface ICourseRepo
    {
        public List<Course> GetAll();
        public Course GetById(int id);
        public void Add(Course course);
        public void Update(Course course);
        public void DeleteById(int id);
    }
    public class CourseRepo : ICourseRepo
    {
        private readonly ITIContext db;

        public CourseRepo(ITIContext _db)
        {
            db = _db;
        }

        public void Add(Course course)
        {
            db.Add(course);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var course = db.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course != null)
            {
                db.Remove(course);
                db.SaveChanges();
            }
        }

        public List<Course> GetAll()
        {
            return db.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return db.Courses.FirstOrDefault(c => c.CourseId == id);
        }

        public void Update(Course course)
        {
            var existingCourse = db.Courses.FirstOrDefault(c => c.CourseId == course.CourseId);
            if (existingCourse != null)
            {
                existingCourse.CourseName = course.CourseName;
                existingCourse.DurationInHours = course.DurationInHours;
                db.SaveChanges();
            }
        }
    }
}
