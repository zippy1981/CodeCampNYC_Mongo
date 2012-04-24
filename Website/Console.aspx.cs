using System;
using System.Configuration;
using System.Web.UI;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

public partial class Console : Page
{
    protected class ConsoleInfo {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Message { get; set; }
        public int FileHandle { get; set; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var db = MongoDatabase.Create
            (ConfigurationManager.ConnectionStrings["codeCampNyc"].ConnectionString);
        var cursor = db["console"].FindAllAs<ConsoleInfo>();
        consoleLines.DataSource = cursor;
        consoleLines.DataBind();
    }
}
