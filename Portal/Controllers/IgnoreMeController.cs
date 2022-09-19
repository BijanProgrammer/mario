using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Database;

namespace Portal.Controllers;

[ApiController]
[Route("[controller]")]
public class IgnoreMeController : ControllerBase
{
    private Context _context;

    public IgnoreMeController(Context context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> SelectAll()
    {
        var result = _context.IgnoreMe.FromSqlRaw("SELECT * FROM \"IgnoreMe\"");
        return Ok(result);
    }
}