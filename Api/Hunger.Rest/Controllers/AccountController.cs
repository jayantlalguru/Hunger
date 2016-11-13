using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hunger.Services.Account;
using Hunger.Domain.Account;
using Hunger.Rest.Utilities;
using Hunger.Domain.Registration;

namespace Hunger.Rest.Controllers
{
    public class AccountController : ApiController
    {
        // GET: api/Account
        public string Get()
        {
            LoginService loginService = new LoginService();
            AdminUser adminUser = new AdminUser();
            adminUser.LoginId = "jayant";
            adminUser.PasswordSalt = loginService.GetPasswordSalt(adminUser.LoginId);
            if(adminUser.PasswordSalt == null || adminUser.PasswordSalt == Guid.Empty)
            {
                return Messages.InvalidIdOrPwd;
            }
            adminUser.Password = "passwor";
            adminUser.Password = Security.Sha512Encryption(adminUser.Password, adminUser.PasswordSalt);
            adminUser = loginService.AdminLogin(adminUser);
            return Status.LoginMessage(adminUser.Status);
        }

        // GET: api/Account/5
        public string Get(int id)
        {            
            LoginService loginService = new LoginService();
            AdminUser adminUser = new AdminUser();
            adminUser.LoginId = "reyaansh";
            adminUser.IsActive = true;
            adminUser.PhoneNumber = "+91-8898308676";
            adminUser.EmailId = "reyaansh@outlook.com";
            adminUser.PasswordSalt = adminUser.NewPasswordSalt;
            adminUser.Password = Security.Sha512Encryption("password", adminUser.PasswordSalt);
            int status = loginService.CreateAdminUser(adminUser);
            return Status.LoginMessage(status);
        }

        // POST: api/Account
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
        }
    }
}
