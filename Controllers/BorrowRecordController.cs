using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BorrowRecordController(IBorrowRecordService borrowRecordService) : ControllerBase
{
    private IBorrowRecordService service = borrowRecordService;

    [HttpPost]
    public async Task<IActionResult> AddBorrowRecord(CreateBorrowRecordDto dto)
    {
        var res = await service.AddBorrowRecord(dto);
        if (!res.Success) return NotFound(res);
        return Ok(res);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBorrowRecord(int id, UpdateBorrowRecordDto dto)
    {
        var res = await service.UpdateBorrowRecord(id, dto);
        if (!res.Success) return NotFound(res);
        return Ok(res);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBorrowRecord(int id)
    {
        var res = await service.DeleteBorrowRecord(id);
        if (!res.Success) return NotFound(res);
        return Ok(res);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBorrowRecord(int id)
    {
        var res = await service.GetBorrowRecord(id);
        if (!res.Success) return NotFound(res);
        return Ok(res);
    }

    [HttpGet("overdue")]
    public async Task<IActionResult> GetOverdueBorrows()
    {
        var res = await service.GetOverdueBorrows();
        return Ok(res);
    }

    [HttpGet("member/{memberId:int}")]
    public async Task<IActionResult> GetBorrowHistoryByMember(int memberId)
    {
        var res = await service.GetBorrowHistoryByMember(memberId);
        return Ok(res);
    }

    [HttpGet("book/{bookId:int}")]
    public async Task<IActionResult> GetBorrowHistoryByBook(int bookId)
    {
        var res = await service.GetBorrowHistoryByBook(bookId);
        return Ok(res);
    }
}