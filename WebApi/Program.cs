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
        var dbs= string.Join(",", dbsList);

        return $"Zugriff auf MongoDb ok. Vorhandene DBs: {dbs}\n\n\nVersion: 1.0";
        
    }
    catch (System.Exception)
    {
        return "Zugriff auf MongoDb nicht ok!";
    }
});

// Insert Movie
// Wenn das übergebene Objekt eingefügt werden konnte,
// wird es mit Statuscode 200 zurückgegeben.
// Bei Fehler wird Statuscode 409 Conflict zurückgegeben.
app.MapPost("/api/movies", () =>
{
throw new NotImplementedException();
});
// Get all Movies
// Gibt alle vorhandenen Movie-Objekte mit Statuscode 200 OK zurück.
app.MapGet("api/movies", () =>
{
throw new NotImplementedException();
});
// Get Movie by id
// Gibt das gewünschte Movie-Objekt mit Statuscode 200 OK zurück.
// Bei ungültiger id wird Statuscode 404 not found zurückgegeben.
app.MapGet("api/movies/{id}", (string id) =>
{
throw new NotImplementedException();
});
// Update Movie
// Gibt das aktualisierte Movie-Objekt zurück.
// Bei ungültiger id wird Statuscode 404 not found zurückgegeben.
app.MapGet("api/movies/{id}", (string id) =>
{
if(id == "1")
{
var myMovie = new Movie()
{
Id = "1",
Title = "Asterix und Obelix",
};
return Results.Ok(myMovie);
}
else
{
return Results.NotFound();
}
});
app.MapPut("/api/movies/{id}", (string id, Movie movie) =>
{
throw new NotImplementedException();
});
// Delete Movie
// Gibt bei erfolgreicher Löschung Statuscode 200 OK zurück.
// Bei ungültiger id wird Statuscode 404 not found zurückgegeben.
app.MapDelete("api/movies/{id}", (string id) =>
{
throw new NotImplementedException();
});


app.Run();
