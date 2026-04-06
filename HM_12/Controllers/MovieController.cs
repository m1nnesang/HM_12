#region using
using HM_12.Models;
using Microsoft.AspNetCore.Mvc;
using HM_12.Services.Interfaces;
using HM_12.Enums;
#endregion

namespace HM_12.Controllers;

public class MovieController : Controller
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index(Genre? genre, int? year)
    {
        var getFilteredMovies = await _movieService.GetFilteredAsync(genre, year);

        return View(getFilteredMovies);
    }

    
    #region Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(MovieModel movie)
    {
        if (!ModelState.IsValid) return View(movie);
        
        await _movieService.AddMovieAsync(movie);

        return RedirectToAction(nameof(Index));
    }
    #endregion
    
    
    #region Edit
    [HttpGet]
    public async Task<IActionResult> Edit(int id )
    {
        var getMovieById = await _movieService.GetMovieByIdAsync(id);
        
        if (getMovieById == null)
        {
            return NotFound();
        }
        
        return View(getMovieById);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(MovieModel movie)
    { 
        await _movieService.UpdateMovieAsync(movie);
        
        return RedirectToAction(nameof(Index));
    }
    #endregion
    
    #region Delete
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var getMovieById = await _movieService.GetMovieByIdAsync(id);
        
        if (getMovieById == null)
        {
            return NotFound();
        }

        return View(getMovieById);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Delete(MovieModel movie)
    {
        await _movieService.RemoveMovieAsync(movie.Id);
        
        return RedirectToAction(nameof(Index));
    }
    #endregion
}