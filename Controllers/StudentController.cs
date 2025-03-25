using System.Threading.Tasks;
using AutoMapper;
using CollegeApp.Data;
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
    public StudentController(ILogger<StudentController> logger, CollegeDBContext dbContext, IMapper mapper)
    {
      _logger = logger;
      _dbContext = dbContext;
      _mapper = mapper;
    }


    // GET: all of the students
    [HttpGet]
    [Route("All", Name = "GetAllStudents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
    {
      _logger.LogInformation("GetStudents Started Execute");
      // var students = _dbContext.Students.ToList();//Returns everything

      //DTO: If you want to return only certain data
      var students = await _dbContext.Students.ToListAsync();
      var studentDTOs = _mapper.Map<List<StudentDTO>>(students);


      return Ok(studentDTOs);
    }



    // GET: student by ID
    [HttpGet("getStudent/{id:int}", Name = "GetStudentByID")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Documented Response Type
    public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
    {
      var student = await _dbContext.Students.FirstOrDefaultAsync(n => n.Id == id);

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

      var studentDTO = _mapper.Map<StudentDTO>(student);
      return Ok(studentDTO); // returns 200 with the student data
    }


    //Get student by string name (NOTICE SAME /getStudent need :dataType) "contraints
    [HttpGet("getStudent/{name:alpha}", Name = "GetStudentByName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<StudentDTO>> GetStudentByName(string name)
    {

      if (string.IsNullOrEmpty(name))
        return BadRequest();

      var student = await _dbContext.Students.FirstOrDefaultAsync(n => n.StudentName == name);

      if (student == null)
      {
        return NotFound($"Student with the name {name} not found");
      }

      var studentDTO = _mapper.Map<StudentDTO>(student);
      return Ok(studentDTO);
      // returns 200 with the student data
    }



    // POST  Create Student
    [HttpPost]
    [Route("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<StudentDTO>> CreateStudent([FromBody] StudentDTO dto)
    {

      if (dto == null)
        return BadRequest();

      Student student = _mapper.Map<Student>(dto);

      await _dbContext.Students.AddAsync(student);
      await _dbContext.SaveChangesAsync();

      dto.Id = student.Id;
      return CreatedAtRoute("GetStudentByID", new { id = dto.Id }, dto);
    }


    //PUT
    [HttpPut]
    [Route("Update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<StudentDTO>> UpdateStudent([FromBody] StudentDTO dto)
    {
      if (dto == null || dto.Id <= 0)
        return BadRequest();

      var existingStudent = await _dbContext.Students.AsNoTracking().Where(s => s.Id == dto.Id).FirstOrDefaultAsync(); //Reading Data

      if (existingStudent == null)
        return NotFound();

      var newRecord = _mapper.Map<Student>(dto);

      _dbContext.Students.Update(newRecord);
      _dbContext.SaveChangesAsync();
      return NoContent();
    }


    //PATCH
    [HttpPatch]
    [Route("{id:int}/UpdatePartial")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateStudentPartial(int id, [FromBody] JsonPatchDocument<StudentDTO> patchDocument)
    {
      if (patchDocument == null || id <= 0)
        return BadRequest();

      var existingStudent = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
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

      _dbContext.Students.Update(updatedEntity);
      await _dbContext.SaveChangesAsync();

      return NoContent();
    }

    //DELETE student by ID
    [HttpDelete("deleteStudentByID/{id:int}", Name = "DeleteStudentByID")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> DeleteStudent(int id)
    {

      if (id <= 0)
        return BadRequest();

      var student = await _dbContext.Students.FirstOrDefaultAsync(n => n.Id == id);

      if (student == null)
      {
        return NotFound($"Student with {id} not found!"); // 404 if student doesn't exist
      }

      _dbContext.Students.Remove(student); // correct lowercase variable
      await _dbContext.SaveChangesAsync();
      return Ok(true); // 200 Success
    }
  }
}