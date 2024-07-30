using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace personal_finance_api.Models;

public class Category
{
   [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
   public int Id {get; set;}
   public string CategoryName {get; set;}
}