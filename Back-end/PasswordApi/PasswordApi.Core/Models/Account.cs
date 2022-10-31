using System.ComponentModel.DataAnnotations;

namespace PasswordApi.Core.Models;

public class Account
{
    [Key]
    public Guid UserId { get; set; }
    
    public TemporaryPassword TemporaryPassword { get; set; }
    public Guid TemporaryPasswordId { get; set; }

    public bool EmptyId()
    {
        return UserId == Guid.Empty;
    }
}