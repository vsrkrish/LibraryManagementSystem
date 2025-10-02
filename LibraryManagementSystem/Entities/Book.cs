namespace LibraryManagementSystem.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
        public int Stock { get; set; } // Total available copies

       // public ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
    }

}
