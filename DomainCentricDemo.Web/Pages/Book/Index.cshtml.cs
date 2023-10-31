using DomainCentricDemo.Application;
using DomainCentricDemo.Web.Pages.Author;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DomainCentricDemo.Web.Pages.Book;

public class IndexModel : PageModel
{
  private readonly IBookQuery _queryService;

  public IndexModel(IBookQuery queryService)
  {
    _queryService = queryService;
  }

  public IList<BookViewModel> Books { get; set; } = default!;

  public void OnGet()
  {
    Books = new List<BookViewModel>();
    foreach (var book in _queryService.GetAll())
    {
      Books.Add(new BookViewModel
      {
        Id = book.Id,
        Title = book.Title,
        Authors = book.Authors.ConvertAll(x => new AuthorViewModel(){Id = x.Id, FirstName = x.FirstName, LastName = x.LastName}),
        Description = book.Description
      });
    }
  }
}