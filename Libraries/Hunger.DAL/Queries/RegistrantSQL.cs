using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunger.DAL.Queries
{
    public class RegistrantSQL
    {
        /// <summary>
        /// Create new registrant and return registrant data
        /// </summary>
        public const string CreateRegistrant = @"IF EXISTS (SELECT 1 FROM Registrant WHERE UserName = @UserName) 
                                                BEGIN 
	                                                SELECT -3 AS Status; 
                                                END 
                                                ELSE
                                                BEGIN
                                                    DECLARE @RegistrantId INT; 
	                                                INSERT INTO Registrant (RegistrationId, UserName, [Password], PasswordSalt, PasswordSalt2, PasswordSalt3, CreatedOn, SystemName, IpAddress) 
                                                    VALUES (@RegistrationId, @UserName, @Password, @PasswordSalt, @PasswordSalt2, @PasswordSalt3, @CreatedOn, @SystemName, @IpAddress);
                                                    SELECT @RegistrantId = SCOPE_IDENTITY();
                                                    SELECT RegistrantId, RegistrationId, UserName, IsActive, 2 AS Status FROM Registrant WHERE RegistrantId = @RegistrantId;
                                                END";

    }
}
