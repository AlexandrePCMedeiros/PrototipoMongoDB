using PrototipoMongoDB.Database.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoMongoDB.Repositories.Mongo
{
    public class MongoRepository<T> : Repository<T> where T : class
    {
        public MongoRepository(IMongoContext context) : base(new MongoCommandRepository<T>(context), new MongoQueryRepository<T>(context)) { }
    }
}
