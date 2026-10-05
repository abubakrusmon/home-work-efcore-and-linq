using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService authorService) : ControllerBase
{
    private IAuthorService service = authorService;

    [HttpPost]
    public async Task<IActionResult> AddAuthor(CreateAuthorDto dto)
    {
        var res = await service.AddAuthor(dto);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAuthor(int id, UpdateAuthorDto dto)
    {
        var res = await service.UpdateAuthor(id,dto);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var res = await service.DeleteAuthor(id);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        var res = await service.GetAuthor(id);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
    [HttpGet("top/{count:int}")]
    public async Task<IActionResult> GetAuthorsWithMostBooks(int count)
    {
        var res = await service.GetAuthorsWithMostBooks(count);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
}
