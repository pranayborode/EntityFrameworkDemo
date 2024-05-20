using EntityFrameworkDemo.Data;

namespace EntityFrameworkDemo.Models
{
    public class StudnetDAL
    {
        private ApplicationDbContext db;

        public StudnetDAL(ApplicationDbContext db)
        {
            this.db = db;
        }


        public List<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        public Student GetStudentById(int id) 
        {
            var model = db.Students.Where(x => x.Id == id).SingleOrDefault();
            return model;
        }

        public int AddStudent(Student student)
        {
            int result = 0;
            db.Students.Add(student);
            result = db.SaveChanges();
            return result;
        }

        public int EditStudent(Student std)
        {
            int result = 0;
            var model = db.Students.Where(x => x.Id == std.Id).SingleOrDefault();
            if(model != null)
            {
                model.Name = std.Name;
                model.Phone = std.Phone;
                model.Email = std.Email;
                model.Address = std.Address;
                result = db.SaveChanges();
            }
            return result;
        }

        public int DeleteStudent(int id)
        {
            int result = 0;
            var model = db.Students.Where(x => x.Id == id).SingleOrDefault();
            if (model != null)
            {
                // remove from dbSet
                db.Students.Remove(model);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
