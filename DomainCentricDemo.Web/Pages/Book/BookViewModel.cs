using DomainCentricDemo.Web.Pages.Author;

namespace DomainCentricDemo.Web.Pages.Book
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AuthorViewModel> Authors { get; set; }
        public byte[] Version { get; set; }
    }
}
