using Dapper;
using Hunger.DAL.Configuration;
using Hunger.DAL.Queries;
using System.Linq;
using DRegistrant = Hunger.Domain.Registrant;

namespace Hunger.DAL.Registrant
{
    public class RegistrantAccountDAL : ConnectionProperties
    {
        public DRegistrant.Registrant CreateRegistrant(DRegistrant.Registrant registrant)
        {
            using (var dbConnection = Connection)
            {
                return dbConnection.Query<DRegistrant.Registrant>(RegistrantSQL.CreateRegistrant, new { registrant.RegistrationId, registrant.UserName, registrant.Password, registrant.PasswordSalt, registrant.PasswordSalt2, registrant.PasswordSalt3, registrant.CurrentDate, registrant.CurrentIpAddress, registrant.CurrentSystemName }).Single();
            }
        }
    }
}
