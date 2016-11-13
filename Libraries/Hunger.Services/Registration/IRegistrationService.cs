using Hunger.Domain.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunger.Services.Registration
{
    public interface IRegistrationService
    {
        int CreateAgreement(Agreement agreement);
        string CreateRegistration(Hunger.Domain.Registration.Registration registration);
        int RejectRegistration(Hunger.Domain.Registration.Registration registration, RegistrationRejectionReason registrationRejectionReason);
        int UpdateRegistrationAgreement(Hunger.Domain.Registration.Registration registration, RegistrationAgreementMapping registrationAgreementMapping);
        Hunger.Domain.Registration.Registration GetRegistrationById(int id);
        int ActivateRegistration(IEnumerable<int> registrationIds);
        int ActivateRegistration(int registration);
        int CopyRegistrationToChef(IEnumerable<int> registrationIds);
        int CopyRegistrationToChef(Hunger.Domain.Registration.Registration registration);
        int DeactivateRegistration(IEnumerable<int> registrationIds);
        int DeactivateRegistration(int registrationId);
    }
}
