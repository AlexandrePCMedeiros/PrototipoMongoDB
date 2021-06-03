using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoMongoDB.Repositories.Contracts
{
    public interface IRepository<T> : ICommandRepository<T>, IQueryRepository<T> where T : class { }
}
