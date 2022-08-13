using Microsoft.AspNetCore.Mvc;
using StudentAPICRUD.BLL.BLL;
using StudentAPICRUD.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManager _studentManager;
        public StudentController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        // GET: api/<StudentController>
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetStudents()
        {
            try
            {
                var students = _studentManager.GetAll();
                if (students == null)
                {
                    return NotFound();
                }
                return Ok(students);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<StudentController>/5
        [HttpGet]
        [Route("[Action]/id")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var student = _studentManager.GetById(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<StudentController>
        [HttpPost]
        [Route("[Action]")]
        public IActionResult Save(Student student)
        {
            try
            {
                var aStudent = _studentManager.Add(student);
                return Ok(student);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            try
            {
                if (id != student.Id)
                {
                    return BadRequest();
                }
                var aStudent = _studentManager.Update(student);
                return Ok(student);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var aStudent = _studentManager.Delete(id);
                return Ok(aStudent);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
