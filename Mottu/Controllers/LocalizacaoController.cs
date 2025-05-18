using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MottuTrackerAPI.Data;
using MottuTrackerAPI.Models;

namespace MottuTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalizacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocalizacaoController(AppDbContext context)
        {
            _context = context;
        }

        // Retorna as 50 localizações mais recentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localizacao>>> Get()
        {
            return await _context.Localizacoes
                .Include(l => l.Moto)
                .OrderByDescending(l => l.DataHora)
                .Take(50)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Localizacao>> Get(int id)
        {
            var local = await _context.Localizacoes
                .Include(l => l.Moto)
                .FirstOrDefaultAsync(l => l.Id == id);

            return local is null ? NotFound() : Ok(local);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Localizacao local)
        {
            _context.Localizacoes.Add(local);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = local.Id }, local);
        }
    }
}
