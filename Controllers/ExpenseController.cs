using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personal_finance_api;
using personal_finance_api.Models;

[ApiController]
[Route("api/[controller]")]
public class ExpenseController : ControllerBase 
{
    private readonly PersonalFinanceDBContext dbContext;

    public ExpenseController(PersonalFinanceDBContext dbContext){
        this.dbContext = dbContext;
    }

    [HttpPost]
    public async Task<ActionResult<Expense>> CreateExpense(Expense expense)
    {
        dbContext.Expense.Add(expense);
        await dbContext.SaveChangesAsync();
        return CreatedAtAction("GetExpense", new { id = expense.Id }, expense);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Expense>>> GetExpense()
    {
        return await dbContext.Expense.ToListAsync();
    }

     [HttpGet("{id}")]
    public async Task<ActionResult<Expense>> GetExpenseById(int id)
    {
        return await dbContext.Expense.FindAsync(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExpense(int id, Expense expense)
    {
        if (id != expense.Id) return BadRequest();
        dbContext.Entry(expense).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense(int id)
    {
        var expense = await dbContext.Expense.FindAsync(id);
        dbContext.Expense.Remove(expense);
        await dbContext.SaveChangesAsync();
        return NoContent();
    }



}