using DomainCentricDemo.Web.Pages.Author;

namespace DomainCentricDemo.Web.Pages.Book
{
    public class BookCreateViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}
