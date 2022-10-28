using System.ComponentModel.DataAnnotations;

namespace PasswordApi.Core.Models;

public class TemporaryPassword
{
    [Key]
    public Guid Id { get; set; }
    public string Password { get; set; }
    public DateTime ExpirationTime { get; set; }
    
    public Account Account { get; set; }
}