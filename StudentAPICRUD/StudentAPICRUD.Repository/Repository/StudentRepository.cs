using StudentAPICRUD.DatabaseContext.DatabaseContext;
using StudentAPICRUD.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentAPICRUD.Repository.Repository
{
    public interface IStudentRepository
    {
        bool Add(Student student);
        bool Update(Student student);
        bool Delete(int id);
        List<Student> GetAll();
        Student GetById(int id);
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;
        public StudentRepository(StudentDbContext studentDbContext)
        {
            _context = studentDbContext;
        }

        public bool Add(Student student)
        {
            _context.Add(student); 
           
            return _context.SaveChanges() > 0;
        }

        public bool Update(Student student)
        {
            _context.Update(student);

            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var aStudent = _context.Students.FirstOrDefault(s => s.Id == id);
            _context.Remove(aStudent);

            return _context.SaveChanges() > 0;
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            var aStudent = _context.Students.FirstOrDefault(s => s.Id == id);
            return aStudent;
        }
    }
}
