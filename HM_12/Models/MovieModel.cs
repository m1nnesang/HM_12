using System.ComponentModel.DataAnnotations;
using HM_12.Enums;

namespace HM_12.Models;

public record MovieModel
{
    public int Id { get; set; }
    
    public int Year { get; set; }
    
    public string Title { get; set; } = String.Empty;
    
    public string? Description { get; set; }
    
    public Genre Genre { get; set; }
}