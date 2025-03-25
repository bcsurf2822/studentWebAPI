using System.ComponentModel.DataAnnotations;
using CollegeApp.Validators;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CollegeApp.Models
{
  public class StudentDTO
  {
    [ValidateNever] // This skips validation for Id — good for auto-generated values
    public int Id { get; set; }

    [Required(ErrorMessage = "Student Name is Required")]
    [StringLength(30, ErrorMessage = "Student Name cannot exceed 30 characters")]
    public string StudentName { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = string.Empty;

    [Range(10, 20, ErrorMessage = "Age must be between 10 and 20")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; } = string.Empty;


    public DateTime DOB { get; set; }


  }
}