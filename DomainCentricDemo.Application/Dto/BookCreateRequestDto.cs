namespace DomainCentricDemo.Application.Dto;

public class BookCreateRequestDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<int> AuthorIds { get; set; }
}