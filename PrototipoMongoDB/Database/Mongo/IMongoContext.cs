using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoMongoDB.Database.Mongo
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
    }
}
