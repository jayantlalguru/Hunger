using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hunger.Services.Registration;
using Hunger.Domain.Registration;

namespace Hunger.Rest.Controllers
{
    public class RegistrationController : ApiController
    {
        private readonly IRegistrationService _registrationService;
        public RegistrationController(IRegistrationService registrationService)
        {
            this._registrationService = registrationService;
        }       
        
        [HttpGet]
        public int CopyRegistrationToChef()
        {
            IList<Hunger.Domain.Registration.Registration> registrations = new List<Hunger.Domain.Registration.Registration>();            
            return _registrationService.CopyRegistrationToChef(registrations);
        }

        [HttpGet]
        public int CopyRegistrationToChef(int id)
        {
            Hunger.Domain.Registration.Registration registration = new Hunger.Domain.Registration.Registration();
            return _registrationService.CopyRegistrationToChef(registration);
        }

        [HttpGet]
        public int DeactivateRegistration()
        {
            IList<int> registrationIds = new List<int>();
            registrationIds.Add(99);
            registrationIds.Add(100);            
            return _registrationService.DeactivateRegistration(registrationIds);
        }

        [HttpGet]
        public int DeactivateRegistration(int id)
        {   
            return _registrationService.DeactivateRegistration(id);
        }

        [HttpGet]
        public int ActivateRegistration()
        {
            IList<int> registrationIds = new List<int>();
            registrationIds.Add(99);
            registrationIds.Add(100);                        
            return _registrationService.ActivateRegistration(registrationIds);
        }

        [HttpGet]
        public int ActivateRegistration(int id)
        {   
            Registration registration = GetRegistrationById(id);
            registration.IsActive = true;
            registration.CreatedBy = 1;
            return _registrationService.ActivateRegistration(registration.RegistrationId);
        }

        [HttpGet]
        public Registration GetRegistrationById(int id)
        {   
            return _registrationService.GetRegistrationById(id);
        }

        // GET: api/Registration
        public IEnumerable<string> Get()
        {   
            Agreement agreement = new Agreement();
            _registrationService.CreateAgreement(agreement);
            return new string[] { "value1", "value2" };
        }

        // GET: api/Registration/5
        public string Get(int id)
        {
            Hunger.Domain.Registration.Registration registration = new Domain.Registration.Registration();            
            return _registrationService.CreateRegistration(registration);
        }        
    }
}
