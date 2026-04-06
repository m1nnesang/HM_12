using HM_12.Enums;
using HM_12.Models;
using HM_12.Services.Interfaces;

namespace HM_12.Services.Classes;

public class MovieService : IMovieService
{
    private readonly Dictionary<int, MovieModel> _movieModel = new();
    private int _nextId = 1;

    public async Task<MovieModel> AddMovieAsync(MovieModel movie)
    {
        await Task.Delay(1000);
        
        movie.Id = _nextId++;

        _movieModel.Add(movie.Id, movie);

        return movie;
    }

    public async Task<MovieModel?> GetMovieByIdAsync(int id)
    {
        await Task.Delay(1000);

        var movieModel = _movieModel.TryGetValue(id, out var movie) ? movie : null;
        
        return movieModel;
    }

    public async Task<MovieModel?> UpdateMovieAsync(MovieModel movie)
    {
        await Task.Delay(1000);
        
        var movieModel = _movieModel.TryGetValue(movie.Id, out var movieToUpdate) ? movieToUpdate : null;

        if (movieModel != null)
        {
            movieModel.Title = movie.Title;
            movieModel.Year = movie.Year;
            movieModel.Description = movie.Description;
            movieModel.Genre = movie.Genre;
        }
        
        return movieModel;
    }
    
    public async Task<bool> RemoveMovieAsync(int id)
    {
        await Task.Delay(1000);
        
        var movieModel = _movieModel.TryGetValue(id , out var movie) ? movie : null;
        
        if (movieModel == null) return false;
        
        _movieModel.Remove(id);
        
        return true;
    }

    public async Task<IEnumerable<MovieModel>> GetAllMoviesAsync()
    {
        await Task.Delay(1000);
        
        return _movieModel.Values;
    }
    
    public async Task<IEnumerable<MovieModel>> GetFilteredAsync(Genre? genre, int? year)
    {
        await Task.Delay(1000);
        
        var result = _movieModel.Values.AsEnumerable();

        if (genre != null)
            result = result.Where(m => m.Genre == genre);

        if (year != null)
            result = result.Where(m => m.Year == year);

        return result;
        
    }

}