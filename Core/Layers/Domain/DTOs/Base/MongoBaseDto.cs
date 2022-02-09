using Core.Layers.Domain.DTOs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layers.Domain.DTOs
{
    public class MongoBaseDto : IEntityDto<string>
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        [BsonElement(Order = 0)]
        public string Id { get; }
    }
}
