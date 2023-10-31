using DomainCentricDemo.Application.Dto;
using DomainCentricDemo.Application.Mapper;

namespace DomainCentricDemo.Application.Implementation
{
  public class AuthorCommand : IAuthorCommand
  {
    private readonly IAuthorRepository _authorRepository;

    public AuthorCommand(IAuthorRepository authorRepository)
    {
      _authorRepository = authorRepository;
    }

    public void Create(AuthorCreateRequestDto createRequest)
    {
      // Create Domain object
      var author = AuthorMapper.MapToDomain(createRequest);

      // Persist Domain object
      _authorRepository.Create(author);
      _authorRepository.Commit();
    }

    public void Update(AuthorUpdateRequestDto updateRequest)
    {
      // Load
      var author = _authorRepository.Load(updateRequest.Id);

      // Execute
      author.FirstName = updateRequest.FirstName;
      author.LastName = updateRequest.LastName;
      author.Version = updateRequest.Version;

      // Persist
      _authorRepository.Save(author);
      _authorRepository.Commit();
    }

    public void Delete(int id)
    {
      // Load
      var author = _authorRepository.Load(id);

      // Delete
      _authorRepository.Delete(author);
      _authorRepository.Commit();
    }
  }
}