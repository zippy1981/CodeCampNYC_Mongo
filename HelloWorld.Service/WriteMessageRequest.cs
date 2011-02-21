using System;
using System.Runtime.Serialization;

using MongoDB.Bson;

namespace HelloWorld.Service
{
    [DataContract]
    public sealed class WriteMessageRequest
    {
        [DataMember(Order = 0)]
        public ObjectId Id { get; set; }
        [DataMember(Order = 1)]
        public string Message { get; set; }
        [DataMember(Order = 2)]
        public int FileHandle { get; set; }
    }
}
