using Callhub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Domain.Interfaces.Repository
{
  public interface ICallRepository : IRepository<Call>
  {
    Task<IEnumerable<Call>> SelectAllByOwner(Guid UserId);
  }
}
