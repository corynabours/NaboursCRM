using System;
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
            RemovePotentialHibernateImplementationsOfIList(result);
            return (List<Person>)result;
        }

        public Person GetContact(string id)
        {
            var result = _repository.GetPerson(new Guid(id));
            RemovePotentialHibernateImplementationsOfIList(result);
            return result;
        }

        public void AddPerson(Person newPerson)
        {
            _repository.AddPerson(newPerson);
        }

        public void UpdatePerson(string id, Person updatedPerson)
        {
            _repository.UpdatePerson(updatedPerson);
        }

        public void DeletePerson(string id)
        {
            _repository.DeletePerson(new Guid(id));
        }

        public void AddPersonForJsonp(Person newPerson)
        {
            _repository.AddPerson(newPerson);
        }

        public void UpdatePersonForJsonp(string id, Person updatedPerson)
        {
            _repository.UpdatePerson(updatedPerson);
        }

        public void DeletePersonForJsonp(string id)
        {
            _repository.DeletePerson(new Guid(id));
        }

        private static void RemovePotentialHibernateImplementationsOfIList(IEnumerable<Person> result)
        {
            foreach (var contact in result)
            {
                RemovePotentialHibernateImplementationsOfIList(contact);
            }
        }

        private static void RemovePotentialHibernateImplementationsOfIList(Person contact)
        {
            contact.Addresses = new List<Address>();
            contact.PhoneNumbers = new List<Phone>();
        }
    }
}
