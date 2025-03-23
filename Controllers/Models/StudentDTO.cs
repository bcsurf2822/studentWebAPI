using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CollegeApp.Models
{
  public class StudentDTO
  {
    [ValidateNever] //Field will not be validated
    public int Id { get; set; }

    [Required(ErrorMessage = "Student Name is Required")]
    [StringLength(30)]
    public string StudentName { get; set; }

    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; }

    [Range(10, 20)]
    public int Age { get; set; }

    [Required]
    public string Address { get; set; }

    public string Password { get; set; }
    // [Compare("Password")] //Confirm p.word will be compare with password field / OR
    [Compare(nameof(Password))]

    public string ConfirmPassword { get; set; }
  }
}