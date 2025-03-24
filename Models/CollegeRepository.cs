namespace CollegeApp.Models
{
  public static class CollegeRepository
  {
    public static List<Student> Students { get; set; } = new List<Student>(){
      new Student
                {
                    Id = 1,
                    StudentName = "Benjamin",
                    Email = "student1@gmail.com",
                    Address = "EHT, NJ"
                },
                new Student
                {
                    Id = 2,
                    StudentName = "Jason",
                    Email = "student2@gmail.com",
                    Address = "Ventnor, NJ"
                },
                new Student
                {
                    Id = 3,
                    StudentName = "Micah",
                    Email = "student3@gmail.com",
                    Address = "Atlantic City, NJ"
                },
                new Student
                {
                    Id = 4,
                    StudentName = "Frank",
                    Email = "student4@gmail.com",
                    Address = "Mays Landing, NJ"
                }
    };
  }
}