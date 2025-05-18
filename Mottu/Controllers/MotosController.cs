using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MottuTrackerAPI.Data;
using MottuTrackerAPI.Models;

namespace MottuTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MotosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moto>>> Get() =>
            await _context.Motos.Include(m => m.Localizacoes).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Moto>> Get(int id)
        {
            var moto = await _context.Motos.Include(m => m.Localizacoes).FirstOrDefaultAsync(m => m.Id == id);
            return moto is null ? NotFound() : Ok(moto);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Moto moto)
        {
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = moto.Id }, moto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Moto moto)
        {
            if (id != moto.Id) return BadRequest();

            _context.Entry(moto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto is null) return NotFound();

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}