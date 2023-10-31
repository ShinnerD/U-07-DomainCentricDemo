using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Dto;
using DomainCentricDemo.Application.Mapper;
using Microsoft.EntityFrameworkCore;

namespace DomainCentricDemo.Infrastructure.Queries
{
  public class AuthorQuery : IAuthorQuery
  {
    private readonly BookContext _db;

    public AuthorQuery(BookContext db)
    {
      _db = db;
    }

    public AuthorDto? Get(int id)
    {
      var author = _db.Authors.AsNoTracking().FirstOrDefault(a => a.Id == id);
      return author is not null ? AuthorMapper.MapToDto(author) : null;
    }

    public List<AuthorDto> GetAll()
    {
      return _db.Authors.Select(author => AuthorMapper.MapToDto(author)).ToList();
    }
  }
}
