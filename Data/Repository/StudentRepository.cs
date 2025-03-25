using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data.Repository
{
  public class StudentRepository : IStudentRepository
  {
    private readonly CollegeDBContext _dbContext;
    public StudentRepository(CollegeDBContext dBContext)
    {
      _dbContext = dBContext;
    }

    public async Task<List<Student>> GetAll()
    {
      return await _dbContext.Students.ToListAsync();
    }

    public async Task<Student> GetByIdAsync(int id)
    {
      return await _dbContext.Students.Where(s => s.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Student> GetByNameAsync(string name)
    {
      return await _dbContext.Students
          .Where(s => s.StudentName.ToLower().Equals(name.ToLower()))
          .FirstOrDefaultAsync();
    }

    public async Task<int> Create(Student student)
    {
      await _dbContext.Students.AddAsync(student);
      await _dbContext.SaveChangesAsync();
      return student.Id;
    }

    public async Task<int> Update(Student student)
    {
      var studentToUpdate = await _dbContext.Students.Where(student => student.Id == student.Id).FirstOrDefaultAsync();
      if (studentToUpdate == null)
      {
        throw new ArgumentNullException($"No Student Found with ID: {student.Id}");
      }
      ;
      studentToUpdate.StudentName = student.StudentName;
      studentToUpdate.Email = student.Email;
      studentToUpdate.Address = student.Address;
      studentToUpdate.DOB = student.DOB;

      await _dbContext.SaveChangesAsync();
      return student.Id;
    }

    public async Task<bool> DeleteAsync(int id)
    {
      var studentToDelete = await _dbContext.Students.Where(student => student.Id == student.Id).FirstOrDefaultAsync();
      if (studentToDelete == null)
      {
        throw new ArgumentNullException($"No Student Found with ID: {studentToDelete.Id}");
      }
      ;

      _dbContext.Students.Remove(studentToDelete);
      await _dbContext.SaveChangesAsync();
      return true;
    }
  }
}