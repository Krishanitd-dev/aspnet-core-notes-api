using NotesApi.Models;
namespace NotesApi.Services;

public class NoteService : INoteService
{
    private readonly List<Note> _notes = new();
    private int _nextId = 1;
    public Task<List<Note>> GetAllAsync()
    {
        return Task.FromResult(_notes.ToList());
    }

    public Task<Note?> GetByIdAsync(int id)
    {
        var note = _notes.FirstOrDefault(n => n.Id == id);
        return Task.FromResult(note);
    }

    public Task<Note> CreateAsync(string title, string content)
    {
        var note = new Note
        {
            Id = _nextId++,
            Title = title,
            Content = content,
            CreatedAt = DateTime.UtcNow
        };
        _notes.Add(note);
        return Task.FromResult(note);
    }

    public Task<bool> UpdateAsync(int id, string title, string content)
    {
        var note = _notes.FirstOrDefault(n => n.Id == id);
        if (note == null)
        {
            return Task.FromResult(false);
        }
        note.Title = title;
        note.Content = content;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var note = _notes.FirstOrDefault(n => n.Id == id);
        if (note == null)
        {
            return Task.FromResult(false);
        }
        _notes.Remove(note);
        return Task.FromResult(true);
    }

    public Task<List<Note>> SearchAsync(string query)
    {
    var results = _notes
        .Where(n =>
            n.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            n.Content.Contains(query, StringComparison.OrdinalIgnoreCase))
        .ToList();
    return Task.FromResult(results);
    }
}

    