using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace personal_finance_api.Models;

public class User : IdentityUser
{

    public string? password  {get; set;}

}