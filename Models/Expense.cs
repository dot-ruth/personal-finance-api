using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace personal_finance_api.Models;

public class Expense
{
   [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
   public int Id {get; set;}
   public decimal ExpenseAmount {get; set;}
   public string ExpenseDescription {get; set;}
   public string ExpenseCategory {get; set;}
   public DateTime  ExpenseDate {get; set;}
}