using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemberController(IMemberService memberService) : ControllerBase
{
    private IMemberService service = memberService;

    [HttpPost]
    public async Task<IActionResult> AddMember(CreateMemberDto member)
    {
        var res = await service.AddMember(member);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateMember(int id,UpdateMemberDto member)
    {
        var res = await service.UpdateMember(id,member);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMember(int id)
    {
        var res = await service.DeleteMember(id);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
    [HttpGet("{id:int}")]    public async Task<IActionResult> GetMember(int id)
    {
        var res = await service.GetMember(id);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
    [HttpGet("recent/{days:int}")]
    public async Task<IActionResult> GetMembersWithRecentBorrows(int days)
    {
        var res = await service.GetMembersWithRecentBorrows(days);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
    [HttpGet("top/{count:int}")]
    public async Task<IActionResult> GetTopNMembersByBorrows(int count)
    {
        var res = await service.GetTopNMembersByBorrows(count);
        if(!res.Success) return NotFound(res);
        return Ok(res);
    }
}
