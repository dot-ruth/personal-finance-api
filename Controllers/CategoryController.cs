using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personal_finance_api;
using personal_finance_api.Models;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase 
{
    private readonly PersonalFinanceDBContext dbContext;

    public CategoryController(PersonalFinanceDBContext dbContext){
        this.dbContext = dbContext;
    }

    [HttpPost]
    public async Task<ActionResult<Category>> CreateCategory(Category category)
    {
        dbContext.Category.Add(category);
        await dbContext.SaveChangesAsync();
        return CreatedAtAction("GetCategory", new { id = category.Id }, category);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
    {
        return await dbContext.Category.ToListAsync();
    }

     [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategoryById(int id)
    {
        return await dbContext.Category.FindAsync(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, Category category)
    {
        if (id != category.Id) return BadRequest();
        dbContext.Entry(category).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await dbContext.Category.FindAsync(id);
        dbContext.Category.Remove(category);
        await dbContext.SaveChangesAsync();
        return NoContent();
    }



}