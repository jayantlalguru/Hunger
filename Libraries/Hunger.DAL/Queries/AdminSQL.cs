using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunger.DAL.Queries
{
    public class AdminSQL
    {
        /// <summary>
        /// Create new admin user
        /// </summary>
        public const string CreateAdminUser = @"IF EXISTS (SELECT 1 FROM AdminUser WHERE LoginId = @LoginId) "
            + "BEGIN "
            + "SELECT -3; "
            + "END "
            + "ELSE IF EXISTS (SELECT 1 FROM AdminUser WHERE EmailId = @EmailId) "
            + "BEGIN "
            + "SELECT -2; "
            + "END "
            + "ELSE "
            + "BEGIN "
            + "INSERT INTO AdminUser (LoginId, EmailId, PhoneNumber, Password, PasswordSalt, CreatedOn) VALUES (@LoginId, @EmailId, @PhoneNumber, @Password, @PasswordSalt, @CurrentDate); SELECT 1; "
            + "END ";

        /// <summary>
        /// Admin Login
        /// </summary>
        public const string AdminLogin = @"DECLARE @adminUserId INT, @isActive BIT, @noOfLoginAttempt TINYINT; "
            + "SELECT @isActive = IsActive, @noOfLoginAttempt = NoOfLoginAttempt FROM AdminUser WHERE LoginId = @LoginId; "
            + "IF(@isActive IS NULL) BEGIN "
            + "SELECT [Status] = -4 END "
            + "ELSE IF(@isActive = 0) BEGIN "
            + "SELECT [Status] = -5 END "
            + "ELSE IF EXISTS (SELECT 1 FROM AdminUser WHERE LoginId = @LoginId AND Password = @Password AND IsActive = 1) BEGIN "
            + "UPDATE AdminUser SET NoOfLoginAttempt = 0, LastAccessed = @CurrentDate WHERE LoginId = @LoginId; "
            + "SELECT AdminUserId, EmailId, PhoneNumber, LastAccessed, [Status] = 1 FROM AdminUser WHERE LoginId = @LoginId; END "
            + "ELSE BEGIN UPDATE AdminUser SET NoOfLoginAttempt = (ISNULL(@noOfLoginAttempt,0) + 1) WHERE LoginId = @LoginId; "
            + "IF(@noOfLoginAttempt > 4) BEGIN UPDATE AdminUser SET IsActive = 0 WHERE LoginId = @LoginId; END SELECT [Status] = -4 END";

        /// <summary>
        /// Admin Password Salt
        /// </summary>
        public const string AdminPasswordSalt = @"SELECT PasswordSalt FROM AdminUser WHERE LoginId = @loginId";            
           
    }
}
