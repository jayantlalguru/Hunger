using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunger.DAL.Registration;
using Hunger.Domain.Registration;
using RDomain = Hunger.Domain.Registration;

namespace Hunger.Services.Registration
{
    public class RegistrationService : IRegistrationService
    {
        public int CreateAgreement(Agreement agreement)
        {
            RegistrationDAL registrationDAL = new RegistrationDAL();            
            agreement.AgreementText = "This is a agreement and you will abide by it.";
            agreement.IsAgreementValid = false;
            agreement.ValidFrom = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            DateTime dt = DateTime.Now.AddDays(700);            
            agreement.ValidTo = Convert.ToDateTime(dt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            agreement.CreatedBy = 10;
            agreement.MaxRejectionLimit = 5;
            registrationDAL.CreateAgreement(agreement);            
            return 1;
        }

        public string CreateRegistration(RDomain.Registration registration)
        {
            RegistrationDAL registrationDAL = new RegistrationDAL();
            registration.Name = "Reyaansh Guru";
            registration.RegisteredPhoneNumber = "9898308676";
            registration.PhoneNumber = "+91-9004381165, +91-9919763092";
            registration.EmailId = "reyaanshguru@outlook.com";
            registration.Address = "Flat No. Ruby-503, Pratik Gems, Plot No. 10 & 11, Sector 35, Kamothe, Navi Mumbai - 410209, Maharashtra";
            registration.AgreementId = 1;
            registration.HasAgreedToTermsAndCondition = true;
            int registrationNumber = registrationDAL.CreateRegistration(registration);
            if (registrationNumber > 0)
            {
                return "Thanks for showing interest to join Hunger.Com. You are at the right place to start your business. Kindly note the registration number mentioned below for further commuinication."
                    + "\r\nYour registration Number is: " + registrationNumber;
            }
            else
            {
                return "Sorry we cannot process your registration right now. Kindly try after some time.";
            }
        }
        
        public int RejectRegistration(RDomain.Registration registration, RegistrationRejectionReason registrationRejectionReason)
        {
            RegistrationDAL registrationDAL = new RegistrationDAL();
            return registrationDAL.RejectRegistration(registration, registrationRejectionReason);
        }

        public int UpdateRegistrationAgreement(RDomain.Registration registration, RegistrationAgreementMapping registrationAgreementMapping)
        {
            RegistrationDAL registrationDAL = new RegistrationDAL();
            return registrationDAL.UpdateRegistrationAgreement(registration, registrationAgreementMapping);
        }

        public RDomain.Registration GetRegistrationById(int id)
        {
            RegistrationDAL registrationDAL = new RegistrationDAL();
            return registrationDAL.GetRegistrationById(id);
        }

        public int ActivateRegistration(IEnumerable<int> registrationIds)
        {
            RegistrationDAL registrationDAL = new RegistrationDAL();
            return registrationDAL.ActivateRegistration(registrationIds);
        }

        public int ActivateRegistration(int registrationId)
        {
            RegistrationDAL registrationDAL = new RegistrationDAL();
            return registrationDAL.ActivateRegistration(registrationId);
        }

        public int CopyRegistrationToChef(IEnumerable<RDomain.Registration> registrations)
        {
            RegistrationDAL registrationDAL = new RegistrationDAL();
            return registrationDAL.CopyRegistrationToChef(registrations);
        }

        public int CopyRegistrationToChef(RDomain.Registration registration)
        {
            RegistrationDAL registrationDAL = new RegistrationDAL();
            return registrationDAL.CopyRegistrationToChef(registration);
        }

        public int DeactivateRegistration(IEnumerable<int> registrationIds)
        {
            RegistrationDAL registrationDAL = new RegistrationDAL();
            return registrationDAL.DeactivateRegistration(registrationIds);
        }

        public int DeactivateRegistration(int registrationId)
        {
            RegistrationDAL registrationDAL = new RegistrationDAL();
            return registrationDAL.DeactivateRegistration(registrationId);
        }
    }
}
