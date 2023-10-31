using DomainCentricDemo.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCentricDemo.Application
{
  public interface IAuthorQuery
  {
    AuthorDto? Get(int id);
    List<AuthorDto> GetAll();
  }
}
