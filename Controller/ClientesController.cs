using ClientesApi.Data;
using ClientesApi.Dtos;
using ClientesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var clientes = await _context.Clientes.ToListAsync();
        return Ok(clientes);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ClienteDto clienteDto)
    {
        var cliente = new Cliente {
            Nome = clienteDto.Nome,
            Email = clienteDto.Email,
            Telefone = clienteDto.Telefone,
            DataCadastro = DateTime.Now
        };
        
        _context.Clientes.Add(cliente);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ClienteDto clienteDto)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
            return NotFound();

        cliente.Nome = clienteDto.Nome;
        cliente.Telefone = clienteDto.Telefone;
        cliente.Email = clienteDto.Email;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
            return NotFound();

        _context.Remove(cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
