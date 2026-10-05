using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService bookService) : ControllerBase
{
    private IBookService service = bookService;

    [HttpPost]
    public async Task<IActionResult> AddBook(CreateBookDto book)
    {
        var res = await service.AddBook(book);
        if(!res.Success) return NotFound(res);
        return Ok(res); 
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBook(UpdateBookDto book , int id)
    {
        var res = await service.UpdateBook(book,id);
        if(!res.Success) return NotFound(res);
        return Ok(res);     
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var res = await service.DeleteBook(id);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var res = await service.GetBook(id);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var res = await service.GetAllBooks();
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
    [HttpGet("author/{authorId}")]
    public async Task<IActionResult> GetBooksByAuthor(int authorId)
    {
        var res = await service.GetBooksByAuthor(authorId);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
    [HttpGet("genre/{genre}")]
    public async Task<IActionResult> GetBooksByGenre(string genre)
    {
        var res = await service.GetBooksByGenre(genre);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
    [HttpGet("recent/{years}")]
    public async Task<IActionResult> GetRecentlyPublishedBooks(int years)
    {
        var res = await service.GetRecentlyPublishedBooks(years);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
}
