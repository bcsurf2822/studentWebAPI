using System.Threading.Tasks;

namespace CollegeApp.Data.Repository
{
  public interface IStudentRepository : ICollegeRepository<Student> //Gives access to all methods here
  {
    Task<List<Student>> GetStudentByFeeStatusAsync(int feeStatus);
  }
}