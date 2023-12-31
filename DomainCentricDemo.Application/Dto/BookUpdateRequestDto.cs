﻿namespace DomainCentricDemo.Application.Dto;

public class BookUpdateRequestDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<int> AuthorIds { get; set; } = new();
    public byte[] Version { get; set; }
}