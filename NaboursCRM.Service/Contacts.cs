using System.Collections.Generic;
using System.ServiceModel.Activation;
using NaboursCRM.DataAccess;
using NaboursCRM.Model;
using NaboursCRM.Model.Repositories;

namespace NaboursCRM.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Contacts : IContacts
    {
        private readonly PersonRepository _repository;

        public Contacts() : this(new PersonData())
        {
            
        }

        public Contacts(PersonRepository repository)
        {
            _repository = repository;
        }


        public List<Person> GetContacts()
        {
            var result = _repository.GetAll();
            return (List<Person>)result;
        }
    }
}
