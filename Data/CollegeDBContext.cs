
using CollegeApp.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data
{
  public class CollegeDBContext : DbContext
  {
    public CollegeDBContext(DbContextOptions<CollegeDBContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //Table1
      modelBuilder.ApplyConfiguration(new StudentConfig());
      modelBuilder.ApplyConfiguration(new DepartmentConfig());
      //Table2

      //Table3

      //Table4
    }
  }
}