using Microsoft.EntityFrameworkCore;
using NotesApi.Data;
using NotesApi.Models;

namespace NotesApi.Services;

public class NoteService : INoteService
{
    private readonly AppDbContext _context;

    public NoteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Note>> GetAllAsync()
    {
        return await _context.Notes
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Note?> GetByIdAsync(int id)
    {
        return await _context.Notes
            .AsNoTracking()
            .FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task<Note> CreateAsync(
        string title, string content)
    {
        var note = new Note
        {
            Title = title,
            Content = content,
            CreatedAt = DateTime.UtcNow
        };

        _context.Notes.Add(note);

        await _context.SaveChangesAsync();

        return note;
    }

    public async Task<bool> UpdateAsync(
        int id, string title, string content)
    {
        var note = await _context.Notes
            .FirstOrDefaultAsync(n => n.Id == id);

        if (note is null)
        {
            return false;
        }

        note.Title = title;
        note.Content = content;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var note = await _context.Notes
            .FirstOrDefaultAsync(n => n.Id == id);

        if (note is null)
        {
            return false;
        }

        _context.Notes.Remove(note);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Note>> SearchAsync(string query)
    {
        return await _context.Notes
            .AsNoTracking()
            .Where(n =>
                n.Title.Contains(query) ||
                n.Content.Contains(query))
            .ToListAsync();
    }

    public async Task<int> GetCountAsync()
    {
        return await _context.Notes.CountAsync();
    }
}
