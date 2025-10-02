using LibraryManagementSystem.DBLayer;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Service
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryContext _context;

        public LibraryService(ILibraryContext context)
        {
            _context = context;
        }

        public async Task<List<string>> BorrowBooksAsync(int memberId, List<int> bookIds)
        {
            var messages = new List<string>();

            var activeBorrowedBookIds = await _context.BorrowRecords
                .Where(r => r.MemberId == memberId && r.ReturnDate == null)
                .Select(r => r.BookId)
                .Distinct()
                .ToListAsync();

            if (activeBorrowedBookIds.Count >= 3)
            {
                messages.Add("You already have 3 active borrowed books. Return one before borrowing more.");
                return messages;
            }

            foreach (var bookId in bookIds.Distinct())
            {
                if (activeBorrowedBookIds.Contains(bookId))
                {
                    messages.Add($"Book ID {bookId} is already borrowed.");
                    continue;
                }

                if (activeBorrowedBookIds.Count >= 3)
                {
                    messages.Add("Borrow limit reached. Skipping remaining books.");
                    break;
                }

                var book = await _context.Books.FindAsync(bookId);
                if (book == null)
                {
                    messages.Add($"Book ID {bookId} not found.");
                    continue;
                }

                if (book.Stock <= 0)
                {
                    messages.Add($"Book '{book.Title}' is out of stock.");
                    continue;
                }

                var record = new BorrowRecord
                {
                    BookId = bookId,
                    MemberId = memberId,
                    BorrowDate = DateTime.UtcNow
                };

                book.Stock -= 1;
                _context.BorrowRecords.Add(record);
                activeBorrowedBookIds.Add(bookId);
                messages.Add($"Borrowed '{book.Title}' successfully.");
            }

            await _context.SaveChangesAsync();
            return messages;
        }

        public async Task<string> ReturnBookAsync(int bookId, int memberId)
        {
            var record = await _context.BorrowRecords
                .Where(r => r.BookId == bookId && r.MemberId == memberId && r.ReturnDate == null)
                .FirstOrDefaultAsync();

            if (record == null) return "No active borrow record found";

            record.ReturnDate = DateTime.UtcNow;

            var book = await _context.Books.FindAsync(bookId);
            if (book != null) book.Stock += 1;

            await _context.SaveChangesAsync();
            return "Book returned successfully";
        }

        public async Task<List<Member>> GetBorrowersByBookIdAsync(int bookId)
        {
            return await _context.BorrowRecords
                .Where(r => r.BookId == bookId && r.ReturnDate == null)
                .Include(r => r.Member)
                .Select(r => r.Member)
                .ToListAsync();
        }
    }
}
