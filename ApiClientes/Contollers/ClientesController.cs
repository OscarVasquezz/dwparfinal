using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiClientes.Data;
using ApiClientes.Models;

namespace ApiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ListadoGeneral")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _context.Clientes
                .Include(c => c.InformacionGeneral)
                .OrderBy(c => c.FechaNacimiento)
                .ThenBy(c => c.Apellidos)
                .ToListAsync();

            return Ok(clientes);
        }
    }
}
