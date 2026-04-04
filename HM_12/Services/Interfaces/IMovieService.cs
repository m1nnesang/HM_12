using HM_12.Models;
using HM_12.Enums;

namespace HM_12.Services.Interfaces;

public interface IMovieService
{
    Task <MovieModel> AddMovieAsync(MovieModel movie);
    
    Task <MovieModel?> GetMovieByIdAsync(int id);
    Task <MovieModel?> UpdateMovieAsync(MovieModel movie);
    
    Task <bool> RemoveMovieAsync(int id);

    Task <IEnumerable<MovieModel>> GetAllMoviesAsync(); 
    Task <IEnumerable<MovieModel>> GetFilteredAsync(Genre? genre, int? year);
}