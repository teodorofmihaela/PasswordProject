namespace PasswordApi.Core.DataTransferObjects;

public class UserLoginInfo
{
    public Guid UserId { get; set; }
    public string Password { get; set; }
}