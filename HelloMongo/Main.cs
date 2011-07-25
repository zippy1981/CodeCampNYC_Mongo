using System;
using System.Configuration;

using MongoDB.Bson;
using MongoDB.Driver;

namespace HelloMongo
{
	internal sealed class MainClass
	{
		private static BsonDocument CreateConsoleMessage (string message, bool error = false) {
			return new BsonDocument {
				{"_id", ObjectId.GenerateNewId() },
				{"Message", message},
				{"FileHandle", error ? 1 : 0}
			};
		}
		
		private static void Main (string[] args)
		{
			var db = MongoDatabase.Create(ConfigurationManager.ConnectionStrings["codeCampNyc"].ConnectionString);
			db["console"].Insert(CreateConsoleMessage("Hello Code Camp NYC!!"));
			try {
                if (args.Length < 1)
                {
                    throw new NotImplementedException("No message passed!");
                }
			    db["console"].Insert(CreateConsoleMessage(args[0]));
                Console.WriteLine("OK");
			}
			catch(Exception ex) {
				db["console"].Insert(CreateConsoleMessage(ex.Message, true));
                Console.Error.WriteLine("Error: {0}", ex.Message);
			}
            db.Server.Disconnect();

            Console.WriteLine("Press Any Key To Continue . . .");
            Console.ReadKey(true);
		}
	}
}

