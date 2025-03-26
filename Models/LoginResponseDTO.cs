using System.ComponentModel.DataAnnotations;

public class LoginResponseDTO
{
  [Required]
  public string UserName { get; set; }
  [Required]
  public string token { get; set; }
}