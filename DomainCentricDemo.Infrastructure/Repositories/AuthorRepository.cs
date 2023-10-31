using DomainCentricDemo.Application;
using DomainCentricDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace DomainCentricDemo.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
  private readonly BookContext _db;

  public AuthorRepository(BookContext db)
  {
    _db = db;
  }

  void IAuthorRepository.Commit()
  {
    _db.SaveChanges();
  }

  void IAuthorRepository.Create(Author author)
  {
    _db.Authors.Add(author);
  }

  void IAuthorRepository.Delete(Author author)
  {
    _db.Authors.Remove(author);
  }

  Author IAuthorRepository.Load(int id)
  {
    return _db.Authors.AsNoTracking().First(author => author.Id == id);
  }

  void IAuthorRepository.Save(Author author)
  {
    _db.Authors.Update(author);
  }
}