using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace personal_finance_api.Models;

public class Budget
{
   [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
   public int Id {get; set;}
   public decimal BudgetAmount {get; set;}
   public string BudgetDescription {get; set;}
   public string BudgetCategory {get; set;}
}