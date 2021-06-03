using PrototipoMongoDB.Database.Mongo;
using PrototipoMongoDB.Models;
using PrototipoMongoDB.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoMongoDB.Repositories.Mongo
{
    public sealed class FotografiaClientePFRepository : MongoRepository<FotografiaClientePF>, IFotografiaClientePFRepository
    {
        public FotografiaClientePFRepository(MongoContext context) : base(context) { }
    }
}
