using System;
using System.Configuration;

using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

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
				//TODO: Finish this application before going on stage in front of all those people.
				throw new NotImplementedException("It ain't done yet");
			}
			catch(Exception ex) {
				db["console"].Insert(CreateConsoleMessage(ex.Message, true));
			}
			db.Server.Disconnect();
		}
	}
}

