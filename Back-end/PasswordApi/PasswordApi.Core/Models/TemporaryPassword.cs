using System.ComponentModel.DataAnnotations;

namespace PasswordApi.Core.Models;

public class TemporaryPassword
{
    [Key]
    public Guid Id { get; set; }
    public string Password { get; set; }
    public DateTime ExpirationTime { get; set; }
    
    public Account Account { get; set; }
    
    public bool EmptyId()
    {
        return Id == Guid.Empty;
    }

    public bool HasExpired()
    {
        return ExpirationTime < DateTime.Now;
    }
}