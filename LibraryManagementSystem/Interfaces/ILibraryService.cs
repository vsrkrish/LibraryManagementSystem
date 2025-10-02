using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Interfaces
{
    public interface ILibraryService
    {
        Task<List<string>> BorrowBooksAsync(int memberId, List<int> bookIds);
        Task<string> ReturnBookAsync(int bookId, int memberId);
        Task<List<Member>> GetBorrowersByBookIdAsync(int bookId);
    }
}
