namespace WebApi.Entities;

using System.Text.Json.Serialization;


/// <summary>
/// 
/// </summary>
public class Account
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Username { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int Currency { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public bool Admin { get; set; }
}