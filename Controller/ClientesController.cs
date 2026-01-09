using ClientesApi.Data;
using ClientesApi.Dtos;
using ClientesApi.DTOs;
using ClientesApi.Models;
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

    public ClientesController(AppDbContext context, ILogger<ClientesController> logger)
    {
        _context = context;
        _logger = logger;
    }

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

        var response = new ClienteResponse
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone,
            CriadoEm = DateTime.Now
        };

        _logger.LogWarning("Cliente com id {id} encontrado", id);
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ClienteRequest clienteDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var cliente = new Cliente
        {
            Nome = clienteDto.Nome,
            Email = clienteDto.Email,
            Telefone = clienteDto.Telefone,
            DataCadastro = DateTime.Now
        };

        _context.Clientes.Add(cliente);

        await _context.SaveChangesAsync();

        var response = new ClienteResponse
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone,
            CriadoEm = DateTime.Now
        };

        _logger.LogWarning("Cliente com id {cliente} encontrado", cliente);
        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ClienteRequest clienteDto)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            _logger.LogWarning("Cliente com id {id} não encontrado", id);
            return NotFound();
        }

        cliente.Nome = clienteDto.Nome;
        cliente.Telefone = clienteDto.Telefone;
        cliente.Email = clienteDto.Email;

        await _context.SaveChangesAsync();

        _logger.LogWarning("Cliente com id {id} alterado com sucesso", id);
        return NoContent();
    }

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
