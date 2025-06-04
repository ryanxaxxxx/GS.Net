using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GS_AquaIntel.Data;
using GS_AquaIntel.Models;
using System;

namespace GS_AquaIntel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OcorrenciasController : ControllerBase
{
    private readonly AppDbContext _context;

    public OcorrenciasController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ocorrencia>>> GetOcorrencias()
    {
        return await _context.Ocorrencias.Include(o => o.Usuario).ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Ocorrencia>> GetOcorrencia(int id)
    {
        var ocorrencia = await _context.Ocorrencias.Include(o => o.Usuario)
                                                   .FirstOrDefaultAsync(o => o.Id == id);

        if (ocorrencia == null)
        {
            return NotFound();
        }

        return ocorrencia;
    }


    [HttpPost]
    public async Task<ActionResult<Ocorrencia>> PostOcorrencia(Ocorrencia ocorrencia)
    {
        // Verifica se o usuário realmente existe
        var usuarioExistente = await _context.Usuarios.FindAsync(ocorrencia.UsuarioId);
        if (usuarioExistente == null)
        {
            return BadRequest("Usuário informado não existe.");
        }

        // Garante que o EF não tente inserir um novo usuário
        ocorrencia.Usuario = null;

        _context.Ocorrencias.Add(ocorrencia);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOcorrencia), new { id = ocorrencia.Id }, ocorrencia);
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> PutOcorrencia(int id, Ocorrencia ocorrencia)
    {
        if (id != ocorrencia.Id)
        {
            return BadRequest("ID da URL difere do corpo da requisição.");
        }

        _context.Entry(ocorrencia).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Ocorrencias.Any(e => e.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOcorrencia(int id)
    {
        var ocorrencia = await _context.Ocorrencias.FindAsync(id);
        if (ocorrencia == null)
        {
            return NotFound();
        }

        _context.Ocorrencias.Remove(ocorrencia);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}