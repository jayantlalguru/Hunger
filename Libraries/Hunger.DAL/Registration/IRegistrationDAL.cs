using System.Collections.Generic;
using RDomain = Hunger.Domain.Registration;
using Hunger.Domain.Registration;

namespace Hunger.DAL.Registration
{
    public interface IRegistrationDAL
    {
        int CreateAgreement(Agreement agreement);
        int CreateRegistration(RDomain.Registration registration);
        int AcceptRegistration(RDomain.Registration registration);
        int RejectRegistration(RDomain.Registration registration, RegistrationRejectionReason registrationRejectionReason);
        int UpdateRegistrationAgreement(RDomain.Registration registration, RegistrationAgreementMapping registrationAgreementMapping);
        RDomain.Registration GetRegistrationById(int id);
        int ActivateRegistration(IEnumerable<int> registrationIds);
        int ActivateRegistration(int registrationId);
        int CopyRegistrationToChef(RDomain.Registration registration);
        int CopyRegistrationToChef(IEnumerable<RDomain.Registration> registrations);
        int DeactivateRegistration(int registrationId);
        int DeactivateRegistration(IEnumerable<int> registrationIds);
    }
}
