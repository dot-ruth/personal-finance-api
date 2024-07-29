using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace personal_finance_api.Models;

public class Income
{
   [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
   public int Id {get; set;}
   public decimal IncomeAmount {get; set;}
   public string IncomeDescription {get; set;}
   public string IncomeCategory {get; set;}
   public DateTime  IncomeDate {get; set;}
}