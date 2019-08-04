using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using NetCoreRESTTemplate.Models;
using NetCoreRESTTemplate.Repository;

namespace NetCoreRESTTemplate.Controllers
{
    [Route("api/[controller]")] // starts header for it
    [ApiController]
    public class StudentController : Controller
    {
        // GET
        private readonly StudentRepository _repository;

        public StudentController(StudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            return Ok(_repository.GetAllStudent());
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(string id)
        {
            var x = _repository.GetStudent(Guid.Parse(id));
            if (x == null)
            {
                return NotFound();
            }

            return Ok(x);

        }
        [HttpPost]
        public ActionResult<Student> Post([FromBody] StudentRequest studentRequest)
        {
            var member = _repository.AddStudent(studentRequest);
            return Created(Request.Path.Value, member);
        }
        
        [HttpPut("{id}")]
        public ActionResult<Student> Put(Guid id, [FromBody] StudentRequest studentRequest)
        {
            return Ok(_repository.UpdateStudent(new Student(id, studentRequest.Name, studentRequest.Age)));
        }

        /// <summary>
        /// Deletes a specific member.
        /// </summary>
        /// <param name="id"></param>  
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _repository.DeleteStudent(id);
            return NoContent();
        }
    }
}