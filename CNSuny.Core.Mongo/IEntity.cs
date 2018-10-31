using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Core.Mongo
{
    public interface IEntity<TKey>
    {
        [BsonId]
        TKey Id
        {
            get;
            set;
        }
    }
}
