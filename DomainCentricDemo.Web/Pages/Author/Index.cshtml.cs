using DomainCentricDemo.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DomainCentricDemo.Web.Pages.Author;

public class IndexModel : PageModel
{
  private readonly IAuthorQuery _queryService;

  public IndexModel(IAuthorQuery queryService)
  {
    _queryService = queryService;
  }

  public IList<AuthorViewModel> Authors { get; set; } = default!;

  public void OnGet()
  {
    Authors = new List<AuthorViewModel>();
    foreach (var author in _queryService.GetAll())
    {
      Authors.Add(new AuthorViewModel()
      {
        Id = author.Id,
        FirstName = author.FirstName,
        LastName = author.LastName
      });
    }
  }
}