namespace HM_12.Enums;
using System.ComponentModel.DataAnnotations;

public enum Genre
{
    [Display(Name = "Комедія")]
    Comedy,
    
    [Display(Name = "Бойовик")]
    Action,
    
    [Display(Name = "Фантастика")]
    Fantasy,
}