using MongoDB.Driver;
using MongoDB.Bson;

var builder = WebApplication.CreateBuilder(args);

var movieDatabaseConfigSection = builder.Configuration.GetSection("DatabaseSettings");
builder.Services.Configure<DatabaseSettings>(movieDatabaseConfigSection);

var app = builder.Build();

app.MapGet("/", () => "Minimal API Version 1.0");


app.MapGet("/check", (Microsoft.Extensions.Options.IOptions<DatabaseSettings> options)  => {

    try
    {
        var client = new MongoClient(options.Value.ConnectionString);  

        var dbsList = client.ListDatabases();

        string dbs = "";

        foreach(var db in dbsList.ToList())
        {
            dbs += ", " + db;
        }

        return $"Zugriff auf MongoDb ok. Vorhandene DBs: {dbs}\n\n\nVersion: 1.0";
        
    }
    catch (System.Exception)
    {
        return "Zugriff auf MongoDb nicht ok!";
    }

});


app.Run();
