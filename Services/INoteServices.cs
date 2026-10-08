using NotesApi.Models;
namespace NotesApi.Services;
public interface INoteService
{
    Task<List<Note>> GetAllAsync();
    Task<Note?> GetByIdAsync(int id);
    Task<Note> CreateAsync(string title, string content);
    Task<bool> UpdateAsync(int id, string title, string content);
    Task<bool> DeleteAsync(int id);
    Task<List<Note>> SearchAsync(string query);
    Task<int> GetCountAsync();
}


