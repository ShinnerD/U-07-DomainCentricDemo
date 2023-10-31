using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Dto;
using DomainCentricDemo.Web.Pages.Author;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DomainCentricDemo.Web.Pages.Book;

public class EditModel : PageModel
{
    private readonly IBookCommand _command;
    private readonly IBookQuery _bookQuery;
    private readonly IAuthorQuery _authorQuery;

    public EditModel(IBookQuery bookQuery, IBookCommand command, IAuthorQuery authorQuery)
    {
        _bookQuery = bookQuery;
        _command = command;
        _authorQuery = authorQuery;
    }

    [BindProperty] public BookViewModel Book { get; set; } = default!;
    public List<SelectListItem> AuthorOptions { get; set; }

    public IActionResult OnGet(int? id)
    {
        if (id == null) return NotFound();

        var book = _bookQuery.Get(id.Value);
        if (book == null) return NotFound();

        Book = new BookViewModel
        {
            Authors = book.Authors.ConvertAll(x => new AuthorViewModel() { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName }),
            Description = book.Description,
            Title = book.Title,
            Id = book.Id,
            Version = book.Version
        };

        AuthorOptions = _authorQuery.GetAll().Select(x => new SelectListItem()
        {
            Value = x.Id.ToString(),
            Text = x.FirstName + " " + x.LastName
        }).ToList();

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        _command.Update(new BookUpdateRequestDto
        {
            AuthorIds = Book.Authors.ConvertAll(x => x.Id),
            Description = Book.Description,
            Title = Book.Title,
            Id = Book.Id,
            Version = Book.Version
        });
        return RedirectToPage("./Index");
    }
}