using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using MongoDB.Bson;

namespace HelloWorld.Service
{
    [DataContract]
    public sealed class GetHostMessagesRequest
    {
        [DataMember(Order = 1)]
        public int MachineId { get; set; }
    }
}
