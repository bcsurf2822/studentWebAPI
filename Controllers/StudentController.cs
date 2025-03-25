using System.Threading.Tasks;
using AutoMapper;
using CollegeApp.Data;
using CollegeApp.Data.Repository;
using CollegeApp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace firstAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Produces("application/json", "application/xml")]

  public class StudentController : ControllerBase
  {
    private readonly ILogger<StudentController> _logger;
    private readonly CollegeDBContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IStudentRepository _studentRepository;
    public StudentController(ILogger<StudentController> logger, CollegeDBContext dbContext, IMapper mapper, IStudentRepository studentRepository)
    {
      _logger = logger;
      _dbContext = dbContext;
      _mapper = mapper;
      _studentRepository = studentRepository;
    }


    // GET: all of the students
    [HttpGet("All", Name = "GetAllStudents")]
    public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
    {
      _logger.LogInformation("GetStudents Started Execute");

      var students = await _studentRepository.GetAllAsync();
      var studentDTOs = _mapper.Map<List<StudentDTO>>(students);

      return Ok(studentDTOs);
    }


    // GET: student by ID
    [HttpGet("getStudent/{id:int}", Name = "GetStudentByID")]
    public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
    {
      if (id <= 0)
      {
        _logger.LogWarning("Bad Request");
        return BadRequest();
      }

      var student = await _studentRepository.GetByIdAsync(id);

      if (student == null)
      {
        _logger.LogError("Student not found with that ID");
        return NotFound($"Student with ID {id} not found");
      }

      var studentDTO = _mapper.Map<StudentDTO>(student);
      return Ok(studentDTO);
    }



    [HttpGet("getStudent/{name:alpha}", Name = "GetStudentByName")]
    public async Task<ActionResult<StudentDTO>> GetStudentByName(string name)
    {
      if (string.IsNullOrEmpty(name))
        return BadRequest();

      var student = await _studentRepository.GetByNameAsync(name);

      if (student == null)
        return NotFound($"Student with name {name} not found");

      var studentDTO = _mapper.Map<StudentDTO>(student);
      return Ok(studentDTO);
    }


    // POST  Create Student
    [HttpPost("Create")]
    public async Task<ActionResult<StudentDTO>> CreateStudent([FromBody] StudentDTO dto)
    {
      if (dto == null)
        return BadRequest();

      var student = _mapper.Map<Student>(dto);
      var newId = await _studentRepository.CreateAsync(student);
      dto.Id = newId;

      return CreatedAtRoute("GetStudentByID", new { id = newId }, dto);
    }

    //PUT
    [HttpPut("Update")]
    public async Task<ActionResult<StudentDTO>> UpdateStudent([FromBody] StudentDTO dto)
    {
      if (dto == null || dto.Id <= 0)
        return BadRequest();

      var student = _mapper.Map<Student>(dto);

      try
      {
        await _studentRepository.UpdateAsync(student);
        return NoContent();
      }
      catch (ArgumentNullException ex)
      {
        return NotFound(ex.Message);
      }
    }


    //PATCH
    [HttpPatch("{id:int}/UpdatePartial")]
    public async Task<ActionResult> UpdateStudentPartial(int id, [FromBody] JsonPatchDocument<StudentDTO> patchDocument)
    {
      if (patchDocument == null || id <= 0)
        return BadRequest();

      var existingStudent = await _studentRepository.GetByIdAsync(id);
      if (existingStudent == null)
        return NotFound();

      var studentDTO = _mapper.Map<StudentDTO>(existingStudent);
      patchDocument.ApplyTo(studentDTO, ModelState);

      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      TryValidateModel(studentDTO);
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var updatedEntity = _mapper.Map<Student>(studentDTO);
      updatedEntity.Id = id;

      await _studentRepository.UpdateAsync(updatedEntity);
      return NoContent();
    }

    //DELETE student by ID

    [HttpDelete("deleteStudentByID/{id:int}", Name = "DeleteStudentByID")]
    public async Task<ActionResult<bool>> DeleteStudent(int id)
    {
      if (id <= 0)
        return BadRequest();

      var success = await _studentRepository.DeleteAsync(id);

      if (!success)
        return NotFound($"Student with ID {id} not found");

      return Ok(true);
    }
  }
}