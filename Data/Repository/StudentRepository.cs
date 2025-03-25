using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data.Repository
{
  public class StudentRepository : IStudentRepository
  {
    private readonly CollegeDBContext _dbContext;
    public StudentRepository(CollegeDBContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<List<Student>> GetAllAsync()
    {
      return await _dbContext.Students.ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
      return await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Student?> GetByNameAsync(string name)
    {
      return await _dbContext.Students
          .FirstOrDefaultAsync(s => s.StudentName.ToLower() == name.ToLower());
    }

    public async Task<int> CreateAsync(Student student)
    {
      await _dbContext.Students.AddAsync(student);
      await _dbContext.SaveChangesAsync();
      return student.Id;
    }

    public async Task<int> UpdateAsync(Student student)
    {
      var studentToUpdate = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == student.Id);
      if (studentToUpdate == null)
      {
        throw new ArgumentNullException($"No Student Found with ID: {student.Id}");
      }

      studentToUpdate.StudentName = student.StudentName;
      studentToUpdate.Email = student.Email;
      studentToUpdate.Address = student.Address;
      studentToUpdate.DOB = student.DOB;

      await _dbContext.SaveChangesAsync();
      return student.Id;
    }

    public async Task<bool> DeleteAsync(int id)
    {
      var studentToDelete = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
      if (studentToDelete == null)
      {
        return false;
      }

      _dbContext.Students.Remove(studentToDelete);
      await _dbContext.SaveChangesAsync();
      return true;
    }
  }
}