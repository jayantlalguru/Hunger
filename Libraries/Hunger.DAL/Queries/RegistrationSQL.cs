using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunger.DAL.Queries
{
    public class RegistrationSQL
    {
        /// <summary>
        /// Create agreement query
        /// </summary>
        public const string Agreement = @"INSERT INTO Agreement (AgreementText, CreatedOn, CreatedBy, IpAddress, SystemName, IsAgreementValid, ValidFrom, ValidTo) VALUES (@AgreementText, @CurrentDate, @CreatedBy, @CurrentIpAddress, @CurrentSystemName, @IsAgreementValid, @ValidFrom, @ValidTo)";

        /// <summary>
        /// Create registration query
        /// </summary>
        public const string Registration = @"INSERT INTO Registration (Name,RegisteredPhoneNumber,PhoneNumber,EmailId,Address,AgreementId,HasAgreedToTermsAndCondition,CreatedOn,AgreementAcceptedOn) VALUES (@Name,@RegisteredPhoneNumber,@PhoneNumber,@EmailId,@Address,@AgreementId,@HasAgreedToTermsAndCondition,@CurrentDate,@CurrentDate); SELECT SCOPE_IDENTITY();";

        /// <summary>
        /// Only accept registration but registraion is not active
        /// </summary>
        public const string AcceptRegistration = @"UPDATE Registration SET IsRegistrationAccepted = 1, IsActive = 0, IsRejected = 0, ModifiedOn = @CurrentModificationDate, ModifiedBy = @ModifiedBy WHERE RegistrationId = @RegistrationId;";

        /// <summary>
        /// Reject a registration with a reason
        /// </summary>
        public const string RejectRegistration = @"UPDATE Registration SET IsRegistrationAccepted = 0, ModifiedOn = @CurrentModificationDate, ModifiedBy = @ModifiedBy, IsActive = 0, NoOfTimeRejected = (ISNULL(NoOfTimeRejected, 0) + 1), IsRejected = 1 WHERE RegistrationId = @RegistrationId; "
                + "INSERT INTO RegistrationRejectionReason(RejectionReasonText, RegistrationId, CreatedOn, CreatedBy, IpAddress, SystemName) VALUES(@RejectionReasonText, @RegistrationId, @CurrentDate, @CreatedBy, @CurrentIpAddress, @CurrentSystemName);";

        /// <summary>
        /// Insert Into RegistrationAgreementMapping
        /// </summary>
        public const string RegistrationAgreementMapping = @"INSERT INTO RegistrationAgreementMapping (RegistrationId, AgreementId, AgreedFrom, AgreedTill) VALUES (@RegistrationId, @AgreementId, @AgreedFrom, @AgreedTill);";
        /// <summary>
        /// Update Registration Table
        /// </summary>
        public const string UpdateAgreement = @"UPDATE Registration SET AgreementId = @AgreementId, ModifiedOn = @CurrentModificationDate, ModifiedBy = @ModifiedBy, AgreementAcceptedOn = @AgreementAcceptedOn WHERE RegistrationId = @RegistrationId;";

        /// <summary>
        ///Select registration details by an Id 
        /// </summary>
        public const string RegistrationById = @"SELECT RG.*, AG.*
        FROM Registration RG
        INNER JOIN Agreement AG
        ON AG.AgreementId = RG.AgreementId
        WHERE RG.RegistrationId = @RegistrationId;        
        SELECT RM.*, AG.* 
        FROM RegistrationAgreementMapping RM
        INNER JOIN Agreement AG
        ON AG.AgreementId = RM.AgreementId
        WHERE RegistrationId = @RegistrationId";

        /// <summary>
        /// Activate a registraion
        /// </summary>
        public const string ActivateRegistration = @"UPDATE Registration SET IsActive = true WHERE RegistrationId = @RegistrationId;";

        /// <summary>
        /// Moves Data from Registration table to Chef table
        /// </summary>
        public const string MoveToChef = @"INSERT INTO CHEF (Name, RegistrationId, CreatedBy, CreatedOn) VALUES (@Name, @RegistrationId, @CreatedBy, @CurrentDate)";

        public const string MoveToChefInBulk = @"INSERT INTO CHEF (Name, RegistrationId, CreatedBy, CreatedOn)
        SELECT Name, RegistrationId, CreatedBy, CreatedOn FROM Registration
        WHERE RegistrationId IN (@RegistrationIds)";
    }
}
