using System.ComponentModel.DataAnnotations;

namespace personal_finance_api.Dtos;

public class LoginRequest
{
    [Required]
     public string? userName {get; set;}

     [Required]
     public string? password {get; set;}

}