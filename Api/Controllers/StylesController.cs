using Api.Models;
using Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StylesController : ControllerBase
    {
        private readonly BtcEntities _db;

        public StylesController(BtcEntities db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var styles = 
                await _db.Styles
                         .Include(x=>x.Color)
                         .Include(x=>x.Size)
                         .Where(x => x.ProductId == id)
                         .ToListAsync();
            var model = styles.Select(style => new StyleListViewModel(style));
            return Ok(model);
        }
    }
}