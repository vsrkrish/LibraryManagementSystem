namespace LibraryManagementSystem.Dtos
{
    public class BorrowRequestDto
    {
        public int MemberId { get; set; }
        public List<int> BookIds { get; set; } = new();


    }
}
