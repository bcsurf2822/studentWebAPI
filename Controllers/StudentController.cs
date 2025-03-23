using CollegeApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace firstAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StudentData : ControllerBase
  {


    // GET: all of the students
    [HttpGet]
    [Route("All", Name = "GetAllStudents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<IEnumerable<StudentDTO>> GetStudents()
    {
      // var students = new List<StudentDTO>();
      // foreach (var item in CollegeRepository.Students)
      // {
      //   StudentDTO obj = new StudentDTO()
      //   {
      //     Id = item.Id,
      //     StudentName = item.StudentName,
      //     Address = item.Address,
      //     Email = item.Email
      //   };
      //   students.Add(obj);
      // }
      var students = CollegeRepository.Students.Select(s => new StudentDTO() //Converting students into the new DTO object LINQ
      {
        Id = s.Id,
        StudentName = s.StudentName,
        Address = s.Address,
        Email = s.Email
      });
      return Ok(students);
    }



    // GET: student by ID
    [HttpGet("getStudent/{id:int}", Name = "GetStudentByID")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Documented Response Type
    public ActionResult<StudentDTO> GetStudentById(int id)
    {
      var student = CollegeRepository.Students.FirstOrDefault(n => n.Id == id);
      //400 Bad Quest = Client Error
      if (id <= 0)
        return BadRequest();

      if (student == null)
      {
        return NotFound($"Student with {id} not found"); // returns 404 if student is not found
      }
      var studentDTO = new StudentDTO
      {
        Id = student.Id,
        StudentName = student.StudentName,
        Email = student.Email,
        Address = student.Address
      };
      return Ok(studentDTO); // returns 200 with the student data
    }


    //Get student by string name (NOTICE SAME /getStudent need :dataType) "contraints
    [HttpGet("getStudent/{name:alpha}", Name = "GetStudentByName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<StudentDTO> GetStudentByName(string name)
    {

      if (string.IsNullOrEmpty(name))
        return BadRequest();

      var student = CollegeRepository.Students.FirstOrDefault(n => n.StudentName == name);

      if (student == null)
      {
        return NotFound($"Student with the name {name} not found");
      }
      var studentDTO = new StudentDTO
      {
        Id = student.Id,
        StudentName = student.StudentName,
        Email = student.Email,
        Address = student.Address
      };
      return Ok(studentDTO);
      // returns 200 with the student data
    }



    //Create Student POST
    [HttpPost]
    [Route("Create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<StudentDTO> CreateStudent([FromBody] StudentDTO model)
    {
      if (model == null)
        return BadRequest();

      int newId = CollegeRepository.Students.LastOrDefault().Id + 1;
      Student student = new Student
      {
        Id = model.Id,
        StudentName = model.StudentName,
        Address = model.Address,
        Email = model.Email,
      };
      CollegeRepository.Students.Add(student);

      model.Id = student.Id;

      return Ok(model);

    }

    //Delete student by ID
    [HttpDelete("deleteStudentByID/{id:int}", Name = "DeleteStudentByID")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<bool> DeleteStudent(int id)
    {

      if (id <= 0)
        return BadRequest();

      var student = CollegeRepository.Students.FirstOrDefault(n => n.Id == id);

      if (student == null)
      {
        return NotFound($"Student with {id} not found!"); // 404 if student doesn't exist
      }

      CollegeRepository.Students.Remove(student); // correct lowercase variable

      return Ok(true); // 200 Success
    }
  }
}