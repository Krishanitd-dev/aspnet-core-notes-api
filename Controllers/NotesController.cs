using NotesApi.DTOs;
using NotesApi.Models;
using NotesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace NotesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly INoteService _noteService;

    public NotesController(INoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Note>>> GetAll()
    {
        var notes = await _noteService.GetAllAsync();

        return Ok(notes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Note>> GetById(int id)
    {
        var note = await _noteService.GetByIdAsync(id);

        if (note == null)
        {
            return NotFound();
        }

        return Ok(note);
    }

    [HttpPost]
    public async Task<ActionResult<Note>> Create(CreateNoteRequest request)
    {
        var note = await _noteService.CreateAsync(
            request.Title,
            request.Content
        );

        return CreatedAtAction(
            nameof(GetById),
            new { id = note.Id },
            note
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateNoteRequest request)
    {
        var updated = await _noteService.UpdateAsync(
            id,
            request.Title,
            request.Content
        );

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _noteService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<Note>>> Search(string query)
    {
        var notes = await _noteService.SearchAsync(query);
        return Ok(notes);
    }   

    [HttpGet("count")]
    public async Task<ActionResult<object>> GetCount()
    {
        var count = await _noteService.GetCountAsync();
        return Ok(new { count });
    }

}

