using System;
using System.Collections.Generic;
using Hunger.Domain.Account;

namespace Hunger.Services.Account.Interfaces
{
    public interface IAdminLoginService
    {
        int CreateAdminUser(AdminUser adminUser);
        IEnumerable<AdminUser> AdminLogin(AdminUser adminUser);
        Guid GetPasswordSalt(string loginId);
    }
}
