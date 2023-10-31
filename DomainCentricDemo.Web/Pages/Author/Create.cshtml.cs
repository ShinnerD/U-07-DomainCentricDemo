using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DomainCentricDemo.Web.Pages.Author;

public class CreateModel : PageModel
{
  private readonly IAuthorCommand _authorCommand;

  public CreateModel(IAuthorCommand authorCommand)
  {
    _authorCommand = authorCommand;
  }

  [BindProperty] public AuthorCreateViewModel Author { get; set; } = default!;

  public IActionResult OnGet()
  {
    return Page();
  }

  public IActionResult OnPost()
  {
    if (!ModelState.IsValid) return Page();

    _authorCommand.Create(new AuthorCreateRequestDto()
    {
      FirstName = Author.FirstName,
      LastName = Author.LastName
    });

    return RedirectToPage("./Index");
  }
}