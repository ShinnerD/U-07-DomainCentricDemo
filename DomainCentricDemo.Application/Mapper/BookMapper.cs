using DomainCentricDemo.Application.Dto;
using DomainCentricDemo.Domain;

namespace DomainCentricDemo.Application.Mapper;

public static class BookMapper
{
  public static Book MapToDomain(BookCreateRequestDto dto, IAuthorRepository authorRepository)
  {
    return new Book
    {
      Title = dto.Title,
      Description = dto.Description,
      Authors = dto.AuthorIds.ConvertAll(authorRepository.Load)
    };
  }

  public static BookDto MapToDto(Book book)
  {
    return new BookDto
    {
      Id = book.Id,
      Title = book.Title,
      Description = book.Description,
      Version = book.Version,
      Authors = book.Authors.ConvertAll(AuthorMapper.MapToDto)    };
  }
}

public static class AuthorMapper
{
  public static AuthorDto MapToDto(Author author)
  {
    return new AuthorDto
    {
      Id = author.Id,
      FirstName = author.FirstName,
      LastName = author.LastName,
      Version = author.Version,
      Books = author.Books.ConvertAll(BookMapper.MapToDto)
    };
  }

  public static Author MapToDomain(AuthorCreateRequestDto dto)
  {
    return new Author()
    {
      FirstName = dto.FirstName,
      LastName = dto.LastName
    };
  }
}