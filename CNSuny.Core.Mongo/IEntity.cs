using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Core.Mongo
{
    /// <summary>
    /// mongo实体实现该接口
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey>
    {
        [BsonId]
        TKey Id { set; get; }
    }
}
