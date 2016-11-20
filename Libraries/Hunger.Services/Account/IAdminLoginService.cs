using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunger.Domain.Account;

namespace Hunger.Services.Account
{
    public interface IAdminLoginService
    {
        int CreateAdminUser(AdminUser adminUser);
        IEnumerable<AdminUser> AdminLogin(AdminUser adminUser);
        Guid GetPasswordSalt(string loginId);
    }
}
