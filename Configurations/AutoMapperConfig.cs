using AutoMapper;
using CollegeApp.Data;
using CollegeApp.Models;

namespace CollegeApp.Configurations
{
  public class AutoMapperConfig : Profile
  {
    public AutoMapperConfig()
    {
      // CreateMap<Student, StudentDTO>();
      // CreateMap<StudentDTO, Student>();
      CreateMap<StudentDTO, Student>().ReverseMap();
      //IGNORE FIELD
      // CreateMap<StudentDTO, Student>().ReverseMap().ForMember(n => n.StudentName, opt => opt.Ignore());

      //DIFFERENT PROPERY NAME Ent-DTO || MapFrom: changes Entity Key into DTO (Remeber Reverse Map**)
      // CreateMap<StudentDTO, Student>().ForMember(n => n.StudentName, opt => opt.MapFrom(x => x.Name)).ReverseMap(); //So we don't have to write twice

      //TRANSFORM FIELD Empty addres => "No Address"
      // CreateMap<StudentDTO, Student>().ReverseMap().AddTransform<string>(n => string.IsNullOrEmpty(n) ? "No Address" : n);
    }
  }
}