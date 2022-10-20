namespace WebApi.Models.Items;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class CreateRequest
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Type { get; set; }
    [Required]
    public int ValueMin { get; set; }
    [Required]
    public int ValueMax { get; set; }
}