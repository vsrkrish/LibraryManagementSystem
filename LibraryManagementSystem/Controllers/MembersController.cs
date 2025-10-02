using LibraryManagementSystem.DBLayer;
using LibraryManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly ILibraryContext _context;

        public MembersController(ILibraryContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Member>> Register(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Register), new { id = member.MemberId }, member);
        }
    }
}
