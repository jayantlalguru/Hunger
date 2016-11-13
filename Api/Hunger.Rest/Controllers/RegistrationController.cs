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
            IList<int> registrationIds = new List<int>();
            registrationIds.Add(99);
            registrationIds.Add(100);
            return _registrationService.CopyRegistrationToChef(registrationIds);
        }

        [HttpGet]
        public int DeactivateRegistration()
        {
            IList<int> registrationIds = new List<int>();
            registrationIds.Add(99);
            registrationIds.Add(100);
            RegistrationService registrationService = new RegistrationService();
            return registrationService.DeactivateRegistration(registrationIds);
        }

        [HttpGet]
        public int DeactivateRegistration(int id)
        {
            RegistrationService registrationService = new RegistrationService();
            return registrationService.DeactivateRegistration(id);
        }

        [HttpGet]
        public int ActivateRegistration()
        {
            IList<int> registrationIds = new List<int>();
            registrationIds.Add(99);
            registrationIds.Add(100);            
            RegistrationService registrationService = new RegistrationService();
            return registrationService.ActivateRegistration(registrationIds);
        }

        [HttpGet]
        public int ActivateRegistration(int id)
        {            
            RegistrationService registrationService = new RegistrationService();
            Registration registration = GetRegistrationById(id);
            registration.IsActive = true;
            registration.CreatedBy = 1;
            return registrationService.ActivateRegistration(registration);
        }
        public Registration GetRegistrationById(int id)
        {
            RegistrationService registrationService = new RegistrationService();
            return registrationService.GetRegistrationById(id);
        }

        // GET: api/Registration
        public IEnumerable<string> Get()
        {
            RegistrationService registrationService = new RegistrationService();
            Agreement agreement = new Agreement();
            registrationService.CreateAgreement(agreement);
            return new string[] { "value1", "value2" };
        }

        // GET: api/Registration/5
        public string Get(int id)
        {
            Hunger.Domain.Registration.Registration registration = new Domain.Registration.Registration();
            RegistrationService registrationService = new RegistrationService();
            return registrationService.CreateRegistration(registration);
        }

        // POST: api/Registration
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Registration/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Registration/5
        public void Delete(int id)
        {
        }
    }
}
