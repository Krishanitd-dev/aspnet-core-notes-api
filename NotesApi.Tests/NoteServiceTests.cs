using NotesApi.Services;

namespace NotesApi.Tests;

public class NoteServiceTests
{
    [Fact]
    public async Task CreateNote_ShouldCreateNote()
    {
        var service = new NoteService();

        var note = await service.CreateAsync(
            "Test Note",
            "This is a test."
        );

        Assert.Equal(1, note.Id);
        Assert.Equal("Test Note", note.Title);
        Assert.Equal("This is a test.", note.Content);
    }
}