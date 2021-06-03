using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PrototipoMongoDB.Database.Mongo
{

    public class MongoContext : IMongoContext
    {
        protected MongoContext(string connectionString)
        {
            Database = new MongoClient(connectionString).GetDatabase(new MongoUrl(connectionString).DatabaseName);
        }

        public IMongoDatabase Database { get; }
    }

    public sealed class MContext : MongoContext
    {
        public MContext(string connectionString) : base(connectionString)
        {
        }
    }
}
