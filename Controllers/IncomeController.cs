using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personal_finance_api;
using personal_finance_api.Models;

[ApiController]
[Route("api/[controller]")]
public class IncomeController : ControllerBase 
{
    private readonly PersonalFinanceDBContext dbContext;

    public IncomeController(PersonalFinanceDBContext dbContext){
        this.dbContext = dbContext;
    }

    [HttpPost]
    public async Task<ActionResult<Income>> CreateIncome(Income income)
    {
        dbContext.Income.Add(income);
        await dbContext.SaveChangesAsync();
        return CreatedAtAction("GetIncome", new { id = income.Id }, income);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Income>>> GetIncome()
    {
        return await dbContext.Income.ToListAsync();
    }

}