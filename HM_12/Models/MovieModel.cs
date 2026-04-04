using System.ComponentModel.DataAnnotations;
using HM_12.Enums;

namespace HM_12.Models;

public record MovieModel
{
    public int Id { get; set; }
    
    [Required]
    public int Year { get; set; }
    
    [Required]
    public string Title { get; set; } = String.Empty;
    
    public string? Description { get; set; }
    
    [Required]
    public Genre Genre { get; set; }
}