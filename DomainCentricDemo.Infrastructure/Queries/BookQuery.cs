using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Dto;
using DomainCentricDemo.Application.Mapper;
using Microsoft.EntityFrameworkCore;

namespace DomainCentricDemo.Infrastructure.Queries;

public class BookQuery : IBookQuery
{
    private readonly BookContext _db;

    public BookQuery(BookContext db)
    {
        _db = db;
    }

    BookDto? IBookQuery.Get(int id)
    {
        var book = _db.Books.AsNoTracking().FirstOrDefault(a => a.Id == id);
        return book is not null ? BookMapper.MapToDto(book) : null;
    }

    List<BookDto> IBookQuery.GetAll()
    {
      return _db.Books.Include(x => x.Authors)
        .Select(book => BookMapper.MapToDto(book))
        .ToList();
    }
}