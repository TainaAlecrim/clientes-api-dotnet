using AutoMapper;
using ClientesApi.Data;
using ClientesApi.Dtos;
using ClientesApi.DTOs;
using ClientesApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClientesApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<ClientesController> _logger;
    private readonly IMapper _mapper;

    public ClientesController(AppDbContext context, ILogger<ClientesController> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        var cliente = await _context.Clientes.ToListAsync();

        if (cliente == null)
        {
            _logger.LogWarning("Nenhum cliente encontrado");
            return NotFound();
        }

        return Ok(cliente);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        _logger.LogInformation("Buscando cliente com id {Id}", id);

        var cliente = await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        if (cliente == null)
        {
            _logger.LogWarning("Cliente com id {id} não encontrado", id);
            return NotFound();
        }

        var response = _mapper.Map<ClienteResponse>(cliente);

        _logger.LogWarning("Cliente com id {id} encontrado", id);
        return Ok(cliente);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Post(ClienteRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var cliente = _mapper.Map<Cliente>(request);

        _context.Clientes.Add(cliente);
         await _context.SaveChangesAsync();
        
        var response = _mapper.Map<ClienteResponse>(cliente);

        _logger.LogWarning("Cliente com id {cliente} encontrado", cliente);
        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ClienteRequest request)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            _logger.LogWarning("Cliente com id {id} não encontrado", id);
            return NotFound();
        }

        _mapper.Map(request, cliente);

        await _context.SaveChangesAsync();

        _logger.LogWarning("Cliente com id {id} alterado com sucesso", id);
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            _logger.LogWarning("Cliente com id {id} não encontrado", id);
            return NotFound();
        }

        _context.Remove(cliente);
        await _context.SaveChangesAsync();

        _logger.LogWarning("Cliente com id {id} removido com sucesso", id);
        return NoContent();
    }

}
