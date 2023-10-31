using DomainCentricDemo.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCentricDemo.Application
{
  public interface IAuthorCommand
  {
    void Create(AuthorCreateRequestDto createRequest);
    void Update(AuthorUpdateRequestDto updateRequest);
    void Delete(int id);
  }
}
