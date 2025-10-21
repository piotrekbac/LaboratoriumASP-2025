using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Models;

public class Contact
{
    [HiddenInput]
    public int Id { get; set; }

    [Required]
    [StringLength(maximumLength: 100, MinimumLength = 2)]
    public string? Name { get; set; }
    
    [EmailAddress]
    public string? Email { get; set; }
    
    // [Phone]
    // public string? Phone { get; set; }
    //
    // [Range (minimum: 1, maximum: 100)]
    // public int FriendsNumber { get; set; }
    //  
    // [DataType(DataType.Date)]
    // public DateTime Created { get; set; }
}