using CollegeApp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace firstAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Produces("application/json", "application/xml")]

  public class StudentData : ControllerBase
  {
    private readonly ILogger<StudentData> _logger;
    public StudentData(ILogger<StudentData> logger)
    {
      _logger = logger;
    }


    // GET: all of the students
    [HttpGet]
    [Route("All", Name = "GetAllStudents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<IEnumerable<StudentDTO>> GetStudents()
    {
      _logger.LogInformation("GetStudents Started Execute");
      var students = CollegeRepository.Students.Select(s => new StudentDTO() //Converting students into the new DTO object var students = CollegeRepository.Students.Select(s => new StudentDTO
      {
        Id = s.Id,
        StudentName = s.StudentName,
        Address = s.Address,
        Email = s.Email
      }).ToList();

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
      {
        _logger.LogWarning("Bad Request");
        return BadRequest();
      }

      if (student == null)
      {
        _logger.LogError("Student not found with that ID");
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



    // POST  Create Student
    [HttpPost]
    [Route("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<StudentDTO> CreateStudent([FromBody] StudentDTO model)
    {
      // if (!ModelState.IsValid)
      //   return BadRequest(ModelState); //Manual Validation Otherwise the [ApiController picks it up]
      if (model == null)
        return BadRequest();

      // if (model.AdmissionDate < DateTime.Now)
      // {
      //   // Add error message to ModelState
      //   //Using Custom attribute
      //   ModelState.AddModelError("Admission Date Error", "Admission date must be greater than or equal to todays date");
      //   return BadRequest(ModelState);
      // }

      int newId = CollegeRepository.Students.LastOrDefault().Id + 1;
      Student student = new Student
      {
        Id = newId,
        StudentName = model.StudentName,
        Address = model.Address,
        Email = model.Email,
      };
      CollegeRepository.Students.Add(student);

      model.Id = student.Id;
      return CreatedAtRoute("GetStudentByID", new { id = model.Id }, model); //201 & new URL as /Student/{newID}
    }


    //PUT
    [HttpPut]
    [Route("Update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<StudentDTO> UpdateStudent([FromBody] StudentDTO model)
    {
      if (model == null || model.Id <= 0)
        BadRequest();

      var existingStudent = CollegeRepository.Students.Where(s => s.Id == model.Id).FirstOrDefault();

      if (existingStudent == null)
        return NotFound();

      existingStudent.StudentName = model.StudentName;
      existingStudent.Email = model.Email;
      existingStudent.Address = model.Address;

      return NoContent();
    }


    //PATCH
    [HttpPatch]
    [Route("{id:int}/UpdatePartial")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<StudentDTO> UpdateStudentPartial(int id, [FromBody] JsonPatchDocument<StudentDTO> patchDocumentl)
    {
      if (patchDocumentl == null || id <= 0)
        BadRequest();

      var existingStudent = CollegeRepository.Students.Where(s => s.Id == id).FirstOrDefault();

      if (existingStudent == null)
        return NotFound();

      var studentDTO = new StudentDTO
      {
        Id = existingStudent.Id,
        StudentName = existingStudent.StudentName,
        Email = existingStudent.Email,
        Address = existingStudent.Address,
      };

      patchDocumentl.ApplyTo(studentDTO, ModelState);

      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      existingStudent.StudentName = studentDTO.StudentName;
      existingStudent.Email = studentDTO.Email;
      existingStudent.Address = studentDTO.Address;

      return NoContent(); //204
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