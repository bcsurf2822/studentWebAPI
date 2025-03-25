using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data.Repository
{
  public class StudentRepository : CollegeRepository<Student>, IStudentRepository//College Repo For student table
  {
    private readonly CollegeDBContext _dbContext;
    public StudentRepository(CollegeDBContext dbContext) : base(dbContext) //pass param to base class
    {
      _dbContext = dbContext;
    }

    public Task<List<Student>> GetStudentByFeeStatusAsync(int feeStatus)
    {
      //Code to return
      return null;
    }

    //can write student specific methods here
  }
}