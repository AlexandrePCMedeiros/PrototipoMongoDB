using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoMongoDB.Database.Mongo
{
    public static class Filters
    {
        public static FilterDefinition<T> Id<T>(object value)
        {
            return Builders<T>.Filter.Eq(nameof(Id), value);
        }
    }
}
