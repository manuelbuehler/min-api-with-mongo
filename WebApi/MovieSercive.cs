using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

public class MovieService : IMovieService
{
    private readonly IMongoCollection<Movie> _movieCollection;

    private const string mongoDbDatabase = "gbs";

    private const string mongoCollection = "movies";


    public MovieService(IOptions<DatabaseSettings> options)
    {
        var mongoDbConnectionString = options.Value.ConnectionString;

        var settings = options.Value;
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(mongoDbDatabase);
        _movies = database.GetCollection<Movie>(mongoCollection);
    }

    public string Check()
    {
        try
        {
            var databaseNames = _movies.Database.ListDatabaseNames().ToList();
            return "Zugriff auf MongoDB ok. Vorhandene DBs: " + string.Join(",", databaseNames);
        }
        catch (Exception e)
        {
            return "Zugriff auf MongoDB funktioniert nicht: " + e.Message;
        }
    }

    public IEnumerable<Movie> Get()
    {
        return _movieCollection.Find(mongoDbDAtabase => true).ToList();
    }

    public Movie Get(string id)
    {
        throw new NotImplementedException();
    }

    public void Create(Movie movie)
    {
        throw new NotImplementedException();
    }

    public void Update(string id, Movie movieIn)
    {
        throw new NotImplementedException();
    }

    public void Remove(string id)
    {
        throw new NotImplementedException();
    }
}

public interface IMovieService
{
    string Check();
    IEnumerable<Movie> Get();
    Movie Get(string id);
    void Create(Movie movie);
    void Update(string id, Movie movie);
    void Remove(string id);
}
