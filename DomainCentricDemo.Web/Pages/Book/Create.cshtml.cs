using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DomainCentricDemo.Web.Pages.Book;

public class CreateModel : PageModel
{
    private readonly IBookCommand _bookCommand;
    private readonly IAuthorQuery _authorQuery;

    public CreateModel(IBookCommand bookCommand, IAuthorQuery authorQuery)
    {
        _bookCommand = bookCommand;
        _authorQuery = authorQuery;
    }

    [BindProperty] 
    public BookCreateViewModel Book { get; set; } = default!;
    
    public SelectList AuthorOptions { get; set; }

    public IActionResult OnGet()
    {
        AuthorOptions = new SelectList(_authorQuery.GetAll(), nameof(AuthorDto.Id), nameof(AuthorDto.FullName));
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        _bookCommand.Create(new BookCreateRequestDto {
            AuthorIds = Book.AuthorIds,
            Description = Book.Description,
            Title = Book.Title});

        return RedirectToPage("./Index");
    }
}