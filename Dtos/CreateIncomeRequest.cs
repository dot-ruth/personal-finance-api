using System.ComponentModel.DataAnnotations;
namespace personal_finance_api.Dtos;

public class CreateIncomeRequest {

    [Required]
    public decimal? IncomeAmount {get; set;}

    [Required]
    public string? IncomeDescription {get; set;}

    [Required]
    public string? IncomeCategory {set; get;}

    [Required]
    public DateTime? IncomeDate {set; get;}
}