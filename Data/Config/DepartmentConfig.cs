
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DepartmentConfig : IEntityTypeConfiguration<Department>
{
  public void Configure(EntityTypeBuilder<Department> builder)
  {
    builder.ToTable("Departments");
    builder.HasKey(x => x.Id);
    builder.Property(x => x.Id).UseIdentityColumn();

    builder.Property(n => n.DepartmentName).IsRequired().HasMaxLength(200);
    builder.Property(n => n.Description).HasMaxLength(500).IsRequired(false);

    builder.HasData(new List<Department>()
    {
      new Department { Id = 1, DepartmentName = "Computer Science", Description = "Focuses on programming, algorithms, and systems." },
      new Department { Id = 2, DepartmentName = "Mathematics", Description = "Deals with numbers, theories, and proofs." },
      new Department { Id = 3, DepartmentName = "Business", Description = "Covers management, marketing, and finance." },
      new Department { Id = 4, DepartmentName = "Biology", Description = "Studies living organisms and ecosystems." }
    });
  }
}