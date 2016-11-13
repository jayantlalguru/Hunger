using System;

namespace Hunger.Domain.Account
{
    public interface IUser
    {
        string LoginId { get; set; }
        string EmailId { get; set; }
        string PhoneNumber { get; set; }
        string Password { get; set; }
        Guid PasswordSalt { get; }
    }
}
