using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HelloWorld.Service
{
    [CollectionDataContract]
    public class GetHostMessagesResponse : List<ConsoleInfo> { }
}
