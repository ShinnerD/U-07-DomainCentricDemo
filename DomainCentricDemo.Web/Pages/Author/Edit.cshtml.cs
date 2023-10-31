using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Dto;
using DomainCentricDemo.Web.Pages.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DomainCentricDemo.Web.Pages.Author;

public class EditModel : PageModel
{
    private readonly IAuthorCommand _command;
    private readonly IAuthorQuery _query;

    public EditModel(IAuthorQuery query, IAuthorCommand command)
    {
        _query = query;
        _command = command;
    }

    [BindProperty] public AuthorViewModel Author { get; set; } = default!;

    public IActionResult OnGet(int? id)
    {
        if (id == null) return NotFound();

        var author = _query.Get(id.Value);
        if (author == null) return NotFound();

        Author = new AuthorViewModel()
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            Books = author.Books.ConvertAll(x => new BookViewModel() {Id = x.Id, Title = x.Title}),
            Version = author.Version
        };
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        _command.Update(new AuthorUpdateRequestDto()
        {
            Id = Author.Id,
            FirstName = Author.FirstName,
            LastName = Author.LastName,
            Version = Author.Version
        });
        return RedirectToPage("./Index");
    }
}