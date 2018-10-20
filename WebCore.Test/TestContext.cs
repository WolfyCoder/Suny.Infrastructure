using CNSuny.Core.Mongo;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Test
{
    public class TestContext : MongoContext
    {
        public TestContext(IOptions<MongoOptions> options) : base(options.Value)
        {
        }
        public IMongoCollection<BsonDocument> Blogs => DB.GetCollection<BsonDocument>("Blogs");
    }
}
