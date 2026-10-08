using System.ComponentModel.DataAnnotations;
namespace NotesApi.DTOs;

public class UpdateNoteRequest
{
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Content { get; set; } = string.Empty;
}