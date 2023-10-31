using System.ComponentModel.DataAnnotations;

namespace DomainCentricDemo.Domain;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Book> Books { get; set; } = new();

    [Timestamp]
    public byte[] Version { get; set; }
}