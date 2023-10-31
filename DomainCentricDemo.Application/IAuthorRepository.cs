using DomainCentricDemo.Domain;

namespace DomainCentricDemo.Application;

public interface IAuthorRepository
{
    void Create(Author author);
    void Commit();
    Author Load(int id);
    void Save(Author author);
    void Delete(Author author);
}