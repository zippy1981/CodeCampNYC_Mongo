using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HelloWorld.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ConsoleService" in both code and config file together.
    public class ConsoleService : IConsoleService
    {
        MongoDatabase _db = MongoDatabase.Create
            (ConfigurationManager.ConnectionStrings["codeCampNyc"].ConnectionString);

        private static BsonDocument CreateConsoleMessage(string message, bool error = false)
        {
            return new BsonDocument {
				{"_id", ObjectId.GenerateNewId() },
				{"Message", message},
				{"FileHandle", error ? 1 : 0}
			};
        }

        public List<ConsoleInfo> GetHostMessages(GetHostMessagesRequest request)
        {
            var cursor = _db["console"].FindAllAs<ConsoleInfo>();

            return (from doc in cursor where doc.Id.Machine == request.MachineId select doc).ToList();
        }

        public void WriteMessage(WriteMessageRequest request)
        {
            _db["console"].Insert(CreateConsoleMessage(request.Message));
        }
    }
}
