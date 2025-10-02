using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowController : ControllerBase
    {
        private readonly ILibraryService _service;

        public BorrowController(ILibraryService service)
        {
            _service = service;
        }

        [HttpPost("borrow")]
        public async Task<IActionResult> BorrowBooks([FromBody] BorrowRequestDto request)
        {
            var result = await _service.BorrowBooksAsync(request.MemberId, request.BookIds);
            return Ok(result);
        }


        [HttpPost("return")]
        public async Task<IActionResult> ReturnBook(ReturnRequestDto request)
        {
            var result = await _service.ReturnBookAsync(request.BookId, request.MemberId);
            return Ok(result);
        }
        [HttpGet("borrowers/{bookId}")]
        public async Task<IActionResult> GetBorrowers(int bookId)
        {
            var borrowers = await _service.GetBorrowersByBookIdAsync(bookId);

            var result = borrowers.Select(m => new {
                m.FullName,
                m.PhoneNumber
            });

            return Ok(result);
        }

    }
}
