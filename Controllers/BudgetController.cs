using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personal_finance_api;
using personal_finance_api.Models;

[ApiController]
[Route("api/[controller]")]
public class BudgetController : ControllerBase 
{
    private readonly PersonalFinanceDBContext dbContext;

    public BudgetController(PersonalFinanceDBContext dbContext){
        this.dbContext = dbContext;
    }

    [HttpPost]
    public async Task<ActionResult<Budget>> CreateBudget(Budget budget)
    {
        dbContext.Budget.Add(budget);
        await dbContext.SaveChangesAsync();
        return CreatedAtAction("GetBudget", new { id = budget.Id }, budget);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Budget>>> GetBudget()
    {
        return await dbContext.Budget.ToListAsync();
    }

     [HttpGet("{id}")]
    public async Task<ActionResult<Budget>> GetBudgetById(int id)
    {
        return await dbContext.Budget.FindAsync(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBudget(int id, Budget budget)
    {
        if (id != budget.Id) return BadRequest();
        dbContext.Entry(budget).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBudget(int id)
    {
        var budget = await dbContext.Budget.FindAsync(id);
        dbContext.Budget.Remove(budget);
        await dbContext.SaveChangesAsync();
        return NoContent();
    }



}