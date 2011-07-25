using System;
using System.Collections.Generic;
using NaboursCRM.DataAccess;
using NaboursCRM.Model;
using NaboursCRM.Model.Repositories;

namespace NaboursCRM.Service
{
    public class Contacts : IContacts
    {
        private readonly PersonRepository _repository;

        public Contacts() : this(new PersonData())
        {
            
        }

        public Contacts(PersonRepository repositoryFactory)
        {
            _repository = repositoryFactory;
        }


        public List<Person> GetContacts()
        {
            return (List<Person>)_repository.GetAll();
        }
    }
}
