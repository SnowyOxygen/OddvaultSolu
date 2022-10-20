namespace WebApi.Models.Accounts;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class CreateRequest
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public int Currency { get; set; }
    [Required]
    public bool Admin { get; set; }
}