using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace HelloWorld.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ConsoleService" in both code and config file together.
    [ServiceContract]
    public interface IConsoleService
    {
        [OperationContract]
        List<ConsoleInfo> GetHostMessages(GetHostMessagesRequest request);

        [OperationContract]
        void WriteMessage(WriteMessageRequest request);

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations
}
