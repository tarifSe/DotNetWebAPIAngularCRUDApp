using StudentAPICRUD.Models.Models;
using StudentAPICRUD.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAPICRUD.BLL.BLL
{
    public interface IStudentManager
    {
        bool Add(Student student);
        bool Update(Student student);
        bool Delete(int id);
        List<Student> GetAll();
        Student GetById(int id);
    }

    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepository _studentRepository;
        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public bool Add(Student student)
        {
            return _studentRepository.Add(student);
        }

        public bool Update(Student student)
        {
            return _studentRepository.Update(student);
        }

        public bool Delete(int id)
        {
            return _studentRepository.Delete(id);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }
    }
}
