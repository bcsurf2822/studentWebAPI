using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollegeApp.Data.Config
{
  public class StudentConfig : IEntityTypeConfiguration<Student>
  {
    public void Configure(EntityTypeBuilder<Student> builder)
    {
      builder.ToTable("Students");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).UseIdentityColumn();

      builder.Property(n => n.StudentName).IsRequired();
      builder.Property(n => n.StudentName).HasMaxLength(250);
      builder.Property(n => n.Address).IsRequired(false).HasMaxLength(500);
      builder.Property(n => n.Email).IsRequired().HasMaxLength(250);

      builder.HasData(new List<Student>()
      {
        new Student { Id = 1, StudentName = "Benjamin", Email = "benjamin@email.com", Address = "NJ", DOB = new DateTime(1990, 2, 8) },
        new Student { Id = 2, StudentName = "Sophia", Email = "sophia@email.com", Address = "CA", DOB = new DateTime(1995, 6, 15) },
        new Student { Id = 3, StudentName = "Liam", Email = "liam@email.com", Address = "NY", DOB = new DateTime(1992, 12, 5) },
        new Student { Id = 4, StudentName = "Olivia", Email = "olivia@email.com", Address = "TX", DOB = new DateTime(1994, 3, 10) },
        new Student { Id = 5, StudentName = "Noah", Email = "noah@email.com", Address = "FL", DOB = new DateTime(1993, 9, 18) },
        new Student { Id = 6, StudentName = "Emma", Email = "emma@email.com", Address = "WA", DOB = new DateTime(1991, 1, 22) },
        new Student { Id = 7, StudentName = "James", Email = "james@email.com", Address = "NV", DOB = new DateTime(1989, 5, 30) },
        new Student { Id = 8, StudentName = "Ava", Email = "ava@email.com", Address = "IL", DOB = new DateTime(1996, 7, 12) },
        new Student { Id = 9, StudentName = "William", Email = "william@email.com", Address = "OH", DOB = new DateTime(1993, 11, 25) },
        new Student { Id = 10, StudentName = "Mia", Email = "mia@email.com", Address = "PA", DOB = new DateTime(1992, 10, 9) },
        new Student { Id = 11, StudentName = "Lucas", Email = "lucas@email.com", Address = "GA", DOB = new DateTime(1994, 4, 17) },
        new Student { Id = 12, StudentName = "Charlotte", Email = "charlotte@email.com", Address = "MI", DOB = new DateTime(1991, 8, 26) },
        new Student { Id = 13, StudentName = "Henry", Email = "henry@email.com", Address = "NC", DOB = new DateTime(1990, 6, 2) },
        new Student { Id = 14, StudentName = "Amelia", Email = "amelia@email.com", Address = "VA", DOB = new DateTime(1995, 3, 29) },
        new Student { Id = 15, StudentName = "Alexander", Email = "alexander@email.com", Address = "MA", DOB = new DateTime(1993, 12, 14) },
        new Student { Id = 16, StudentName = "Evelyn", Email = "evelyn@email.com", Address = "CO", DOB = new DateTime(1996, 9, 6) },
        new Student { Id = 17, StudentName = "Michael", Email = "michael@email.com", Address = "AZ", DOB = new DateTime(1988, 11, 3) },
        new Student { Id = 18, StudentName = "Harper", Email = "harper@email.com", Address = "OR", DOB = new DateTime(1994, 5, 20) },
        new Student { Id = 19, StudentName = "Daniel", Email = "daniel@email.com", Address = "WI", DOB = new DateTime(1992, 2, 28) },
        new Student { Id = 20, StudentName = "Ella", Email = "ella@email.com", Address = "MN", DOB = new DateTime(1990, 7, 11) }
      }
      );
    }
  }
}